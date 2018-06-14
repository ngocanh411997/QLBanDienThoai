using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.BUS
{
    public class BUSDoanhThu
    {
        DAL.DALDoanhThu da = new DAL.DALDoanhThu();
        public DataTable GetDataProc( Entity.EntityDoanhThu dt)
        {
            return da.GetDataProc(dt);
        }
    }
}
