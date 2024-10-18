GO
USE LinhkienLaptop; 
GO

-- View--------------------------------------------------
-- Xem toàn bộ thông tin linh kiện:
CREATE VIEW vw_ThongTinLinhKien AS
SELECT lk.MaLinhKien, lk.TenLinhKien, lk.MoTaChiTiet, lk.GiaBan, lk.GiaNhap, lk.SoLuongTonKho, 
       llk.TenLoaiLinhKien, ncc.TenNhaCungCap, llk.MaLoaiLinhKien
FROM LinhKien lk
JOIN LoaiLinhKien llk ON lk.MaLoaiLinhKien = llk.MaLoaiLinhKien
JOIN NhaCungCap ncc ON lk.MaNhaCungCap = ncc.MaNhaCungCap;
GO

-- Xem toàn bộ linh kiện sắp hết hàng
CREATE VIEW vw_LinhKienSapHetHang AS
SELECT lk.MaLinhKien, lk.TenLinhKien, lk.MoTaChiTiet, lk.GiaBan, lk.GiaNhap, lk.SoLuongTonKho, 
       llk.TenLoaiLinhKien, ncc.TenNhaCungCap
FROM LinhKien lk
JOIN LoaiLinhKien llk ON lk.MaLoaiLinhKien = llk.MaLoaiLinhKien
JOIN NhaCungCap ncc ON lk.MaNhaCungCap = ncc.MaNhaCungCap
WHERE lk.SoLuongTonKho < 10;
GO

-- Xem thông tin loại linh kiện
CREATE VIEW vw_ThongTinLoaiLinhKien AS
	SELECT * FROM LoaiLinhKien;
GO

-- Xem thông tin nhà cung cấp
CREATE VIEW vw_ThongTinNhaCungCap AS
	SELECT * FROM NhaCungCap;
GO

-- Xem lương chi tiết
CREATE VIEW vw_LuongChiTiet AS
SELECT nv.MaNhanVien, nv.TenNhanVien, l.ThoiGian, l.Luong, l.Thuong, l.TongNhan
FROM NhanVien nv
JOIN Luong l ON nv.MaNhanVien = l.MaNhanVien;
GO

-- Xem ca làm việc của nhân viên
CREATE VIEW vw_CaLamViecNhanVien AS
SELECT nv.MaNhanVien, nv.TenNhanVien, llv.NgayLam, clv.TenCa, clv.GioBatDau, clv.GioKetThuc
FROM NhanVien nv
JOIN CoLichLam cl ON nv.MaNhanVien = cl.MaNhanVien
JOIN LichLamViec llv ON cl.MaLichLamViec = llv.MaLichLamViec
JOIN CaLamViec clv ON llv.MaCa = clv.MaCa
WHERE cl.TrangThai = 'HoanThanh';
GO

-- Xem ca làm việc
CREATE VIEW vw_XemCaLam AS
SELECT * FROM CaLamViec;
GO

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

-- Thêm đơn hàng
CREATE PROCEDURE sp_ThemDonHang
    @MaDonHang INT,
    @NgayDatHang DATE,
    @MaKhachHang INT,
    @MaNhanVien INT,
    @MaGiamGia INT,
    @TongGiaTri DECIMAL(15, 2),
    @PhuongThuc NVARCHAR(100)
AS
BEGIN
    INSERT INTO DonHang (MaDonHang, NgayDatHang, MaKhachHang, MaNhanVien, MaGiamGia, TongGiaTri, PhuongThuc)
    VALUES (@MaDonHang, @NgayDatHang, @MaKhachHang, @MaNhanVien, @MaGiamGia, @TongGiaTri, @PhuongThuc);
END;
GO

-- Thêm phiếu nhập hàng
CREATE PROCEDURE InsertPhieuNhapHang
    @NgayNhap DATE,
    @GiaNhap DECIMAL(15, 2),
    @SoLuong INT,
    @MaLinhKien INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM LinhKien WHERE MaLinhKien = @MaLinhKien)
    BEGIN
        RAISERROR('LinhKien ID does not exist.', 16, 1);
        RETURN;
    END
    
    INSERT INTO PhieuNhapHang (NgayNhap, GiaNhap, SoLuong, MaLinhKien)
    VALUES (@NgayNhap, @GiaNhap, @SoLuong, @MaLinhKien);
       
    PRINT 'PhieuNhapHang inserted and stock updated successfully.';
