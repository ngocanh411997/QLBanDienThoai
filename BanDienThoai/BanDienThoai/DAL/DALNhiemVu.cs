using BanDienThoai.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.DAL
{
    public class DALNhiemVu
    {
        KetNoi conn = new KetNoi();
        public DataTable GetDataProc()
        {
            return conn.GetDataProc("XemNVu", null);
        }
        public int InsertData(EntityNhiemVu NV)
        {
            SqlParameter[] para =
            {
                new SqlParameter("id",NV.id),
                new SqlParameter("nhiemvu",NV.nhiemvu)          
            };
            return conn.ExcuteSQL("ThemNhVu", para);
        }
        public int UpdateData(EntityNhiemVu NV)
        {
            SqlParameter[] para =
             {
                new SqlParameter("id",NV.id),
                new SqlParameter("nhiemvu",NV.nhiemvu)
            };
            return conn.ExcuteSQL("SuaNhVu", para);
        }
        public int DeleteData(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("id",ID)
        };
            return conn.ExcuteSQL("XoaNhVu", para);
        }
        public string TangMa()
        {
            return conn.TangMaNVU("SELECT * FROM dbo.tbl_nhiemvu", "NVU");
        }
        public DataTable TimKiem(string strTimKiem)
        {
            return conn.GetDataStr(strTimKiem);
        }
        public DataTable TimKiemTen(string Ten)
        {
            return conn.GetDataStr(Ten);
        }
    }
}
