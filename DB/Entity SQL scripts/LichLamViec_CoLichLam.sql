
--LichLamViec(MaLichLamViec, NgayLam, MaCa)
--them trong fLichLamViec  ***
CREATE PROCEDURE sp_ThemLichLamViec
    @NgayLam DATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Thêm tất cả các MaCa từ bảng CaLamViec vào LichLamViec với NgayLam đã cho
        INSERT INTO LichLamViec (NgayLam, MaCa)
        SELECT @NgayLam, MaCa
        FROM CaLamViec;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi thêm lịch làm việc. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
-- Thêm CoLichLam
CREATE PROCEDURE sp_ThemCoLichLam
    @MaNhanVien INT,
    @MaLichLamViec INT,
    @DanhGia NVARCHAR(255),
    @TrangThai NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO CoLichLam (MaNhanVien, MaLichLamViec, DanhGia, TrangThai)
        VALUES (@MaNhanVien, @MaLichLamViec, @DanhGia, @TrangThai);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi thêm. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Sửa CoLichLam
CREATE PROCEDURE sp_SuaCoLichLam
    @MaNhanVien INT,
    @MaLichLamViec INT,
    @DanhGia NVARCHAR(255),
    @TrangThai NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE CoLichLam
        SET DanhGia = @DanhGia,
            TrangThai = @TrangThai
        WHERE MaNhanVien = @MaNhanVien AND MaLichLamViec = @MaLichLamViec;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi sửa. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Xóa CoLichLam
CREATE PROCEDURE sp_XoaCoLichLam
    @MaNhanVien INT,
    @MaLichLamViec INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM CoLichLam
        WHERE MaNhanVien = @MaNhanVien AND MaLichLamViec = @MaLichLamViec;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi xóa. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);    
    END CATCH
END;
GO

--Func


---Xem lich lam trong ngay **
CREATE FUNCTION dbo.fn_XemLichLamTrongNgay (@ngay DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        llv.MaLichLamViec,
        llv.MaCa,
        llv.NgayLam,
        clv.TenCa,
        clv.GioBatDau,
        clv.GioKetThuc
    FROM 
        LichLamViec llv
	INNER JOIN CaLamViec clv on clv.MaCa = llv.MaCa
    WHERE llv.NgayLam = @ngay 
);

GO

CREATE FUNCTION dbo.fn_XemCaLamViecCuaNhanVien (@MaNhanVien INT, @NgayDau DATE, @NgayCuoi DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        LLV.NgayLam,
        CLL.DanhGia,
        CLL.TrangThai,
        CLV.TenCa,
        CLV.GioBatDau,
        CLV.GioKetThuc
    FROM 
        CoLichLam CLL
    JOIN 
        LichLamViec LLV ON CLL.MaLichLamViec = LLV.MaLichLamViec
    JOIN 
        CaLamViec CLV ON LLV.MaCa = CLV.MaCa
    WHERE 
        CLL.MaNhanVien = @MaNhanVien
        AND LLV.NgayLam BETWEEN @NgayDau AND @NgayCuoi
);
GO

--func dem ngay lam, ngay nghi cua nhan vien 
CREATE FUNCTION dbo.fn_DemCaLamCaNghi (@MaNhanVien INT, @NgayDau DATE, @NgayCuoi DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        YEAR(LLV.NgayLam) AS Nam, 
        MONTH(LLV.NgayLam) AS Thang,
        SUM(CASE WHEN TrangThai = 'HoanThanh' THEN 1 ELSE 0 END) AS HoanThanh,
        SUM(CASE WHEN TrangThai = 'Chua' Then 1 ELSE 0 END) AS Chua
    FROM 
        CoLichLam CLL
    JOIN 
        LichLamViec LLV ON CLL.MaLichLamViec = LLV.MaLichLamViec
    WHERE 
        CLL.MaNhanVien = @MaNhanVien
        AND LLV.NgayLam BETWEEN @NgayDau AND @NgayCuoi
    GROUP BY YEAR(LLV.NgayLam), MONTH(LLV.NgayLam)
)
GO

-- dung trong fthemca  **
CREATE FUNCTION dbo.fn_XemNhanVienTrongLichLamViec (@MaLichLamViec int)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        nv.MaNhanVien,
        nv.TenNhanVien,
		cll.DanhGia,
		cll.TrangThai
    FROM 
        NhanVien nv
	JOIN CoLichLam cll on nv.MaNhanVien = cll.MaNhanVien
    WHERE 
        cll.MaLichLamViec = @MaLichLamViec
);
GO
-- CREATE FUNCTION dbo.fn_XemTatCaLichLam ()
-- RETURNS TABLE
-- AS
-- RETURN
-- (
--     SELECT 
--         nv.TenNhanVien,
-- 		cll.DanhGia,
-- 		cll.TrangThai,
--         clv.TenCa,
--         clv.GioBatDau,
--         clv.GioKetThuc
--     FROM 
--         NhanVien nv
-- 	JOIN CoLichLam cll on nv.MaNhanVien = cll.MaNhanVien
-- 	JOIN LichLamViec llv on cll.MaLichLamViec = llv.MaLichLamViec
-- 	JOIN CaLamViec clv on clv.MaCa = llv.MaCa
-- );
-- GO
