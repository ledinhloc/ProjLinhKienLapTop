CREATE FUNCTION dbo.fn_TongSoDonHang(
    @start DATE,
    @end DATE
)
RETURNS INT
AS
BEGIN
    DECLARE @TongSoDonHang INT;
    SELECT @TongSoDonHang = COUNT(*)
    FROM DonHang
    WHERE NgayDatHang BETWEEN @start AND @end;
    RETURN @TongSoDonHang;
END;

GO
CREATE FUNCTION dbo.fn_DoanhThu(
    @start DATE,
    @end DATE
)
RETURNS DECIMAL(15, 2)
AS
BEGIN
    DECLARE @DoanhThu DECIMAL(15, 2);
    SELECT @DoanhThu = SUM(TongGiaTri)
    FROM DonHang
    WHERE NgayDatHang BETWEEN @start AND @end;
    RETURN @DoanhThu;
END;
GO

CREATE FUNCTION dbo.fn_ChiPhi(
    @start DATE,
    @end DATE
)
RETURNS DECIMAL(15, 2)
AS
BEGIN
    DECLARE @ChiPhiLuong DECIMAL(15, 2);
    DECLARE @ChiPhiLinhKien DECIMAL(15, 2);
    DECLARE @TongChiPhi DECIMAL(15, 2);

    SELECT @ChiPhiLuong = SUM(TongNhan)
    FROM Luong
    WHERE ThoiGian BETWEEN @start AND @end;

    SELECT @ChiPhiLinhKien = SUM(ctdh.SoLuong * lk.GiaNhap)
    FROM ChiTietDonHang ctdh
    JOIN DonHang dh ON ctdh.MaDonHang = dh.MaDonHang
    JOIN LinhKien lk ON ctdh.MaLinhKien = lk.MaLinhKien
    WHERE dh.NgayDatHang BETWEEN @start AND @end;

    SET @TongChiPhi = ISNULL(@ChiPhiLuong, 0) + ISNULL(@ChiPhiLinhKien, 0);

    RETURN @TongChiPhi;
END;
GO

CREATE FUNCTION fn_TinhTongLuongTheoNgay
(
    @startDay DATE,
    @endDay DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        llv.NgayLam AS ngay, 
        SUM((DATEDIFF(MINUTE, clv.GioBatDau, clv.GioKetThuc) / 60.0) * l.LuongGio) AS tongLuong
    FROM 
        CoLichLam cll
        JOIN LichLamViec llv ON cll.MaLichLamViec = llv.MaLichLamViec
        JOIN CaLamViec clv ON clv.MaCa = llv.MaCa
        JOIN NhanVien nv ON nv.MaNhanVien = cll.MaNhanVien
        JOIN Luong l ON l.MaNhanVien = nv.MaNhanVien 
                     AND MONTH(l.ThoiGian) = MONTH(llv.NgayLam) 
                     AND YEAR(l.ThoiGian) = YEAR(llv.NgayLam)
    WHERE 
        cll.TrangThai = 'HoanThanh'
        AND llv.NgayLam BETWEEN @startDay AND @endDay
    GROUP BY 
        llv.NgayLam
);
GO

CREATE PROCEDURE sp_ThongTinChiPhiTheoNgay
    @start DATE,
    @end DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        dh.NgayDatHang AS Ngay,
        COUNT(dh.MaDonHang) AS TongSoDonHang,
        SUM(dh.TongGiaTri) AS TongDoanhThu,
        ISNULL(l.TongNhan, 0) AS Luong,  
        ISNULL(SUM(ctdh.SoLuong * lk.GiaNhap), 0) AS GiaVon,
        (
            ISNULL(SUM(l.TongNhan), 0) + ISNULL(SUM(ctdh.SoLuong * lk.GiaNhap), 0)
        ) AS TongChiPhi,
        ( 
            SUM(dh.TongGiaTri) - (
                ISNULL(SUM(l.TongNhan), 0) + ISNULL(SUM(ctdh.SoLuong * lk.GiaNhap), 0)
            )
        ) AS LoiNhuan,
        ISNULL(SUM(tl.tongLuong), 0) AS TongLuong
    FROM DonHang dh
    LEFT JOIN ChiTietDonHang ctdh ON dh.MaDonHang = ctdh.MaDonHang
    LEFT JOIN LinhKien lk ON ctdh.MaLinhKien = lk.MaLinhKien
    LEFT JOIN Luong l ON dh.NgayDatHang = l.ThoiGian
    LEFT JOIN fn_TinhTongLuongTheoNgay(@start, @end) AS tl
        ON dh.NgayDatHang = tl.ngay
    WHERE dh.NgayDatHang BETWEEN @start AND @end
    GROUP BY dh.NgayDatHang
    ORDER BY dh.NgayDatHang;
END;
GO

CREATE PROCEDURE sp_TaoTableTamDieuKienThuong
AS
BEGIN
    CREATE TABLE [dbo].[DieuKienThuong] (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        TenFunction NVARCHAR(255) NOT NULL,
        ThamSo NVARCHAR(255) NOT NULL,
        Nguong DECIMAL(18,2) NOT NULL,
        SoSanh NVARCHAR(2) NOT NULL,
        GiaTriThuong NVARCHAR(255) NOT NULL
    );
END;
GO
CREATE PROCEDURE sp_ThemDieuKienThuong
    @TenFunction NVARCHAR(255),
    @ThamSo NVARCHAR(255),
    @Nguong DECIMAL(18,2),
    @SoSanh NVARCHAR(2),
    @GiaTriThuong NVARCHAR(255)
