using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanDienThoai.Entity;
using System.Data;
using System.Data.SqlClient;
namespace BanDienThoai.DAL
{
   public class DALKhachHang
    {
        KetNoi conn = new KetNoi();
        public DataTable GetDataProc()
        {
            return conn.GetDataProc("XemKH", null);

        }
        public int InsertData(EntityKhachHang KH)
        {
            SqlParameter[] para =
            {
                new SqlParameter("id",KH.id),
                new SqlParameter("ten",KH.ten),
                new SqlParameter ("sdt",KH.sdt),
                new SqlParameter("diachi",KH.diachi),
                new SqlParameter("email",KH.email)
            };
            return conn.ExcuteSQL("ThemKH", para);

        }
        public int UpdateData(EntityKhachHang KH)
        {
            SqlParameter[] para =
              {
                new SqlParameter("id",KH.id),
                new SqlParameter("ten",KH.ten),
                new SqlParameter ("sdt",KH.sdt),
                new SqlParameter("diachi",KH.diachi),
                new SqlParameter("email",KH.email)
            };
            return conn.ExcuteSQL("SuaKH", para);

        }
        public int DeleteData(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("id",ID)
        };
            return conn.ExcuteSQL("XoaKH", para);
        }
        public string TangMa()
        {
            return conn.TangMa("SELECT tbl_khachhang.id,ten,sdt,email FROM dbo.tbl_khachhang" , "KH");
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
