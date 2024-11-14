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











-- Don Hang:
--- VIEW
-- Xem Don Hang
CREATE VIEW vw_DonHangList
AS SELECT * 
FROM DonHang
GO

-- Thá»§ tá»¥c thÃªm má»™t record vÃ o báº£ng DonHang
-- Táº¡o Ä‘Æ¡n hÃ ng
CREATE PROCEDURE sp_ThemDonHang
    @NgayDatHang DATE,
    @MaKhachHang INT,
    @MaNhanVien INT,
    @MaGiamGia INT = NULL,
    @TongGiaTri DECIMAL(15, 2),
    @PhuongThuc NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO DonHang (NgayDatHang, MaKhachHang, MaNhanVien, MaGiamGia, TongGiaTri, PhuongThuc)
        OUTPUT inserted.MaDonHang 
        VALUES (@NgayDatHang, @MaKhachHang, @MaNhanVien, @MaGiamGia, @TongGiaTri, @PhuongThuc);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR (N'ÄÃ£ xáº£y ra lá»—i khi thÃªm Ä‘Æ¡n hÃ ng.', 16, 1);
    END CATCH
END;

GO
-- Lay Chi TIet Don Hang
CREATE PROCEDURE sp_ChiTietDonHang
    @MaDonHang INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        dh.MaDonHang,
        dh.NgayDatHang,
        kh.TenKhachHang,
        nv.TenNhanVien,
        gg.TenGiamGia,
        dh.TongGiaTri,
        dh.PhuongThuc,
        lk.TenLinhKien,
        ctdh.SoLuong,
        ctdh.GiaBan,
        (ctdh.SoLuong * ctdh.GiaBan) AS ThanhTien
    FROM 
        DonHang dh
    LEFT JOIN KhachHang kh ON dh.MaKhachHang = kh.MaKhachHang
    LEFT JOIN NhanVien nv ON dh.MaNhanVien = nv.MaNhanVien
    LEFT JOIN GiamGia gg ON dh.MaGiamGia = gg.MaGiamGia
    LEFT JOIN ChiTietDonHang ctdh ON dh.MaDonHang = ctdh.MaDonHang
    LEFT JOIN LinhKien lk ON lk.MaLinhKien = ctdh.MaLinhKien
    WHERE dh.MaDonHang = @MaDonHang;
END;
GO

--- CHITIETDONHANG
-- ThÃªm chi tiáº¿t Ä‘Æ¡n hÃ ng
CREATE PROCEDURE sp_ThemChiTietDonHang
    @MaDonHang INT,                          
    @MaLinhKien INT,                         
    @SoLuong INT,                            
    @GiaBan DECIMAL(15, 2)                   
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        SET NOCOUNT ON;
        INSERT INTO ChiTietDonHang (MaDonHang, MaLinhKien, SoLuong, GiaBan)
        VALUES (@MaDonHang, @MaLinhKien, @SoLuong, @GiaBan);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR (N'ÄÃ£ xáº£y ra lá»—i khi thÃªm chi tiáº¿t Ä‘Æ¡n hÃ ng.', 16, 1);
    END CATCH
END;
GO


--- VIEW
CREATE VIEW vw_KhachHangList AS
SELECT *
FROM dbo.KhachHang
GO


-- Stored Procedure ----------------------------------------------------
-- ThÃªm khÃ¡ch hÃ ng:
CREATE PROCEDURE sp_ThemKhachHang
    @TenKhachHang NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT NVARCHAR(10),
    @Email NVARCHAR(100),
    @NgaySinh DATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO KhachHang (TenKhachHang, DiaChi, SDT, Email, NgaySinh)
        VALUES (@TenKhachHang, @DiaChi, @SDT, @Email, @NgaySinh);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'ÄÃ£ xáº£y ra lá»—i khi thÃªm khÃ¡ch hÃ ng. Lá»—i: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
-- Sá»­a khÃ¡ch hÃ ng
CREATE PROCEDURE sp_SuaKhachHang
    @MaKhachHang INT,
    @TenKhachHang NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT NVARCHAR(10),
    @Email NVARCHAR(100),
    @NgaySinh DATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE KhachHang
        SET TenKhachHang = @TenKhachHang,
            DiaChi = @DiaChi,
            SDT = @SDT,
            Email = @Email,
            NgaySinh = @NgaySinh
        WHERE MaKhachHang = @MaKhachHang;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'ÄÃ£ xáº£y ra lá»—i khi sá»­a khÃ¡ch hÃ ng. Lá»—i: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO


-- XÃ³a khÃ¡ch hÃ ng
CREATE PROCEDURE sp_XoaKhachHang
    @MaKhachHang INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM KhachHang
        WHERE MaKhachHang = @MaKhachHang;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'ÄÃ£ xáº£y ra lá»—i khi xÃ³a khÃ¡ch hÃ ng. Lá»—i: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;


GO
---- STORED PROCEDURE
CREATE PROCEDURE sp_TimKiemKhachHang
    @SearchOption NVARCHAR(50), 
    @SearchText NVARCHAR(255) 
AS
BEGIN
    SET NOCOUNT ON;
    IF @SearchOption = 'MaKhachHang'
    BEGIN
        SELECT * FROM KhachHang
        WHERE MaKhachHang = TRY_CAST(@SearchText AS INT);
    END
    ELSE IF @SearchOption = 'TenKhachHang'
    BEGIN
        SELECT * FROM KhachHang
        WHERE TenKhachHang LIKE '%' + @SearchText + '%';
    END
    ELSE IF @SearchOption = 'DiaChi'
    BEGIN
        SELECT * FROM KhachHang
        WHERE DiaChi LIKE '%' + @SearchText + '%';
    END
    ELSE IF @SearchOption = 'SDT'
    BEGIN
        SELECT * FROM KhachHang
        WHERE SDT LIKE '%' + @SearchText + '%';
    END
    ELSE IF @SearchOption = 'Email'
    BEGIN
        SELECT * FROM KhachHang
        WHERE Email LIKE '%' + @SearchText + '%';
    END
    ELSE
    BEGIN
        RAISERROR (N'TiÃªu chÃ­ tÃ¬m kiáº¿m khÃ´ng há»£p lá»‡.', 16, 1);
    END
