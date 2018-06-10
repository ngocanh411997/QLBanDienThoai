CREATE PROC [dbo].[TongDoanhThu](@Start date, @end date)
AS
BEGIN
	DECLARE @DoanhThu INT
	SET @DoanhThu = 0
	--
	--
	SELECT @DoanhThu=SUM(thanhtien)
	 FROM dbo.tbl_dondathang 
	 INNER JOIN dbo.tbl_chitietdonhang 
	 ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id
	 WHERE id_tinhtrang=1 AND ngaylap BETWEEN @Start AND @end


	SELECT @DoanhThu
END
GO


  
--Doanh Thu theo nhan vien --start date end date
CREATE PROC DoanhThuTheoNhanVien(@id_nhanvien VARCHAR(50),@start DATE, @end DATE)
AS
BEGIN
	DECLARE @DoanhThu INT
	SET @DoanhThu=0

	IF @id_nhanvien IS NULL OR @id_nhanvien=''
		BEGIN
			SELECT @DoanhThu=SUM(thanhtien)
			FROM dbo.tbl_dondathang 
			INNER JOIN dbo.tbl_chitietdonhang 
			ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id
			WHERE id_tinhtrang=1 AND ngaylap BETWEEN @Start AND @end

		END
	ELSE
		BEGIN
			SELECT @DoanhThu=SUM(thanhtien)
			FROM dbo.tbl_dondathang 
			INNER JOIN dbo.tbl_chitietdonhang ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id
			INNER JOIN dbo.tbl_nhanvien ON tbl_nhanvien.id = tbl_dondathang.id_nguoilap
			WHERE id_nguoilap=@id_nhanvien AND id_tinhtrang=1 AND ngaylap BETWEEN @Start AND @end
	
		END
    
	SELECT @DoanhThu
END
GO




CREATE PROC ChiTietDoanhThu (@startdate DATE, @enddate DATE)
AS
BEGIN	
	SELECT tbl_dondathang.id, ngaylap, dbo.tbl_nhanvien.ten nhanvien,sdt,ghichu, SUM(thanhtien) tongtien FROM dbo.tbl_dondathang
	INNER JOIN dbo.tbl_nhanvien
	ON tbl_nhanvien.id = tbl_dondathang.id_nguoilap
	INNER JOIN dbo.tbl_chitietdonhang
	ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id
	WHERE id_tinhtrang=1 AND ngaylap BETWEEN @startdate AND @enddate
	GROUP BY dbo.tbl_dondathang.id,ngaylap,dbo.tbl_nhanvien.ten,sdt,ghichu
END
GO

