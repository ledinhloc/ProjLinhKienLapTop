
-- 1.	View
-- - Xem toàn bộ thông tin linh kiện
GO
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
GO

-- Stored Procedure
-- Thêm linh kiện
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
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO LinhKien (TenLinhKien, MoTaChiTiet, HinhAnh, GiaBan, GiaNhap, SoLuongTonKho, MaLoaiLinhKien, MaNhaCungCap)
        VALUES (@TenLinhKien, @MoTaChiTiet, @HinhAnh, @GiaBan, @GiaNhap, @SoLuongTonKho, @MaLoaiLinhKien, @MaNhaCungCap);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR (N'Đã xảy ra lỗi khi thêm linh kiện.', 16, 1);
    END CATCH
END;
GO

-- Sửa linh kiện
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
    BEGIN TRY
        BEGIN TRANSACTION;

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

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR (N'Đã xảy ra lỗi khi sửa linh kiện.', 16, 1);
    END CATCH
END;
GO

-- Xóa linh kiện
CREATE PROCEDURE sp_XoaLinhKien
    @MaLinhKien INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM LinhKien
        WHERE MaLinhKien = @MaLinhKien;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR (N'Đã xảy ra lỗi khi xóa linh kiện.', 16, 1);
    END CATCH
END;
GO

-- "LOAI LINH KIEN" -------- CHUA TRIEN KHAI
-- Thêm loại linh kiện
CREATE PROCEDURE sp_ThemLoaiLinhKien
    @TenLoaiLinhKien NVARCHAR(255)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO LoaiLinhKien (TenLoaiLinhKien)
        VALUES (@TenLoaiLinhKien);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR (N'Đã xảy ra lỗi khi thêm loại linh kiện.', 16, 1);
    END CATCH
END;

-- Sửa loại linh kiện
CREATE PROCEDURE sp_SuaLoaiLinhKien
    @MaLoaiLinhKien INT,
    @TenLoaiLinhKien NVARCHAR(255)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE LoaiLinhKien
        SET TenLoaiLinhKien = @TenLoaiLinhKien
        WHERE MaLoaiLinhKien = @MaLoaiLinhKien;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR (N'Đã xảy ra lỗi khi sửa loại linh kiện.', 16, 1);
    END CATCH
END;

-- Xóa loại linh kiện
CREATE PROCEDURE sp_XoaLoaiLinhKien
    @MaLoaiLinhKien INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM LoaiLinhKien
        WHERE MaLoaiLinhKien = @MaLoaiLinhKien;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR (N'Đã xảy ra lỗi khi xóa loại linh kiện.', 16, 1);
    END CATCH
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
GO

