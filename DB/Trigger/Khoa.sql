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

--  Cập nhật số lượng tồn kho khi thêm vào ChiTietDonHang 
CREATE TRIGGER trg_UpdateSoLuongTonKho
ON ChiTietDonHang
AFTER INSERT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Cập nhật số lượng tồn kho sau khi chèn chi tiết đơn hàng
        UPDATE LinhKien
        SET SoLuongTonKho = SoLuongTonKho - inserted.SoLuong
        FROM LinhKien
        INNER JOIN inserted ON LinhKien.MaLinhKien = inserted.MaLinhKien;

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

GO
