CREATE ROLE NhanVienRole;

GO
-- cấp quyền cho role
GRANT SELECT ON NhaCungCap TO NhanVienRole;
GRANT SELECT, UPDATE ON KhachHang TO NhanVienRole;
GRANT SELECT ON NhanVien TO NhanVienRole;
GRANT SELECT ON LoaiLinhKien TO NhanVienRole;
GRANT SELECT ON LinhKien TO NhanVienRole;--aa
GRANT SELECT ON PhieuNhapHang TO NhanVienRole;
GRANT SELECT ON GiamGia TO NhanVienRole;
GRANT SELECT, INSERT ON DonHang TO NhanVienRole;
GRANT SELECT, INSERT ON ChiTietDonHang TO NhanVienRole;--aa
GRANT SELECT ON CaLamViec TO NhanVienRole;
GRANT SELECT ON Luong TO NhanVienRole;
GRANT SELECT ON LichLamViec TO NhanVienRole;
GRANT SELECT ON CoLichLam TO NhanVienRole;
GO

GRANT EXECUTE TO NhanVienRole
GRANT SELECT TO NhanVienRole

GO
--cam cac quyen 
DENY EXECUTE ON sp_SuaKhachHang to NhanVienRole;
DENY EXECUTE ON sp_XoaKhachHang to NhanVienRole;

DENY EXECUTE ON sp_SuaCaLamViec to NhanVienRole;
DENY EXECUTE ON sp_XoaCaLamViec to NhanVienRole;
DENY EXECUTE ON sp_ThemLuong to NhanVienRole;

DENY EXECUTE ON sp_ThemLichLamViec to NhanVienRole;
DENY EXECUTE ON sp_ThemCoLichLam to NhanVienRole;
DENY EXECUTE ON sp_SuaCoLichLam to NhanVienRole;
DENY EXECUTE ON sp_XoaCoLichLam to NhanVienRole;

DENY EXECUTE ON sp_ThemLinhKien to NhanVienRole;
DENY EXECUTE ON sp_SuaLinhKien to NhanVienRole;
DENY EXECUTE ON sp_XoaLinhKien to NhanVienRole;
DENY EXECUTE ON sp_ThemLoaiLinhKien to NhanVienRole;

DENY EXECUTE ON sp_ThemLoaiLinhKien to NhanVienRole;
DENY EXECUTE ON sp_SuaLoaiLinhKien to NhanVienRole;
DENY EXECUTE ON sp_XoaLoaiLinhKien to NhanVienRole;

DENY EXECUTE ON sp_ThemGiamGia to NhanVienRole;
DENY EXECUTE ON sp_XoaGiamGia to NhanVienRole;

DENY EXECUTE ON sp_SuaNhaCungCap to NhanVienRole;
DENY EXECUTE ON sp_XoaNhaCungCap to NhanVienRole;

DENY EXECUTE ON sp_ThemNhanVien to NhanVienRole;
DENY EXECUTE ON sp_SuaNhanVien to NhanVienRole;

DENY EXECUTE ON sp_ThemPhieuNhapHang to NhanVienRole;
DENY EXECUTE ON sp_SuaPhieuNhapHang to NhanVienRole;
DENY EXECUTE ON DeletePhieuNhapHang to NhanVienRole;


 --Tạo Login và User cho nhân viên
CREATE LOGIN [nguyenvantam@company.com]
    WITH PASSWORD = 'matkhau1',
    CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
    DEFAULT_DATABASE = LinhKienLapTop;
GO
CREATE USER [nguyenvantam@company.com] FOR LOGIN [nguyenvantam@company.com];
GO
EXEC sp_addsrvrolemember 'nguyenvantam@company.com', 'sysadmin';
GO

GO
CREATE LOGIN [tranthilan@company.com]
    WITH PASSWORD = 'matkhau2',
    CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
    DEFAULT_DATABASE = LinhKienLapTop;
GO
CREATE USER [tranthilan@company.com] FOR LOGIN [tranthilan@company.com];
GO

EXEC sp_addrolemember 'NhanVienRole', 'tranthilan@company.com';
Go
CREATE LOGIN [levanhoa@company.com]
    WITH PASSWORD = 'matkhau3',
    CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
    DEFAULT_DATABASE = LinhKienLapTop;
GO
CREATE USER [levanhoa@company.com] FOR LOGIN [levanhoa@company.com];
GO
EXEC sp_addrolemember 'NhanVienRole', 'levanhoa@company.com';
GO

CREATE LOGIN [phamthibinh@company.com]
    WITH PASSWORD = 'matkhau4',
    CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
    DEFAULT_DATABASE = LinhKienLapTop;
GO
CREATE USER [phamthibinh@company.com] FOR LOGIN [phamthibinh@company.com];
GO
EXEC sp_addrolemember 'NhanVienRole', 'phamthibinh@company.com';
GO

CREATE LOGIN [hoangvanphuc@company.com]
    WITH PASSWORD = 'matkhau5',
    CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
    DEFAULT_DATABASE = LinhKienLapTop;
GO
CREATE USER [hoangvanphuc@company.com] FOR LOGIN [hoangvanphuc@company.com];
GO
EXEC sp_addrolemember 'NhanVienRole', 'hoangvanphuc@company.com';
GO

CREATE LOGIN [vuthinga@company.com]
    WITH PASSWORD = 'matkhau6',
    CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
    DEFAULT_DATABASE = LinhKienLapTop;
GO
CREATE USER [vuthinga@company.com] FOR LOGIN [vuthinga@company.com];
GO
EXEC sp_addrolemember 'NhanVienRole', 'vuthinga@company.com';
GO

CREATE LOGIN [nguyenvanquoc@company.com]
    WITH PASSWORD = 'matkhau7',
    CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
    DEFAULT_DATABASE = LinhKienLapTop;
GO
CREATE USER [nguyenvanquoc@company.com] FOR LOGIN [nguyenvanquoc@company.com];
GO
EXEC sp_addrolemember 'NhanVienRole', 'nguyenvanquoc@company.com';
GO

CREATE LOGIN [tranthimai@company.com]
    WITH PASSWORD = 'matkhau8',
    CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
    DEFAULT_DATABASE = LinhKienLapTop;
GO
CREATE USER [tranthimai@company.com] FOR LOGIN [tranthimai@company.com];
GO
EXEC sp_addrolemember 'NhanVienRole', 'tranthimai@company.com';
GO

CREATE LOGIN [levandung@company.com]
    WITH PASSWORD = 'matkhau9',
    CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
    DEFAULT_DATABASE = LinhKienLapTop;
GO
CREATE USER [levandung@company.com] FOR LOGIN [levandung@company.com];
GO
EXEC sp_addrolemember 'NhanVienRole', 'levandung@company.com';
GO

CREATE LOGIN [phamthithu@company.com]
    WITH PASSWORD = 'matkhau10',
    CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF,
    DEFAULT_DATABASE = LinhKienLapTop;
GO
CREATE USER [phamthithu@company.com] FOR LOGIN [phamthithu@company.com];
GO
EXEC sp_addrolemember 'NhanVienRole', 'phamthithu@company.com';
GO
