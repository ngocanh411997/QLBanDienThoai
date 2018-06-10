
Alter proc XemSP 
as
begin
select * from tbl_sanpham where TrangThai=0
end
go

CREATE proc ThemSP(@id nchar(10), @id_KM int, @id_DM int, @ten nvarchar(50), @linkanh nvarchar(50), @gia int,
@SoLg int, @trongLg int, @ROM int, @RAM int, @thenho int, @CamTrc int, @CamSau int, @pin int, @BaoHanh int, @Bluetooth float,
@idNSX int, @TrangThai Nvarchar(50))
as
begin
insert into tbl_sanpham(id, id_khuyenmai, id_danhmuc, ten, link_anh, gia, soluong, trongluong, ROM, RAM, thenho,
 camera_truoc, camera_sau, pin, baohanh, bluetooth, id_nhasanxuat, TrangThai )
 values (@id, @id_KM,@id_DM, @ten, @linkanh, @gia, @SoLg, @trongLg, @ROM, @RAM, @thenho, @CamTrc, @CamSau, @pin,
 @BaoHanh, @Bluetooth, @idNSX, @TrangThai)
end
go

CREATE proc SuaSP(@id nchar(10), @id_KM int, @id_DM int, @ten nvarchar(50), @linkanh nvarchar(50), @gia int,
@SoLg int, @trongLg int, @ROM int, @RAM int, @thenho int, @CamTrc int, @CamSau int, @pin int, @BaoHanh int, @Bluetooth float,
@idNSX int, @TrangThai nvarchar(50))
as
begin
update tbl_sanpham
set id=@id, id_khuyenmai= @id_KM, id_danhmuc= @id_DM, ten= @ten, link_anh= @linkanh, gia= @gia, soluong=@SoLg,
trongluong= @trongLg, ROM=@ROM,RAM=@RAM,thenho=@thenho, camera_truoc=@CamTrc, camera_sau=@CamSau, pin= @pin, 
baohanh= @BaoHanh, bluetooth= @Bluetooth, id_nhasanxuat=@idNSX, TrangThai=@TrangThai
where id=@id
end
go

ALter proc XoaSP(@id nvarchar(50))
as
begin
update tbl_sanpham
set TrangThai=1
where id=@id
end
go

