GO
USE LinhkienLaptop; 
GO

INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, SDT, Email) 
VALUES 
    ('Cong Ty TNHH SX TM DV A Chau', '456 Nguyen Van Cu, Q.1, TPHCM', '0908888888', 'sales@achau.com'),
    ('Cong Ty TNHH MTV Kim Long', '789 Le Dai Hanh, Q.10, TPHCM', '0917777777', 'contact@kimlong.com'),
    ('Cong Ty TNHH XD Viet Duc', '101 Le Lai, Q.3, TPHCM', '0926666666', 'info@vietduc.com'),
    ('Cong Ty TNHH TM DV Hoang Gia', '202 Tran Hung Dao, Q.5, TPHCM', '0935555555', 'support@hoanggia.com'),
    ('Cong Ty CP TM DV Thanh Phat', '303 Cach Mang Thang Tam, Q.10, TPHCM', '0944444444', 'admin@thanhphat.com');
GO

INSERT INTO KhachHang (TenKhachHang, DiaChi, SDT, Email, NgaySinh) 
VALUES 
    ('Nguyen Van Anh', '123 Le Loi, Q.1, TPHCM', '0901123456', 'nguyenvananh@example.com', '1990-01-01'),
    ('Tran Thi Bich', '456 Hai Ba Trung, Q.3, TPHCM', '0902123457', 'tranthibich@example.com', '1991-02-01'),
    ('Le Van Cuong', '789 Nguyen Trai, Q.5, TPHCM', '0903123458', 'levancuong@example.com', '1992-03-01'),
    ('Pham Thi Dao', '101 Nguyen Hue, Q.7, TPHCM', '0904123459', 'phamthidao@example.com', '1993-04-01'),
    ('Hoang Van Dung', '202 Cach Mang Thang Tam, Q.9, TPHCM', '0905123460', 'hoangvandung@example.com', '1994-05-01'),
    ('Vu Thi Em', '303 Le Hong Phong, Q.10, TPHCM', '0906123461', 'vuthiem@example.com', '1995-06-01'),
    ('Nguyen Van Phuoc', '404 Tran Hung Dao, Q.11, TPHCM', '0907123462', 'nguyenvanphuoc@example.com', '1996-07-01'),
    ('Tran Thi Ha', '505 Pham Van Dong, Q.12, TPHCM', '0908123463', 'tranthiha@example.com', '1997-08-01'),
    ('Le Van Kiet', '606 Vo Van Tan, Q.Binh Thanh, TPHCM', '0909123464', 'levankiet@example.com', '1998-09-01'),
    ('Pham Thi Lan', '707 Ly Tu Trong, Q.Tan Binh, TPHCM', '0910123465', 'phamthilan@example.com', '1999-10-01'),
    ('Hoang Van Minh', '808 Mac Dinh Chi, Q.1, TPHCM', '0911123466', 'hoangvanminh@example.com', '1989-11-01'),
    ('Vu Thi Nhung', '909 Dinh Tien Hoang, Q.2, TPHCM', '0912123467', 'vuthinhung@example.com', '1988-12-01'),
    ('Nguyen Van Oanh', '1010 Nam Ky Khoi Nghia, Q.3, TPHCM', '0913123468', 'nguyenvanoanh@example.com', '1987-01-01'),
    ('Tran Thi Phuong', '1111 Phan Dinh Phung, Q.4, TPHCM', '0914123469', 'tranthiphuong@example.com', '1986-02-01'),
    ('Le Van Quy', '1212 Hoang Sa, Q.5, TPHCM', '0915123470', 'levanquy@example.com', '1985-03-01'),
    ('Pham Thi Quynh', '1313 Truong Dinh, Q.6, TPHCM', '0916123471', 'phamthiquynh@example.com', '1984-04-01'),
    ('Hoang Van Son', '1414 Ky Con, Q.7, TPHCM', '0917123472', 'hoangvanson@example.com', '1983-05-01'),
    ('Vu Thi Tam', '1515 Vo Thi Sau, Q.8, TPHCM', '0918123473', 'vuthitam@example.com', '1982-06-01'),
    ('Nguyen Van Tuan', '1616 Dien Bien Phu, Q.9, TPHCM', '0919123474', 'nguyenvantuan@example.com', '1981-07-01'),
    ('Tran Thi Uyen', '1717 Nguyen Thi Minh Khai, Q.10, TPHCM', '0920123475', 'tranthiuyen@example.com', '1980-08-01');
