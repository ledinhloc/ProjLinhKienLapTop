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
    ('SSD 256GB Samsung', 'SSD 256GB cho laptop, thuong hieu Samsung.', 'ssd_256gb_samsung.jpg', 1200000, 1000000, 25, 5, 5),
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

INSERT INTO DonHang (NgayDatHang, MaKhachHang, MaNhanVien, MaGiamGia, TongGiaTri, PhuongThuc) 
VALUES 
    ('2024-01-12', 1, 1, 1, 850000, 'Chuyen Khoan'),
    ('2024-02-14', 2, 2, 2, 2400000, 'Tien Mat'),
    ('2024-03-20', 3, 3, 3, 1200000, 'Chuyen Khoan'),
    ('2024-04-10', 4, 4, 4, 3000000, 'Tien Mat'),
    ('2024-05-05', 5, 5, 5, 2100000, 'Chuyen Khoan'),
    ('2024-06-18', 6, 6, 6, 2760000, 'Tien Mat'),
    ('2024-07-22', 7, 7, 7, 1500000, 'Chuyen Khoan'),
    ('2024-08-08', 8, 8, 8, 1840000, 'Tien Mat'),
    ('2024-09-15', 9, 9, 9, 4500000, 'Chuyen Khoan'),
    ('2024-10-05', 10, 10, 10, 2100000, 'Tien Mat');
GO

INSERT INTO DonHang (NgayDatHang, MaKhachHang, MaNhanVien, MaGiamGia, TongGiaTri, PhuongThuc) 
VALUES 
    ('2024-01-20', 1, 2, 3, 5000000, 'Tien Mat'),
    ('2024-02-25', 3, 4, 5, 8000000, 'Chuyen Khoan'),
    ('2024-03-30', 5, 6, 7, 3500000, 'Tien Mat'),
    ('2024-04-15', 7, 8, 9, 9000000, 'Chuyen Khoan'),
    ('2024-05-05', 2, 1, 4, 4500000, 'Tien Mat');
GO

INSERT INTO ChiTietDonHang (MaDonHang, MaLinhKien, SoLuong, GiaBan) 
VALUES 
    (1, 1, 2, 2500000),
    (2, 2, 1, 1500000),
    (3, 3, 4, 1000000),
    (4, 4, 1, 4500000),
    (5, 5, 1, 1200000),
    (6, 6, 3, 2700000),
    (7, 7, 2, 1800000),
    (8, 8, 2, 2000000),
    (9, 9, 1, 5000000),
    (10, 10, 1, 2000000),
	(11, 1, 2, 2500000), 
    (11, 2, 1, 1500000), 
    (12, 3, 2, 1000000), 
    (12, 4, 1, 4500000), 
    (13, 5, 1, 1200000), 
    (13, 6, 2, 2700000), 
    (14, 7, 1, 1800000), 
    (14, 8, 1, 2000000), 
    (15, 9, 1, 5000000), 
    (15, 10, 1, 2000000);
GO

INSERT INTO CaLamViec (TenCa, GioBatDau, GioKetThuc)
VALUES ( N'Ca Sáng', '08:00', '12:00'),
		( N'Ca Chiều', '13:00', '17:00'),
		( N'Ca Tối', '18:00', '22:00');
GO

INSERT INTO LichLamViec (NgayLam, MaCa) 
VALUES 
    ('2024-01-01', 1),
    ('2024-01-01', 2),
    ('2024-01-01', 3),
    ('2024-01-02', 1),
    ('2024-01-02', 2),
    ('2024-01-02', 3),
    ('2024-01-03', 1),
    ('2024-01-03', 2),
    ('2024-01-03', 3),
    ('2024-01-04', 1);

GO
INSERT INTO LichLamViec (NgayLam, MaCa) 
VALUES 
    ('2024-09-25', 1),
    ('2024-09-25', 2),
    ('2024-09-25', 3),
    ('2024-09-26', 1),
    ('2024-09-26', 2),
    ('2024-09-26', 3),
    ('2024-09-27', 1),
    ('2024-09-27', 2),
    ('2024-09-27', 3),
    ('2024-09-28', 1),
    ('2024-09-28', 2),
    ('2024-09-28', 3),
    ('2024-09-29', 1),
    ('2024-09-29', 2),
    ('2024-09-29', 3),
    ('2024-09-30', 1),
    ('2024-09-30', 2),
    ('2024-09-30', 3),
    ('2024-10-01', 1),
    ('2024-10-01', 2),
    ('2024-10-01', 3),
	('2024-10-02', 1),
    ('2024-10-02', 2),
    ('2024-10-02', 3),
    ('2024-10-03', 1),
    ('2024-10-03', 2),
    ('2024-10-03', 3),
    ('2024-10-04', 1),
    ('2024-10-04', 2),
    ('2024-10-04', 3),
    ('2024-10-05', 1),
    ('2024-10-05', 2),
    ('2024-10-05', 3),
    ('2024-10-06', 1),
    ('2024-10-06', 2),
    ('2024-10-06', 3),
    ('2024-10-07', 1),
    ('2024-10-07', 2),
    ('2024-10-07', 3),
    ('2024-10-08', 1),
    ('2024-10-08', 2),
    ('2024-10-08', 3);