END;
GO

-- Thêm lương
CREATE PROCEDURE sp_ThemLuong
    @MaLuong INT,
    @Luong DECIMAL(15, 2),
    @Thuong DECIMAL(15, 2),
    @ThoiGian DATE,
    @SoCa INT,
    @MaNhanVien INT
AS
BEGIN
    INSERT INTO Luong (MaLuong, Luong, Thuong, ThoiGian, SoCa, MaNhanVien)
    VALUES (@MaLuong, @Luong, @Thuong, @ThoiGian, @SoCa, @MaNhanVien);
END;
GO

-- Thêm ca làm việc
CREATE PROCEDURE sp_ThemCaLamViec
    @MaCa INT,
    @TenCa NVARCHAR(100),
    @GioBatDau TIME,
    @GioKetThuc TIME
AS
BEGIN
    INSERT INTO CaLamViec (MaCa, TenCa, GioBatDau, GioKetThuc)
    VALUES (@MaCa, @TenCa, @GioBatDau, @GioKetThuc);
END;
GO

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
    INSERT INTO LinhKien (TenLinhKien, MoTaChiTiet, HinhAnh, GiaBan, GiaNhap, SoLuongTonKho, MaLoaiLinhKien, MaNhaCungCap)
    VALUES (@TenLinhKien, @MoTaChiTiet, @HinhAnh, @GiaBan, @GiaNhap, @SoLuongTonKho, @MaLoaiLinhKien, @MaNhaCungCap);
END;
GO

-- Thêm nhà cung cấp
CREATE PROCEDURE sp_ThemNhaCungCap
	@TenNhaCungCap NVARCHAR(255),
	@DiaChi NVARCHAR(255),
	@SDT NVARCHAR(10),
	@Email NVARCHAR(100)
AS
BEGIN
	INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, SDT, Email)
	VALUES (@TenNhaCungCap, @DiaChi, @SDT, @Email);
END;
GO

-- Thêm loại linh kiện
CREATE PROCEDURE sp_ThemLoaiLinhKien
	@TenLoaiLinhKien NVARCHAR(255)
AS
BEGIN
	INSERT INTO LoaiLinhKien (TenLoaiLinhKien)
	VALUES (@TenLoaiLinhKien);
END;
GO

-- Thêm lịch làm việc
CREATE PROCEDURE sp_ThemLichLamViec
    @MaLichLamViec INT,
    @NgayLam DATE,
    @MaCa INT
AS
BEGIN
    INSERT INTO LichLamViec (MaLichLamViec, NgayLam, MaCa)
    VALUES (@MaLichLamViec, @NgayLam, @MaCa);
END;
GO

-- Thêm có lịch làm
CREATE PROCEDURE sp_ThemCoLichLam
    @MaNhanVien INT,
    @MaLichLamViec INT,
    @DanhGia NVARCHAR(255),
    @TrangThai NVARCHAR(100)
AS
BEGIN
    INSERT INTO CoLichLam (MaNhanVien, MaLichLamViec, DanhGia, TrangThai)
    VALUES (@MaNhanVien, @MaLichLamViec, @DanhGia, @TrangThai);
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

-- Sửa phiếu nhập hàng
CREATE PROCEDURE UpdatePhieuNhapHang
    @MaPhieuNhap INT,
    @NgayNhap DATE,
    @GiaNhap DECIMAL(15, 2),
    @SoLuong INT,
    @MaLinhKien INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM PhieuNhapHang WHERE MaPhieuNhap = @MaPhieuNhap)
    BEGIN
        RAISERROR('PhieuNhapHang ID does not exist.', 16, 1);
        RETURN;
    END

    UPDATE PhieuNhapHang
    SET NgayNhap = @NgayNhap, GiaNhap = @GiaNhap, SoLuong = @SoLuong, MaLinhKien = @MaLinhKien
    WHERE MaPhieuNhap = @MaPhieuNhap;
    
    PRINT 'PhieuNhapHang updated successfully.';
END;
GO

-- Sửa công lịch làm
CREATE PROCEDURE sp_SuaCoLichLam
    @MaNhanVien INT,
    @MaLichLamViec INT,
    @DanhGia NVARCHAR(255),
    @TrangThai NVARCHAR(100)
AS
BEGIN
    UPDATE CoLichLam
    SET DanhGia = @DanhGia,
        TrangThai = @TrangThai
    WHERE MaNhanVien = @MaNhanVien AND MaLichLamViec = @MaLichLamViec;