AS
BEGIN
    INSERT INTO DieuKienThuong (TenFunction, ThamSo, Nguong, SoSanh, GiaTriThuong)
    VALUES (@TenFunction, @ThamSo, @Nguong, @SoSanh, @GiaTriThuong);
END;
GO

CREATE PROCEDURE sp_TinhThuongDuaTrenDieuKien
    @start DATE,
    @end DATE
AS
BEGIN
    DECLARE @MaNhanVien INT;
    DECLARE @TenNhanVien NVARCHAR(100);
    DECLARE @Id INT;
    DECLARE @TenFunction NVARCHAR(100);
    DECLARE @ThamSo NVARCHAR(100);
    DECLARE @GiaTriThucTe DECIMAL(18, 2);
    DECLARE @Nguong DECIMAL(18, 2);
    DECLARE @GiaTriThuong DECIMAL(18, 2);
    DECLARE @Thuong DECIMAL(18, 2);
    DECLARE @SoSanh NVARCHAR(2);
    DECLARE @SQL NVARCHAR(MAX);
    DECLARE @ParamDefinition NVARCHAR(255);

    DECLARE @Result TABLE (
        MaNhanVien INT,
        TenNhanVien NVARCHAR(100),
        ResultGiaTriThuong DECIMAL(18, 2)
    );

    -- Khởi tạo lại @Thuong cho mỗi nhân viên
    SET @Thuong = 0;

    -- Cursor duyệt qua từng nhân viên
    DECLARE nhanvien_cursor CURSOR FOR
        SELECT MaNhanVien, TenNhanVien FROM NhanVien;

    OPEN nhanvien_cursor;
    FETCH NEXT FROM nhanvien_cursor INTO @MaNhanVien, @TenNhanVien;

    -- Vòng lặp duyệt qua từng nhân viên
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @Thuong = 0;

        -- Cursor duyệt qua các điều kiện
        DECLARE dieukien_cursor CURSOR FOR
            SELECT Id, TenFunction, ThamSo, Nguong, SoSanh, GiaTriThuong
            FROM DieuKienThuong;

        OPEN dieukien_cursor;
        FETCH NEXT FROM dieukien_cursor INTO @Id, @TenFunction, @ThamSo, @Nguong, @SoSanh, @GiaTriThuong;

        -- Vòng lặp duyệt qua từng điều kiện
        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Kiểm tra xem có cần tham số MaNhanVien hay không
            IF CHARINDEX('MaNhanVien', @ThamSo) > 0
            BEGIN
                SET @SQL = 'SELECT @GiaTriThucTe = dbo.' + @TenFunction + '(@start, @end, @MaNhanVien)';
                SET @ParamDefinition = N'@start DATE, @end DATE, @MaNhanVien INT, @GiaTriThucTe DECIMAL(18, 2) OUTPUT';
                
                EXEC sp_executesql @SQL, @ParamDefinition,
                    @start = @start,
                    @end = @end,
                    @MaNhanVien = @MaNhanVien,
                    @GiaTriThucTe = @GiaTriThucTe OUTPUT;
            END
            ELSE
            BEGIN
                SET @SQL = 'SELECT @GiaTriThucTe = dbo.' + @TenFunction + '(@start, @end)';
                SET @ParamDefinition = N'@start DATE, @end DATE, @GiaTriThucTe DECIMAL(18, 2) OUTPUT';
                
                EXEC sp_executesql @SQL, @ParamDefinition,
                    @start = @start,
                    @end = @end,
                    @GiaTriThucTe = @GiaTriThucTe OUTPUT;
            END

            -- Debug: In giá trị GiaTriThucTe
            PRINT 'GiaTriThucTe: ' + CAST(@GiaTriThucTe AS NVARCHAR(100));

            -- Kiểm tra điều kiện và tính toán thưởng nếu điều kiện thoả mãn
            IF (@SoSanh = '<' AND @GiaTriThucTe < @Nguong) OR
               (@SoSanh = '>' AND @GiaTriThucTe > @Nguong) OR
               (@SoSanh = '>=' AND @GiaTriThucTe >= @Nguong) OR
               (@SoSanh = '<=' AND @GiaTriThucTe <= @Nguong) OR
               (@SoSanh = '=' AND @GiaTriThucTe = @Nguong)
            BEGIN
                SET @Thuong = @GiaTriThuong + @Thuong;
            END

            -- Lấy điều kiện tiếp theo
            FETCH NEXT FROM dieukien_cursor INTO @Id, @TenFunction, @ThamSo, @Nguong, @SoSanh, @GiaTriThuong;
        END

        -- Đóng và giải phóng con trỏ dieukien_cursor
        CLOSE dieukien_cursor;
        DEALLOCATE dieukien_cursor;

        -- Insert kết quả vào bảng tạm
        INSERT INTO @Result (MaNhanVien, TenNhanVien, ResultGiaTriThuong)
        VALUES (@MaNhanVien, @TenNhanVien, @Thuong);

        -- Lấy nhân viên tiếp theo
        FETCH NEXT FROM nhanvien_cursor INTO @MaNhanVien, @TenNhanVien;
    END

    -- Đóng và giải phóng con trỏ nhanvien_cursor
    CLOSE nhanvien_cursor;
    DEALLOCATE nhanvien_cursor;

    -- Hiển thị kết quả
    SELECT * FROM @Result;
    RETURN;
END;
GO