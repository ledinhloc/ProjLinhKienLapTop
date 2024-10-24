-- Trigger kiểm tra tồn kho trước khi chèn chi tiết đơn hàng
CREATE TRIGGER trg_KiemTraTonKho
ON ChiTietDonHang
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN LinhKien lk ON i.MaLinhKien = lk.MaLinhKien
        WHERE i.SoLuong > lk.SoLuongTonKho
    )
    BEGIN
        RAISERROR ('Không đủ số lượng tồn kho để đáp ứng đơn hàng.', 16, 1);
    END
    ELSE
    BEGIN
        INSERT INTO ChiTietDonHang (MaDonHang, MaLinhKien, SoLuong, GiaBan)
        SELECT MaDonHang, MaLinhKien, SoLuong, GiaBan
        FROM inserted;
    END
END;
GO