GO

INSERT INTO CoLichLam (MaNhanVien, MaLichLamViec, DanhGia, TrangThai) 
VALUES 
    (1, 1, 'Rất tốt', 'HoanThanh'),
    (2, 1, 'Tốt', 'HoanThanh'),
    (3, 2, 'Khá', 'Chua'),
    (4, 2, 'Tốt', 'HoanThanh'),
    (5, 3, 'Rất tốt', 'HoanThanh'),
    (6, 3, 'Khá', 'Chua'),
    (7, 4, 'Tốt', 'HoanThanh'),
    (8, 4, 'Rất tốt', 'HoanThanh'),
    (9, 5, 'Khá', 'Chua'),
    (10, 5, 'Tốt', 'HoanThanh'),
    (1, 6, 'Rất tốt', 'HoanThanh'),
    (2, 6, 'Khá', 'Chua'),
    (3, 7, 'Tốt', 'HoanThanh'),
    (4, 7, 'Rất tốt', 'HoanThanh'),
    (5, 8, 'Khá', 'Chua'),
    (6, 8, 'Tốt', 'HoanThanh'),
    (7, 9, 'Rất tốt', 'HoanThanh'),
    (8, 9, 'Khá', 'Chua'),
    (9, 10, 'Tốt', 'HoanThanh'),
    (10, 10, 'Rất tốt', 'HoanThanh'),
	(1, 11, 'Rất tốt', 'HoanThanh'),
    (2, 11, 'Tốt', 'HoanThanh'),
    (3, 12, 'Khá', 'Chua'),
    (4, 12, 'Tốt', 'HoanThanh'),
    (5, 13, 'Rất tốt', 'HoanThanh'),
    (6, 13, 'Khá', 'Chua'),
    (7, 14, 'Tốt', 'HoanThanh'),
    (8, 14, 'Rất tốt', 'HoanThanh'),
    (9, 15, 'Khá', 'Chua'),
    (10, 15, 'Tốt', 'HoanThanh'),
    (1, 16, 'Rất tốt', 'HoanThanh'),
    (2, 16, 'Khá', 'Chua'),
    (3, 17, 'Tốt', 'HoanThanh'),
    (4, 17, 'Rất tốt', 'HoanThanh'),
    (5, 18, 'Khá', 'Chua'),
    (6, 18, 'Tốt', 'HoanThanh'),
    (7, 19, 'Rất tốt', 'HoanThanh'),
    (8, 19, 'Khá', 'Chua'),
    (9, 20, 'Tốt', 'HoanThanh'),
    (10, 20, 'Rất tốt', 'HoanThanh'),
    (1, 21, 'Rất tốt', 'HoanThanh'),
    (2, 21, 'Tốt', 'HoanThanh'),
    (3, 22, 'Khá', 'Chua'),
    (4, 22, 'Tốt', 'HoanThanh'),
    (5, 23, 'Rất tốt', 'HoanThanh'),
    (6, 23, 'Khá', 'Chua'),
    (7, 24, 'Tốt', 'HoanThanh'),
    (8, 24, 'Rất tốt', 'HoanThanh'),
    (9, 25, 'Khá', 'Chua'),
    (10, 25, 'Tốt', 'HoanThanh'),
    (1, 26, 'Rất tốt', 'HoanThanh'),
    (2, 26, 'Khá', 'Chua'),
    (3, 27, 'Tốt', 'HoanThanh'),
    (4, 27, 'Rất tốt', 'HoanThanh'),
    (5, 28, 'Khá', 'Chua'),
    (6, 28, 'Tốt', 'HoanThanh'),
    (7, 29, 'Rất tốt', 'HoanThanh'),
    (8, 29, 'Khá', 'Chua'),
    (9, 30, 'Tốt', 'HoanThanh'),
    (10, 30, 'Rất tốt', 'HoanThanh');
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



