using BanDienThoai.DAL;
using BanDienThoai.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.BUS
{
    public class BUSNhiemVu
    {
        DALNhiemVu da = new DALNhiemVu();
        public DataTable GetDataProc()
        {
            return da.GetDataProc();
        }
        public int InsertData(EntityNhiemVu NV)
        {
            return da.InsertData(NV);
        }
        public int UpdateData(EntityNhiemVu NV)
        {
            return da.UpdateData(NV);
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
