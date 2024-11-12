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
