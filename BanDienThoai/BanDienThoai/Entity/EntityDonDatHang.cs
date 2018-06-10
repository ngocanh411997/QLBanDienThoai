using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.Entity
{
    public class EntityDonDatHang
    {
        public string id { get; set; }
        public string id_khachhang { get; set; }
        public int id_tinhtrang { get; set; }
        public string id_shipper { get; set; }
        public string id_nguoilap { get; set; }
        public DateTime ngaylap { get; set; }
        public string noinhan { get; set; }
        public string ghichu { get; set; }

        public EntityDonDatHang()
        {
            id = "";
            id_khachhang = "";
            id_tinhtrang = 0;
            id_shipper = "";
            id_nguoilap = "";
            ngaylap = DateTime.Parse("01/01/2017");
            noinhan = "";
            ghichu = "";
        }
        public EntityDonDatHang(string _id, string _id_khachhang, int _id_tinhtrang, string _id_shipper, string _id_nguoilap, DateTime _ngaylap, string _noinhan, string _ghichu)
        {
            id = _id;
            id_khachhang = _id_khachhang;
            id_tinhtrang = _id_tinhtrang;
            id_shipper = _id_shipper;
            id_nguoilap = _id_nguoilap;
            ngaylap = _ngaylap;
            noinhan = _noinhan;
            ghichu = _ghichu;
        }
    }
}
