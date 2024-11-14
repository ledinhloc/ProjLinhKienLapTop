USE LinhkienLaptop
GO

CREATE TRIGGER trg_BeforeDelete_LoaiLinhKien_CheckUsage
ON LoaiLinhKien
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM LinhKien 
        WHERE MaLoaiLinhKien IN (SELECT MaLoaiLinhKien FROM deleted)
    )
    BEGIN
        RAISERROR('Không thể xóa loại linh kiện vì đã có linh kiện liên quan.', 16, 1);
        ROLLBACK TRANSACTION; 
    END
    ELSE
    BEGIN
        DELETE FROM LoaiLinhKien
        WHERE MaLoaiLinhKien IN (SELECT MaLoaiLinhKien FROM deleted);
    END
END;
GO

CREATE TRIGGER trg_BeforeDelete_NhaCungCap_CheckUsage
ON NhaCungCap
INSTEAD OF DELETE
AS 
BEGIN
	IF EXISTS (
        SELECT 1 
        FROM LinhKien 
        WHERE MaNhaCungCap IN (SELECT MaNhaCungCap FROM deleted)
    )
    BEGIN
        RAISERROR('Không thể xóa nhà cung cấp vì đã có linh kiện liên quan.', 16, 1);
        ROLLBACK TRANSACTION; 
    END
    ELSE
    BEGIN
        DELETE FROM NhaCungCap
        WHERE MaNhaCungCap IN (SELECT MaNhaCungCap FROM deleted);
    END
END;

GO

CREATE TRIGGER [dbo].[trg_after_delete_linh_kien]
ON [dbo].[LinhKien]
AFTER DELETE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF EXISTS (
            SELECT 1 
            FROM deleted d
            JOIN dbo.ChiTietDonHang o ON d.MaLinhKien = o.MaLinhKien
        )
        BEGIN
            THROW 50001, 'E', 1;
        END
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR('Không thể xóa linh kiện vì đã tồn tại trong đơn hàng', 16, 1);
    END CATCH;
END;

