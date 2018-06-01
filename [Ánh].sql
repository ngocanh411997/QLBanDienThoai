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
ALTER PROC ThemNhVu(@id VARCHAR(50), @nhiemvu NVARCHAR(50))
AS
BEGIN
	INSERT INTO dbo.tbl_nhiemvu
	        ( id, nhiemvu )
	VALUES  ( @id,@nhiemvu)
END
-- Sửa nhiệm vụ
GO
ALTER PROC SuaNhVu(@id VARCHAR(50), @nhiemvu NVARCHAR(50))
AS
BEGIN
	UPDATE dbo.tbl_nhiemvu
	SET nhiemvu=@nhiemvu
	WHERE id=@id
END
-- Xóa nhiệm vụ
GO
ALTER PROC XoaNhVu(@id VARCHAR(50))
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