END;

GO
------ FUNCTION
-- TÃ­nh tá»•ng sá»‘ khÃ¡ch hÃ ng
CREATE FUNCTION fn_TinhTongKhachHang()
RETURNS INT
AS
BEGIN
    DECLARE @TongKhachHang INT;
    SELECT @TongKhachHang = COUNT(*)
    FROM KhachHang;

    RETURN @TongKhachHang;
END;
GO



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
    UPDATE CoLichLam
    SET DanhGia = @DanhGia,
        TrangThai = @TrangThai
    WHERE MaNhanVien = @MaNhanVien AND MaLichLamViec = @MaLichLamViec;
END;
GO

-- Xóa CoLichLam
CREATE PROCEDURE sp_XoaCoLichLam
    @MaNhanVien INT,
    @MaLichLamViec INT
AS
BEGIN
    DELETE FROM CoLichLam
    WHERE MaNhanVien = @MaNhanVien AND MaLichLamViec = @MaLichLamViec;
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
CREATE FUNCTION fn_DemCaLam (@start DATE, @end DATE, @MaNhanVien INT)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM CoLichLam CLL
        JOIN LichLamViec LLV ON CLL.MaLichLamViec = LLV.MaLichLamViec
        WHERE CLL.MaNhanVien = @MaNhanVien
            AND LLV.NgayLam BETWEEN @start AND @end
            AND TrangThai = 'HoanThanh'
    );
END;
GO
CREATE FUNCTION fn_DemCaNghi (@start DATE, @end DATE, @MaNhanVien INT)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM CoLichLam CLL
        JOIN LichLamViec LLV ON CLL.MaLichLamViec = LLV.MaLichLamViec
        WHERE CLL.MaNhanVien = @MaNhanVien
            AND LLV.NgayLam BETWEEN @start AND @end
            AND TrangThai = 'Chua'
    );
END;
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


GO


GO
CREATE VIEW vw_ThongTinLinhKien AS
SELECT lk.MaLinhKien, lk.TenLinhKien, lk.MoTaChiTiet, lk.GiaBan, lk.GiaNhap, lk.SoLuongTonKho, 
       llk.TenLoaiLinhKien, ncc.TenNhaCungCap, llk.MaLoaiLinhKien, lk.HinhAnh
FROM LinhKien lk
JOIN LoaiLinhKien llk ON lk.MaLoaiLinhKien = llk.MaLoaiLinhKien
JOIN NhaCungCap ncc ON lk.MaNhaCungCap = ncc.MaNhaCungCap;
GO

Create PROCEDURE sp_TimKiemLinhKienTheoID
    @MaLinhKien INT
AS
BEGIN
    SELECT * FROM dbo.LinhKien
    WHERE MaLinhKien = @MaLinhKien;
END;
GO


CREATE FUNCTION fn_DoanhThuTheoLinhKien(@MaLinhKien INT)
RETURNS INT
AS
BEGIN
    DECLARE @DoanhThu INT;

    SELECT @DoanhThu = SUM(ISNULL(SoLuong, 0) * ISNULL(GiaBan, 0))
    FROM ChiTietDonHang
    WHERE MaLinhKien = @MaLinhKien;

    RETURN ISNULL(@DoanhThu, 0);
END;
GO

CREATE FUNCTION fn_DoanhThuTheoLoaiLinhKien(@MaLoaiLinhKien INT)
RETURNS INT
AS
BEGIN
	DECLARE @DoanhThu INT;
	SELECT @DoanhThu = SUM(C.SoLuong * C.GiaBan)
	FROM ChiTietDonHang C
	INNER JOIN LinhKien L
	ON C.MaLinhKien = L.MaLinhKien
	WHERE L.MaLoaiLinhKien = @MaLoaiLinhKien
	RETURN ISNULL(@DoanhThu, 0);
END;
GO

CREATE FUNCTION fn_HTKTheoLinhKien(@MaLinhKien INT)
RETURNS INT
AS
BEGIN
	DECLARE @SL INT
	SELECT @SL=SoLuongTonKho
	FROM LinhKien
	WHERE MaLinhKien=@MaLinhKien
	RETURN ISNULL(@SL, 0);
END
GO

CREATE FUNCTION fn_HTKTheoLoaiLinhKien(@MaLoaiLinhKien INT)
RETURNS INT
AS
BEGIN
	DECLARE @SL INT
	SELECT @SL=SUM(SoLuongTonKho)
	FROM LinhKien
	WHERE MaLoaiLinhKien = @MaLoaiLinhKien
	RETURN ISNULL(@SL, 0);
END
GO


CREATE FUNCTION fn_ThongKeDoanhThuLinhKien()
RETURNS TABLE
AS
RETURN
(
	SELECT TenLinhKien, dbo.fn_DoanhThuTheoLinhKien(MaLinhKien) AS DoanhThu 
	FROM LinhKien
	)
GO

CREATE FUNCTION fn_ThongKeDoanhThuLoaiLinhKien()
RETURNS TABLE
AS
RETURN
(
	SELECT TenLoaiLinhKien, dbo.fn_DoanhThuTheoLoaiLinhKien(MaLoaiLinhKien) AS DoanhThu
	FROM LoaiLinhKien
)
GO

CREATE FUNCTION fn_ThongKeHTKTheoLinhKien()
RETURNS TABLE
RETURN (
	SELECT TenLinhKien, dbo.fn_HTKTheoLinhKien(MaLinhKien) as SoLuong
	FROM LinhKien
)
GO