END;
GO

-- Sửa ca làm việc
CREATE PROCEDURE sp_SuaCaLamViec
    @MaCa INT,
    @TenCa NVARCHAR(100),
    @GioBatDau TIME,
    @GioKetThuc TIME
AS
BEGIN
    UPDATE CaLamViec
    SET TenCa = @TenCa,
        GioBatDau = @GioBatDau,
        GioKetThuc = @GioKetThuc
    WHERE MaCa = @MaCa;
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
GO

-- Sửa loại linh kiện
CREATE PROCEDURE sp_SuaLoaiLinhKien
    @MaLoaiLinhKien INT,
    @TenLoaiLinhKien NVARCHAR(255)
AS
BEGIN
    UPDATE LoaiLinhKien
    SET TenLoaiLinhKien = @TenLoaiLinhKien
    WHERE MaLoaiLinhKien = @MaLoaiLinhKien;
END;
GO

-- Sửa nhà cung cấp
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

-- Sửa lương
CREATE PROCEDURE sp_SuaLuong
    @MaLuong INT,
    @Luong DECIMAL(15, 2),
    @Thuong DECIMAL(15, 2),
    @ThoiGian DATE,
    @SoCa INT,
    @MaNhanVien INT
AS
BEGIN
    UPDATE Luong
    SET Luong = @Luong,
        Thuong = @Thuong,
        ThoiGian = @ThoiGian,
        SoCa = @SoCa,
        MaNhanVien = @MaNhanVien
    WHERE MaLuong = @MaLuong;
END;
GO

-- Sửa lịch làm việc
CREATE PROCEDURE sp_SuaLichLamViec
    @MaLichLamViec INT,
    @NgayLam DATE,
    @MaCa INT
AS
BEGIN
    UPDATE LichLamViec
    SET NgayLam = @NgayLam,
        MaCa = @MaCa
    WHERE MaLichLamViec = @MaLichLamViec;
END;
GO

-- Sửa đơn hàng
CREATE PROCEDURE sp_SuaDonHang
    @MaDonHang INT,
    @NgayDatHang DATE,
    @MaKhachHang INT,
    @MaNhanVien INT,
    @MaGiamGia INT,
    @TongGiaTri DECIMAL(15, 2),
    @PhuongThuc NVARCHAR(100)
AS
BEGIN
    UPDATE DonHang
    SET NgayDatHang = @NgayDatHang,
        MaKhachHang = @MaKhachHang,
        MaNhanVien = @MaNhanVien,
        MaGiamGia = @MaGiamGia,
        TongGiaTri = @TongGiaTri,
        PhuongThuc = @PhuongThuc
    WHERE MaDonHang = @MaDonHang;
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

-- Xóa đơn hàng
CREATE PROCEDURE sp_XoaDonHang
    @MaDonHang INT
AS
BEGIN
    DELETE FROM DonHang
    WHERE MaDonHang = @MaDonHang;
END;
GO

-- Xóa phiếu nhập hàng
CREATE PROCEDURE DeletePhieuNhapHang
    @MaPhieuNhap INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM PhieuNhapHang WHERE MaPhieuNhap = @MaPhieuNhap)
    BEGIN
        RAISERROR('PhieuNhapHang ID does not exist.', 16, 1);
        RETURN;
    END

    DELETE FROM PhieuNhapHang
    WHERE MaPhieuNhap = @MaPhieuNhap;
    
    PRINT 'PhieuNhapHang deleted successfully.';
END;
GO

-- Xóa công lịch làm
CREATE PROCEDURE sp_XoaCoLichLam
    @MaNhanVien INT,
    @MaLichLamViec INT
AS
BEGIN
    DELETE FROM CoLichLam
    WHERE MaNhanVien = @MaNhanVien AND MaLichLamViec = @MaLichLamViec;
END;
GO

-- Xóa lịch làm việc
CREATE PROCEDURE sp_XoaLichLamViec
    @MaLichLamViec INT
AS
BEGIN
    DELETE FROM LichLamViec
    WHERE MaLichLamViec = @MaLichLamViec;
END;
GO

-- Xóa lương
CREATE PROCEDURE sp_XoaLuong
    @MaLuong INT
AS
BEGIN
    DELETE FROM Luong
    WHERE MaLuong = @MaLuong;
END;
GO

