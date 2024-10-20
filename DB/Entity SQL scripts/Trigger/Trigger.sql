CREATE TRIGGER trg_CapNhatLuong
ON CoLichLam
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE Luong
    SET 
        -- Tính tổng số giờ làm việc dựa trên thời gian của các ca làm việc
        Luong = LuongGio * (SELECT SUM(DATEDIFF(MINUTE, clv.GioBatDau, clv.GioKetThuc)) / 60.0
                             FROM CoLichLam cl
                             JOIN LichLamViec llv ON cl.MaLichLamViec = llv.MaLichLamViec
                             JOIN CaLamViec clv ON llv.MaCa = clv.MaCa
                             WHERE cl.MaNhanVien = inserted.MaNhanVien
							 AND cl.TrangThai = 'HoanThanh'
                             AND MONTH(llv.NgayLam) = MONTH(l.ThoiGian)
                             AND YEAR(llv.NgayLam) = YEAR(l.ThoiGian)),
        
        -- Tính tổng nhận = Lương + Thưởng
        TongNhan = Luong + Thuong
    FROM Luong l, inserted
    WHERE l.MaNhanVien = (SELECT MaNhanVien FROM inserted);
	PRINT 'Da cap nhat Luong va TongNhan trong bang Luong'
END;
GO

CREATE TRIGGER trg_CapNhatLuongKhiXoa
ON CoLichLam
AFTER DELETE
AS
BEGIN
    -- Cập nhật lại lương cho nhân viên dựa trên tổng thời gian các ca đã hoàn thành
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
	PRINT 'Da cap nhat Luong va TongNhan trong bang Luong'
END;



