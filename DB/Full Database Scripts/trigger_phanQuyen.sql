﻿
--trigger tạo tai khoan
--DROP Trigger [trg_TaoLoginKhiThemNV]
CREATE TRIGGER [dbo].[trg_TaoLoginKhiThemNV] ON [dbo].[NhanVien]
AFTER INSERT
AS
BEGIN
	DECLARE @emai nvarchar(100), @matKhau nvarchar(100), @manv int
    DECLARE @sqlString nvarchar(2000);

    SELECT @emai = i.Email, @matKhau = i.MatKhau, @manv = i.MaNhanVien
    FROM inserted i;

	SET @sqlString= 'CREATE LOGIN [' + @emai +'] WITH PASSWORD= '''+ @matKhau
	+''', DEFAULT_DATABASE=[LinhKienLaptop], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF'
	EXEC (@sqlString)
	----
	SET @sqlString = 'CREATE USER [' + @emai + '] FOR LOGIN [' + @emai + ']'
	EXEC (@sqlString)
	SET @sqlString = 'ALTER ROLE NhanVienRole ADD MEMBER [' + @emai + ']';
	EXEC (@sqlString)
END

GO
--procedure  xoa nhan vien
CREATE PROCEDURE [dbo].[proc_XoaLoginNhanVien]
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