-- Xóa ca làm việc
CREATE PROCEDURE sp_XoaCaLamViec
    @MaCa INT
AS
BEGIN
    DELETE FROM CaLamViec
    WHERE MaCa = @MaCa;
END;
GO

-- Xóa linh kiện
CREATE PROCEDURE sp_XoaLinhKien
    @MaLinhKien INT
AS
BEGIN
    DELETE FROM LinhKien WHERE MaLinhKien = @MaLinhKien;
END;
GO

-- Xóa loại linh kiện
CREATE PROCEDURE sp_XoaLoaiLinhKien
    @MaLoaiLinhKien INT
AS
BEGIN
    DELETE FROM LoaiLinhKien WHERE MaLoaiLinhKien = @MaLoaiLinhKien;
END;
GO

-- Xóa nhà cung cấp
CREATE PROCEDURE sp_XoaNhaCungCap
    @MaNhaCungCap INT
AS
BEGIN
    DELETE FROM NhaCungCap WHERE MaNhaCungCap = @MaNhaCungCap;
END;
GO
-- Tìm kiếm linh kiện theo từ khóa
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

-- Tìm kiếm linh kiện theo giá
CREATE PROCEDURE sp_TimKiemLinhKienTheoGia
    @GiaMin DECIMAL(15, 2),
    @GiaMax DECIMAL(15, 2)
AS
BEGIN
    SELECT *
    FROM vw_ThongTinLinhKien
    WHERE GiaBan BETWEEN @GiaMin AND @GiaMax;
END;
GO
-- Lấy chi tiết phiếu nhập hàng theo mã phiếu nhập
CREATE FUNCTION dbo.GetPhieuNhapHangDetails (@MaPhieuNhap INT)
RETURNS TABLE
AS
RETURN (
    SELECT 
        MaPhieuNhap,
        NgayNhap,
        GiaNhap,
        SoLuong,
        MaLinhKien
    FROM PhieuNhapHang
    WHERE MaPhieuNhap = @MaPhieuNhap
);
GO

-- Lấy chi tiết đơn hàng theo mã đơn hàng
CREATE FUNCTION dbo.GetDonHangDetails (@MaDonHang INT)
RETURNS TABLE
AS
RETURN (
    SELECT 
        MaDonHang,
        NgayDatHang,
        MaKhachHang,
        MaNhanVien,
        MaGiamGia,
        TongGiaTri,
        PhuongThuc
    FROM DonHang
    WHERE MaDonHang = @MaDonHang
);
GO

-- Lấy tên loại linh kiện theo mã loại linh kiện
CREATE FUNCTION dbo.GetTenLoaiLinhKien (@MaLoaiLinhKien INT)
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @TenLoaiLinhKien NVARCHAR(255);
    
    SELECT @TenLoaiLinhKien = TenLoaiLinhKien
    FROM LoaiLinhKien
    WHERE MaLoaiLinhKien = @MaLoaiLinhKien;
    
    RETURN @TenLoaiLinhKien;
END;
GO

-- Xem lương theo nhân viên
CREATE FUNCTION fn_XemLuongTheoNhanVien
(
    @MaNhanVien INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        MaLuong,
        Luong,
        Thuong,
        ThoiGian,
        SoCa
    FROM 
        Luong
    WHERE 
        MaNhanVien = @MaNhanVien
);
GO

-- Xem tất cả lương theo tháng năm
CREATE FUNCTION dbo.fn_XemTatCaLuongTheoThangNam
(
    @Thang INT, @Nam INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        l.MaLuong,
        l.Luong,
        l.Thuong,
        l.ThoiGian,
        l.SoCa,
        nv.TenNhanVien
    FROM 
        Luong l
    JOIN 
        NhanVien nv ON l.MaNhanVien = nv.MaNhanVien
    WHERE 
        MONTH(l.ThoiGian) = @Thang AND
        YEAR(l.ThoiGian) = @Nam
);
GO

-- Xem ca làm việc của nhân viên
CREATE FUNCTION dbo.XemCaLamViecCuaNhanVien (@MaNhanVien INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        LLV.MaLichLamViec,
        LLV.NgayLam,
        CLV.TenCa,
        CLV.GioBatDau,
        CLV.GioKetThuc
    FROM 
        CoLichLam CLL
    JOIN 
        LichLamViec LLV ON CLL.MaLichLamViec = LLV.MaLichLamViec
    JOIN 
        CaLamViec CLV ON LLV.MaCa = CLV.MaCa
    WHERE 
        CLL.MaNhanVien = @MaNhanVien
);
GO

