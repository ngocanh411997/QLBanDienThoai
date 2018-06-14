-- Nhiệm vụ
-- Xem nhiệm vụ
GO
CREATE PROC XemNVu
AS
BEGIN
	SELECT *
	FROM dbo.tbl_nhiemvu
END

-- Thêm nhiệm vụ
GO
CREATE PROC ThemNhVu(@id VARCHAR(50), @nhiemvu NVARCHAR(50))
AS
BEGIN
	INSERT INTO dbo.tbl_nhiemvu
	        ( id, nhiemvu )
	VALUES  ( @id,@nhiemvu)
END
-- Sửa nhiệm vụ
GO
CREATE PROC SuaNhVu(@id VARCHAR(50), @nhiemvu NVARCHAR(50))
AS
BEGIN
	UPDATE dbo.tbl_nhiemvu
	SET nhiemvu=@nhiemvu
	WHERE id=@id
END
-- Xóa nhiệm vụ
GO
CREATE PROC XoaNhVu(@id VARCHAR(50))
AS
BEGIN
	DELETE dbo.tbl_nhanvien
	WHERE id_nhiemvu=@id
	DELETE dbo.tbl_nhiemvu
	WHERE id=@id
END

-- tìm kiếm tên nhiệm vụ
go
CREATE PROC TKTenNVu(@Ten NVARCHAR(50))
AS BEGIN
SELECT *
FROM dbo.tbl_nhiemvu
WHERE dbo.ChuyenDoiUnicode(nhiemvu) LIKE N'%'+dbo.ChuyenDoiUnicode(@Ten)+N'%'
END

GO
EXEC dbo.TKTenNVu @Ten = N'' -- nvarchar(50)

-- Nhân Viên
-- xem NV
GO
CREATE PROC XemNV
AS
BEGIN
	SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh 
	FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu
END
-- Thêm NV
GO
CREATE PROC ThemNV(@id VARCHAR(50),@id_nhiemvu VARCHAR(50), @ten NVARCHAR(100), @sdt DECIMAL(18,0), @email VARCHAR(100), @ngaysinh DATE)
AS
BEGIN
	INSERT INTO dbo.tbl_nhanvien
	        ( id ,
	          id_nhiemvu ,
	          ten ,
	          sdt ,
	          email ,
	          ngaysinh
	        )
	VALUES  ( @id,@id_nhiemvu,@ten,@sdt,@email,@ngaysinh)
END
-- Sửa NV
GO
CREATE PROC SuaNV(@id VARCHAR(50),@id_nhiemvu VARCHAR(50), @ten NVARCHAR(100), @sdt DECIMAL(18,0), @email VARCHAR(100), @ngaysinh DATE)
AS
BEGIN
	UPDATE dbo.tbl_nhanvien
	SET id_nhiemvu=@id_nhiemvu,ten=@ten,sdt=@sdt,email=@email,ngaysinh=@ngaysinh
	WHERE id=@id
END
-- Xóa NV
GO
CREATE PROC XoaNV(@id VARCHAR(50))
AS
BEGIN
	DELETE dbo.tbl_dondathang
	WHERE id_nguoilap=@id OR id_shipper=@id
	DELETE dbo.tbl_nhanvien
	WHERE id=@id
END
-- Tìm kiếm nhân viên
go
CREATE PROC TKTenNV(@Ten NVARCHAR(50))
AS BEGIN
SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh 
	FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu
WHERE dbo.ChuyenDoiUnicode(ten) LIKE N'%'+dbo.ChuyenDoiUnicode(@Ten)+N'%'
END
-- tìm kiếm nhiệm vụ
go
CREATE PROC TK_NVu(@Ten NVARCHAR(50))
AS BEGIN
SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh 
	FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu
WHERE dbo.ChuyenDoiUnicode(nhiemvu) LIKE N'%'+dbo.ChuyenDoiUnicode(@Ten)+N'%'
END

SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu WHERE email LIKE'%"+txtTimKiem.Text+"%'

---Đơn đặt hàng
SELECT * FROM dbo.tbl_dondathang
-- Xem đơn đặt hàng
GO
ALTER PROC XemDDH
AS
BEGIN
	SELECT tbl_dondathang.id,tbl_khachhang.ten,id_shipper,id_nguoilap,ngaylap,noinhan,ghichu
	FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id WHERE id_tinhtrang=0
