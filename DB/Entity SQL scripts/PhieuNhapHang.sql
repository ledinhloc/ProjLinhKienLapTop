-- Thêm Phiếu Nhập Hàng
GO
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