-- Xem nhân viên trong ca làm
CREATE FUNCTION dbo.fn_XemNhanVienTrongCaLam (@MaCa INT, @ngay DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        nv.TenNhanVien,
        cll.DanhGia,
        cll.TrangThai,
        clv.TenCa,
        clv.GioBatDau,
        clv.GioKetThuc
    FROM 
        NhanVien nv
    JOIN CoLichLam cll ON nv.MaNhanVien = cll.MaNhanVien
    JOIN LichLamViec llv ON cll.MaLichLamViec = llv.MaLichLamViec
    JOIN CaLamViec clv ON clv.MaCa = llv.MaCa
    WHERE 
        clv.MaCa = @MaCa AND llv.NgayLam = @ngay
);
GO
-- Trigger để cập nhật số lượng tồn kho khi có đơn hàng mới
CREATE TRIGGER trg_UpdateSoLuongTonKho
ON ChiTietDonHang
AFTER INSERT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        UPDATE LinhKien
        SET SoLuongTonKho = SoLuongTonKho - inserted.SoLuong
        FROM LinhKien
        INNER JOIN inserted ON LinhKien.MaLinhKien = inserted.MaLinhKien;

        IF EXISTS (
            SELECT 1
            FROM LinhKien
            WHERE SoLuongTonKho < 0
        )
        BEGIN
            ROLLBACK TRANSACTION;
            THROW 50000, 'Số lượng tồn kho không đủ!', 1;
        END
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END;
GO

-- Trigger thông báo khi số lượng tồn kho dưới 10
CREATE TRIGGER trg_ThongBaoTonKho
ON LinhKien
AFTER UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE SoLuongTonKho < 10
    )
    BEGIN
        DECLARE @Message NVARCHAR(MAX) = '';
        SELECT @Message = STRING_AGG('Cảnh báo: Sắp hết linh kiện ' + CAST(MaLinhKien AS NVARCHAR(10)), '; ')
        FROM inserted
        WHERE SoLuongTonKho < 10;

        PRINT @Message;
    END
END;
GO

-- Trigger kiểm tra tồn kho trước khi chèn chi tiết đơn hàng
CREATE TRIGGER trg_KiemTraTonKho
ON ChiTietDonHang
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN LinhKien lk ON i.MaLinhKien = lk.MaLinhKien
        WHERE i.SoLuong > lk.SoLuongTonKho
    )
    BEGIN
        RAISERROR ('Không đủ số lượng tồn kho để đáp ứng đơn hàng.', 16, 1);
    END
    ELSE
    BEGIN
        INSERT INTO ChiTietDonHang (MaDonHang, MaLinhKien, SoLuong, GiaBan)
        SELECT MaDonHang, MaLinhKien, SoLuong, GiaBan
        FROM inserted;
    END
END;
GO

-- Trigger cập nhật lương khi có thay đổi trong lịch làm việc
CREATE TRIGGER trg_CapNhatLuong
ON CoLichLam
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE Luong
    SET 
        Luong = LuongGio * (SELECT SUM(DATEDIFF(MINUTE, clv.GioBatDau, clv.GioKetThuc)) / 60.0
                             FROM CoLichLam cl
                             JOIN LichLamViec llv ON cl.MaLichLamViec = llv.MaLichLamViec
                             JOIN CaLamViec clv ON llv.MaCa = clv.MaCa
                             WHERE cl.MaNhanVien = inserted.MaNhanVien
                             AND cl.TrangThai = 'HoanThanh'
                             AND MONTH(llv.NgayLam) = MONTH(l.ThoiGian)
                             AND YEAR(llv.NgayLam) = YEAR(l.ThoiGian)),
        
        TongNhan = Luong + Thuong
    FROM Luong l, inserted
    WHERE l.MaNhanVien = (SELECT MaNhanVien FROM inserted);
    
    PRINT 'Đã cập nhật Lương và Tổng Nhận trong bảng Lương';
END;
GO

