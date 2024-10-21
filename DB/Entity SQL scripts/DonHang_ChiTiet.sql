-- Don Hang:
--- VIEW
-- Xem Don Hang
CREATE VIEW vw_DonHangList
AS SELECT * 
FROM DonHang
GO

-- Thủ tục thêm một record vào bảng DonHang
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
-- Xóa một record trong bảng DonHang
CREATE PROCEDURE sp_XoaDonHang
    @MaDonHang INT
AS
BEGIN
    DELETE FROM DonHang
    WHERE MaDonHang = @MaDonHang;
END;
GO
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
