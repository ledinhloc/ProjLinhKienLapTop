USE [LinhkienLaptop]
GO

CREATE PROC sp_TimKiemLoaiLinhKienTheoID @MaLLK INT
AS
BEGIN
	SELECT TenLoaiLinhKien
	FROM LoaiLinhKien
	WHERE MaLoaiLinhKien = @MaLLK
END
GO
