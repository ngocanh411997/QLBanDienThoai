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
    public class DALNhanVien
    {
        KetNoi conn = new KetNoi();
        public DataTable GetDataProc()
        {
            return conn.GetDataProc("XemNV", null);
        }
        public int InsertData(EntityNhanVien NV)
        {
            SqlParameter[] para =
            {
               new SqlParameter("id",NV.id),
                new SqlParameter("id_nhiemvu",NV.id_nhiemvu),
                new SqlParameter("ten",NV.ten),
                new SqlParameter("sdt",NV.sdt),
                new SqlParameter("email",NV.email),
                new SqlParameter("ngaysinh",NV.ngaysinh)
            };
            return conn.ExcuteSQL("ThemNV", para);
        }
        public int UpdateData(EntityNhanVien NV)
        {
            SqlParameter[] para =
             {
                new SqlParameter("id",NV.id),
                new SqlParameter("id_nhiemvu",NV.id_nhiemvu),
                new SqlParameter("ten",NV.ten),
                new SqlParameter("sdt",NV.sdt),
                new SqlParameter("email",NV.email),
                new SqlParameter("ngaysinh",NV.ngaysinh)
            };
            return conn.ExcuteSQL("SuaNV", para);
        }
        public int DeleteData(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("id",ID)
        };
            return conn.ExcuteSQL("XoaNV", para);
        }
        public string TangMa()
        {
            return conn.TangMa("SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu", "NV");
        }
        public DataTable TimKiem(string strTimKiem)
        {
            return conn.GetDataStr(strTimKiem);
        }
        public DataTable TimKiemTen(string Ten)
        {
            return conn.GetDataStr(Ten);
        }
        public DataTable GetListNhiemVu()
        {
            return conn.GetDataProc("XemNVu ", null);
        }
    }
}
