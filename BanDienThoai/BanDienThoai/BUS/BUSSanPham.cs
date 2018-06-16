using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BanDienThoai.DAL;
using BanDienThoai.Entity;

namespace BanDienThoai.BUS
{
    class BUSSanPham
    {
        DALSanPham da = new DALSanPham();
        public DataTable GetDataProc()
        {
            return da.GetDataProc();
        }
        public int InsertData(EntitySanPham SP)
        {
            return da.InsertData(SP);
        }
        public int UpdateData(EntitySanPham SP)
        {
            return da.UpdateData(SP);
        }
        public int DeleteData(string ID)
        {
            return da.DeleteData(ID);
        }
        public DataTable TimKiem(string strTimKiem)
        {
            return da.TimKiem(strTimKiem);
        }
        public DataTable TimKiemTen(string sql)
        {
            return da.TimKiemTen(sql);
        }
        public DataTable GetListDM()
        {
            return da.GetListDanhMuc();
        }
        public DataTable GetListNSX()
        {
            return da.GetListNhaSX();
        }
        public string TangMa()
        {
            return da.TangMa();
        }
    }
}
