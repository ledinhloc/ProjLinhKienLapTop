CREATE DATABASE LinhkienLaptop;
GO
USE LinhkienLaptop; 

GO

CREATE TABLE NhaCungCap (
    MaNhaCungCap INT PRIMARY KEY IDENTITY(1,1),
    TenNhaCungCap NVARCHAR(255) NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    SDT NVARCHAR(10) NOT NULL CHECK (SDT LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    Email NVARCHAR(100) NOT NULL CHECK (Email LIKE '%_@__%.__%'),
);
GO

CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY IDENTITY(1,1),
    TenKhachHang NVARCHAR(255) NOT NULL,
	DiaChi NVARCHAR(255) NOT NULL,
    SDT NVARCHAR(10) NOT NULL  CHECK (SDT LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    Email NVARCHAR(100) NOT NULL CHECK (Email LIKE '%_@__%.__%'),
    NgaySinh DATE NOT NULL CHECK (NgaySinh < GETDATE())
);
GO
CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY IDENTITY(1,1),
    TenNhanVien NVARCHAR(255) NOT NULL,
	ChucVu NVARCHAR(50) NOT NULL,
	DiaChi NVARCHAR(255) NOT NULL,
    SDT NVARCHAR(15) NOT NULL  CHECK (SDT LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	Email NVARCHAR(100) NOT NULL CHECK (Email LIKE '%_@__%.__%'),
	MatKhau NVARCHAR(100) NOT NULL,
    NgaySinh DATE CHECK (DATEDIFF(YEAR, NgaySinh, GETDATE()) >= 18),
);
GO
CREATE TABLE LoaiLinhKien (
    MaLoaiLinhKien INT PRIMARY KEY IDENTITY(1,1),
    TenLoaiLinhKien NVARCHAR(255) NOT NULL
);
GO
CREATE TABLE LinhKien (
    MaLinhKien INT PRIMARY KEY IDENTITY(1,1),
    TenLinhKien NVARCHAR(255) NOT NULL,
	MoTaChiTiet NVARCHAR(1000) NOT NULL, 
	HinhAnh NVARCHAR(255), 
    GiaBan DECIMAL(15, 2) NOT NULL CHECK (GiaBan > 0),
    GiaNhap DECIMAL(15, 2) NOT NULL CHECK (GiaNhap > 0),
    SoLuongTonKho INT NOT NULL CHECK (SoLuongTonKho >= 0),
    MaLoaiLinhKien INT,
    MaNhaCungCap INT,
    FOREIGN KEY (MaLoaiLinhKien) REFERENCES LoaiLinhKien(MaLoaiLinhKien),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);
GO
CREATE TABLE PhieuNhapHang (
    MaPhieuNhap INT PRIMARY KEY IDENTITY(1,1),
	NgayNhap DATE NOT NULL,
    GiaNhap DECIMAL(15, 2) CHECK (GiaNhap >= 0),
    SoLuong INT CHECK (SoLuong > 0),
    MaLinhKien INT,
    FOREIGN KEY (MaLinhKien) REFERENCES LinhKien(MaLinhKien)
);
GO
CREATE TABLE GiamGia (
    MaGiamGia INT PRIMARY KEY IDENTITY(1,1),
    TenGiamGia NVARCHAR(255) NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    GiaTri DECIMAL(5, 2) NOT NULL CHECK (GiaTri BETWEEN 0 AND 100),
    CONSTRAINT check_ngay CHECK (NgayBatDau < NgayKetThuc)
);
GO
CREATE TABLE DonHang (
    MaDonHang INT PRIMARY KEY IDENTITY(1,1),
	NgayDatHang DATE NOT NULL,
    MaKhachHang INT,
    MaNhanVien INT,
    MaGiamGia INT,
    TongGiaTri DECIMAL(15, 2) CHECK (TongGiaTri > 0),
    PhuongThuc NVARCHAR(100) NOT NULL,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaGiamGia) REFERENCES GiamGia(MaGiamGia)
);
GO
CREATE TABLE ChiTietDonHang (
    MaDonHang INT,
    MaLinhKien INT,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    GiaBan DECIMAL(15, 2) NOT NULL CHECK (GiaBan >= 0),
    PRIMARY KEY (MaDonHang, MaLinhKien),
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
    FOREIGN KEY (MaLinhKien) REFERENCES LinhKien(MaLinhKien)
);
GO
CREATE TABLE CaLamViec (
    MaCa INT PRIMARY KEY IDENTITY(1,1),
    TenCa NVARCHAR(100) NOT NULL,
    GioBatDau TIME NOT NULL,
    GioKetThuc TIME NOT NULL,
    CONSTRAINT check_gio CHECK (GioBatDau < GioKetThuc)
);
GO
CREATE TABLE Luong (
    MaLuong INT PRIMARY KEY IDENTITY(1,1),
    Luong DECIMAL(15, 2) CHECK (Luong >= 0),
	LuongGio DECIMAL(15, 2) CHECK (LuongGio >= 0),
    Thuong DECIMAL(15, 2) CHECK (Thuong >= 0),
	TongNhan DECIMAL(15, 2),
    ThoiGian DATE CHECK (ThoiGian <= GETDATE()),
    SoCa INT CHECK (SoCa >= 0),
    MaNhanVien INT,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO
CREATE TABLE LichLamViec (
    MaLichLamViec INT PRIMARY KEY IDENTITY(1,1),
    NgayLam DATE NOT NULL,
    MaCa INT ,
    FOREIGN KEY (MaCa) REFERENCES CaLamViec(MaCa)
);
GO
CREATE TABLE CoLichLam (
    MaNhanVien INT,
    MaLichLamViec INT,
    DanhGia NVARCHAR(255),
    TrangThai NVARCHAR(100),
    PRIMARY KEY (MaNhanVien, MaLichLamViec),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaLichLamViec) REFERENCES LichLamViec(MaLichLamViec)
);
GO