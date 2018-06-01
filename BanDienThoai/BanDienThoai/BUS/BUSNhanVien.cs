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
    public class BUSNhanVien
    {
        DALNhanVien da = new DALNhanVien();
        public DataTable GetDataProc()
        {
            return da.GetDataProc();
        }
        public int InsertData(EntityNhanVien NV)
        {
            return da.InsertData(NV);
        }
        public int UpdateData(EntityNhanVien NV)
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
        public DataTable GetListNV()
        {
            return da.GetListNhiemVu();
        }
    }
}
