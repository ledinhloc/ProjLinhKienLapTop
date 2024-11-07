-- Don Hang:
--- VIEW
-- Xem Don Hang
CREATE VIEW vw_DonHangList
AS SELECT * 
FROM DonHang
GO

-- Thủ tục thêm một record vào bảng DonHang
-- Tạo đơn hàng
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
        RAISERROR (N'Đã xảy ra lỗi khi thêm đơn hàng.', 16, 1);
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
-- Thêm chi tiết đơn hàng
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
        RAISERROR (N'Đã xảy ra lỗi khi thêm chi tiết đơn hàng.', 16, 1);
    END CATCH
END;
