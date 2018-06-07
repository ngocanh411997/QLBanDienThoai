using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanDienThoai.DAL;
using BanDienThoai.Entity;
using System.Data;

namespace BanDienThoai.BUS
{
   public class BUSKhachHang
    {
        DALKhachHang da = new DALKhachHang();
        public DataTable GetDataProc()
        {
            return da.GetDataProc();
        }
        public int InsertData(EntityKhachHang KH)
        {
            return da.InsertData(KH);
        }
        public int UpdateData(EntityKhachHang KH)
        {
            return da.UpdateData(KH);
        }
        public int DeleteData(string ID)
        {
            return da.DeleteData(ID);
        }
        public string TangMa()
        {
            return da.TangMa();
        }
        public DataTable TimKiem(string strTimKiem)
        {
            return da.TimKiem(strTimKiem);
        }
        public DataTable TimKiemTen(string sql)
        {
            return da.TimKiemTen(sql);
        }


    }
}
