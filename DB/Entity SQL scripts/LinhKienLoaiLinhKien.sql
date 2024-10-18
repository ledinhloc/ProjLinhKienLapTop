
-- 1.	View
-- - Xem toàn bộ thông tin linh kiện
CREATE VIEW vw_ThongTinLinhKien AS
SELECT lk.MaLinhKien, lk.TenLinhKien, lk.MoTaChiTiet, lk.GiaBan, lk.GiaNhap, lk.SoLuongTonKho, 
       llk.TenLoaiLinhKien, ncc.TenNhaCungCap
FROM LinhKien lk
JOIN LoaiLinhKien llk ON lk.MaLoaiLinhKien = llk.MaLoaiLinhKien
JOIN NhaCungCap ncc ON lk.MaNhaCungCap = ncc.MaNhaCungCap;

-- Xem linh kiện sắp hết hàng
-- SELECT lk.MaLinhKien, lk.TenLinhKien, lk.MoTaChiTiet, lk.GiaBan, lk.GiaNhap, lk.SoLuongTonKho, 
-- 		llk.TenLoaiLinhKien, ncc.TenNhaCungCap
-- FROM LinhKien lk
-- JOIN LoaiLinhKien llk ON lk.MaLoaiLinhKien = llk.MaLoaiLinhKien
-- JOIN NhaCungCap ncc ON lk.MaNhaCungCap = ncc.MaNhaCungCap
-- WHERE lk.SoLuongTonKho < 10;

-- Xem thông tin loại linh kiện
CREATE VIEW vw_ThongTinLoaiLinhKien AS
	SELECT * FROM LoaiLinhKien

-- Xem thông tin nhà cung cấp
CREATE VIEW vw_ThongTinNhaCungCap AS
	SELECT * FROM NhaCungCap

-- Stored Procedure
-- - Thêm linh kiện
CREATE PROCEDURE sp_ThemLinhKien
    @TenLinhKien NVARCHAR(255),
    @MoTaChiTiet NVARCHAR(1000),
    @HinhAnh NVARCHAR(255),
    @GiaBan DECIMAL(15, 2),
    @GiaNhap DECIMAL(15, 2),
    @SoLuongTonKho INT,
    @MaLoaiLinhKien INT,
    @MaNhaCungCap INT
AS
BEGIN
    INSERT INTO LinhKien (TenLinhKien, MoTaChiTiet, HinhAnh, GiaBan, GiaNhap, SoLuongTonKho, MaLoaiLinhKien, MaNhaCungCap)
    VALUES (@TenLinhKien, @MoTaChiTiet, @HinhAnh, @GiaBan, @GiaNhap, @SoLuongTonKho, @MaLoaiLinhKien, @MaNhaCungCap);
END;

-- - Sửa linh kiện
CREATE PROCEDURE sp_SuaLinhKien
	@MaLinhKien INT,
	@TenLinhKien NVARCHAR(255),
    @MoTaChiTiet NVARCHAR(1000),
    @HinhAnh NVARCHAR(255),
    @GiaBan DECIMAL(15, 2),
    @GiaNhap DECIMAL(15, 2),
    @SoLuongTonKho INT,
	@MaLoaiLinhKien INT,
    @MaNhaCungCap INT
AS
BEGIN
	UPDATE LinhKien
	SET TenLinhKien = @TenLinhKien,
		MoTaChiTiet = @MoTaChiTiet,
		HinhAnh = @HinhAnh,
		GiaBan = @GiaBan,
		GiaNhap = @GiaNhap,
		SoLuongTonKho = @SoLuongTonKho,
		MaLoaiLinhKien = @MaLoaiLinhKien,
		MaNhaCungCap = @MaNhaCungCap
	WHERE MaLinhKien = @MaLinhKien;
END;

-- - Xóa Linh kiện
CREATE PROCEDURE sp_XoaLinhKien
	@MaLinhKien INT
AS
BEGIN
    DELETE FROM LinhKien WHERE MaLinhKien = @MaLinhKien;
END;


-- "LOAI LINH KIEN"


-- Thêm loại linh kiện
CREATE PROCEDURE sp_ThemLoaiLinhKien
	@TenLoaiLinhKien NVARCHAR(255)
AS
BEGIN
	INSERT INTO LoaiLinhKien (TenLoaiLinhKien)
	VALUES (@TenLoaiLinhKien)
END;

-- Sửa loại linh kiện
CREATE PROCEDURE sp_SuaLoaiLinhKien
	@MaLoaiLinhKien INT,
	@TenLoaiLinhKien NVARCHAR(255)
AS
BEGIN
	UPDATE LoaiLinhKien
	SET TenLoaiLinhKien = @TenLoaiLinhKien
	WHERE MaLoaiLinhKien = @MaLoaiLinhKien
END;

-- - Xóa loại linh kiện
CREATE PROCEDURE sp_XoaLoaiLinhKien
	@MaLoaiLinhKien INT
AS
BEGIN
	DELETE FROM LoaiLinhKien WHERE MaLoaiLinhKien= @MaLoaiLinhKien;
END;

-- Tìm kiếm
CREATE PROCEDURE sp_TimKiemLinhKienTheoTuKhoa
    @TuKhoa NVARCHAR(255)
AS
BEGIN
    SELECT *
    FROM vw_ThongTinLinhKien lk
    WHERE lk.TenLinhKien LIKE '%' + @TuKhoa + '%'
       OR lk.MoTaChiTiet LIKE '%' + @TuKhoa + '%';
END;

-- - Tìm kiếm linh kiện theo giá
CREATE PROCEDURE sp_TimKiemLinhKienTheoGia
    @GiaMin DECIMAL(15, 2),
    @GiaMax DECIMAL(15, 2)
AS
BEGIN
    SELECT *
    FROM vw_ThongTinLinhKien
    WHERE GiaBan BETWEEN @GiaMin AND @GiaMax;
END;

EXEC sp_TimKiemLinhKienTheoGia @GiaMin = 0, @GiaMax = 10000000;
