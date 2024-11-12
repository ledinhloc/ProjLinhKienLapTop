
--khi thay doi trong CoLichLam la hoan thành thì tính lại lương
CREATE TRIGGER trg_CapNhatLuong
ON CoLichLam
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @LuongMoi DECIMAL(15,2);
	DECLARE @Ngay DATE;

	SELECT @Ngay = NgayLam
	FROM inserted JOIN LichLamViec ON inserted.MaLichLamViec = LichLamViec.MaLichLamViec

    UPDATE Luong
    SET 
        -- Tính tổng số giờ làm việc dựa trên thời gian của các ca làm việc
        @LuongMoi = (LuongGio * (SELECT SUM(DATEDIFF(MINUTE, clv.GioBatDau, clv.GioKetThuc)) / 60.0
                             FROM CoLichLam cl
                             JOIN LichLamViec llv ON cl.MaLichLamViec = llv.MaLichLamViec
                             JOIN CaLamViec clv ON llv.MaCa = clv.MaCa
                             WHERE cl.MaNhanVien = inserted.MaNhanVien
							 AND cl.TrangThai = 'HoanThanh'
                             AND MONTH(llv.NgayLam) = MONTH(l.ThoiGian)
                             AND YEAR(llv.NgayLam) = YEAR(l.ThoiGian)) ),        
        -- Tính tổng nhận = Lương + Thưởng

        TongNhan = @LuongMoi + Thuong,
		Luong = @LuongMoi
    FROM Luong l, inserted
    WHERE l.MaNhanVien = inserted.MaNhanVien
		AND MONTH(l.ThoiGian) = MONTH(@Ngay) AND YEAR(l.ThoiGian) = YEAR(@Ngay);
END;

GO
--khi xoa CoLichLam thi tinh lai luong
CREATE TRIGGER trg_CapNhatLuongKhiXoa
ON CoLichLam
AFTER DELETE
AS
BEGIN
	DECLARE @LuongMoi DECIMAL(15,2);
	DECLARE @Ngay DATE;

	SELECT @Ngay = NgayLam
	FROM deleted JOIN LichLamViec ON deleted.MaLichLamViec = LichLamViec.MaLichLamViec

    UPDATE Luong
    SET 
        -- Tính tổng số giờ làm việc dựa trên thời gian của các ca làm việc
        @LuongMoi = (LuongGio * (SELECT SUM(DATEDIFF(MINUTE, clv.GioBatDau, clv.GioKetThuc)) / 60.0
                             FROM CoLichLam cl
                             JOIN LichLamViec llv ON cl.MaLichLamViec = llv.MaLichLamViec
                             JOIN CaLamViec clv ON llv.MaCa = clv.MaCa
                             WHERE cl.MaNhanVien = deleted.MaNhanVien
							 AND cl.TrangThai = 'HoanThanh'
                             AND MONTH(llv.NgayLam) = MONTH(l.ThoiGian)
                             AND YEAR(llv.NgayLam) = YEAR(l.ThoiGian))),        
        -- Tính tổng nhận = Lương + Thưởng

        TongNhan = @LuongMoi + Thuong,
		Luong = @LuongMoi
    FROM Luong l, deleted
    WHERE l.MaNhanVien = deleted.MaNhanVien
		AND MONTH(l.ThoiGian) = MONTH(@Ngay) AND YEAR(l.ThoiGian) = YEAR(@Ngay);
END;

GO
--sau khi inset, update CoLichLam thi tinh lai SoCa trong bang luong
CREATE TRIGGER trg_CapNhatSoCaTrongLuong
ON CoLichLam
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE l
    SET 
        SoCa = (SELECT COUNT(*)
                FROM CoLichLam cll
                JOIN LichLamViec llv ON cll.MaLichLamViec = llv.MaLichLamViec
                WHERE cll.MaNhanVien = i.MaNhanVien
                AND cll.TrangThai = 'HoanThanh'
                AND MONTH(llv.NgayLam) = MONTH(l.ThoiGian)
                AND YEAR(llv.NgayLam) = YEAR(l.ThoiGian))
    FROM Luong l
    JOIN inserted i ON l.MaNhanVien = i.MaNhanVien;
END;

GO

CREATE TRIGGER trg_TrungLichLamViec
ON dbo.LichLamViec
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN dbo.LichLamViec llv ON  i.MaLichLamViec <> llv.MaLichLamViec 
                       AND i.NgayLam = llv.NgayLam AND i.MaCa = llv.MaCa 
    )
    BEGIN
        -- Nếu trùng, raise lỗi và rollback
        RAISERROR ('Ca lam trong ngay nay da ton tai!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END

GO
