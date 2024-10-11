
USE Linhkiendientu

CREATE TABLE NhaCungCap (
    MaNhaCungCap INT PRIMARY KEY,
    TenNhaCungCap NVARCHAR(100),
    DiaChi NVARCHAR(255),
    SDT NVARCHAR(15),
    Email NVARCHAR(100)
);
CREATE TABLE LoaiLinhKien (
    MaLoaiLinhKien INT PRIMARY KEY,
    TenLoaiLinhKien NVARCHAR(100)
);
CREATE TABLE LinhKien (
    MaLinhKien INT PRIMARY KEY,
    TenLinhKien NVARCHAR(100),
    MoTaChiTiet NVARCHAR(255),
    HinhAnh NVARCHAR(255),
    GiaBan DECIMAL(10, 2),
    GiaNhap DECIMAL(10, 2),
    SoLuongTonKho INT,
    MaLoaiLinhKien INT,
    MaNhaCungCap INT,
    FOREIGN KEY (MaLoaiLinhKien) REFERENCES LoaiLinhKien(MaLoaiLinhKien),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);

CREATE TABLE PhieuNhapHang (
    MaPhieuNhap INT PRIMARY KEY,
    NgayNhap DATE,
    GiaNhap DECIMAL(10, 2),
    SoLuong INT,
    MaLinhKien INT,
    FOREIGN KEY (MaLinhKien) REFERENCES LinhKien(MaLinhKien)
);
CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY,
    TenKhachHang NVARCHAR(100),
    DiaChi NVARCHAR(255),
    SDT NVARCHAR(15),
    Email NVARCHAR(100),
    NgaySinh DATE
);
CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY,
    TenNhanVien NVARCHAR(100),
    SDT NVARCHAR(15),
    Email NVARCHAR(100),
    NgaySinh DATE,
    DiaChi NVARCHAR(255),
    MatKhau NVARCHAR(100)
);
CREATE TABLE DonHang (
    MaDonHang INT PRIMARY KEY,
    NgayDatHang DATE,
    MaKhachHang INT,
    TongGiaTri DECIMAL(10, 2),
    PhuongThuc NVARCHAR(100),
    MaNhanVien INT,
    GiamGia DECIMAL(5, 2),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
CREATE TABLE ChiTietDonHang (
    MaDonHang INT,
    MaLinhKien INT,
    SoLuong INT,
    GiaBan DECIMAL(10, 2),
    PRIMARY KEY (MaDonHang, MaLinhKien),
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
    FOREIGN KEY (MaLinhKien) REFERENCES LinhKien(MaLinhKien)
);

CREATE TABLE CaLamViec (
    MaCa INT PRIMARY KEY,
    TenCa NVARCHAR(100),
    GioBatDau TIME,
    GioKetThuc TIME
);
CREATE TABLE Luong (
    MaLuong INT PRIMARY KEY,
    Luong DECIMAL(10, 2),
    Thuong DECIMAL(10, 2),
    ThoiGian DATE,
    SoCa INT,
    MaNhanVien INT,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
CREATE TABLE LichLamViec (
    MaLichLamViec INT PRIMARY KEY,
    NgayLam DATE,
    MaCa INT,
    FOREIGN KEY (MaCa) REFERENCES CaLamViec(MaCa)
);
CREATE TABLE CoLichLam (
    MaNhanVien INT,
    MaLichLamViec INT,
    DanhGia NVARCHAR(255),
    TrangThai NVARCHAR(100),
    PRIMARY KEY (MaNhanVien, MaLichLamViec),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaLichLamViec) REFERENCES LichLamViec(MaLichLamViec)
);
CREATE TABLE GiamGia (
    MaGiamGia INT PRIMARY KEY,
    TenGiamGia NVARCHAR(100),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    GiaTri DECIMAL(5, 2)
);