-- Trigger cập nhật lương khi xóa lịch làm việc
CREATE TRIGGER trg_CapNhatLuongKhiXoa
ON CoLichLam
AFTER DELETE
AS
BEGIN
    UPDATE Luong
    SET 
        Luong = LuongGio * (SELECT SUM(DATEDIFF(MINUTE, clv.GioBatDau, clv.GioKetThuc)) / 60.0
                             FROM CoLichLam cl
                             JOIN LichLamViec llv ON cl.MaLichLamViec = llv.MaLichLamViec
                             JOIN CaLamViec clv ON llv.MaCa = clv.MaCa
                             WHERE cl.MaNhanVien = deleted.MaNhanVien
                             AND cl.TrangThai = 'HoanThanh'
                             AND MONTH(llv.NgayLam) = MONTH(l.ThoiGian)
                             AND YEAR(llv.NgayLam) = YEAR(l.ThoiGian)),
        
        TongNhan = Luong + Thuong
    FROM Luong l, deleted
    WHERE l.MaNhanVien = (SELECT MaNhanVien FROM deleted);
    
    PRINT 'Đã cập nhật Lương và Tổng Nhận trong bảng Lương';
END;
GO

-- Trigger cập nhật số lượng tồn kho khi có phiếu nhập hàng mới
CREATE TRIGGER trg_AfterInsert_PhieuNhapHang
ON PhieuNhapHang
AFTER INSERT
AS
BEGIN
    UPDATE LinhKien
    SET SoLuongTonKho = LinhKien.SoLuongTonKho + inserted.SoLuong
    FROM LinhKien
    INNER JOIN inserted ON LinhKien.MaLinhKien = inserted.MaLinhKien;
END;
GO

-- Trigger cập nhật giá nhập khi có phiếu nhập hàng mới
CREATE TRIGGER trg_AfterInsert_PhieuNhapHang_UpdatePrice
ON PhieuNhapHang
AFTER INSERT
AS
BEGIN
    UPDATE LinhKien
    SET GiaNhap = inserted.GiaNhap
    FROM LinhKien
    INNER JOIN inserted ON LinhKien.MaLinhKien = inserted.MaLinhKien;
END;
GO

-- Trigger cập nhật số lượng tồn kho khi xóa phiếu nhập hàng
CREATE TRIGGER trg_AfterDelete_PhieuNhapHang_UpdateStock
ON PhieuNhapHang
AFTER DELETE
AS
BEGIN
    UPDATE LinhKien
    SET SoLuongTonKho = LinhKien.SoLuongTonKho - deleted.SoLuong
    FROM LinhKien
    INNER JOIN deleted ON LinhKien.MaLinhKien = deleted.MaLinhKien;
END;
GO

-- Trigger kiểm tra sử dụng trước khi xóa loại linh kiện
CREATE TRIGGER trg_BeforeDelete_LoaiLinhKien_CheckUsage
ON LoaiLinhKien
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM LinhKien 
        WHERE MaLoaiLinhKien IN (SELECT MaLoaiLinhKien FROM deleted)
    )
    BEGIN
        RAISERROR('Không thể xóa loại linh kiện vì đã có linh kiện liên quan.', 16, 1);
        ROLLBACK TRANSACTION; 
    END
    ELSE
    BEGIN
        DELETE FROM LoaiLinhKien
        WHERE MaLoaiLinhKien IN (SELECT MaLoaiLinhKien FROM deleted);
    END
END;
GO

-- Trigger cập nhật tổng giá trị đơn hàng khi có chi tiết đơn hàng mới
CREATE TRIGGER trg_AfterInsert_ChiTietDonHang_UpdateTotal
ON ChiTietDonHang
AFTER INSERT
AS
BEGIN
    DECLARE @total DECIMAL(15, 2);
    DECLARE @MaDonHang INT;

    SELECT @MaDonHang = MaDonHang FROM inserted;

    SELECT @total = SUM(SoLuong * GiaBan)
    FROM ChiTietDonHang
    WHERE MaDonHang = @MaDonHang;

    UPDATE DonHang
    SET TongGiaTri = @total
    WHERE MaDonHang = @MaDonHang;
END;
GO

CREATE PROCEDURE sp_ThemGiamGia
    @TenGiamGia NVARCHAR(255),
    @NgayBatDau DATE,
    @NgayKetThuc DATE,
    @GiaTri DECIMAL(5, 2)
AS
BEGIN
    INSERT INTO GiamGia (TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri)
    VALUES (@TenGiamGia, @NgayBatDau, @NgayKetThuc, @GiaTri);
END
Go
CREATE PROCEDURE sp_XoaGiamGia
    @MaGiamGia INT
