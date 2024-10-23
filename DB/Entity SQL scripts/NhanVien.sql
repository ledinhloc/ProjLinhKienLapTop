
--- View show tonaf bộ nhân viên
CREATE VIEW vw_NhanVienList AS
SELECT MaNhanVien, TenNhanVien, SDT, Email, NgaySinh, DiaChi
FROM dbo.NhanVien
GO
---    Stored Procedures  -----
-- Thêm
CREATE PROCEDURE sp_ThemNhanVien
    @TenNhanVien NVARCHAR(100),
    @SDT NVARCHAR(15),
    @Email NVARCHAR(100),
    @NgaySinh DATE,
    @DiaChi NVARCHAR(255),
    @MatKhau NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.NhanVien (TenNhanVien, SDT, Email, NgaySinh, DiaChi, MatKhau, ChucVu)
    VALUES (@TenNhanVien, @SDT, @Email, @NgaySinh, @DiaChi, @MatKhau, 'nv')
END

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
GO