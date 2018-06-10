-- Nha San Xuat
-- Xem Nha San Xuat
GO
CREATE PROC XemNSX
AS
BEGIN
	SELECT *
	FROM dbo.tbl_nhasanxuat
END

-- Thêm nha san xuat
GO
CREATE PROC ThemNSX(@id VARCHAR(50), @ten NVARCHAR(50))
AS
BEGIN
	INSERT INTO dbo.tbl_nhasanxuat
	        ( id, ten )
	VALUES  ( @id,@ten)
END
-- Sửa nha san xuat
GO
CREATE PROC SuaNSX(@id VARCHAR(50), @ten NVARCHAR(50))
AS
BEGIN
	UPDATE dbo.tbl_nhasanxuat
	SET ten=@ten
	WHERE id=@id
END
-- Xóa nha san xuat
GO
CREATE PROC XoaN(@id VARCHAR(50))
AS
BEGIN

	DELETE dbo.tbl_nhasanxuat
	WHERE id=@id
END

-- tìm kiếm  nhasanxuat
go
CREATE PROC TK_NSX(@id NVARCHAR(50))
AS BEGIN
SELECT *
FROM dbo.tbl_nhasanxuat
WHERE id=@id;
END


-- Danh muc
-- Xem Danh muc
GO
CREATE PROC XemDM
AS
BEGIN
	SELECT *
	FROM dbo.tbl_danhmuc
END

-- Thêm Danh muc
GO
CREATE PROC ThemDM(@id VARCHAR(50), @ten NVARCHAR(50),@icon NVARCHAR(50))
AS
BEGIN
	INSERT INTO dbo.tbl_danhmuc
	        ( id, ten,icon )
	VALUES  ( @id,@ten,@icon)
END
-- Sửa nha Danh muc
GO
CREATE PROC SuaDM(@id VARCHAR(50), @ten NVARCHAR(50),@icon NVARCHAR(50))
AS
BEGIN
	UPDATE dbo.tbl_danhmuc
	SET ten=@ten,icon=@icon
	WHERE id=@id
END
-- Xóa nha Danh muc
GO
CREATE PROC XoaDM(@id VARCHAR(50))
AS
BEGIN

	DELETE dbo.tbl_danhmuc
	WHERE id=@id
END

-- tìm kiếm Danh muc
go
CREATE PROC TK_DM(@id NVARCHAR(50))
AS BEGIN
SELECT *
FROM dbo.tbl_danhmuc
WHERE id=@id;
END


