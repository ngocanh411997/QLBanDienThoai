using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.Entity
{
    public class EntityNhanVien
    {
        public string id { get; set; }
        public string id_nhiemvu { get; set; }
        public string ten { get; set; }
        public int sdt { get; set; }
        public string email { get; set; }
        public DateTime ngaysinh { get; set; }

        public EntityNhanVien()
        {
            id = "";
            id_nhiemvu = "";
            ten = "";
            sdt = 0;
            email = "";
            ngaysinh = DateTime.Parse("01/01/1997");
        }
        public EntityNhanVien(string _id, string _id_nhiemvu, string _ten, int _sdt, string _email, DateTime _ngaysinh)
        {
            id = _id;
            id_nhiemvu = _id_nhiemvu;
            ten = _ten;
            sdt = _sdt;
            email = _email;
            ngaysinh = _ngaysinh;
        }
    }
}
