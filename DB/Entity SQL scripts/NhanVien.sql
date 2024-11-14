
--- View show tonaf bộ nhân viên
CREATE VIEW vw_NhanVienList AS
SELECT MaNhanVien, TenNhanVien, SDT, Email, NgaySinh, DiaChi
FROM dbo.NhanVien
GO
---    Stored Procedures  -----
-- Thêm nhân viên
CREATE PROCEDURE sp_ThemNhanVien
    @TenNhanVien NVARCHAR(100),
    @SDT NVARCHAR(15),
    @Email NVARCHAR(100),
    @NgaySinh DATE,
    @DiaChi NVARCHAR(255),
    @MatKhau NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO dbo.NhanVien (TenNhanVien, SDT, Email, NgaySinh, DiaChi, MatKhau, ChucVu)
        VALUES (@TenNhanVien, @SDT, @Email, @NgaySinh, @DiaChi, @MatKhau, 'nv');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi thêm nhân viên. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Sửa thông tin nhân viên
CREATE PROCEDURE sp_SuaNhanVien
    @MaNhanVien INT,
    @TenNhanVien NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT NVARCHAR(15),
    @Email NVARCHAR(100),
    @MatKhau NVARCHAR(100),
    @NgaySinh DATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE NhanVien
        SET
            TenNhanVien = @TenNhanVien,
            DiaChi = @DiaChi,
            SDT = @SDT,
            Email = @Email,
            MatKhau = @MatKhau,
            NgaySinh = @NgaySinh
        WHERE MaNhanVien = @MaNhanVien;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = N'Đã xảy ra lỗi khi sửa nhân viên. Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-----  Function ----- 
GO
-- Name
    CREATE FUNCTION fn_SearchNhanVienByName (@TenNhanVien NVARCHAR(100))
    RETURNS @NhanVienList TABLE (
        MaNhanVien INT,
        TenNhanVien NVARCHAR(100),
        SDT NVARCHAR(15),
        Email NVARCHAR(100),
        NgaySinh DATE,
        DiaChi NVARCHAR(255)
    )
    AS
    BEGIN
        INSERT INTO @NhanVienList
        SELECT MaNhanVien, TenNhanVien, SDT, Email, NgaySinh, DiaChi
        FROM dbo.NhanVien
        WHERE TenNhanVien LIKE '%' + @TenNhanVien + '%'
    
        RETURN
    END
    GO

    -- Email
    CREATE FUNCTION fn_SearchNhanVienByEmail (@Email NVARCHAR(100))
    RETURNS @NhanVienList TABLE (
        MaNhanVien INT,
        TenNhanVien NVARCHAR(100),
        SDT NVARCHAR(15),
        Email NVARCHAR(100),
        NgaySinh DATE,
        DiaChi NVARCHAR(255)
    )
    AS
    BEGIN
        INSERT INTO @NhanVienList
        SELECT MaNhanVien, TenNhanVien, SDT, Email, NgaySinh, DiaChi
        FROM dbo.NhanVien
        WHERE Email LIKE '%' + @Email + '%'
    
        RETURN
    END
GO

CREATE FUNCTION fn_TimNhanVien
(
    @MaNhanVien INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM 
        NhanVien
    WHERE 
        MaNhanVien = @MaNhanVien
);
GO
--procedure  xoa nhan vien
CREATE PROCEDURE [dbo].[proc_XoaNhanVien]
 @MaNV nvarchar(100)
AS
BEGIN
	DECLARE @email varchar(15);
	SELECT @email= Email FROM NhanVien WHERE MaNhanVien=@maNV
	DECLARE @sql varchar(100)
	
	 BEGIN TRANSACTION;
	 BEGIN TRY
		SET @sql = 'DROP USER ['+ @email +']'
		exec (@sql)
		--
		SET @sql = 'DROP LOGIN ['+ @email +']'
		exec (@sql)
	DELETE FROM NhanVien WHERE MaNhanVien=@maNV;
	END TRY
	BEGIN CATCH
		DECLARE @err NVARCHAR(MAX)
		SELECT @err = N'Lỗi khi xoa ' + ERROR_MESSAGE()
		RAISERROR(@err, 16, 1)
		ROLLBACK TRANSACTION;
		
	END CATCH
	 COMMIT TRANSACTION;
END
GO

----  TEST
---- View
--SELECT * FROM vw_NhanVienList;
---- Add
--EXEC sp_AddNhanVien 
--    @TenNhanVien = N'Nguyễn Văn A',
--    @SDT = '0912345678',
--    @Email = 'nguyenvana@example.com',
--    @NgaySinh = '1990-01-15',
--    @DiaChi = N'Số 123, Đường ABC, Quận 1',
--    @MatKhau = N'matkhau1';
---- Update
--EXEC sp_UpdateNhanVien 
--    @MaNhanVien = 1,
--    @TenNhanVien = N'Trần Thị B',
--    @SDT = '0987654321',
--    @Email = 'tranthib@example.com',
--    @NgaySinh = '1992-02-20',
--    @DiaChi = N'Số 456, Đường DEF, Quận 2';
----- Funtion
--USE Linhkiendientu;
--SELECT dbo.fn_GetTotalEmployees() AS TotalEmployees;
--SELECT * FROM dbo.fn_SearchNhanVienByName(N'Nguyễn');
--SELECT * FROM dbo.fn_FilterNhanVienByDateRange('1990-01-01', '2000-12-31');
--SELECT * FROM dbo.fn_SearchNhanVienByEmail(N'tranthi');

--SELECT *
--FROM sys.objects
--WHERE name = 'fn_GetTotalEmployees' AND type = 'FN';