GO

INSERT INTO NhanVien (TenNhanVien, ChucVu, DiaChi, SDT, Email, MatKhau, NgaySinh) 
VALUES 
    ('Nguyen Van Tam', 'ql', '456 Nguyen Van Troi, Q.3, TPHCM', '0901122334', 'nguyenvantam@company.com', 'matkhau1', '1980-03-25'),
    ('Tran Thi Lan', 'nv', '789 Dien Bien Phu, Q.Binh Thanh, TPHCM', '0902233445', 'tranthilan@company.com', 'matkhau2', '1985-06-15'),
    ('Le Van Hoa', 'nv', '123 Xo Viet Nghe Tinh, Q.2, TPHCM', '0903344556', 'levanhoa@company.com', 'matkhau3', '1990-07-20'),
    ('Pham Thi Binh', 'nv', '456 Pham Van Dong, Q.9, TPHCM', '0904455667', 'phamthibinh@company.com', 'matkhau4', '1983-08-10'),
    ('Hoang Van Phuc', 'nv', '789 Le Loi, Q.1, TPHCM', '0905566778', 'hoangvanphuc@company.com', 'matkhau5', '1995-09-05'),
    ('Vu Thi Nga', 'nv', '101 Le Thanh Ton, Q.3, TPHCM', '0906677889', 'vuthinga@company.com', 'matkhau6', '1992-01-30'),
    ('Nguyen Van Quoc', 'nv', '202 Tran Hung Dao, Q.5, TPHCM', '0907788990', 'nguyenvanquoc@company.com', 'matkhau7', '1988-12-25'),
    ('Tran Thi Mai', 'nv', '303 Nguyen Thi Minh Khai, Q.10, TPHCM', '0908899001', 'tranthimai@company.com', 'matkhau8', '1993-05-15'),
    ('Le Van Dung', 'nv', '404 Cach Mang Thang Tam, Q.11, TPHCM', '0909900112', 'levandung@company.com', 'matkhau9', '1987-11-20'),
    ('Pham Thi Thu', 'nv', '505 Hoang Sa, Q.7, TPHCM', '0911011223', 'phamthithu@company.com', 'matkhau10', '1982-02-10');
GO

INSERT INTO LoaiLinhKien (TenLoaiLinhKien) VALUES 
    ('Bo Mach Laptop'),
    ('Pin Laptop'),
    ('RAM Laptop'),
    ('CPU Laptop'),
    ('SSD Laptop');
GO

