using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.Entity
{
    class EntitySanPham
    {
        public string id { get; set; }
        public int id_KM { get; set; }
        public int id_DanhMuc { get; set; }
        public string ten { get; set; }
        public string linkanh { get; set; }
        public int gia { get; set; }
        public int SoLg { get; set; }
        public int TrongLg { get; set; }
        public int ROM { get; set; }
        public int RAM { get; set; }
        public int TheNho { get; set; }
        public int Cam_Trc { get; set; }
        public int Cam_Sau { get; set; }
        public int Pin { get; set; }
        public int BaoHanh { get; set; }
        public float Bluetooth { get; set; }
        public int id_NSX { get; set; }
        public string TrangThai { get; set; }

        public EntitySanPham()
        {
            id = "";
            id_KM = 0;
            id_DanhMuc = 0;
            ten = "";
            linkanh = "";
            gia = 0;
            SoLg = 0;
            TrongLg = 0;
            ROM = 0;
            RAM = 0;
            TheNho = 0;
            Cam_Trc = 0;
            Cam_Sau = 0;
            Pin = 0;
            BaoHanh = 0;
            Bluetooth = 0;
            id_NSX = 0;
            TrangThai = "";

        }

        public EntitySanPham(String _id, int _id_KM, int _id_DanhMuc, string _ten, string _linkanh, int _gia, int _SoLg, int _TrongLg,
            int _ROM, int _RAM, int _TheNho, int _Cam_Trc, int _Cam_Sau, int _Pin, int _BaoHanh, float _Bluetooth, int _id_NSX, string _TrangThai)
        {
            id = _id;
            id_KM = _id_KM;
            id_DanhMuc = _id_DanhMuc;
            ten = _ten;
            linkanh = _linkanh;
            gia = _gia;
            SoLg = _SoLg;
            TrongLg = _TrongLg;
            ROM = _ROM;
            RAM = _RAM;
            TheNho = _TheNho;
            Cam_Trc = _Cam_Trc;
            Cam_Sau = _Cam_Sau;
            Pin = _Pin;
            BaoHanh = _BaoHanh;
            Bluetooth = _Bluetooth;
            id_NSX = _id_NSX;
            TrangThai = _TrangThai;
        }
    }
}