END
-- Thêm đơn đặt hàng
GO
ALTER PROC ThemDDH(@id VARCHAR(50),@id_khachhang VARCHAR(50), @id_tinhtrang INT,@id_shipper VARCHAR(50), @id_nguoilap VARCHAR(50),@ngaylap DATE,@noinhan NVARCHAR(250), @ghichu NVARCHAR(150))
AS
BEGIN
	INSERT INTO dbo.tbl_dondathang
	        ( id ,
	          id_khachhang ,
	          id_tinhtrang ,
	          id_shipper ,
	          id_nguoilap ,
	          ngaylap ,
	          noinhan ,
	          ghichu
	        )
	VALUES  ( @id,@id_khachhang,0,@id_shipper,@id_nguoilap,@ngaylap,@noinhan,@ghichu)
END
-- Sửa đơn đătk hàng
GO
ALTER PROC SuaDDH(@id VARCHAR(50),@id_khachhang VARCHAR(50), @id_tinhtrang INT,@id_shipper VARCHAR(50), @id_nguoilap VARCHAR(50),@ngaylap DATE,@noinhan NVARCHAR(250), @ghichu NVARCHAR(150))
AS
BEGIN
	UPDATE dbo.tbl_dondathang
	SET id_khachhang=@id_khachhang,id_tinhtrang=0,id_shipper=@id_shipper,id_nguoilap=@id_nguoilap,ngaylap=@ngaylap,noinhan=@noinhan,ghichu=@ghichu
	WHERE id=@id
END
-- Xóa đơn đặt hàng
GO
CREATE PROC XoaDDH(@id VARCHAR(50))
AS
BEGIN
	DELETE dbo.tbl_chitietdonhang
	WHERE id_dondathang=@id
	DELETE dbo.tbl_dondathang
	WHERE id=@id
END

SELECT * FROM dbo.tbl_khachhang

-- tìm kiếm khách hàng
go
ALTER PROC TK_KH(@Ten NVARCHAR(50))
AS BEGIN
SELECT  tbl_dondathang.id,tbl_khachhang.ten,id_shipper,id_nguoilap,ngaylap,noinhan,ghichu
	FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id WHERE id_tinhtrang=0
and dbo.ChuyenDoiUnicode(tbl_khachhang.ten) LIKE N'%'+dbo.ChuyenDoiUnicode(@Ten)+N'%'
END
-- tìm kiếm NVL
go
CREATE PROC TK_NVDDH(@Ten NVARCHAR(50))
AS BEGIN
SELECT tbl_dondathang.id,tbl_khachhang.ten,tbl_nhanvien.ten,tbl_nhanvien.ten,ngaylap,noinhan,ghichu
	FROM dbo.tbl_dondathang INNER JOIN dbo.tbl_khachhang ON tbl_khachhang.id = tbl_dondathang.id_khachhang INNER JOIN dbo.tbl_nhanvien ON tbl_nhanvien.id = tbl_dondathang.id_nguoilap AND tbl_nhanvien.id = tbl_dondathang.id_shipper WHERE id_tinhtrang=0
and dbo.ChuyenDoiUnicode(tbl_nhanvien.ten) LIKE N'%'+dbo.ChuyenDoiUnicode(@Ten)+N'%'
END

SELECT tbl_dondathang.id,tbl_khachhang.ten,tbl_nhanvien.ten,tbl_nhanvien.ten,ngaylap,noinhan,ghichu
	FROM dbo.tbl_dondathang INNER JOIN dbo.tbl_khachhang ON tbl_khachhang.id = tbl_dondathang.id_khachhang INNER JOIN dbo.tbl_nhanvien ON tbl_nhanvien.id = tbl_dondathang.id_nguoilap AND tbl_nhanvien.id = tbl_dondathang.id_shipper WHERE id_tinhtrang=0 AND ngaylap LIKE ''


-- Chi tiết hóa đơn đặt hàng
-- thêm ctddh
GO
CREATE PROC ThemCTDDH(@id_dondathang VARCHAR(50), @id_sanpham VARCHAR(50), @soluong INT,@thanhtien int)
AS
BEGIN
	INSERT INTO dbo.tbl_chitietdonhang
	        ( id_dondathang ,
	          id_sanpham ,
	          soluong,
			 thanhtien
	        )
	VALUES  ( @id_dondathang,@id_sanpham,@soluong,@soluong*(SELECT gia FROM dbo.tbl_sanpham WHERE id=@id_sanpham)
	        )
END

