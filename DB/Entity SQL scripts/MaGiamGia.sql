
--- View
CREATE VIEW vw_GiamGia
AS
SELECT MaGiamGia, TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri
FROM dbo.GiamGia
GO
-- Stored Procedure
-- Tạo
CREATE PROCEDURE sp_ThemGiamGia
    @TenGiamGia NVARCHAR(100),
    @NgayBatDau DATE,
    @NgayKetThuc DATE,
    @GiaTri DECIMAL(5, 2)
AS
BEGIN
    INSERT INTO dbo.GiamGia (TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri)
    VALUES (@TenGiamGia, @NgayBatDau, @NgayKetThuc, @GiaTri);
END;
GO
CREATE PROCEDURE sp_XoaGiamGia
    @MaGiamGia INT
AS
BEGIN
    DELETE FROM GiamGia
    WHERE MaGiamGia = @MaGiamGia;
END;

GO
-- Lấy mã theo thời gian
CREATE PROCEDURE sp_TimKiemMaGiamGiaTheoThoiGian
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT MaGiamGia, TenGiamGia, NgayBatDau, NgayKetThuc, GiaTri
    FROM dbo.GiamGia
    WHERE NgayBatDau BETWEEN @StartDate AND @EndDate;
END;
GO
---- Function
-- Kiểm tra mã giảm giá hợp lệ
CREATE FUNCTION fn_CheckGiamGiaHopLe (
    @MaGiamGia INT
)
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @NgayBatDau DATE, @NgayKetThuc DATE;
    DECLARE @Result NVARCHAR(50);

    SELECT @NgayBatDau = NgayBatDau, @NgayKetThuc = NgayKetThuc
    FROM dbo.GiamGia
    WHERE MaGiamGia = @MaGiamGia;

    IF @NgayBatDau IS NULL
    BEGIN
        SET @Result = N'Mã giảm giá không tồn tại';
        RETURN @Result;
    END

    IF GETDATE() < @NgayBatDau
    BEGIN
        SET @Result = N'Mã giảm giá chưa có hiệu lực';
    END
    ELSE IF GETDATE() > @NgayKetThuc
    BEGIN
        SET @Result = N'Mã giảm giá đã hết hạn';
    END
    ELSE
    BEGIN
        SET @Result = N'Mã giảm giá hợp lệ';
    END

    RETURN @Result;
END;
GO
-- Tính giá trị đơn sau khi giảm
CREATE FUNCTION fn_CalculateFinalPrice (
    @GiaTriDonHang DECIMAL(10, 2),
    @MaGiamGia INT
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @GiaTriGiam DECIMAL(5, 2);
    DECLARE @FinalPrice DECIMAL(10, 2);
    
    SELECT @GiaTriGiam = GiaTri
    FROM dbo.GiamGia
    WHERE MaGiamGia = @MaGiamGia 
        AND GETDATE() BETWEEN NgayBatDau AND NgayKetThuc;

    IF @GiaTriGiam IS NULL
    BEGIN
        SET @FinalPrice = @GiaTriDonHang;
    END
    ELSE
    BEGIN
        SET @FinalPrice = @GiaTriDonHang * (1 - @GiaTriGiam / 100);
    END
    
    RETURN @FinalPrice;
END;
GO

------   TEST       -------
-- Xem các mã giảm giá còn hiệu lực
-- -- View
-- SELECT * FROM vw_GiamGia;
-- -- Stored procedure
-- EXEC sp_InsertGiamGia 
--     @TenGiamGia = N'Giảm giá Valentine', 
--     @NgayBatDau = '2024-02-10', 
--     @NgayKetThuc = '2024-02-20', 
--     @GiaTri = 10.00;
-- EXEC sp_UpdateGiamGia 
--     @MaGiamGia = 1, 
--     @TenGiamGia = N'Giảm giá Tết 20245', 
--     @NgayBatDau = '2024-01-01', 
--     @NgayKetThuc = '2024-01-31', 
--     @GiaTri = 12.00;
-- EXEC sp_GetGiamGiaByDateRange 
--     @StartDate = '2023-01-01', 
--     @EndDate = '2023-12-31';
-- -- Function
-- SELECT dbo.fn_CheckGiamGiaHopLe(1) AS TinhTrangGiamGia;
-- SELECT dbo.fn_CalculateFinalPrice(1000000, 1) AS GiaSauKhiGiam;





