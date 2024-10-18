--LichLamViec(MaLichLamViec, NgayLam, MaCa)
select * from LichLamViec

--them
CREATE PROCEDURE sp_ThemLichLamViec
    @MaLichLamViec INT,
    @NgayLam DATE,
    @MaCa INT
AS
BEGIN
    INSERT INTO LichLamViec (MaLichLamViec, NgayLam, MaCa)
    VALUES (@MaLichLamViec, @NgayLam, @MaCa);
END;

--sua
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

--xoa
CREATE PROCEDURE sp_XoaLichLamViec
    @MaLichLamViec INT
AS
BEGIN
    DELETE FROM LichLamViec
    WHERE MaLichLamViec = @MaLichLamViec;
END;

--CoLichLam(MaNhanVien, MaLichLamViec, DanhGia, TrangThai)

--them
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

--sua
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

--xoa
CREATE PROCEDURE sp_XoaCoLichLam
    @MaNhanVien INT,
    @MaLichLamViec INT
AS
BEGIN
    DELETE FROM CoLichLam
    WHERE MaNhanVien = @MaNhanVien AND MaLichLamViec = @MaLichLamViec;
END;

--Func
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

SELECT * FROM dbo.XemCaLamViecCuaNhanVien(1); 
--
CREATE FUNCTION dbo.fn_XemNhanVienTrongCaLam (@MaCa int, @ngay date)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        nv.TenNV,
		cll.DanhGia,
		cll.TrangThai,
        clv.TenCa,
        clv.GioBatDau,
        clv.GioKetThuc
    FROM 
        NhanVien nv
	JOIN CoLichLam cll on nv.MaNhanVien = cll.MaNhanVien
	JOIN LichLamViec llv on cll.MaLichLamViec = llv.MaLichLamViec
	JOIN CaLamViec clv on clv.MaCa = llv.MaCa
    WHERE 
        clv.MaCa = @MaCa AND llv.NgayLam = @ngay
);

SELECT * FROM dbo.fn_XemNhanVienTrongCaLam(1, '2024-10-01'); 