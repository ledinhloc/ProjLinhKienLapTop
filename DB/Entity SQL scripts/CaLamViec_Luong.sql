--view xem ca lam viec  *

GO
USE LinhkienLaptop; 
GO

CREATE VIEW vw_XemCaLam
AS
SELECT *
FROM CaLamViec
GO
-- Thêm ca làm việc
CREATE PROCEDURE sp_ThemCaLamViec
    @TenCa NVARCHAR(100),
    @GioBatDau TIME,
    @GioKetThuc TIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO CaLamViec (TenCa, GioBatDau, GioKetThuc)
        VALUES (@TenCa, @GioBatDau, @GioKetThuc);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi thêm ca làm việc. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Sửa ca làm việc
CREATE PROCEDURE sp_SuaCaLamViec
    @MaCa INT,
    @TenCa NVARCHAR(100),
    @GioBatDau TIME,
    @GioKetThuc TIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE CaLamViec
        SET TenCa = @TenCa,
            GioBatDau = @GioBatDau,
            GioKetThuc = @GioKetThuc
        WHERE MaCa = @MaCa;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi sửa ca làm việc. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Xóa ca làm việc
CREATE PROCEDURE sp_XoaCaLamViec 
    @MaCa INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM CaLamViec
        WHERE MaCa = @MaCa;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi xóa ca làm việc. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Thêm lương
CREATE PROCEDURE sp_ThemLuong
    @Luong DECIMAL(15, 2),
    @LuongGio DECIMAL(15, 2),
    @Thuong DECIMAL(15, 2),
    @TongNhan DECIMAL(15, 2),
    @ThoiGian DATE,
    @SoCa INT,
    @MaNhanVien INT
AS
BEGIN
    INSERT INTO Luong (Luong, LuongGio, Thuong, TongNhan, ThoiGian, SoCa, MaNhanVien)
    VALUES (@Luong, @LuongGio, @Thuong, @TongNhan, @ThoiGian, @SoCa, @MaNhanVien);
END;
GO
-- Cập nhật thưởng -> Tổng nhận
CREATE PROCEDURE sp_CapNhatThuongTongNhan
    @MaNhanVien INT,
    @Thuong DECIMAL(15, 2),
    @Thang INT, 
    @Nam INT    
AS
BEGIN
    UPDATE Luong
    SET Thuong = @Thuong,
        TongNhan = Luong + @Thuong
    WHERE MaNhanVien = @MaNhanVien
        AND MONTH(ThoiGian) = @Thang   
        AND YEAR(ThoiGian) = @Nam;    
END;
GO
--xoa
-- CREATE PROCEDURE sp_XoaLuong
--     @MaLuong INT
-- AS
-- BEGIN
--     DELETE FROM Luong
--     WHERE MaLuong = @MaLuong;
-- END;

--Function ****
CREATE FUNCTION fn_XemLuongTheoNhanVien
(
    @MaNhanVien INT,
    @NgayBD DATE,
    @NgayKT DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        MaLuong,
        Luong,
        Thuong,
        ThoiGian,
        SoCa
    FROM 
        Luong
    WHERE 
        MaNhanVien = @MaNhanVien
        AND ThoiGian BETWEEN @NgayBD AND @NgayKT
);
GO

-- INSERT INTO Luong (Luong, LuongGio, Thuong, TongNhan, ThoiGian, SoCa, MaNhanVien)
-- VALUES
--     (22 * 25000, 25000, 1000000, (22 * 25000) + 1000000, '2024-06-01', 22, 1),
--     (23 * 25000, 25000, 1200000, (23 * 25000) + 1200000, '2024-07-01', 23, 1),
--     (24 * 25000, 25000, 1500000, (24 * 25000) + 1500000, '2024-08-01', 24, 1);


-- DELETE FROM Luong WHERE MaLuong = 15
-- SELECT * FROM dbo.fn_XemLuongTheoNhanVien(1,'2024-07-01','2024-12-01');


--
CREATE FUNCTION dbo.fn_XemTatCaLuongTheoThangNam
(
    @Thang INT, 
    @Nam INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        l.MaLuong,
        l.Luong,
        l.Thuong,
        FORMAT(l.ThoiGian, 'MM-yyyy') AS ThoiGian, -- Chỉ lấy tháng và năm
        l.SoCa,
        nv.TenNhanVien,
        dbo.fn_DemCaNghi(
            DATEFROMPARTS(@Nam, @Thang, 1),
            EOMONTH(DATEFROMPARTS(@Nam, @Thang, 1)),
            nv.MaNhanVien
        ) AS CaNghi -- Adding Ca Nghỉ using the fn_DemCaNghi function
    FROM 
        Luong l
    JOIN 
        NhanVien nv ON l.MaNhanVien = nv.MaNhanVien
    WHERE 
        MONTH(l.ThoiGian) = @Thang AND
        YEAR(l.ThoiGian) = @Nam
);
GO


-- SELECT * FROM dbo.fn_XemTatCaLuongTheoThangNam(9, 2024);









