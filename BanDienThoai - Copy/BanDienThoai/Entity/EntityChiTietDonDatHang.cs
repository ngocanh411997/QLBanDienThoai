using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.Entity
{
    public class EntityChiTietDonDatHang
    {
        public string id_dondathang { get; set; }
        public string id_sanpham { get; set; }
        public int soluong { get; set; }
        public int thanhtien { get; set; }

        public EntityChiTietDonDatHang()
        {
            id_dondathang = "";
            id_sanpham = "";
            soluong = 0;
            thanhtien = 0;
        }
        public EntityChiTietDonDatHang(string _id_dondathang, string _id_sanpham, int _soluong, int _thanhtien)
        {
            id_dondathang = _id_dondathang;
            id_sanpham = _id_sanpham;
            soluong = _soluong;
            thanhtien = _thanhtien;
        }
    }
}