CREATE FUNCTION fn_ThongKeHTKTheoLoaiLinhKien()
RETURNS TABLE
RETURN(
	SELECT TenLoaiLinhKien, dbo.fn_HTKTheoLoaiLinhKien(MaLoaiLinhKien) as SoLuong
	FROM LoaiLinhKien
)

GO
CREATE FUNCTION fn_TopLinhKienMD(@StartDate DATE, @EndDate DATE)
RETURNS TABLE
AS
RETURN (
    SELECT 
        lk.MaLinhKien, 
        SUM(ct.SoLuong * ct.GiaBan) AS DoanhThu,
        AVG(SUM(ct.SoLuong * ct.GiaBan)) OVER (PARTITION BY lk.MaLoaiLinhKien) AS TrungBinhDoanhThuLoai,
        CASE 
            WHEN SUM(ct.SoLuong * ct.GiaBan) > AVG(SUM(ct.SoLuong * ct.GiaBan)) OVER (PARTITION BY lk.MaLoaiLinhKien) 
            THEN 'High' 
            ELSE 'Low' 
        END AS MucDoanhThu,
        ROW_NUMBER() OVER (ORDER BY SUM(ct.SoLuong * ct.GiaBan) DESC) AS XepHang
    FROM DonHang dh
    JOIN ChiTietDonHang ct ON dh.MaDonHang = ct.MaDonHang
    JOIN LinhKien lk ON lk.MaLinhKien = ct.MaLinhKien
    WHERE dh.NgayDatHang BETWEEN @StartDate AND @EndDate
    GROUP BY lk.MaLinhKien, lk.MaLoaiLinhKien
)

GO

CREATE PROC sp_ThongTinTopKLinhKienMD
    @K INT, 
    @StartDate DATE, 
    @EndDate DATE
AS
BEGIN
    SELECT TOP(@K)
        tlk.XepHang, 
        lk.TenLinhKien, 
        llk.TenLoaiLinhKien, 
        tlk.DoanhThu, 
        tlk.TrungBinhDoanhThuLoai,
        tlk.MucDoanhThu
    FROM LinhKien lk
    JOIN fn_TopLinhKienMD(@StartDate, @EndDate) tlk
    ON lk.MaLinhKien = tlk.MaLinhKien
    JOIN LoaiLinhKien llk
    ON lk.MaLoaiLinhKien = llk.MaLoaiLinhKien
    ORDER BY tlk.XepHang
END



-- 1.	View
-- - Xem toàn bộ thông tin linh kiện
GO
-- Xem linh kiện sắp hết hàng
-- SELECT lk.MaLinhKien, lk.TenLinhKien, lk.MoTaChiTiet, lk.GiaBan, lk.GiaNhap, lk.SoLuongTonKho, 
-- 		llk.TenLoaiLinhKien, ncc.TenNhaCungCap
-- FROM LinhKien lk
-- JOIN LoaiLinhKien llk ON lk.MaLoaiLinhKien = llk.MaLoaiLinhKien
-- JOIN NhaCungCap ncc ON lk.MaNhaCungCap = ncc.MaNhaCungCap
-- WHERE lk.SoLuongTonKho < 10;

-- Xem thông tin loại linh kiện
CREATE VIEW vw_ThongTinLoaiLinhKien AS
	SELECT * FROM LoaiLinhKien
GO

-- Stored Procedure
-- Thêm linh kiện
CREATE PROCEDURE sp_ThemLinhKien
    @TenLinhKien NVARCHAR(255),
    @MoTaChiTiet NVARCHAR(1000),
    @HinhAnh NVARCHAR(255),
    @GiaBan DECIMAL(15, 2),
    @GiaNhap DECIMAL(15, 2),
    @SoLuongTonKho INT,
    @MaLoaiLinhKien INT,
    @MaNhaCungCap INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO LinhKien (TenLinhKien, MoTaChiTiet, HinhAnh, GiaBan, GiaNhap, SoLuongTonKho, MaLoaiLinhKien, MaNhaCungCap)
        VALUES (@TenLinhKien, @MoTaChiTiet, @HinhAnh, @GiaBan, @GiaNhap, @SoLuongTonKho, @MaLoaiLinhKien, @MaNhaCungCap);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi thêm linh kiện. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);   
    END CATCH
END;
GO

-- Sửa linh kiện
CREATE PROCEDURE sp_SuaLinhKien
    @MaLinhKien INT,
    @TenLinhKien NVARCHAR(255),
    @MoTaChiTiet NVARCHAR(1000),
    @HinhAnh NVARCHAR(255),
    @GiaBan DECIMAL(15, 2),
    @GiaNhap DECIMAL(15, 2),
    @SoLuongTonKho INT,
    @MaLoaiLinhKien INT,
    @MaNhaCungCap INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE LinhKien
        SET TenLinhKien = @TenLinhKien,
            MoTaChiTiet = @MoTaChiTiet,
            HinhAnh = @HinhAnh,
            GiaBan = @GiaBan,
            GiaNhap = @GiaNhap,
            SoLuongTonKho = @SoLuongTonKho,
            MaLoaiLinhKien = @MaLoaiLinhKien,
            MaNhaCungCap = @MaNhaCungCap
        WHERE MaLinhKien = @MaLinhKien;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi sửa linh kiện. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);   
    END CATCH
END;
GO

-- Xóa linh kiện
CREATE PROCEDURE sp_XoaLinhKien
    @MaLinhKien INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM LinhKien
        WHERE MaLinhKien = @MaLinhKien;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi xóa linh kiện. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);   
    END CATCH
END;
GO

-- "LOAI LINH KIEN" -------- CHUA TRIEN KHAI
-- Thêm loại linh kiện
CREATE PROCEDURE sp_ThemLoaiLinhKien
    @TenLoaiLinhKien NVARCHAR(255)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO LoaiLinhKien (TenLoaiLinhKien)
        VALUES (@TenLoaiLinhKien);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi thêm loại linh kiện. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);   
    END CATCH