INSERT INTO LinhKien (TenLinhKien, MoTaChiTiet, HinhAnh, GiaBan, GiaNhap, SoLuongTonKho, MaLoaiLinhKien, MaNhaCungCap) VALUES 
    ('Bo Mach Dell Inspiron', 'Bo mach cho dong laptop Dell Inspiron.', 'bomach_dell_inspiron.jpg', 2500000, 2000000, 10, 1, 1),
    ('Pin HP Pavilion', 'Pin cho dong laptop HP Pavilion voi thoi luong su dung 6 gio.', 'pin_hp_pavilion.jpg', 1500000, 1200000, 20, 2, 2),
    ('RAM 8GB DDR4 Kingston', 'RAM 8GB DDR4 cho laptop, thuong hieu Kingston.', 'ram_8gb_ddr4_kingston.jpg', 1000000, 800000, 30, 3, 3),
    ('CPU Intel Core i5', 'CPU Intel Core i5 the he thu 10 cho laptop.', 'cpu_intel_core_i5.jpg', 4500000, 4000000, 15, 4, 4),
    ('SSD 256GB Samsung', 'SSD 256GB cho laptop, thuong hieu Samsung.', 'ssd_256gb_samsung.png', 1200000, 1000000, 25, 5, 5),
    ('Bo Mach Asus VivoBook', 'Bo mach cho dong laptop Asus VivoBook.', 'bomach_asus_vivobook.jpg', 2700000, 2300000, 12, 1, 1),
    ('Pin Lenovo ThinkPad', 'Pin cho dong laptop Lenovo ThinkPad voi thoi luong su dung 8 gio.', 'pin_lenovo_thinkpad.jpg', 1800000, 1500000, 18, 2, 2),
    ('RAM 16GB DDR4 Corsair', 'RAM 16GB DDR4 cho laptop, thuong hieu Corsair.', 'ram_16gb_ddr4_corsair.jpg', 2000000, 1700000, 22, 3, 3),
    ('CPU AMD Ryzen 5', 'CPU AMD Ryzen 5 the he thu 4 cho laptop.', 'cpu_amd_ryzen_5.jpg', 5000000, 4500000, 10, 4, 4),
    ('SSD 512GB WD Black', 'SSD 512GB cho laptop, thuong hieu WD Black.', 'ssd_512gb_wd_black.jpg', 2000000, 1800000, 20, 5, 5);
GO

INSERT INTO PhieuNhapHang (NgayNhap, GiaNhap, SoLuong, MaLinhKien) 
VALUES 
    ('2024-01-15', 2000000, 10, 1),
    ('2024-02-10', 1200000, 20, 2),
    ('2024-03-05', 800000, 30, 3),
    ('2024-04-01', 4000000, 15, 4),
    ('2024-05-18', 1000000, 25, 5),
    ('2024-06-12', 2300000, 12, 6),
    ('2024-07-22', 1500000, 18, 7),
    ('2024-08-08', 1700000, 22, 8),
    ('2024-09-15', 4500000, 10, 9),
    ('2024-10-05', 1800000, 20, 10);
GO

INSERT INTO GiamGia (TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri) 
VALUES 
    ('Khuyen Mai Tet', '2024-01-10', '2024-01-25', 15.00),
    ('Black Friday', '2024-11-25', '2024-12-01', 50.00),
    ('Giam Gia He', '2024-06-01', '2024-06-15', 20.00),
    ('Sinh Nhat Cong Ty', '2024-07-01', '2024-07-07', 10.00),
    ('Mua Sam Cuoi Nam', '2024-12-15', '2024-12-31', 30.00),
    ('Le Vu Lan', '2024-08-10', '2024-08-20', 25.00),
    ('Khuyen Mai Trung Thu', '2024-09-20', '2024-09-30', 18.00),
    ('Giam Gia 8/3', '2024-03-01', '2024-03-10', 12.00),
    ('Quoc Khanh 2/9', '2024-08-29', '2024-09-05', 22.00),
    ('Le Giang Sinh', '2024-12-20', '2024-12-26', 35.00);
GO

--- DonHang và ChiTietDonHang auto generate ----
DECLARE @startDate DATE = '2024-09-01';
DECLARE @endDate DATE = '2024-11-13';
DECLARE @maKhachHang INT;
DECLARE @ordersPerDay INT;

SET @maKhachHang = 1;

