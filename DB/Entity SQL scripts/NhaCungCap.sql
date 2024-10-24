--- View
--- XEM lại
CREATE VIEW vw_ThongTinNhaCungCap AS
	SELECT * FROM NhaCungCap
GO
-- STORED PROCEDURE 

-- - Thêm nhà cung cấp
CREATE PROCEDURE sp_ThemNhaCungCap
	@TenNhaCungCap NVARCHAR(255),
	@DiaChi NVARCHAR(255),
	@SDT NVARCHAR(10),
	@Email NVARCHAR(100)
AS
BEGIN
	INSERT INTO NhaCungCap (TenNhaCungCap,DiaChi,SDT,Email)
	VALUES (@TenNhaCungCap,@DiaChi,@SDT,@Email);
END;
GO

-- - Sửa nhà cung cấp
CREATE PROCEDURE sp_SuaNhaCungCap
	@MaNhaCungCap INT,
	@TenNhaCungCap NVARCHAR(255),
	@DiaChi NVARCHAR(255),
	@SDT NVARCHAR(10),
	@Email NVARCHAR(100)
AS
BEGIN
	UPDATE NhaCungCap
	SET TenNhaCungCap = @TenNhaCungCap,
		DiaChi = @DiaChi,
		SDT = @SDT,
		Email = @Email
	WHERE MaNhaCungCap = @MaNhaCungCap;
END;
GO

-- - Xóa nhà cung cấp
CREATE PROCEDURE sp_XoaNhaCungCap
	@MaNhaCungCap INT
AS
BEGIN
	DELETE FROM NhaCungCap WHERE MaNhaCungCap= @MaNhaCungCap;
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
