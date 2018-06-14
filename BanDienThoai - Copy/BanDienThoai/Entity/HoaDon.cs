using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.Entity
{
    public class HoaDon
    {
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public int ThanhTien { get; set; }
        public int TongTien { get; set; }
        public string MaHD { get; set; }
        public string MaNV { get; set; }
        public DateTime Ngay { get; set; }
        public string MaKH { get; set; }
        public string TenKH { get; set; }

        public HoaDon()
        {
            TenSP = "";
            SoLuong = 0;
            Gia = 0;
            ThanhTien = 0;
            TongTien = 0;
            MaHD = "";
            MaNV = "";
            Ngay = DateTime.Parse("01/01/2017");
            MaKH = "";
            TenKH = "";
        }
        public HoaDon(string _TenSP, int _SL, int _Gia, int _ThanhTien, int _TongTien, string _MaHD, string _MaNV, DateTime _Ngay, string _MaKH, string _TenKH)
        {
            TenSP = _TenSP;
            SoLuong = _SL;
            Gia = _Gia;
            ThanhTien = _ThanhTien;
            TongTien = _TongTien;
            MaHD = _MaHD;
            MaNV = _MaNV;
            Ngay = _Ngay;
            MaKH = _MaKH;
            TenKH = _TenKH;
        }
    }
}
