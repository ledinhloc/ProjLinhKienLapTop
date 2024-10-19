--CaLamViec (MaCa, TenCa, GioBatDau, GioKetThuc)

CREATE VIEW vw_LuongChiTiet
AS
SELECT nv.MaNhanVien, nv.TenNhanVien, l.ThoiGian, l.Luong, l.Thuong, l.TongNhan
FROM NhanVien nv
JOIN Luong l ON nv.MaNhanVien = l.MaNhanVien;


GO
--xem ca lam viec cua nhan vien 
CREATE VIEW vw_CaLamViecNhanVien
AS
SELECT nv.MaNhanVien, nv.TenNhanVien, llv.NgayLam, clv.TenCa, clv.GioBatDau, clv.GioKetThuc
FROM NhanVien nv
JOIN CoLichLam cl ON nv.MaNhanVien = cl.MaNhanVien
JOIN LichLamViec llv ON cl.MaLichLamViec = llv.MaLichLamViec
JOIN CaLamViec clv ON llv.MaCa = clv.MaCa
WHERE cl.TrangThai = 'HoanThanh';


--view xem ca lam viec
CREATE VIEW vw_XemCaLam
AS
SELECT *
FROM CaLamViec

select * from vw_XemCaLam

--them
CREATE PROCEDURE sp_ThemCaLamViec
    @MaCa INT,
    @TenCa NVARCHAR(100),
    @GioBatDau TIME,
    @GioKetThuc TIME
AS
BEGIN
    INSERT INTO CaLamViec (MaCa, TenCa, GioBatDau, GioKetThuc)
    VALUES (@MaCa, @TenCa, @GioBatDau, @GioKetThuc);
END

--sua
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
END

--xoa
CREATE PROCEDURE sp_XoaCaLamViec 
@MaCa INT
AS
BEGIN
    DELETE FROM CaLamViec
    WHERE MaCa = @MaCa;
END

--Luong(MaLuong, Luong, Thuong, ThoiGian, SoCA, MaNhanVien)

select * from NhanVien

--them
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

--sua
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

--xoa
CREATE PROCEDURE sp_XoaLuong
    @MaLuong INT
AS
BEGIN
    DELETE FROM Luong
    WHERE MaLuong = @MaLuong;
END;

--Function
CREATE FUNCTION fn_XemLuongTheoNhanVien
(
    @MaNhanVien INT,
    @NgayBD DATE,
    @NgayKT DATE
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
        AND ThoiGian BETWEEN @NgayBD AND @NgayKT
);


INSERT INTO Luong (Luong, LuongGio, Thuong, TongNhan, ThoiGian, SoCa, MaNhanVien)
VALUES
    (22 * 25000, 25000, 1000000, (22 * 25000) + 1000000, '2024-06-01', 22, 1),
    (23 * 25000, 25000, 1200000, (23 * 25000) + 1200000, '2024-07-01', 23, 1),
    (24 * 25000, 25000, 1500000, (24 * 25000) + 1500000, '2024-08-01', 24, 1);


DELETE FROM Luong WHERE MaLuong = 15
SELECT * FROM dbo.fn_XemLuongTheoNhanVien(1,'2024-07-01','2024-12-01');

GO
--
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
        nv.TenNV
    FROM 
        Luong l
    JOIN 
        NhanVien nv ON l.MaNhanVien = nv.MaNhanVien
    WHERE 
        MONTH(l.ThoiGian) = @Thang AND
        YEAR(l.ThoiGian) = @Nam
);

SELECT * FROM dbo.fn_XemTatCaLuongTheoThangNam(9, 2024);









