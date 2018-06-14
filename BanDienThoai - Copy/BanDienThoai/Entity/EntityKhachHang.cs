using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.Entity
{
  public  class EntityKhachHang
    {
        public string id { get; set; }
        public string ten { get; set; }
        public int sdt { get; set; }
        public string diachi { get; set; }
        public string email { get; set; }


        public EntityKhachHang()
        {
            id = "";
            ten = "";
            sdt = 0 ;
            diachi = "";
            email = "";
        }
        public EntityKhachHang(string _id, string _ten, int _sdt, string _diachi, string _email)
        {
            id = _id;
            ten = _ten;
            sdt = _sdt;
            email = _email;
            diachi = _diachi;
        }


    }
}
