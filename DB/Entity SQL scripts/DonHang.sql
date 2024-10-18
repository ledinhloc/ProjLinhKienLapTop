-- Don Hang:
-- Thủ tục thêm một record vào bảng DonHang
CREATE PROCEDURE sp_ThemDonHang
    @MaDonHang INT,
    @NgayDatHang DATE,
    @MaKhachHang INT,
    @MaNhanVien INT,
    @MaGiamGia INT,
    @TongGiaTri DECIMAL(15, 2),
    @PhuongThuc NVARCHAR(100)
AS
BEGIN
    INSERT INTO DonHang (MaDonHang, NgayDatHang, MaKhachHang, MaNhanVien, MaGiamGia, TongGiaTri, PhuongThuc)
    VALUES (@MaDonHang, @NgayDatHang, @MaKhachHang, @MaNhanVien, @MaGiamGia, @TongGiaTri, @PhuongThuc);
END;

-- Xóa một record trong bảng DonHang
CREATE PROCEDURE sp_XoaDonHang
    @MaDonHang INT
AS
BEGIN
    DELETE FROM DonHang
    WHERE MaDonHang = @MaDonHang;
END;

-- Sửa một record trong bảng DonHang
CREATE PROCEDURE sp_SuaDonHang
    @MaDonHang INT,
    @NgayDatHang DATE,
    @MaKhachHang INT,
    @MaNhanVien INT,
    @MaGiamGia INT,
    @TongGiaTri DECIMAL(15, 2),
    @PhuongThuc NVARCHAR(100)
AS
BEGIN
    UPDATE DonHang
    SET NgayDatHang = @NgayDatHang,
        MaKhachHang = @MaKhachHang,
        MaNhanVien = @MaNhanVien,
        MaGiamGia = @MaGiamGia,
        TongGiaTri = @TongGiaTri,
        PhuongThuc = @PhuongThuc
    WHERE MaDonHang = @MaDonHang;
END;

-- FUNCTION
CREATE FUNCTION dbo.GetDonHangDetails (@MaDonHang INT)
RETURNS TABLE
AS
RETURN (
    SELECT 
        MaDonHang,
        NgayDatHang,
        MaKhachHang,
        MaNhanVien,
        MaGiamGia,
        TongGiaTri,
        PhuongThuc
    FROM DonHang
    WHERE MaDonHang = @MaDonHang
);