using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.DAL
{
    public class DALDoanhThu
    {
        KetNoi conn = new KetNoi();

        public DataTable GetDataProc(Entity.EntityDoanhThu DT)
        {
            SqlParameter[] para = { new SqlParameter("startdate",DT.startdate), new SqlParameter("enddate",DT.enddate) };
            return conn.GetDataProc("ChiTietDoanhThu", para);
        }

    }
}
