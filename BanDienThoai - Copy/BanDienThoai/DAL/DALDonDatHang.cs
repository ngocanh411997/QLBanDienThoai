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
    public class DALDonDatHang
    {
        KetNoi conn = new KetNoi();
        public DataTable GetDataProc()
        {
            return conn.GetDataProc("XemDDH", null);
        }
        public DataTable GetDataThanhToan(string Str)
        {
            return conn.GetDataStr(Str);
        }
        public int InsertData(EntityDonDatHang DDH)
        {
            SqlParameter[] para =
            {
                new SqlParameter("id",DDH.id),
                new SqlParameter("id_khachhang",DDH.id_khachhang),
                new SqlParameter("id_tinhtrang",DDH.id_tinhtrang),
                new SqlParameter("id_shipper",DDH.id_shipper),
                new SqlParameter("id_nguoilap",DDH.id_nguoilap),
                new SqlParameter("ngaylap",DDH.ngaylap),
                new SqlParameter("noinhan",DDH.noinhan),
                new SqlParameter("ghichu",DDH.ghichu)
            };
            return conn.ExcuteSQL("ThemDDH", para);
        }
        public int UpdateData(EntityDonDatHang DDH)
        {
            SqlParameter[] para =
           {
               new SqlParameter("id",DDH.id),
                new SqlParameter("id_khachhang",DDH.id_khachhang),
                new SqlParameter("id_tinhtrang",DDH.id_tinhtrang),
                new SqlParameter("id_shipper",DDH.id_shipper),
                new SqlParameter("id_nguoilap",DDH.id_nguoilap),
                new SqlParameter("ngaylap",DDH.ngaylap),
                new SqlParameter("noinhan",DDH.noinhan),
                new SqlParameter("ghichu",DDH.ghichu)
            };
            return conn.ExcuteSQL("SuaDDH", para);
        }
        public int DeleteData(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("id",ID)
        };
            return conn.ExcuteSQL("XoaDDH", para);
        }
        public string TangMa()
        {
            return conn.TangMaNVU("SELECT * FROM dbo.tbl_dondathang", "DDH");
        }
        public DataTable TimKiemPYC(string strTimKiem)
        {
            return conn.GetDataStr(strTimKiem);
        }

        //////////////////// chi tiết đơn đặt hàng
        public DataTable DataCTDDH(string strCTYC)
        {
            return conn.GetDataStr(strCTYC);
        }
        public int InsertDataCT(EntityChiTietDonDatHang CTDDH)
        {
            SqlParameter[] para =
            {
                new SqlParameter("id_dondathang",CTDDH.id_dondathang),
                new SqlParameter("id_sanpham",CTDDH.id_sanpham),
                new SqlParameter("soluong",CTDDH.soluong),
                new SqlParameter("thanhtien",CTDDH.thanhtien)
            };
            return conn.ExcuteSQL("ThemCTDDH", para);
        }
        public int UpdateDataCT(EntityChiTietDonDatHang CTDDH)
        {
            SqlParameter[] para =
             {
                  new SqlParameter("id_dondathang",CTDDH.id_dondathang),
                new SqlParameter("id_sanpham",CTDDH.id_sanpham),
                new SqlParameter("soluong",CTDDH.soluong),
                new SqlParameter("thanhtien",CTDDH.thanhtien)
            };
            return conn.ExcuteSQL("SuaCTDDH", para);
        }
        public int DeleteDataCT(string IDMP, string IDMM)
        {
            SqlParameter[] para =
            {
                new SqlParameter("id_dondathang",IDMP),
                new SqlParameter("id_sanpham",IDMM)

        };
            return conn.ExcuteSQL("XoaCTDDH", para);
        }
        public DataTable GetListSP(string sql)
        {
            return conn.GetDataStr(sql);
        }
        // DS sản phẩm không có trong CTDDH
        public DataTable GetListThemSP(string sql)
        {
            return conn.GetDataStr(sql);
        }
        /// <summary>
        /// Sau khi thanh toán, trạng thái hóa đơn chuyển từ chưa thanh toán sang đã thanh toán (0==>1)
        /// </summary>
        /// <param name="PYC"></param>
        /// <returns></returns>
        public int UpdateDataTT(EntityDonDatHang DDH)
        {
            SqlParameter[] para =
           {
               new SqlParameter("id",DDH.id),
                new SqlParameter("id_tinhtrang",DDH.id_tinhtrang)
            };
            return conn.ExcuteSQL("DaTT", para);
        }
        // Quản lý hóa đơn đã thanh toán
        public DataTable GetDataHoaDonTT()
        {
            return conn.GetDataProc("HoaDonDaTT", null);
        }

        ///
        public DataTable GetListNVLap()
        {
            return conn.GetDataStr("SELECT * FROM dbo.tbl_nhanvien WHERE id_nhiemvu='NVU02'");
        }
        public DataTable GetListNVShipper()
        {
            return conn.GetDataStr("SELECT * FROM dbo.tbl_nhanvien WHERE id_nhiemvu='NVU03'");
        }
        public DataTable GetListKH()
        {
            return conn.GetDataStr("SELECT * FROM dbo.tbl_khachhang");
        }
        
        // TK gần đúng
        public DataTable TimKiemTen(string Ten)
        {
            return conn.GetDataStr(Ten);
        }
        //
        public DataTable GetListDM()
        {
            return conn.GetDataProc("Sellect_All_DM", null);
        }
    }
}
