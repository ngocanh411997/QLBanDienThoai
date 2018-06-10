
ALTER proc XemSP 
as
begin
select id,id_khuyenmai,id_danhmuc,ten,link_anh,gia,soluong,trongluong,ROM,RAM,thenho,camera_truoc,camera_sau,pin,baohanh,bluetooth,id_nhasanxuat from tbl_sanpham where TrangThai='0'
end
go

ALTER proc ThemSP(@id VARCHAR(50), @id_KM int, @id_DM int, @ten nvarchar(150), @linkanh nvarchar(150), @gia DECIMAL,
@SoLg int, @trongLg int, @ROM int, @RAM int, @thenho int, @CamTrc int, @CamSau int, @pin int, @BaoHanh int, @Bluetooth float,
@idNSX int, @TrangThai VARCHAR(2))
as
begin
insert into tbl_sanpham(id, id_khuyenmai, id_danhmuc, ten, link_anh, gia, soluong, trongluong, ROM, RAM, thenho,
 camera_truoc, camera_sau, pin, baohanh, bluetooth, id_nhasanxuat, TrangThai )
 values (@id, @id_KM,@id_DM, @ten, @linkanh, @gia, @SoLg, @trongLg, @ROM, @RAM, @thenho, @CamTrc, @CamSau, @pin,
 @BaoHanh, @Bluetooth, @idNSX, '0')
end
go

ALTER proc SuaSP(@id VARCHAR(50), @id_KM int, @id_DM int, @ten nvarchar(150), @linkanh nvarchar(150), @gia DECIMAL,
@SoLg int, @trongLg int, @ROM int, @RAM int, @thenho int, @CamTrc int, @CamSau int, @pin int, @BaoHanh int, @Bluetooth float,
@idNSX int, @TrangThai VARCHAR(2))
as
begin
update tbl_sanpham
set id=@id, id_khuyenmai= @id_KM, id_danhmuc= @id_DM, ten= @ten, link_anh= @linkanh, gia= @gia, soluong=@SoLg,
trongluong= @trongLg, ROM=@ROM,RAM=@RAM,thenho=@thenho, camera_truoc=@CamTrc, camera_sau=@CamSau, pin= @pin, 
baohanh= @BaoHanh, bluetooth= @Bluetooth, id_nhasanxuat=@idNSX, TrangThai='1'
where id=@id
end
go

CREATE proc XoaSP(@id nvarchar(50))
as
BEGIN
DELETE dbo.tbl_chitietdonhang 
WHERE id_sanpham=@id AND id_dondathang IN (SELECT id FROM dbo.tbl_dondathang WHERE id_tinhtrang=0)
update tbl_sanpham
set TrangThai=1
where id=@id
end
go

