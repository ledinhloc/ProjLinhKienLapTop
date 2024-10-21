CREATE VIEW vw_XemLinhKien as
SELECT lk.MaLinhKien 'Mã Linh Kiện', lk.TenLinhKien 'Tên Linh Kiện', llk.TenLoaiLinhKien 'Loại Linh Kiện', lk.GiaBan 'Gía Bán', lk.SoLuongTonKho 'Số Lượng Tồn Kho' 
FROM dbo.LinhKien lk
join dbo.LoaiLinhKien llk
on lk.MaLoaiLinhKien = llk.MaLoaiLinhKien
GO

CREATE VIEW vw_ThongTinLinhKien AS
SELECT lk.MaLinhKien, lk.TenLinhKien, lk.MoTaChiTiet, lk.GiaBan, lk.GiaNhap, lk.SoLuongTonKho, 
       llk.TenLoaiLinhKien, ncc.TenNhaCungCap, llk.MaLoaiLinhKien, lk.HinhAnh
FROM LinhKien lk
JOIN LoaiLinhKien llk ON lk.MaLoaiLinhKien = llk.MaLoaiLinhKien
JOIN NhaCungCap ncc ON lk.MaNhaCungCap = ncc.MaNhaCungCap;
GO
-- Xóa linh kiện
ALTER PROCEDURE [dbo].[sp_XoaLinhKien]
    @MaLinhKien INT
AS
BEGIN
	UPDATE LinhKien SET SoLuongTonKho = 0 WHERE MaLinhKien = @MaLinhKien;
END;
GO

Create PROCEDURE [dbo].[sp_TimKiemLinhKienTheoID]
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

CREATE PROCEDURE sp_TimLinhKien
    @searchText NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM LinhKien
    WHERE TenLinhKien LIKE '%' + @searchText + '%'
       OR MoTaChiTiet LIKE '%' + @searchText + '%';
END
GO
