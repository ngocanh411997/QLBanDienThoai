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
    class DALSanPham
    {
        KetNoi conn = new KetNoi();
        public DataTable GetDataProc()
        {
            return conn.GetDataProc("XemSP", null);
        }
        public int InsertData(EntitySanPham SP)
        {
            SqlParameter[] para =
            {
               new SqlParameter("@id",SP.id),
               new SqlParameter("@id_KM",SP.id_KM),
               new SqlParameter("@id_DM",SP.id_DanhMuc),
               new SqlParameter("@ten",SP.ten),
               new SqlParameter("@linkanh",SP.linkanh),
               new SqlParameter("@gia",SP.gia),
               new SqlParameter("@SoLg",SP.SoLg),
               new SqlParameter("@trongLg",SP.TrongLg),
               new SqlParameter("@ROM",SP.ROM),
               new SqlParameter("@RAM",SP.RAM),
               new SqlParameter("@thenho",SP.TheNho),
               new SqlParameter("@CamTrc",SP.Cam_Trc),
               new SqlParameter("@CamSau",SP.Cam_Sau),
               new SqlParameter("@pin",SP.Pin),
               new SqlParameter("@BaoHanh",SP.BaoHanh),
               new SqlParameter("@Bluetooth",SP.Bluetooth),
               new SqlParameter("@idNSX",SP.id_NSX),
               new SqlParameter("@TrangThai",SP.TrangThai)

            };
            return conn.ExcuteSQL("ThemSP", para);
        }
        public int UpdateData(EntitySanPham SP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@id",SP.id),
               new SqlParameter("@id_KM",SP.id_KM),
               new SqlParameter("@id_DM",SP.id_DanhMuc),
               new SqlParameter("@ten",SP.ten),
               new SqlParameter("@linkanh",SP.linkanh),
               new SqlParameter("@gia",SP.gia),
               new SqlParameter("@SoLg",SP.SoLg),
               new SqlParameter("@trongLg",SP.TrongLg),
               new SqlParameter("@ROM",SP.ROM),
               new SqlParameter("@RAM",SP.RAM),
               new SqlParameter("@thenho",SP.TheNho),
               new SqlParameter("@CamTrc",SP.Cam_Trc),
               new SqlParameter("@CamSau",SP.Cam_Sau),
               new SqlParameter("@pin",SP.Pin),
               new SqlParameter("@BaoHanh",SP.BaoHanh),
               new SqlParameter("@Bluetooth",SP.Bluetooth),
               new SqlParameter("@idNSX",SP.id_NSX),
               new SqlParameter("@TrangThai",SP.TrangThai)


            };
            return conn.ExcuteSQL("SuaSP", para);
        }
        public int DeleteData(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("id",ID)
        };
            return conn.ExcuteSQL("XoaSP", para);
        }
        public DataTable TimKiem(string strTimKiem)
        {
            return conn.GetDataStr(strTimKiem);
        }
        public DataTable TimKiemTen(string Ten)
        {
            return conn.GetDataStr(Ten);
        }
        public DataTable GetListDanhMuc()
        {
            return conn.GetDataProc("XemDM ", null);
        }
        public DataTable GetListNhaSX()
        {
            return conn.GetDataProc("XemNSX", null);
        }
        public string TangMa()
        {
            return conn.TangMa("SELECT * from tbl_sanpham", "SP");
        }
    }
}
