CREATE TRIGGER trg_SendEmailOnInsertCoLichLam
ON CoLichLam
AFTER INSERT
AS
BEGIN
    DECLARE @MaNhanVien INT;
    DECLARE @DanhGia NVARCHAR(255);
    DECLARE @TrangThai NVARCHAR(100);
    DECLARE @NgayLam DATE; -- Thêm trường NgayLam
    DECLARE @Email NVARCHAR(100);
    DECLARE @Subject NVARCHAR(255);
    DECLARE @Body NVARCHAR(MAX);

    -- Lấy thông tin nhân viên, đánh giá, trạng thái và ngày làm từ bảng inserted và LichLamViec
    SELECT 
        @MaNhanVien = c.MaNhanVien,
        @DanhGia = c.DanhGia,
        @TrangThai = c.TrangThai,
        @NgayLam = l.NgayLam -- JOIN để lấy ngày làm từ bảng LichLamViec
    FROM inserted c
    JOIN LichLamViec l ON c.MaLichLamViec = l.MaLichLamViec;

    -- Lấy địa chỉ email của nhân viên từ bảng NhanVien
    SELECT @Email = Email
    FROM NhanVien
    WHERE MaNhanVien = @MaNhanVien;

    -- Tạo chủ đề và nội dung email
    SET @Subject = N'Thông báo về lịch làm việc';
    SET @Body = N'Kính gửi nhân viên,<br>' +  
                N'Bạn đã được thêm vào lịch làm việc. Dưới đây là thông tin chi tiết: <br>' +  
				N'Ngày làm: ' + CONVERT(NVARCHAR, @NgayLam, 103) + '<br>' +  
                N'Trạng Thái: ' + @TrangThai + '<br>' +  
                N'Xin vui lòng kiểm tra và xác nhận thông tin.<br>' +  
                N'Trân trọng!';

    -- Gửi email sử dụng Database Mail
    EXEC msdb.dbo.sp_send_dbmail
        @profile_name = 'GuiMail',  -- Tên profile của Database Mail
        @recipients = @Email,              -- Địa chỉ email của nhân viên
        @subject = @Subject,               -- Chủ đề email
        @body = @Body,                     -- Nội dung email
        @body_format = 'HTML';             -- Định dạng HTML để hỗ trợ ký tự đặc biệt
END;