-- sửa ctddh
GO
CREATE PROC SuaCTDDH(@id_dondathang VARCHAR(50), @id_sanpham VARCHAR(50), @soluong INT,@thanhtien int)
AS
BEGIN
	UPDATE dbo.tbl_chitietdonhang
	SET soluong=@soluong,thanhtien=@soluong*(SELECT gia FROM dbo.tbl_sanpham WHERE id=@id_sanpham)
	WHERE id_dondathang=@id_dondathang AND id_sanpham=@id_sanpham   
END
-- xóa ctddh
GO
CREATE PROC XoaCTDDH(@id_dondathang VARCHAR(50), @id_sanpham VARCHAR(50))
AS
BEGIN
	DELETE dbo.tbl_chitietdonhang
	WHERE id_dondathang=@id_dondathang AND id_sanpham=@id_sanpham
END

--
GO
CREATE PROC SelectAll_Sp
AS
BEGIN
SELECT * FROM dbo.tbl_sanpham
END
--
SELECT id_dondathang,ten,tbl_chitietdonhang.soluong,gia,thanhtien FROM dbo.tbl_chitietdonhang INNER JOIN dbo.tbl_sanpham ON tbl_sanpham.id = tbl_chitietdonhang.id_sanpham WHERE TrangThai=0

SELECT * FROM dbo.tbl_sanpham WHERE ten NOT IN (SELECT ten FROM dbo.tbl_chitietdonhang INNER JOIN dbo.tbl_sanpham ON tbl_sanpham.id = tbl_chitietdonhang.id_sanpham WHERE id_dondathang LIKE '') AND TrangThai=0

SELECT tbl_dondathang.id,ten,SUM(thanhtien) AS tongtien FROM dbo.tbl_chitietdonhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id = tbl_chitietdonhang.id_dondathang INNER JOIN dbo.tbl_khachhang ON tbl_khachhang.id = tbl_dondathang.id_khachhang WHERE tbl_dondathang.id LIKE 'DDH01'
GROUP BY tbl_dondathang.id,ten

-- Đã thanh toán
GO
CREATE PROC DaTT(@id VARCHAR(50),@id_tinhtrang INT)
AS
BEGIN
	UPDATE dbo.tbl_dondathang
	SET id_tinhtrang=1
	WHERE id=@id
END

-- Hóa đơn đã thanh toán
GO
CREATE PROC HoaDonDaTT
AS
BEGIN
	SELECT tbl_dondathang.id,ten,id_nguoilap,ngaylap,SUM(thanhtien) AS tongtien FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id INNER JOIN dbo.tbl_chitietdonhang ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id
	WHERE id_tinhtrang=1 AND tbl_dondathang.id LIKE ''
	GROUP BY tbl_dondathang.id,ten,id_nguoilap,ngaylap
END
---

SELECT ten,tbl_chitietdonhang.soluong,gia,thanhtien FROM dbo.tbl_chitietdonhang INNER JOIN dbo.tbl_sanpham ON tbl_sanpham.id = tbl_chitietdonhang.id_sanpham WHERE id_dondathang LIKE'' AND TrangThai=0

GO
SELECT tbl_dondathang.id,id_nguoilap,ngaylap,id_khachhang,ten,SUM(thanhtien) AS TongTien FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id INNER JOIN dbo.tbl_chitietdonhang ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id WHERE id_dondathang LIKE'DDH01' GROUP BY tbl_dondathang.id,id_nguoilap,ngaylap,id_khachhang,ten
-----------
GO
CREATE PROC Sellect_All_DM
AS
BEGIN
	SELECT * FROM dbo.tbl_danhmuc
END
--
GO
SELECT tbl_sanpham.id,tbl_sanpham.ten FROM dbo.tbl_sanpham INNER JOIN dbo.tbl_danhmuc ON tbl_danhmuc.id = tbl_sanpham.id_danhmuc WHERE tbl_danhmuc.ten LIKE'' AND TrangThai=0
--
SELECT * FROM dbo.tbl_sanpham WHERE ten NOT IN (SELECT ten FROM dbo.tbl_chitietdonhang INNER JOIN dbo.tbl_sanpham ON tbl_sanpham.id = tbl_chitietdonhang.id_sanpham INNER JOIN dbo.tbl_danhmuc ON tbl_danhmuc.id = tbl_sanpham.id_danhmuc WHERE id_dondathang LIKE 'DDH01' AND tbl_danhmuc.ten LIKE'') AND TrangThai=0