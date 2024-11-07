--view xem ca lam viec  *

GO
USE LinhkienLaptop; 
GO

CREATE VIEW vw_XemCaLam
AS
SELECT *
FROM CaLamViec
GO

--them trong fCaLamViec *
CREATE PROCEDURE sp_ThemCaLamViec
    @TenCa NVARCHAR(100),
    @GioBatDau TIME,
    @GioKetThuc TIME
AS
BEGIN
    INSERT INTO CaLamViec ( TenCa, GioBatDau, GioKetThuc)
    VALUES ( @TenCa, @GioBatDau, @GioKetThuc);
END
GO

--sua fCaLamViec *
CREATE PROCEDURE sp_SuaCaLamViec
    @MaCa INT,
    @TenCa NVARCHAR(100),
    @GioBatDau TIME,
    @GioKetThuc TIME
AS
BEGIN
    UPDATE CaLamViec
    SET TenCa = @TenCa,
        GioBatDau = @GioBatDau,
        GioKetThuc = @GioKetThuc
    WHERE MaCa = @MaCa;
END
GO

--xoa
CREATE PROCEDURE sp_XoaCaLamViec 
@MaCa INT
AS
BEGIN
    DELETE FROM CaLamViec
    WHERE MaCa = @MaCa;
END
GO

-- fThemCaLam
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
    INSERT INTO Luong ( Luong,LuongGio, Thuong,TongNhan, ThoiGian, SoCa, MaNhanVien)
    VALUES ( @Luong,@LuongGio, @Thuong, @TongNhan, @ThoiGian, @SoCa, @MaNhanVien);
END;
GO
--sua
-- CREATE PROCEDURE sp_SuaLuong
--     @MaLuong INT,
--     @Luong DECIMAL(15, 2),
--     @Thuong DECIMAL(15, 2),
--     @ThoiGian DATE,
--     @SoCa INT,
--     @MaNhanVien INT
-- AS
-- BEGIN
-- 	UPDATE Luong
--     SET Luong = @Luong,
--         Thuong = @Thuong,
--         ThoiGian = @ThoiGian,
--         SoCa = @SoCa,
--         MaNhanVien = @MaNhanVien
--     WHERE MaLuong = @MaLuong;
-- END;

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

GO
--
-- CREATE FUNCTION dbo.fn_XemTatCaLuongTheoThangNam
-- (
--     @Thang INT, @Nam INT
-- )
-- RETURNS TABLE
-- AS
-- RETURN
-- (
--     SELECT 
--         l.MaLuong,
--         l.Luong,
--         l.Thuong,
--         l.ThoiGian,
--         l.SoCa,
--         nv.TenNV
--     FROM 
--         Luong l
--     JOIN 
--         NhanVien nv ON l.MaNhanVien = nv.MaNhanVien
--     WHERE 
--         MONTH(l.ThoiGian) = @Thang AND
--         YEAR(l.ThoiGian) = @Nam
-- );

-- SELECT * FROM dbo.fn_XemTatCaLuongTheoThangNam(9, 2024);











-- Don Hang:
--- VIEW
-- Xem Don Hang
CREATE VIEW vw_DonHangList
AS SELECT * 
FROM DonHang
GO

-- Thá»§ tá»¥c thÃªm má»™t record vÃ o báº£ng DonHang
CREATE PROCEDURE sp_ThemDonHang
    @NgayDatHang DATE,
    @MaKhachHang INT,
    @MaNhanVien INT,
    @MaGiamGia INT = NULL,
    @TongGiaTri DECIMAL(15, 2),
    @PhuongThuc NVARCHAR(100)
AS
BEGIN
    INSERT INTO DonHang (NgayDatHang, MaKhachHang, MaNhanVien, MaGiamGia, TongGiaTri, PhuongThuc)
    OUTPUT inserted.MaDonHang 
    VALUES (@NgayDatHang, @MaKhachHang, @MaNhanVien, @MaGiamGia, @TongGiaTri, @PhuongThuc);
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
-- Them chi tiet don hang
CREATE PROCEDURE sp_ThemChiTietDonHang
    @MaDonHang INT,                          
    @MaLinhKien INT,                        
    @SoLuong INT,                           
    @GiaBan DECIMAL(15, 2)                   
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ChiTietDonHang (MaDonHang, MaLinhKien, SoLuong, GiaBan)
    VALUES (@MaDonHang, @MaLinhKien, @SoLuong, @GiaBan);
END
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
	INSERT INTO KhachHang (TenKhachHang, DiaChi, SDT, Email, NgaySinh)
	VALUES (@TenKhachHang, @DiaChi, @SDT, @Email, @NgaySinh);
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
    UPDATE KhachHang
    SET TenKhachHang = @TenKhachHang,
        DiaChi = @DiaChi,
        SDT = @SDT,
        Email = @Email,
        NgaySinh = @NgaySinh
    WHERE MaKhachHang = @MaKhachHang;
