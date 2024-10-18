----- Kiểm tra ton kho truoc khi insert
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

--- TEST trg_KiemTraTonKho
INSERT INTO ChiTietDonHang (MaDonHang, MaLinhKien, SoLuong, GiaBan)
VALUES (3, 2, 10, 100000.00);  
INSERT INTO ChiTietDonHang (MaDonHang, MaLinhKien, SoLuong, GiaBan)
VALUES (3, 2, 1, 100000.00);  
GO

--------------     Thong bao sap het hang ----------
CREATE TRIGGER trg_ThongBaoTonKho
ON LinhKien
AFTER UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE SoLuongTonKho < 10
    )
    BEGIN
        DECLARE @Message NVARCHAR(MAX) = '';
        SELECT @Message = STRING_AGG('Canh bao: Sap het linh kien ' + CAST(MaLinhKien AS NVARCHAR(10)), '; ')
        FROM inserted
        WHERE SoLuongTonKho < 10;

        PRINT @Message;
    END
END;

-- TEST trigger canh bao het hang
UPDATE LinhKien
SET SoLuongTonKho = 8
WHERE MaLinhKien = 2;