END;
GO
-- Sửa loại linh kiện
CREATE PROCEDURE sp_SuaLoaiLinhKien
    @MaLoaiLinhKien INT,
    @TenLoaiLinhKien NVARCHAR(255)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE LoaiLinhKien
        SET TenLoaiLinhKien = @TenLoaiLinhKien
        WHERE MaLoaiLinhKien = @MaLoaiLinhKien;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi sửa loại linh kiện. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);   
    END CATCH
END;
GO
-- Xóa loại linh kiện
CREATE PROCEDURE sp_XoaLoaiLinhKien
    @MaLoaiLinhKien INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM LoaiLinhKien
        WHERE MaLoaiLinhKien = @MaLoaiLinhKien;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi xóa loại linh kiện. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);   
    END CATCH
END;
GO
-- Tìm kiếm
CREATE PROCEDURE sp_TimKiemLinhKienTheoTuKhoa
    @TuKhoa NVARCHAR(255)
AS
BEGIN
    SELECT *
    FROM vw_ThongTinLinhKien lk
    WHERE lk.TenLinhKien LIKE '%' + @TuKhoa + '%'
       OR lk.MoTaChiTiet LIKE '%' + @TuKhoa + '%';
END;
GO



USE [LinhkienLaptop]
GO

CREATE PROC sp_TimKiemLoaiLinhKienTheoID @MaLLK INT
AS
BEGIN
	SELECT TenLoaiLinhKien
	FROM LoaiLinhKien
	WHERE MaLoaiLinhKien = @MaLLK
END
GO



