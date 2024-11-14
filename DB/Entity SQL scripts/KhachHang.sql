--- VIEW
CREATE VIEW vw_KhachHangList AS
SELECT *
FROM dbo.KhachHang
GO


-- Stored Procedure ----------------------------------------------------
-- Thêm khách hàng:
CREATE PROCEDURE sp_ThemKhachHang
    @TenKhachHang NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT NVARCHAR(10),
    @Email NVARCHAR(100),
    @NgaySinh DATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO KhachHang (TenKhachHang, DiaChi, SDT, Email, NgaySinh)
        VALUES (@TenKhachHang, @DiaChi, @SDT, @Email, @NgaySinh);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi thêm khách hàng. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
-- Sửa khách hàng
CREATE PROCEDURE sp_SuaKhachHang
    @MaKhachHang INT,
    @TenKhachHang NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT NVARCHAR(10),
    @Email NVARCHAR(100),
    @NgaySinh DATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE KhachHang
        SET TenKhachHang = @TenKhachHang,
            DiaChi = @DiaChi,
            SDT = @SDT,
            Email = @Email,
            NgaySinh = @NgaySinh
        WHERE MaKhachHang = @MaKhachHang;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi sửa khách hàng. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO


-- Xóa khách hàng
CREATE PROCEDURE sp_XoaKhachHang
    @MaKhachHang INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM KhachHang
        WHERE MaKhachHang = @MaKhachHang;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi xóa khách hàng. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;


GO
---- STORED PROCEDURE
CREATE PROCEDURE sp_TimKiemKhachHang
    @SearchOption NVARCHAR(50), 
    @SearchText NVARCHAR(255) 
AS
BEGIN
    SET NOCOUNT ON;
    IF @SearchOption = 'MaKhachHang'
    BEGIN
        SELECT * FROM KhachHang
        WHERE MaKhachHang = TRY_CAST(@SearchText AS INT);
    END
    ELSE IF @SearchOption = 'TenKhachHang'
    BEGIN
        SELECT * FROM KhachHang
        WHERE TenKhachHang LIKE '%' + @SearchText + '%';
    END
    ELSE IF @SearchOption = 'DiaChi'
    BEGIN
        SELECT * FROM KhachHang
        WHERE DiaChi LIKE '%' + @SearchText + '%';
    END
    ELSE IF @SearchOption = 'SDT'
    BEGIN
        SELECT * FROM KhachHang
        WHERE SDT LIKE '%' + @SearchText + '%';
    END
    ELSE IF @SearchOption = 'Email'
    BEGIN
        SELECT * FROM KhachHang
        WHERE Email LIKE '%' + @SearchText + '%';
    END
END;

GO
------ FUNCTION
-- Tính tổng số khách hàng
CREATE FUNCTION fn_TinhTongKhachHang()
RETURNS INT
AS
BEGIN
    DECLARE @TongKhachHang INT;
    SELECT @TongKhachHang = COUNT(*)
    FROM KhachHang;

    RETURN @TongKhachHang;
END;
GO
