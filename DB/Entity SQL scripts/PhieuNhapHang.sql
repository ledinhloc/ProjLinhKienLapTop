-- Thêm Phiếu Nhập Hàng
CREATE PROCEDURE sp_ThemPhieuNhapHang
    @NgayNhap DATE,
    @GiaNhap DECIMAL(15, 2),
    @SoLuong INT,
    @MaLinhKien INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        INSERT INTO PhieuNhapHang (NgayNhap, GiaNhap, SoLuong, MaLinhKien)
        VALUES (@NgayNhap, @GiaNhap, @SoLuong, @MaLinhKien);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi thêm phiếu nhập hàng. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Cập nhật phiếu nhập hàng
CREATE PROCEDURE sp_SuaPhieuNhapHang
    @MaPhieuNhap INT,
    @NgayNhap DATE,
    @GiaNhap DECIMAL(15, 2),
    @SoLuong INT,
    @MaLinhKien INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        UPDATE PhieuNhapHang
        SET NgayNhap = @NgayNhap, GiaNhap = @GiaNhap, SoLuong = @SoLuong, MaLinhKien = @MaLinhKien
        WHERE MaPhieuNhap = @MaPhieuNhap;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi cập nhật phiếu nhập hàng. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Xóa phiếu nhập hàng
CREATE PROCEDURE DeletePhieuNhapHang
    @MaPhieuNhap INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        -- Xóa phiếu nhập hàng
        DELETE FROM PhieuNhapHang
        WHERE MaPhieuNhap = @MaPhieuNhap;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi xóa phiếu nhập hàng. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
-- Trigger cập nhật số lượng tồn kho khi có phiếu nhập hàng mới
CREATE TRIGGER trg_AfterInsert_PhieuNhapHang
ON PhieuNhapHang
AFTER INSERT
AS
BEGIN
    UPDATE LinhKien
    SET SoLuongTonKho = LinhKien.SoLuongTonKho + inserted.SoLuong
    FROM LinhKien
    INNER JOIN inserted ON LinhKien.MaLinhKien = inserted.MaLinhKien;
END;
GO

-- Trigger cập nhật giá nhập khi có phiếu nhập hàng mới
CREATE TRIGGER trg_AfterInsert_PhieuNhapHang_UpdatePrice
ON PhieuNhapHang
AFTER INSERT
AS
BEGIN
    UPDATE LinhKien
    SET GiaNhap = inserted.GiaNhap
    FROM LinhKien
    INNER JOIN inserted ON LinhKien.MaLinhKien = inserted.MaLinhKien;
END;
GO

-- Trigger cập nhật số lượng tồn kho khi xóa phiếu nhập hàng
CREATE TRIGGER trg_AfterDelete_PhieuNhapHang_UpdateStock
ON PhieuNhapHang
AFTER DELETE
AS
BEGIN
    UPDATE LinhKien
    SET SoLuongTonKho = LinhKien.SoLuongTonKho - deleted.SoLuong
    FROM LinhKien
    INNER JOIN deleted ON LinhKien.MaLinhKien = deleted.MaLinhKien;
END;
GO
CREATE VIEW vw_DanhSachPhieuNhap AS
SELECT 
    p.MaPhieuNhap,
    p.NgayNhap,
    p.GiaNhap,
    p.SoLuong,
    l.TenLinhKien,
    p.MaLinhKien
FROM 
    PhieuNhapHang p
JOIN 
    LinhKien l ON p.MaLinhKien = l.MaLinhKien;
GO