AS
BEGIN
    DELETE FROM GiamGia WHERE MaGiamGia = @MaGiamGia;
END
Go

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
    VALUES (@TenNhanVien, @SDT, @Email, @NgaySinh, @DiaChi, @MatKhau,'nv')
END
Go
--Update
CREATE PROCEDURE sp_SuaNhanVien
    @MaNhanVien INT,
    @TenNhanVien NVARCHAR(100),
    @SDT NVARCHAR(15),
    @Email NVARCHAR(100),
    @NgaySinh DATE,
    @DiaChi NVARCHAR(255)
AS
BEGIN
    UPDATE dbo.NhanVien
    SET TenNhanVien = @TenNhanVien, SDT = @SDT, Email = @Email, NgaySinh = @NgaySinh, DiaChi = @DiaChi
    WHERE MaNhanVien = @MaNhanVien
END
GO
-----  Function ----- 
-- Tính tổng
CREATE FUNCTION fn_GetTotalEmployees()
RETURNS INT
AS
BEGIN
    DECLARE @TotalEmployees INT;
    
    SELECT @TotalEmployees = COUNT(*)
    FROM dbo.NhanVien;
    
    RETURN @TotalEmployees;
END
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
-- Date range
CREATE FUNCTION fn_FilterNhanVienByDateRange (@StartDate DATE, @EndDate DATE)
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
    WHERE NgaySinh BETWEEN @StartDate AND @EndDate
    
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
--- View
CREATE VIEW vw_GiamGia
AS
SELECT MaGiamGia, TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri
FROM dbo.GiamGia
GO
-- Stored Procedure

CREATE PROCEDURE sp_UpdateGiamGia
    @MaGiamGia INT,
    @TenGiamGia NVARCHAR(100),
    @NgayBatDau DATE,
    @NgayKetThuc DATE,
    @GiaTri DECIMAL(5, 2)
AS
BEGIN
    UPDATE dbo.GiamGia
    SET TenGiamGia = @TenGiamGia,
        NgayBatDau = @NgayBatDau,
        NgayKetThuc = @NgayKetThuc,
        GiaTri = @GiaTri
    WHERE MaGiamGia = @MaGiamGia;
END;
GO
-- Lấy mã theo thời gian
CREATE PROCEDURE sp_GetGiamGiaByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT MaGiamGia, TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri
    FROM dbo.GiamGia
    WHERE NgayBatDau BETWEEN @StartDate AND @EndDate;
END;
GO
---- Function
-- Kiểm tra mã giảm giá hợp lệ
CREATE FUNCTION fn_CheckGiamGiaHopLe (
    @MaGiamGia INT
)
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @NgayBatDau DATE, @NgayKetThuc DATE;
    DECLARE @Result NVARCHAR(50);

    SELECT @NgayBatDau = NgayBatDau, @NgayKetThuc = NgayKetThuc
    FROM dbo.GiamGia
    WHERE MaGiamGia = @MaGiamGia;

    IF @NgayBatDau IS NULL
    BEGIN
        SET @Result = N'Mã giảm giá không tồn tại';
        RETURN @Result;
    END

    IF GETDATE() < @NgayBatDau
    BEGIN
        SET @Result = N'Mã giảm giá chưa có hiệu lực';
    END
    ELSE IF GETDATE() > @NgayKetThuc
    BEGIN
        SET @Result = N'Mã giảm giá đã hết hạn';
    END
    ELSE
    BEGIN
        SET @Result = N'Mã giảm giá hợp lệ';
    END

    RETURN @Result;
END;
GO
-- Tính giá trị đơn sau khi giảm
CREATE FUNCTION fn_CalculateFinalPrice (
    @GiaTriDonHang DECIMAL(10, 2),
    @MaGiamGia INT
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @GiaTriGiam DECIMAL(5, 2);
    DECLARE @FinalPrice DECIMAL(10, 2);
    
    SELECT @GiaTriGiam = GiaTri
    FROM dbo.GiamGia
    WHERE MaGiamGia = @MaGiamGia 
        AND GETDATE() BETWEEN NgayBatDau AND NgayKetThuc;

    IF @GiaTriGiam IS NULL
    BEGIN
        SET @FinalPrice = @GiaTriDonHang;
    END
    ELSE
    BEGIN
        SET @FinalPrice = @GiaTriDonHang * (1 - @GiaTriGiam / 100);
    END
    
    RETURN @FinalPrice;
END;
GO
