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

Table LoaiLinhKien:
1.1. Thủ tục thêm một record vào bảng LoaiLinhKien
CREATE PROCEDURE sp_ThemLoaiLinhKien
    @MaLoaiLinhKien INT,
    @TenLoaiLinhKien NVARCHAR(255)
AS
BEGIN
    INSERT INTO LoaiLinhKien (MaLoaiLinhKien, TenLoaiLinhKien)
    VALUES (@MaLoaiLinhKien, @TenLoaiLinhKien);
END;

1.2. Thủ tục chỉnh sửa một record trong bảng LoaiLinhKien
CREATE PROCEDURE sp_SuaLoaiLinhKien
    @MaLoaiLinhKien INT,
    @TenLoaiLinhKien NVARCHAR(255)
AS
BEGIN
    UPDATE LoaiLinhKien
    SET TenLoaiLinhKien = @TenLoaiLinhKien
    WHERE MaLoaiLinhKien = @MaLoaiLinhKien;
END;

1.3.  Thủ tục xóa một record trong bảng LoaiLinhKien
CREATE PROCEDURE sp_XoaLoaiLinhKien
    @MaLoaiLinhKien INT
AS
BEGIN
    DELETE FROM LoaiLinhKien
    WHERE MaLoaiLinhKien = @MaLoaiLinhKien;
END;


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

1.2. Thủ tục xóa một record trong bảng DonHang
CREATE PROCEDURE sp_XoaDonHang
    @MaDonHang INT
AS
BEGIN
    DELETE FROM DonHang
    WHERE MaDonHang = @MaDonHang;
END;

1.3. Thủ tục cập nhập một record trong bảng DonHang
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

1. Functions
Table LoaiLinhKien:
1.1. Hàm sẽ nhận MaLoaiLinhKien và trả về tên loại linh kiện. 
CREATE FUNCTION dbo.GetTenLoaiLinhKien (@MaLoaiLinhKien INT)
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @TenLoaiLinhKien NVARCHAR(255);
    
    SELECT @TenLoaiLinhKien = TenLoaiLinhKien
    FROM LoaiLinhKien
    WHERE MaLoaiLinhKien = @MaLoaiLinhKien;
    
    RETURN @TenLoaiLinhKien;
END;

Table DonHang:
1.1. Hàm sẽ nhận MaDonHang và trả về thông tin của đơn hàng.
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

Table PhieuNhapHang:
1.1. Hàm sẽ nhận MaPhieuNhap và trả về thông tin của phiếu nhập hàng.
CREATE FUNCTION dbo.GetPhieuNhapHangDetails (@MaPhieuNhap INT)
RETURNS TABLE
AS
RETURN (
    SELECT 
        MaPhieuNhap,
        NgayNhap,
        GiaNhap,
        SoLuong,
        MaLinhKien
    FROM PhieuNhapHang
    WHERE MaPhieuNhap = @MaPhieuNhap
);

Trigger ChiTietDonHang thì trừ số lượng trong LinhKien
CREATE TRIGGER trg_UpdateSoLuongTonKho
ON ChiTietDonHang
AFTER INSERT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        UPDATE LinhKien
        SET SoLuongTonKho = SoLuongTonKho - inserted.SoLuong
        FROM LinhKien
        INNER JOIN inserted ON LinhKien.MaLinhKien = inserted.MaLinhKien;

        IF EXISTS (
            SELECT 1
            FROM LinhKien
            WHERE SoLuongTonKho < 0
        )
        BEGIN
            ROLLBACK TRANSACTION;
            THROW 50000, 'Số lượng tồn kho không đủ!', 1;
        END
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END;