END;
GO


-- XÃ³a khÃ¡ch hÃ ng
CREATE PROCEDURE sp_XoaKhachHang
    @MaKhachHang INT
AS
BEGIN
    DELETE FROM KhachHang
    WHERE MaKhachHang = @MaKhachHang;
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
        PRINT 'TiÃªu chÃ­ tÃ¬m kiáº¿m khÃ´ng há»£p lá»‡.';
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


GO
--LichLamViec(MaLichLamViec, NgayLam, MaCa)
--them trong fLichLamViec  ***
CREATE PROCEDURE sp_ThemLichLamViec
    @NgayLam DATE
AS
BEGIN
    -- Thêm tất cả các MaCa từ bảng CaLamViec vào LichLamViec với NgayLam đã cho
    INSERT INTO LichLamViec (NgayLam, MaCa)
    SELECT @NgayLam, MaCa
    FROM CaLamViec;
END;
GO
--sua
-- CREATE PROCEDURE sp_SuaLichLamViec
--     @MaLichLamViec INT,
--     @NgayLam DATE,
--     @MaCa INT
-- AS
-- BEGIN
--     UPDATE LichLamViec
--     SET NgayLam = @NgayLam,
--         MaCa = @MaCa
--     WHERE MaLichLamViec = @MaLichLamViec;
-- END;

--xoa
-- CREATE PROCEDURE sp_XoaLichLamViec
--     @MaLichLamViec INT
-- AS
-- BEGIN
--     DELETE FROM LichLamViec
--     WHERE MaLichLamViec = @MaLichLamViec;
-- END;

--CoLichLam(MaNhanVien, MaLichLamViec, DanhGia, TrangThai)

--them ***
CREATE PROCEDURE sp_ThemCoLichLam
    @MaNhanVien INT,
    @MaLichLamViec INT,
    @DanhGia NVARCHAR(255),
    @TrangThai NVARCHAR(100)
AS
BEGIN
    INSERT INTO CoLichLam (MaNhanVien, MaLichLamViec, DanhGia, TrangThai)
    VALUES (@MaNhanVien, @MaLichLamViec, @DanhGia, @TrangThai);
END;
GO
--sua
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

--xoa ***
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

GO
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
GO


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
-- - Thêm linh kiện
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
    INSERT INTO LinhKien (TenLinhKien, MoTaChiTiet, HinhAnh, GiaBan, GiaNhap, SoLuongTonKho, MaLoaiLinhKien, MaNhaCungCap)
    VALUES (@TenLinhKien, @MoTaChiTiet, @HinhAnh, @GiaBan, @GiaNhap, @SoLuongTonKho, @MaLoaiLinhKien, @MaNhaCungCap);
END;
GO

-- - Sửa linh kiện
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
END;
GO

-- - Xóa Linh kiện
CREATE PROCEDURE sp_XoaLinhKien
	@MaLinhKien INT
AS
BEGIN
    DELETE FROM LinhKien WHERE MaLinhKien = @MaLinhKien;
END;
GO

-- "LOAI LINH KIEN" -------- CHUA TRIEN KHAI


-- Thêm loại linh kiện
-- CREATE PROCEDURE sp_ThemLoaiLinhKien
-- 	@TenLoaiLinhKien NVARCHAR(255)
-- AS
-- BEGIN
-- 	INSERT INTO LoaiLinhKien (TenLoaiLinhKien)
-- 	VALUES (@TenLoaiLinhKien)
-- END;

-- -- Sửa loại linh kiện
-- CREATE PROCEDURE sp_SuaLoaiLinhKien
-- 	@MaLoaiLinhKien INT,
-- 	@TenLoaiLinhKien NVARCHAR(255)
-- AS
-- BEGIN
-- 	UPDATE LoaiLinhKien
-- 	SET TenLoaiLinhKien = @TenLoaiLinhKien
-- 	WHERE MaLoaiLinhKien = @MaLoaiLinhKien
-- END;

-- -- - Xóa loại linh kiện
-- CREATE PROCEDURE sp_XoaLoaiLinhKien
-- 	@MaLoaiLinhKien INT
-- AS
-- BEGIN
-- 	DELETE FROM LoaiLinhKien WHERE MaLoaiLinhKien= @MaLoaiLinhKien;
-- END;

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
CREATE PROCEDURE sp_ThemGiamGia
    @TenGiamGia NVARCHAR(100),
    @NgayBatDau DATE,
    @NgayKetThuc DATE,
    @GiaTri DECIMAL(5, 2)
AS
BEGIN
    INSERT INTO dbo.GiamGia (TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri)
    VALUES (@TenGiamGia, @NgayBatDau, @NgayKetThuc, @GiaTri);
