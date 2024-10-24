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

--khi them hoac thay doi trang thai CoLichLam thi Cap Nhat lai
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
    
    PRINT 'Đã cập nhật SoCa trong bảng Luong';
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

-- trigger kiem tra co lich lam viec bị trung khong (cung ngay, cung ca)
CREATE TRIGGER TG_TrungLichLamViec
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

-- trigger khi them colichlam cho nhan vien se them neu da them thi khong them nua
CREATE TRIGGER trg_KiemTraKhiThemLuong
ON dbo.Luong
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN dbo.Luong l ON  i.MaLuong <> l.MaLuong 
                       AND i.MaNhanVien = l.MaNhanVien
                       AND i.ThoiGian = l.ThoiGian
    )
    BEGIN
        -- Nếu trùng rollback
        ROLLBACK TRANSACTION;
    END
END
