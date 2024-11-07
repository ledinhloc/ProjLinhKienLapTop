--- View
--- XEM lại
CREATE VIEW vw_ThongTinNhaCungCap AS
	SELECT * FROM NhaCungCap
GO
-- STORED PROCEDURE 
-- Thêm nhà cung cấp
CREATE PROCEDURE sp_ThemNhaCungCap
    @TenNhaCungCap NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT NVARCHAR(10),
    @Email NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, SDT, Email)
        VALUES (@TenNhaCungCap, @DiaChi, @SDT, @Email);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR (N'Đã xảy ra lỗi khi thêm nhà cung cấp.', 16, 1);
    END CATCH
END;
GO

-- Sửa nhà cung cấp
CREATE PROCEDURE sp_SuaNhaCungCap
    @MaNhaCungCap INT,
    @TenNhaCungCap NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT NVARCHAR(10),
    @Email NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE NhaCungCap
        SET TenNhaCungCap = @TenNhaCungCap,
            DiaChi = @DiaChi,
            SDT = @SDT,
            Email = @Email
        WHERE MaNhaCungCap = @MaNhaCungCap;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR (N'Đã xảy ra lỗi khi sửa nhà cung cấp.', 16, 1);
    END CATCH
END;
GO

-- Xóa nhà cung cấp
CREATE PROCEDURE sp_XoaNhaCungCap
    @MaNhaCungCap INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM NhaCungCap
        WHERE MaNhaCungCap = @MaNhaCungCap;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR (N'Đã xảy ra lỗi khi xóa nhà cung cấp.', 16, 1);
    END CATCH
END;
GO

CREATE PROCEDURE sp_TimKiemNCCTheoID
    @MaNCC INT
AS
BEGIN
    SELECT * FROM dbo.NhaCungCap
    WHERE MaNhaCungCap = @MaNCC;
END;
GO