END;
GO
CREATE PROCEDURE sp_XoaGiamGia
    @MaGiamGia INT
AS
BEGIN
    DELETE FROM GiamGia
    WHERE MaGiamGia = @MaGiamGia;
END;

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

-- - ThÃªm nhÃ  cung cáº¥p
CREATE PROCEDURE sp_ThemNhaCungCap
	@TenNhaCungCap NVARCHAR(255),
	@DiaChi NVARCHAR(255),
	@SDT NVARCHAR(10),
	@Email NVARCHAR(100)
AS
BEGIN
	INSERT INTO NhaCungCap (TenNhaCungCap,DiaChi,SDT,Email)
	VALUES (@TenNhaCungCap,@DiaChi,@SDT,@Email);
END;
GO

-- - Sá»­a nhÃ  cung cáº¥p
CREATE PROCEDURE sp_SuaNhaCungCap
	@MaNhaCungCap INT,
	@TenNhaCungCap NVARCHAR(255),
	@DiaChi NVARCHAR(255),
	@SDT NVARCHAR(10),
	@Email NVARCHAR(100)
AS
BEGIN
	UPDATE NhaCungCap
	SET TenNhaCungCap = @TenNhaCungCap,
		DiaChi = @DiaChi,
		SDT = @SDT,
		Email = @Email
	WHERE MaNhaCungCap = @MaNhaCungCap;
END;
GO

-- - XÃ³a nhÃ  cung cáº¥p
CREATE PROCEDURE sp_XoaNhaCungCap
	@MaNhaCungCap INT
AS
BEGIN
	DELETE FROM NhaCungCap WHERE MaNhaCungCap= @MaNhaCungCap;
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
-- ThÃªm 
CREATE PROCEDURE sp_ThemNhanVien
    @TenNhanVien NVARCHAR(100),
    @SDT NVARCHAR(15),
    @Email NVARCHAR(100),
    @NgaySinh DATE,
    @DiaChi NVARCHAR(255),
    @MatKhau NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.NhanVien (TenNhanVien, SDT, Email, NgaySinh, DiaChi, MatKhau, ChucVu)
    VALUES (@TenNhanVien, @SDT, @Email, @NgaySinh, @DiaChi, @MatKhau, 'nv')
END
GO
--sua thong tin nhan vien *
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
    UPDATE NhanVien
    SET
        TenNhanVien = @TenNhanVien,
        DiaChi = @DiaChi,
        SDT = @SDT,
        Email = @Email,
        MatKhau = @MatKhau,
        NgaySinh = @NgaySinh
    WHERE MaNhanVien = @MaNhanVien;
END;

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
CREATE PROCEDURE sp_ThemPhieuNhapHang
    @NgayNhap DATE,
    @GiaNhap DECIMAL(15, 2),
    @SoLuong INT,
    @MaLinhKien INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM LinhKien WHERE MaLinhKien = @MaLinhKien)
    BEGIN
        RAISERROR('LinhKien khong ton tai.', 16, 1);
        RETURN;
    END
    
    INSERT INTO PhieuNhapHang (NgayNhap, GiaNhap, SoLuong, MaLinhKien)
    VALUES (@NgayNhap, @GiaNhap, @SoLuong, @MaLinhKien);
       
    PRINT 'Cap nhat kho phieu nhap hang thanh cong.';
END;
GO
-- Cập nhật
CREATE PROCEDURE UpdatePhieuNhapHang
    @MaPhieuNhap INT,
    @NgayNhap DATE,
    @GiaNhap DECIMAL(15, 2),
    @SoLuong INT,
    @MaLinhKien INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM PhieuNhapHang WHERE MaPhieuNhap = @MaPhieuNhap)
    BEGIN
        RAISERROR('Phieu nhap hang khong ton tai.', 16, 1);
        RETURN;
    END

    UPDATE PhieuNhapHang
    SET NgayNhap = @NgayNhap, GiaNhap = @GiaNhap, SoLuong = @SoLuong, MaLinhKien = @MaLinhKien
    WHERE MaPhieuNhap = @MaPhieuNhap;
    
    PRINT 'PhieuNhapHang cap nhat thanh cong.';
END;
GO

-- Xóa
CREATE PROCEDURE DeletePhieuNhapHang
    @MaPhieuNhap INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM PhieuNhapHang WHERE MaPhieuNhap = @MaPhieuNhap)
    BEGIN
        RAISERROR('Phieu nhap hang khong ton tai.', 16, 1);
        RETURN;
    END

    DELETE FROM PhieuNhapHang
    WHERE MaPhieuNhap = @MaPhieuNhap;
    
    PRINT 'Xoa phieu nhap hang thanh cong.';
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


