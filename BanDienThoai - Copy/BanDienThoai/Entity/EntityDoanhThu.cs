using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.Entity
{
    public class EntityDoanhThu
    {
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public EntityDoanhThu()
        {
            
        }
        public EntityDoanhThu(DateTime _start, DateTime _end)
        {
            this.startdate = _start;
            this.enddate = _end;
        }
    }
}
