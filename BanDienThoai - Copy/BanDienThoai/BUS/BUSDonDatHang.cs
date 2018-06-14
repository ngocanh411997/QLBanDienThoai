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
    public class BUSDonDatHang
    {
        DALDonDatHang da = new DALDonDatHang();
        public DataTable GetDataProc()
        {
            return da.GetDataProc();
        }
        public DataTable GetDataThanhToan(string Str)
        {
            return da.GetDataThanhToan(Str);
        }
        public int InsertData(EntityDonDatHang DDH)
        {
            return da.InsertData(DDH);
        }
        public int UpdateData(EntityDonDatHang DDH)
        {
            return da.UpdateData(DDH);
        }
        public int DeleteData(string ID)
        {
            return da.DeleteData(ID);
        }
        public string TangMa()
        {
            return da.TangMa();
        }
        public DataTable TimKiemPYC(string strTimKiem)
        {
            return da.TimKiemPYC(strTimKiem);
        }
        ////////////////

        public DataTable DataCTDDH(string strCTYC)
        {
            return da.DataCTDDH(strCTYC);
        }
        public int InsertDataCT(EntityChiTietDonDatHang CTDDH)
        {
            return da.InsertDataCT(CTDDH);
        }
        public int UpdateDataCT(EntityChiTietDonDatHang CTDDH)
        {
            return da.UpdateDataCT(CTDDH);
        }
        public int DeleteDataCT(string IDMP, string IDMM)
        {
            return da.DeleteDataCT(IDMP, IDMM);
        }
        public DataTable GetListSanPham(string sql)
        {
            return da.GetListSP(sql);
        }
        //
        public DataTable GetListSP(string sql)
        {
            return da.GetListThemSP(sql);
        }
        
        public int UpdateDataTT(EntityDonDatHang DDH)
        {
            return da.UpdateDataTT(DDH);
        }
        //
        public DataTable GetDataHoaDonTT()
        {
            return da.GetDataHoaDonTT();
        }

        public DataTable GetListNVLap()
        {
            return da.GetListNVLap();
        }
        public DataTable GetListNVShipper()
        {
            return da.GetListNVShipper();
        }
        public DataTable GetListKH()
        {
            return da.GetListKH();
        }
       
        // TK gần đúng
        public DataTable TimKiemTen(string Ten)
        {
            return da.TimKiemTen(Ten);
        }
        //
        public DataTable GetListDM()
        {
            return da.GetListDM();
        }
    }
}
