CREATE VIEW vw_XemLinhKien as
SELECT lk.MaLinhKien 'Mã Linh Kiện', lk.TenLinhKien 'Tên Linh Kiện', llk.TenLoaiLinhKien 'Loại Linh Kiện', lk.GiaBan 'Gía Bán', lk.SoLuongTonKho 'Số Lượng Tồn Kho' 
FROM dbo.LinhKien lk
join dbo.LoaiLinhKien llk
on lk.MaLoaiLinhKien = llk.MaLoaiLinhKien
GO



-- Xóa linh kiện
ALTER PROCEDURE [dbo].[sp_XoaLinhKien]
    @MaLinhKien INT
AS
BEGIN
	UPDATE LinhKien SET SoLuongTonKho = 0 WHERE MaLinhKien = @MaLinhKien;
END;
GO

Create PROCEDURE [dbo].[sp_TimKiemLinhKienTheoID]
    @MaLinhKien INT
AS
BEGIN
    SELECT * FROM dbo.LinhKien
    WHERE MaLinhKien = @MaLinhKien;
END;


