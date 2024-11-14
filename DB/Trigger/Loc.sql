
--khi thay doi trong CoLichLam la hoan thành thì tính lại lương
CREATE TRIGGER trg_CapNhatLuong
ON CoLichLam
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @LuongMoi DECIMAL(15,2);
	DECLARE @Ngay DATE;

	SELECT @Ngay = NgayLam
	FROM inserted JOIN LichLamViec ON inserted.MaLichLamViec = LichLamViec.MaLichLamViec

    UPDATE Luong
    SET 
        -- Tính tổng số giờ làm việc dựa trên thời gian của các ca làm việc
        @LuongMoi = (LuongGio * (SELECT SUM(DATEDIFF(MINUTE, clv.GioBatDau, clv.GioKetThuc)) / 60.0
                             FROM CoLichLam cl
                             JOIN LichLamViec llv ON cl.MaLichLamViec = llv.MaLichLamViec
                             JOIN CaLamViec clv ON llv.MaCa = clv.MaCa
                             WHERE cl.MaNhanVien = inserted.MaNhanVien
							 AND cl.TrangThai = 'HoanThanh'
                             AND MONTH(llv.NgayLam) = MONTH(l.ThoiGian)
                             AND YEAR(llv.NgayLam) = YEAR(l.ThoiGian)) ),        
        -- Tính tổng nhận = Lương + Thưởng

        TongNhan = ISNULL(@LuongMoi, 0) + Thuong,
		Luong = ISNULL(@LuongMoi, 0)
    FROM Luong l, inserted
    WHERE l.MaNhanVien = inserted.MaNhanVien
		AND MONTH(l.ThoiGian) = MONTH(@Ngay) AND YEAR(l.ThoiGian) = YEAR(@Ngay);
END;

GO
--khi xoa CoLichLam thi tinh lai luong
CREATE TRIGGER trg_CapNhatLuongKhiXoa
ON CoLichLam
AFTER DELETE
AS
BEGIN
	DECLARE @LuongMoi DECIMAL(15,2);
	DECLARE @Ngay DATE;

	SELECT @Ngay = NgayLam
	FROM deleted JOIN LichLamViec ON deleted.MaLichLamViec = LichLamViec.MaLichLamViec

    UPDATE Luong
    SET 
        -- Tính tổng số giờ làm việc dựa trên thời gian của các ca làm việc
        @LuongMoi = (LuongGio * (SELECT SUM(DATEDIFF(MINUTE, clv.GioBatDau, clv.GioKetThuc)) / 60.0
                             FROM CoLichLam cl
                             JOIN LichLamViec llv ON cl.MaLichLamViec = llv.MaLichLamViec
                             JOIN CaLamViec clv ON llv.MaCa = clv.MaCa
                             WHERE cl.MaNhanVien = deleted.MaNhanVien
							 AND cl.TrangThai = 'HoanThanh'
                             AND MONTH(llv.NgayLam) = MONTH(l.ThoiGian)
                             AND YEAR(llv.NgayLam) = YEAR(l.ThoiGian))),        
        -- Tính tổng nhận = Lương + Thưởng

        TongNhan = ISNULL(@LuongMoi, 0) + Thuong,
		Luong = ISNULL(@LuongMoi, 0)
    FROM Luong l, deleted
    WHERE l.MaNhanVien = deleted.MaNhanVien
		AND MONTH(l.ThoiGian) = MONTH(@Ngay) AND YEAR(l.ThoiGian) = YEAR(@Ngay);
END;

GO
--sau khi inset, update, delete CoLichLam thi tinh lai SoCa trong bang luong
CREATE TRIGGER trg_CapNhatSoCaTrongLuong
ON CoLichLam
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Cập nhật SoCa khi có thao tác INSERT hoặc UPDATE
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        UPDATE l
        SET 
            SoCa = (SELECT COUNT(*)
                    FROM CoLichLam cll
                    JOIN LichLamViec llv ON cll.MaLichLamViec = llv.MaLichLamViec
                    WHERE cll.MaNhanVien = i.MaNhanVien
                    AND cll.TrangThai = 'HoanThanh'
                    AND MONTH(llv.NgayLam) = MONTH(l.ThoiGian)
                    AND YEAR(llv.NgayLam) = YEAR(l.ThoiGian))
        FROM Luong l
        JOIN inserted i ON l.MaNhanVien = i.MaNhanVien;
    END

    -- Cập nhật SoCa khi có thao tác DELETE
    IF EXISTS (SELECT 1 FROM deleted)
    BEGIN
        UPDATE l
        SET 
            SoCa = (SELECT COUNT(*)
                    FROM CoLichLam cll
                    JOIN LichLamViec llv ON cll.MaLichLamViec = llv.MaLichLamViec
                    WHERE cll.MaNhanVien = d.MaNhanVien
                    AND cll.TrangThai = 'HoanThanh'
                    AND MONTH(llv.NgayLam) = MONTH(l.ThoiGian)
                    AND YEAR(llv.NgayLam) = YEAR(l.ThoiGian))
        FROM Luong l
        JOIN deleted d ON l.MaNhanVien = d.MaNhanVien;
    END
END;
GO

CREATE TRIGGER trg_TrungLichLamViec
ON dbo.LichLamViec
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN dbo.LichLamViec llv ON  i.MaLichLamViec <> llv.MaLichLamViec 
                       AND i.NgayLam = llv.NgayLam AND i.MaCa = llv.MaCa 
    )
    BEGIN
        -- Nếu trùng, raise lỗi và rollback
        RAISERROR ('Ca lam trong ngay nay da ton tai!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END
GO

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
GO

CREATE ROLE NhanVienRole;

GO
-- cấp quyền cho role
GRANT SELECT ON NhaCungCap TO NhanVienRole;
GRANT SELECT, INSERT ON KhachHang TO NhanVienRole;
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
GO

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



