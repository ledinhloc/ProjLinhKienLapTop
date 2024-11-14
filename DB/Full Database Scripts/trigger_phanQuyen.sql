
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


--cap nhat login khi sua nhan vien
CREATE TRIGGER [dbo].[trg_SuaLogin] ON [dbo].[NhanVien]
AFTER UPDATE
AS
BEGIN
	DECLARE @emailMoi nvarchar(150);
	DECLARE @matKhauMoi nvarchar(150);
	DECLARE @emailCu nvarchar(150);
	DeCLARE @matKhauCu nvarchar(100);

	SELECT @emailMoi = i.Email, @matKhauMoi = i.MatKhau



	FROM inserted i 

	SELECT @emailCu = d.Email, @matKhauCu= d.MatKhau
	FROM deleted d

	-- Kiểm tra nếu email và mật khẩu nếu thay đổi
    IF (@emailMoi != @emailCu OR @matKhauMoi != @matKhauCu)
    BEGIN
        EXEC('ALTER LOGIN [' + @emailCu + '] WITH NAME = [' + @emailMoi + ']');
		EXEC('ALTER LOGIN [' + @emailMoi + '] WITH PASSWORD = ''' + @matKhauMoi + '''');
		EXEC('ALTER USER [' + @emailCu + '] WITH NAME = [' + @emailMoi + ']');
    END	
END





