EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;
EXEC sp_configure 'Database Mail XPs', 1;
RECONFIGURE;

EXEC msdb.dbo.sysmail_add_account_sp
    @account_name = 'TienDung',                      -- Tên của account
    @description = 'EmailThongBaoLichLam',            -- Mô tả account
    @email_address = 'nguyentiendung17062k4@gmail.com',        -- Địa chỉ email gửi đi
    @display_name = 'Manager',                   -- Tên người gửi hiển thị trong email
    @replyto_address = 'nguyentiendung17062k4@gmail.com',  -- Địa chỉ email phản hồi (tùy chọn)
    @mailserver_name = 'smtp.gmail.com',             -- Tên hoặc địa chỉ IP của SMTP server
    @port = 587,                                      -- Cổng SMTP server (ví dụ: 587 cho TLS, 465 cho SSL)
    @enable_ssl = 1,                                  -- Bật SSL (1 là có, 0 là không)
    @username = 'nguyentiendung17062k4@gmail.com',                      -- Tên đăng nhập SMTP (nếu cần)
    @password = 'dycb odue fdqw yjlv';                      -- Mật khẩu SMTP (nếu cần)

EXEC msdb.dbo.sysmail_add_profile_sp
    @profile_name = 'GuiMail',                     -- Tên profile
    @description = 'ThongBao';    

EXEC msdb.dbo.sysmail_add_profileaccount_sp
    @profile_name = 'GuiMail',                     -- Tên profile vừa tạo
    @account_name = 'TienDung',                     -- Tên account vừa tạo
    @sequence_number = 1;                             -- Thứ tự ưu tiên của account (1 là ưu tiên nhất)

EXEC msdb.dbo.sysmail_add_principalprofile_sp
    @profile_name = 'GuiMail', 
    @principal_name = 'public',                       -- Chỉ định là 'public' cho phép mọi người dùng
    @is_default = 1;           
Go
CREATE TRIGGER trg_SendEmailOnInsertCoLichLam
ON CoLichLam
AFTER INSERT
AS
BEGIN
    DECLARE @MaNhanVien INT;
    DECLARE @DanhGia NVARCHAR(255);
    DECLARE @TrangThai NVARCHAR(100);
    DECLARE @NgayLam DATE;
    DECLARE @Email NVARCHAR(100);
    DECLARE @TenCa NVARCHAR(100);
    DECLARE @BatDau TIME;
    DECLARE @KetThuc TIME;
    DECLARE @Subject NVARCHAR(255);
    DECLARE @Body NVARCHAR(MAX);

    -- Lấy thông tin từ bảng inserted, LichLamViec, và CaLamViec
    SELECT 
        @MaNhanVien = c.MaNhanVien,
        @DanhGia = c.DanhGia,
        @TrangThai = c.TrangThai,
        @NgayLam = l.NgayLam,
        @TenCa = clv.TenCa,
        @BatDau = clv.GioBatDau,
        @KetThuc = clv.GioKetThuc
    FROM inserted c
    JOIN LichLamViec l ON c.MaLichLamViec = l.MaLichLamViec
    JOIN CaLamViec clv ON l.MaCa = clv.MaCa;

    -- Lấy địa chỉ email từ bảng NhanVien
    SELECT @Email = Email
    FROM NhanVien
    WHERE MaNhanVien = @MaNhanVien;

    -- Tạo chủ đề và nội dung email
    SET @Subject = N'Thông báo về lịch làm việc';
    SET @Body = N'Gửi nhân viên,<br>' +  
                N'Bạn đã được thêm vào lịch làm việc. Dưới đây là thông tin chi tiết: <br>' +  
                N'Ngày làm: ' + CONVERT(NVARCHAR, @NgayLam, 103) + '<br>' +
                N'Tên ca: ' + @TenCa + '<br>' +
                N'Giờ làm: ' + CONVERT(NVARCHAR, @BatDau, 108) + ' - ' + CONVERT(NVARCHAR, @KetThuc, 108) + '<br>' +
                N'Trạng Thái: ' + @TrangThai + '<br>' +  
                N'Xin vui lòng kiểm tra và xác nhận thông tin.<br>' +  
                N'Trân trọng!';

    -- Gửi email sử dụng Database Mail
    EXEC msdb.dbo.sp_send_dbmail
        @profile_name = 'GuiMail',        -- Tên profile của Database Mail
        @recipients = @Email,             -- Địa chỉ email của nhân viên
        @subject = @Subject,              -- Chủ đề email
        @body = @Body,                    -- Nội dung email
        @body_format = 'HTML';            -- Định dạng HTML để hỗ trợ ký tự đặc biệt
END;
Go