WHILE @startDate <= @endDate
BEGIN
    SET @ordersPerDay = ABS(CHECKSUM(NEWID())) % 15 + 1; -- Số đơn hàng ngẫu nhiên từ 10 đến 50 đơn hàng mỗi ngày

    WHILE @ordersPerDay > 0
    BEGIN
        -- Lấy một MaNhanVien ngẫu nhiên từ bảng NhanVien
        DECLARE @randomMaNhanVien INT;
        SELECT TOP 1 @randomMaNhanVien = MaNhanVien FROM NhanVien ORDER BY NEWID();

        -- Lấy một MaGiamGia NULL
        DECLARE @randomMaGiamGia INT = NULL;

        -- Chèn dữ liệu vào bảng DonHang
        INSERT INTO DonHang (NgayDatHang, MaKhachHang, MaNhanVien, MaGiamGia, TongGiaTri, PhuongThuc)
        VALUES 
        (@startDate, @maKhachHang, @randomMaNhanVien, @randomMaGiamGia, 5, 'Tiền mặt');

        DECLARE @newMaDonHang INT = SCOPE_IDENTITY(); -- Lấy ID của đơn hàng vừa được chèn

        -- Tạo các mục trong ChiTietDonHang cho đơn hàng mới
        DECLARE @itemsPerOrder INT = ABS(CHECKSUM(NEWID())) % 4 + 1; -- Số lượng mặt hàng ngẫu nhiên từ 1 đến 4 cho mỗi đơn hàng
        DECLARE @counter INT = 1;

        WHILE @counter <= @itemsPerOrder
        BEGIN
            DECLARE @MaLinhKien INT;
            DECLARE @GiaBan DECIMAL(15, 2);
            DECLARE @SoLuong INT = ABS(CHECKSUM(NEWID())) % 3 + 1; -- Số lượng ngẫu nhiên từ 1 đến 3

            -- Lấy ngẫu nhiên một LinhKien từ bảng LinhKien
            SELECT TOP 1 @MaLinhKien = MaLinhKien, @GiaBan = GiaBan FROM LinhKien ORDER BY NEWID();

            -- Kiểm tra nếu mặt hàng chưa tồn tại trong ChiTietDonHang cho đơn hàng này
            IF NOT EXISTS (SELECT 1 FROM ChiTietDonHang WHERE MaDonHang = @newMaDonHang AND MaLinhKien = @MaLinhKien)
            BEGIN
                INSERT INTO ChiTietDonHang (MaDonHang, MaLinhKien, SoLuong, GiaBan)
                VALUES 
                (@newMaDonHang, @MaLinhKien, @SoLuong, @GiaBan);
            END;

            SET @counter = @counter + 1;
        END;

        -- Cập nhật TongGiaTri cho đơn hàng
        UPDATE DonHang
        SET TongGiaTri = (
            SELECT SUM(ct.SoLuong * ct.GiaBan)
            FROM ChiTietDonHang ct
            WHERE ct.MaDonHang = DonHang.MaDonHang
        )
        WHERE MaDonHang = @newMaDonHang;

        SET @maKhachHang = @maKhachHang % 6 + 1; -- Tạo dữ liệu khách hàng ngẫu nhiên từ MaKhachHang 1-5
        SET @ordersPerDay = @ordersPerDay - 1;
    END;

    SET @startDate = DATEADD(DAY, 1, @startDate); -- Tăng ngày lên một ngày
END;
GO

INSERT INTO CaLamViec (TenCa, GioBatDau, GioKetThuc)
VALUES ( N'Ca Sáng', '08:00', '12:00'),
		( N'Ca Chiều', '13:00', '17:00'),
		( N'Ca Tối', '18:00', '22:00');
GO
-- Tạo dữ liệu cho bảng LichLamViec
DECLARE @startDate DATE = '2024-09-01';
DECLARE @endDate DATE = '2024-11-13';
WHILE @startDate <= @endDate
BEGIN
    -- Lặp qua 3 ca làm việc trong một ngày
    DECLARE @shiftCount INT = 3;
    DECLARE @shiftCounter INT = 1;
    
    WHILE @shiftCounter <= @shiftCount
    BEGIN
        -- Lấy MaCa từ bảng CaLamViec theo thứ tự
        DECLARE @maCa INT;
        SELECT @maCa = MaCa FROM (
            SELECT MaCa, ROW_NUMBER() OVER (ORDER BY MaCa) AS RowNum
            FROM CaLamViec
        ) AS CaShift
        WHERE RowNum = @shiftCounter;

        -- Chèn dữ liệu vào LichLamViec cho ngày hiện tại và ca hiện tại nếu chưa tồn tại
        IF NOT EXISTS (SELECT 1 FROM LichLamViec WHERE NgayLam = @startDate AND MaCa = @maCa)
        BEGIN
            INSERT INTO LichLamViec (NgayLam, MaCa)
            VALUES (@startDate, @maCa);
        END

        SET @shiftCounter = @shiftCounter + 1;
    END

    SET @startDate = DATEADD(DAY, 1, @startDate); -- Tăng ngày lên một ngày
