using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.Entity
{
   public class EntityNhiemVu
    {
        public string id { get; set; }
        public string nhiemvu { get; set; }

        public EntityNhiemVu()
        {
            id = "";
            nhiemvu = "";
        }
        public EntityNhiemVu(string _id, string _nhiemvu)
        {
            id = _id;
            nhiemvu = _nhiemvu;
        }
    }
}
