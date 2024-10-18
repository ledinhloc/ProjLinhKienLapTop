
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
	INSERT INTO KhachHang (TenKhachHang, DiaChi, SDT, Email, NgaySinh)
	VALUES (@TenKhachHang, @DiaChi, @SDT, @Email, @NgaySinh);
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
    UPDATE KhachHang
    SET TenKhachHang = @TenKhachHang,
        DiaChi = @DiaChi,
        SDT = @SDT,
        Email = @Email,
        NgaySinh = @NgaySinh
    WHERE MaKhachHang = @MaKhachHang;
END;
GO


-- Xóa khách hàng
CREATE PROCEDURE sp_XoaKhachHang
    @MaKhachHang INT
AS
BEGIN
    DELETE FROM KhachHang
    WHERE MaKhachHang = @MaKhachHang;
END;
GO