--- View
CREATE VIEW vw_GiamGia
AS
SELECT MaGiamGia, TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri
FROM dbo.GiamGia
GO
-- Stored Procedure
-- Táº¡o
-- ThÃªm giáº£m giÃ¡
CREATE PROCEDURE sp_ThemGiamGia
    @TenGiamGia NVARCHAR(100),
    @NgayBatDau DATE,
    @NgayKetThuc DATE,
    @GiaTri DECIMAL(5, 2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO dbo.GiamGia (TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri)
        VALUES (@TenGiamGia, @NgayBatDau, @NgayKetThuc, @GiaTri);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'ÄÃ£ xáº£y ra lá»—i khi thÃªm mÃ£ giáº£m giÃ¡. Lá»—i: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- XÃ³a giáº£m giÃ¡
CREATE PROCEDURE sp_XoaGiamGia
    @MaGiamGia INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM GiamGia
        WHERE MaGiamGia = @MaGiamGia;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'ÄÃ£ xáº£y ra lá»—i khi xÃ³a mÃ£ giáº£m giÃ¡. Lá»—i: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

GO
-- Láº¥y mÃ£ theo thá»i gian
CREATE PROCEDURE sp_TimKiemMaGiamGiaTheoThoiGian
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT MaGiamGia, TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri
    FROM dbo.GiamGia
    WHERE NgayBatDau BETWEEN @StartDate AND @EndDate;
END;
GO
---- Function
-- Kiá»ƒm tra mÃ£ giáº£m giÃ¡ há»£p lá»‡
CREATE FUNCTION fn_CheckGiamGiaHopLe (
    @MaGiamGia INT
)
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @NgayBatDau DATE, @NgayKetThuc DATE;
    DECLARE @Result NVARCHAR(50);

    SELECT @NgayBatDau = NgayBatDau, @NgayKetThuc = NgayKetThuc
    FROM dbo.GiamGia
    WHERE MaGiamGia = @MaGiamGia;

    IF @NgayBatDau IS NULL
    BEGIN
        SET @Result = N'MÃ£ giáº£m giÃ¡ khÃ´ng tá»“n táº¡i';
        RETURN @Result;
    END

    IF GETDATE() < @NgayBatDau
    BEGIN
        SET @Result = N'MÃ£ giáº£m giÃ¡ chÆ°a cÃ³ hiá»‡u lá»±c';
    END
    ELSE IF GETDATE() > @NgayKetThuc
    BEGIN
        SET @Result = N'MÃ£ giáº£m giÃ¡ Ä‘Ã£ háº¿t háº¡n';
    END
    ELSE
    BEGIN
        SET @Result = N'MÃ£ giáº£m giÃ¡ há»£p lá»‡';
    END

    RETURN @Result;
END;
GO
-- TÃ­nh giÃ¡ trá»‹ Ä‘Æ¡n sau khi giáº£m
CREATE FUNCTION fn_CalculateFinalPrice (
    @GiaTriDonHang DECIMAL(10, 2),
    @MaGiamGia INT
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @GiaTriGiam DECIMAL(5, 2);
    DECLARE @FinalPrice DECIMAL(10, 2);
    
    SELECT @GiaTriGiam = GiaTri
    FROM dbo.GiamGia
    WHERE MaGiamGia = @MaGiamGia 
        AND GETDATE() BETWEEN NgayBatDau AND NgayKetThuc;

    IF @GiaTriGiam IS NULL
    BEGIN
        SET @FinalPrice = @GiaTriDonHang;
    END
    ELSE
    BEGIN
        SET @FinalPrice = @GiaTriDonHang * (1 - @GiaTriGiam / 100);
    END
    
    RETURN @FinalPrice;
END;
GO

------   TEST       -------
-- Xem cÃ¡c mÃ£ giáº£m giÃ¡ cÃ²n hiá»‡u lá»±c
-- -- View
-- SELECT * FROM vw_GiamGia;
-- -- Stored procedure
-- EXEC sp_InsertGiamGia 
--     @TenGiamGia = N'Giáº£m giÃ¡ Valentine', 
--     @NgayBatDau = '2024-02-10', 
--     @NgayKetThuc = '2024-02-20', 
--     @GiaTri = 10.00;
-- EXEC sp_UpdateGiamGia 
--     @MaGiamGia = 1, 
--     @TenGiamGia = N'Giáº£m giÃ¡ Táº¿t 20245', 
--     @NgayBatDau = '2024-01-01', 
--     @NgayKetThuc = '2024-01-31', 
--     @GiaTri = 12.00;
-- EXEC sp_GetGiamGiaByDateRange 
--     @StartDate = '2023-01-01', 
--     @EndDate = '2023-12-31';
-- -- Function
-- SELECT dbo.fn_CheckGiamGiaHopLe(1) AS TinhTrangGiamGia;
-- SELECT dbo.fn_CalculateFinalPrice(1000000, 1) AS GiaSauKhiGiam;







--- View
--- XEM láº¡i
CREATE VIEW vw_ThongTinNhaCungCap AS
	SELECT * FROM NhaCungCap
GO
-- STORED PROCEDURE 
-- ThÃªm nhÃ  cung cáº¥p
CREATE PROCEDURE sp_ThemNhaCungCap
    @TenNhaCungCap NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT NVARCHAR(10),
    @Email NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, SDT, Email)
        VALUES (@TenNhaCungCap, @DiaChi, @SDT, @Email);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'ÄÃ£ xáº£y ra lá»—i khi thÃªm nhÃ  cung cáº¥p. Lá»—i: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);   
    END CATCH
END;
GO

-- Sá»­a nhÃ  cung cáº¥p
CREATE PROCEDURE sp_SuaNhaCungCap
    @MaNhaCungCap INT,
    @TenNhaCungCap NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT NVARCHAR(10),
    @Email NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE NhaCungCap
        SET TenNhaCungCap = @TenNhaCungCap,
            DiaChi = @DiaChi,
            SDT = @SDT,
            Email = @Email
        WHERE MaNhaCungCap = @MaNhaCungCap;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'ÄÃ£ xáº£y ra lá»—i khi sá»­a nhÃ  cung cáº¥p. Lá»—i: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);   
    END CATCH
END;
GO

-- XÃ³a nhÃ  cung cáº¥p
CREATE PROCEDURE sp_XoaNhaCungCap
    @MaNhaCungCap INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM NhaCungCap
        WHERE MaNhaCungCap = @MaNhaCungCap;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'ÄÃ£ xáº£y ra lá»—i khi xÃ³a nhÃ  cung cáº¥p. Lá»—i: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);   
    END CATCH
END;
GO

CREATE PROCEDURE sp_TimKiemNCCTheoID
    @MaNCC INT
AS
BEGIN
    SELECT * FROM dbo.NhaCungCap
    WHERE MaNhaCungCap = @MaNCC;
END;
GO



--- View show tonaf bá»™ nhÃ¢n viÃªn
CREATE VIEW vw_NhanVienList AS
SELECT MaNhanVien, TenNhanVien, SDT, Email, NgaySinh, DiaChi
FROM dbo.NhanVien
GO
---    Stored Procedures  -----
-- ThÃªm nhÃ¢n viÃªn
CREATE PROCEDURE sp_ThemNhanVien
    @TenNhanVien NVARCHAR(100),
    @SDT NVARCHAR(15),
    @Email NVARCHAR(100),
    @NgaySinh DATE,
    @DiaChi NVARCHAR(255),
    @MatKhau NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO dbo.NhanVien (TenNhanVien, SDT, Email, NgaySinh, DiaChi, MatKhau, ChucVu)
        VALUES (@TenNhanVien, @SDT, @Email, @NgaySinh, @DiaChi, @MatKhau, 'nv');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'ÄÃ£ xáº£y ra lá»—i khi thÃªm nhÃ¢n viÃªn. Lá»—i: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Sá»­a thÃ´ng tin nhÃ¢n viÃªn
CREATE PROCEDURE sp_SuaNhanVien
    @MaNhanVien INT,
    @TenNhanVien NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT NVARCHAR(15),
    @Email NVARCHAR(100),
    @MatKhau NVARCHAR(100),
    @NgaySinh DATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE NhanVien
        SET
            TenNhanVien = @TenNhanVien,
            DiaChi = @DiaChi,
            SDT = @SDT,
            Email = @Email,
            MatKhau = @MatKhau,
            NgaySinh = @NgaySinh
        WHERE MaNhanVien = @MaNhanVien;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'ÄÃ£ xáº£y ra lá»—i khi sá»­a nhÃ¢n viÃªn. Lá»—i: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-----  Function ----- 
GO
-- Name
    CREATE FUNCTION fn_SearchNhanVienByName (@TenNhanVien NVARCHAR(100))
    RETURNS @NhanVienList TABLE (
        MaNhanVien INT,
        TenNhanVien NVARCHAR(100),
        SDT NVARCHAR(15),
        Email NVARCHAR(100),
        NgaySinh DATE,
        DiaChi NVARCHAR(255)
    )
    AS
    BEGIN
        INSERT INTO @NhanVienList
        SELECT MaNhanVien, TenNhanVien, SDT, Email, NgaySinh, DiaChi
        FROM dbo.NhanVien
        WHERE TenNhanVien LIKE '%' + @TenNhanVien + '%'
    
        RETURN
    END
    GO

    -- Email
    CREATE FUNCTION fn_SearchNhanVienByEmail (@Email NVARCHAR(100))
    RETURNS @NhanVienList TABLE (
        MaNhanVien INT,
        TenNhanVien NVARCHAR(100),
        SDT NVARCHAR(15),
        Email NVARCHAR(100),
        NgaySinh DATE,
        DiaChi NVARCHAR(255)
    )
    AS
    BEGIN
        INSERT INTO @NhanVienList
        SELECT MaNhanVien, TenNhanVien, SDT, Email, NgaySinh, DiaChi
        FROM dbo.NhanVien
        WHERE Email LIKE '%' + @Email + '%'
    
        RETURN
    END
GO

CREATE FUNCTION fn_TimNhanVien
(
    @MaNhanVien INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM 
        NhanVien
    WHERE 
        MaNhanVien = @MaNhanVien
);
GO
--procedure  xoa nhan vien
CREATE PROCEDURE [dbo].[proc_XoaNhanVien]
 @MaNV nvarchar(100)
AS
BEGIN
	DECLARE @email varchar(15);
	SELECT @email= Email FROM NhanVien WHERE MaNhanVien=@maNV
	DECLARE @sql varchar(100)
	
	 BEGIN TRANSACTION;
	 BEGIN TRY
		SET @sql = 'DROP USER ['+ @email +']'
		exec (@sql)
		--
		SET @sql = 'DROP LOGIN ['+ @email +']'
		exec (@sql)
	DELETE FROM NhanVien WHERE MaNhanVien=@maNV;
	END TRY
	BEGIN CATCH
		DECLARE @err NVARCHAR(MAX)
		SELECT @err = N'Lá»—i khi xoa ' + ERROR_MESSAGE()
		RAISERROR(@err, 16, 1)
		ROLLBACK TRANSACTION;
		
	END CATCH
	 COMMIT TRANSACTION;
END
GO

----  TEST
---- View
--SELECT * FROM vw_NhanVienList;
---- Add
--EXEC sp_AddNhanVien 
--    @TenNhanVien = N'Nguyá»…n VÄƒn A',
--    @SDT = '0912345678',
--    @Email = 'nguyenvana@example.com',
--    @NgaySinh = '1990-01-15',
--    @DiaChi = N'Sá»‘ 123, ÄÆ°á»ng ABC, Quáº­n 1',
--    @MatKhau = N'matkhau1';
---- Update
--EXEC sp_UpdateNhanVien 
--    @MaNhanVien = 1,
--    @TenNhanVien = N'Tráº§n Thá»‹ B',
--    @SDT = '0987654321',
--    @Email = 'tranthib@example.com',
--    @NgaySinh = '1992-02-20',
--    @DiaChi = N'Sá»‘ 456, ÄÆ°á»ng DEF, Quáº­n 2';
----- Funtion
--USE Linhkiendientu;
--SELECT dbo.fn_GetTotalEmployees() AS TotalEmployees;
--SELECT * FROM dbo.fn_SearchNhanVienByName(N'Nguyá»…n');
--SELECT * FROM dbo.fn_FilterNhanVienByDateRange('1990-01-01', '2000-12-31');
--SELECT * FROM dbo.fn_SearchNhanVienByEmail(N'tranthi');

--SELECT *
--FROM sys.objects
--WHERE name = 'fn_GetTotalEmployees' AND type = 'FN';


-- Thêm Phiếu Nhập Hàng
GO
CREATE PROCEDURE sp_ThemPhieuNhapHang
    @NgayNhap DATE,
    @GiaNhap DECIMAL(15, 2),
    @SoLuong INT,
    @MaLinhKien INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        INSERT INTO PhieuNhapHang (NgayNhap, GiaNhap, SoLuong, MaLinhKien)
        VALUES (@NgayNhap, @GiaNhap, @SoLuong, @MaLinhKien);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi thêm phiếu nhập hàng. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Cập nhật phiếu nhập hàng
CREATE PROCEDURE sp_SuaPhieuNhapHang
    @MaPhieuNhap INT,
    @NgayNhap DATE,
    @GiaNhap DECIMAL(15, 2),
    @SoLuong INT,
    @MaLinhKien INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        UPDATE PhieuNhapHang
        SET NgayNhap = @NgayNhap, GiaNhap = @GiaNhap, SoLuong = @SoLuong, MaLinhKien = @MaLinhKien
        WHERE MaPhieuNhap = @MaPhieuNhap;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi cập nhật phiếu nhập hàng. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Xóa phiếu nhập hàng
CREATE PROCEDURE DeletePhieuNhapHang
    @MaPhieuNhap INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        -- Xóa phiếu nhập hàng
        DELETE FROM PhieuNhapHang
        WHERE MaPhieuNhap = @MaPhieuNhap;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi xóa phiếu nhập hàng. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
-- Trigger cập nhật số lượng tồn kho khi có phiếu nhập hàng mới
CREATE TRIGGER trg_AfterInsert_PhieuNhapHang
ON PhieuNhapHang
AFTER INSERT
AS
BEGIN
    UPDATE LinhKien
    SET SoLuongTonKho = LinhKien.SoLuongTonKho + inserted.SoLuong
    FROM LinhKien
    INNER JOIN inserted ON LinhKien.MaLinhKien = inserted.MaLinhKien;
END;
GO

-- Trigger cập nhật giá nhập khi có phiếu nhập hàng mới
CREATE TRIGGER trg_AfterInsert_PhieuNhapHang_UpdatePrice
ON PhieuNhapHang
AFTER INSERT
AS
BEGIN
    UPDATE LinhKien
    SET GiaNhap = inserted.GiaNhap
    FROM LinhKien
    INNER JOIN inserted ON LinhKien.MaLinhKien = inserted.MaLinhKien;
END;
GO

-- Trigger cập nhật số lượng tồn kho khi xóa phiếu nhập hàng
CREATE TRIGGER trg_AfterDelete_PhieuNhapHang_UpdateStock
ON PhieuNhapHang
AFTER DELETE
AS
BEGIN
    UPDATE LinhKien
    SET SoLuongTonKho = LinhKien.SoLuongTonKho - deleted.SoLuong
    FROM LinhKien
    INNER JOIN deleted ON LinhKien.MaLinhKien = deleted.MaLinhKien;
END;
GO
CREATE VIEW vw_DanhSachPhieuNhap AS
SELECT 
    p.MaPhieuNhap,
    p.NgayNhap,
    p.GiaNhap,
    p.SoLuong,
    l.TenLinhKien,
    p.MaLinhKien
FROM 
    PhieuNhapHang p
JOIN 
    LinhKien l ON p.MaLinhKien = l.MaLinhKien;
GO


CREATE FUNCTION dbo.fn_TongSoDonHang(
    @start DATE,
    @end DATE
)
RETURNS INT
AS
BEGIN
    DECLARE @TongSoDonHang INT;
    SELECT @TongSoDonHang = COUNT(*)
    FROM DonHang
    WHERE NgayDatHang BETWEEN @start AND @end;
    RETURN @TongSoDonHang;
END;

GO
CREATE FUNCTION dbo.fn_DoanhThu(
    @start DATE,
    @end DATE
)
RETURNS DECIMAL(15, 2)
AS
BEGIN
    DECLARE @DoanhThu DECIMAL(15, 2);
    SELECT @DoanhThu = SUM(TongGiaTri)
    FROM DonHang
    WHERE NgayDatHang BETWEEN @start AND @end;
    RETURN @DoanhThu;
END;
GO

CREATE FUNCTION dbo.fn_ChiPhi(
    @start DATE,
    @end DATE
)
RETURNS DECIMAL(15, 2)
AS
BEGIN
    DECLARE @ChiPhiLuong DECIMAL(15, 2);
    DECLARE @ChiPhiLinhKien DECIMAL(15, 2);
    DECLARE @TongChiPhi DECIMAL(15, 2);

    SELECT @ChiPhiLuong = SUM(TongNhan)
    FROM Luong
    WHERE ThoiGian BETWEEN @start AND @end;

    SELECT @ChiPhiLinhKien = SUM(ctdh.SoLuong * lk.GiaNhap)
    FROM ChiTietDonHang ctdh
    JOIN DonHang dh ON ctdh.MaDonHang = dh.MaDonHang
    JOIN LinhKien lk ON ctdh.MaLinhKien = lk.MaLinhKien
    WHERE dh.NgayDatHang BETWEEN @start AND @end;

    SET @TongChiPhi = ISNULL(@ChiPhiLuong, 0) + ISNULL(@ChiPhiLinhKien, 0);

    RETURN @TongChiPhi;
END;
GO

CREATE FUNCTION fn_TinhTongLuongTheoNgay
(
    @startDay DATE,
    @endDay DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        llv.NgayLam AS ngay, 
        SUM((DATEDIFF(MINUTE, clv.GioBatDau, clv.GioKetThuc) / 60.0) * l.LuongGio) AS tongLuong
    FROM 
        CoLichLam cll
        JOIN LichLamViec llv ON cll.MaLichLamViec = llv.MaLichLamViec
        JOIN CaLamViec clv ON clv.MaCa = llv.MaCa
        JOIN NhanVien nv ON nv.MaNhanVien = cll.MaNhanVien
        JOIN Luong l ON l.MaNhanVien = nv.MaNhanVien 
                     AND MONTH(l.ThoiGian) = MONTH(llv.NgayLam) 
                     AND YEAR(l.ThoiGian) = YEAR(llv.NgayLam)
    WHERE 
        cll.TrangThai = 'HoanThanh'
        AND llv.NgayLam BETWEEN @startDay AND @endDay
    GROUP BY 
        llv.NgayLam
);
GO
CREATE PROCEDURE sp_ThongTinChiPhiTheoNgay
    @start DATE,
    @end DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        dh.NgayDatHang AS Ngay,
        COUNT(DISTINCT dh.MaDonHang) AS TongSoDonHang,
        SUM(dh.TongGiaTri) AS TongDoanhThu,
        ISNULL(SUM(l.TongNhan), 0) AS Luong,
        ISNULL(SUM(ctdh.SoLuong * lk.GiaNhap), 0) AS GiaVon,
        (
            ISNULL(SUM(l.TongNhan), 0) + ISNULL(SUM(ctdh.SoLuong * lk.GiaNhap), 0)
        ) AS TongChiPhi,
        (
            SUM(dh.TongGiaTri) - (
                ISNULL(SUM(l.TongNhan), 0) + ISNULL(SUM(ctdh.SoLuong * lk.GiaNhap), 0)
            )
        ) AS LoiNhuan,
        ISNULL(tl.TongLuong, 0) AS TongLuong
    FROM DonHang dh
    LEFT JOIN ChiTietDonHang ctdh ON dh.MaDonHang = ctdh.MaDonHang
    LEFT JOIN LinhKien lk ON ctdh.MaLinhKien = lk.MaLinhKien
    LEFT JOIN Luong l ON dh.NgayDatHang = l.ThoiGian
    LEFT JOIN (
        SELECT ngay, SUM(tongLuong) AS TongLuong
        FROM fn_TinhTongLuongTheoNgay(@start, @end)
        GROUP BY ngay
    ) AS tl ON dh.NgayDatHang = tl.ngay
    WHERE dh.NgayDatHang BETWEEN @start AND @end
    GROUP BY dh.NgayDatHang, tl.TongLuong
    ORDER BY dh.NgayDatHang;
END;
GO


CREATE PROCEDURE sp_TaoTableTamDieuKienThuong
AS
BEGIN
    CREATE TABLE [dbo].[DieuKienThuong] (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        TenFunction NVARCHAR(255) NOT NULL,
        ThamSo NVARCHAR(255) NOT NULL,
        Nguong DECIMAL(18,2) NOT NULL,
        SoSanh NVARCHAR(2) NOT NULL,
        GiaTriThuong NVARCHAR(255) NOT NULL
    );
END;
GO
CREATE PROCEDURE sp_ThemDieuKienThuong
    @TenFunction NVARCHAR(255),
    @ThamSo NVARCHAR(255),
    @Nguong DECIMAL(18,2),
    @SoSanh NVARCHAR(2),
    @GiaTriThuong NVARCHAR(255)
AS
BEGIN
    INSERT INTO DieuKienThuong (TenFunction, ThamSo, Nguong, SoSanh, GiaTriThuong)
    VALUES (@TenFunction, @ThamSo, @Nguong, @SoSanh, @GiaTriThuong);
END;
GO

CREATE PROCEDURE sp_TinhThuongDuaTrenDieuKien
    @start DATE,
    @end DATE
AS
BEGIN
    DECLARE @MaNhanVien INT;
    DECLARE @TenNhanVien NVARCHAR(100);
    DECLARE @Id INT;
    DECLARE @TenFunction NVARCHAR(100);
    DECLARE @ThamSo NVARCHAR(100);
    DECLARE @GiaTriThucTe DECIMAL(18, 2);
    DECLARE @Nguong DECIMAL(18, 2);
    DECLARE @GiaTriThuong DECIMAL(18, 2);
    DECLARE @Thuong DECIMAL(18, 2);
    DECLARE @SoSanh NVARCHAR(2);
    DECLARE @SQL NVARCHAR(MAX);
    DECLARE @ParamDefinition NVARCHAR(255);

    DECLARE @Result TABLE (
        MaNhanVien INT,
        TenNhanVien NVARCHAR(100),
        ResultGiaTriThuong DECIMAL(18, 2)
    );

    -- Khá»Ÿi táº¡o láº¡i @Thuong cho má»—i nhÃ¢n viÃªn
    SET @Thuong = 0;

    -- Cursor duyá»‡t qua tá»«ng nhÃ¢n viÃªn
    DECLARE nhanvien_cursor CURSOR FOR
        SELECT MaNhanVien, TenNhanVien FROM NhanVien;

    OPEN nhanvien_cursor;
    FETCH NEXT FROM nhanvien_cursor INTO @MaNhanVien, @TenNhanVien;

    -- VÃ²ng láº·p duyá»‡t qua tá»«ng nhÃ¢n viÃªn
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @Thuong = 0;

        -- Cursor duyá»‡t qua cÃ¡c Ä‘iá»u kiá»‡n
        DECLARE dieukien_cursor CURSOR FOR
            SELECT Id, TenFunction, ThamSo, Nguong, SoSanh, GiaTriThuong
            FROM DieuKienThuong;

        OPEN dieukien_cursor;
        FETCH NEXT FROM dieukien_cursor INTO @Id, @TenFunction, @ThamSo, @Nguong, @SoSanh, @GiaTriThuong;

        -- VÃ²ng láº·p duyá»‡t qua tá»«ng Ä‘iá»u kiá»‡n
        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Kiá»ƒm tra xem cÃ³ cáº§n tham sá»‘ MaNhanVien hay khÃ´ng
            IF CHARINDEX('MaNhanVien', @ThamSo) > 0
            BEGIN
                SET @SQL = 'SELECT @GiaTriThucTe = dbo.' + @TenFunction + '(@start, @end, @MaNhanVien)';
                SET @ParamDefinition = N'@start DATE, @end DATE, @MaNhanVien INT, @GiaTriThucTe DECIMAL(18, 2) OUTPUT';
                
                EXEC sp_executesql @SQL, @ParamDefinition,
                    @start = @start,
                    @end = @end,
                    @MaNhanVien = @MaNhanVien,
                    @GiaTriThucTe = @GiaTriThucTe OUTPUT;
            END
            ELSE
            BEGIN
                SET @SQL = 'SELECT @GiaTriThucTe = dbo.' + @TenFunction + '(@start, @end)';
                SET @ParamDefinition = N'@start DATE, @end DATE, @GiaTriThucTe DECIMAL(18, 2) OUTPUT';
                
                EXEC sp_executesql @SQL, @ParamDefinition,
                    @start = @start,
                    @end = @end,
                    @GiaTriThucTe = @GiaTriThucTe OUTPUT;
            END

            -- Debug: In giÃ¡ trá»‹ GiaTriThucTe
            PRINT 'GiaTriThucTe: ' + CAST(@GiaTriThucTe AS NVARCHAR(100));

            -- Kiá»ƒm tra Ä‘iá»u kiá»‡n vÃ  tÃ­nh toÃ¡n thÆ°á»Ÿng náº¿u Ä‘iá»u kiá»‡n thoáº£ mÃ£n
            IF (@SoSanh = '<' AND @GiaTriThucTe < @Nguong) OR
               (@SoSanh = '>' AND @GiaTriThucTe > @Nguong) OR
               (@SoSanh = '>=' AND @GiaTriThucTe >= @Nguong) OR
               (@SoSanh = '<=' AND @GiaTriThucTe <= @Nguong) OR
               (@SoSanh = '=' AND @GiaTriThucTe = @Nguong)
            BEGIN
                SET @Thuong = @GiaTriThuong + @Thuong;
            END

            -- Láº¥y Ä‘iá»u kiá»‡n tiáº¿p theo
            FETCH NEXT FROM dieukien_cursor INTO @Id, @TenFunction, @ThamSo, @Nguong, @SoSanh, @GiaTriThuong;
        END

        -- ÄÃ³ng vÃ  giáº£i phÃ³ng con trá» dieukien_cursor
        CLOSE dieukien_cursor;
        DEALLOCATE dieukien_cursor;

        -- Insert káº¿t quáº£ vÃ o báº£ng táº¡m
        INSERT INTO @Result (MaNhanVien, TenNhanVien, ResultGiaTriThuong)
        VALUES (@MaNhanVien, @TenNhanVien, @Thuong);

        -- Láº¥y nhÃ¢n viÃªn tiáº¿p theo
        FETCH NEXT FROM nhanvien_cursor INTO @MaNhanVien, @TenNhanVien;
    END

    -- ÄÃ³ng vÃ  giáº£i phÃ³ng con trá» nhanvien_cursor
    CLOSE nhanvien_cursor;
    DEALLOCATE nhanvien_cursor;

    -- Hiá»ƒn thá»‹ káº¿t quáº£
    SELECT * FROM @Result;
    RETURN;
END;
GO