END

-- Tạo dữ liệu cho bảng CoLichLam
DECLARE @maLichLamViec INT;

DECLARE lich_cursor CURSOR FOR 
SELECT MaLichLamViec FROM LichLamViec;

OPEN lich_cursor;
FETCH NEXT FROM lich_cursor INTO @maLichLamViec;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Số lượng nhân viên ngẫu nhiên từ 1 đến 3 cho mỗi lịch làm việc
    DECLARE @employeesPerShift INT = ABS(CHECKSUM(NEWID())) % 3 + 1;
    DECLARE @counter INT = 1;

    WHILE @counter <= @employeesPerShift
    BEGIN
        -- Thiết lập trạng thái và đánh giá
        DECLARE @randomTrangThai NVARCHAR(100) = N'HoanThanh';
        DECLARE @danhGia NVARCHAR(255) = N'Tot';

        -- Lấy MaNhanVien ngẫu nhiên từ bảng NhanVien
        DECLARE @maNhanVien INT;
        SELECT TOP 1 @maNhanVien = MaNhanVien FROM NhanVien ORDER BY NEWID();

        -- Kiểm tra nếu nhân viên chưa có lịch làm việc cho MaLichLamViec này
        IF NOT EXISTS (SELECT 1 FROM CoLichLam WHERE MaNhanVien = @maNhanVien AND MaLichLamViec = @maLichLamViec)
        BEGIN
            INSERT INTO CoLichLam (MaNhanVien, MaLichLamViec, DanhGia, TrangThai)
            VALUES 
            (@maNhanVien, @maLichLamViec, @danhGia, @randomTrangThai);
        END;

        SET @counter = @counter + 1;
    END;

    FETCH NEXT FROM lich_cursor INTO @maLichLamViec;
END;

CLOSE lich_cursor;
DEALLOCATE lich_cursor;
GO


INSERT INTO Luong (Luong, LuongGio, Thuong, TongNhan, ThoiGian, SoCa, MaNhanVien) 
VALUES 
    (6 * 4 * 25000, 25000, 2000000, (20 * 25000) + 2000000, '2024-09-01', 6, 1),
    (3 * 4 * 25000, 25000, 1500000, (18 * 25000) + 1500000, '2024-09-01', 3, 2),
    (3 * 4 * 25000, 25000, 2500000, (22 * 25000) + 2500000, '2024-09-01', 3, 3),
    (6* 4 * 25000, 25000, 1800000, (16 * 25000) + 1800000, '2024-09-01', 6, 4),
    (3* 4 * 25000, 25000, 2200000, (21 * 25000) + 2200000, '2024-09-01', 3, 5),
    (3* 4 * 25000, 25000, 1700000, (19 * 25000) + 1700000, '2024-09-01', 3, 6),
    (6* 4 * 25000, 25000, 2300000, (20 * 25000) + 2300000, '2024-10-01', 6, 7),
    (3* 4 * 25000, 25000, 1600000, (17 * 25000) + 1600000, '2024-10-01', 3, 8),
    (3* 4 * 25000, 25000, 2100000, (20 * 25000) + 2100000, '2024-10-01', 3, 9),
    (6* 4 * 25000, 25000, 1900000, (18 * 25000) + 1900000, '2024-10-01', 6, 10);



