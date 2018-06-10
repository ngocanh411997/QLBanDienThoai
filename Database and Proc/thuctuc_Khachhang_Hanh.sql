--Khách hàng
--Xem KH
create proc XemKH
as
begin
select *
 from tbl_khachhang
 end
 --thêm KH
 GO
CREATE PROC ThemKH(@id VARCHAR(50), @ten NVARCHAR(50), @sdt DECIMAL(18,0),@diachi nvarchar(200), @email VARCHAR(100))
AS
BEGIN
	INSERT INTO tbl_khachhang
	        ( id ,   
	          ten ,
	          sdt ,
	          email ,
	          diachi
	        )
	VALUES  ( @id,@ten,@sdt,@diachi,@email)
END
-- Sửa KH
GO
CREATE PROC SuaKH(@id VARCHAR(50), @ten NVARCHAR(50), @sdt DECIMAL(18,0),@diachi nvarchar(200), @email VARCHAR(100))
AS
BEGIN
	UPDATE tbl_khachhang
	SET id=@id,ten=@ten,sdt=@sdt,email=@email,diachi=@diachi
	WHERE id=@id
END
-- Xóa KH
GO
CREATE PROC XoaKH(@id VARCHAR(50))
AS
BEGIN
	
	DELETE tbl_khachhang
	WHERE id=@id
END
-- Tìm kiếm Khách hàng
go
CREATE PROC TKTenKH(@Ten NVARCHAR(50))
AS BEGIN
select *
FROM tbl_khachhang
WHERE dbo.ChuyenDoiUnicode(ten) LIKE N'%'+dbo.ChuyenDoiUnicode(@Ten)+N'%'
END
