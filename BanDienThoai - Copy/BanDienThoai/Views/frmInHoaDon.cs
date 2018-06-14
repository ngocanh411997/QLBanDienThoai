using BanDienThoai.DAL;
using BanDienThoai.Entity;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanDienThoai.Views
{
    public partial class frmInHoaDon : Form
    {
        public frmInHoaDon()
        {
            InitializeComponent();
        }
        KetNoi dblayer = new KetNoi();
        ReportDocument cry = new ReportDocument();
        string ma;
        public frmInHoaDon(string text):this()
        {
            ma = text;
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            txtMaHD.Text = ma;
            txtMaHD.Enabled = false;
            List<HoaDon> _List = new List<HoaDon>();
            DataSet ds1 = dblayer.HD1("SELECT ten,tbl_chitietdonhang.soluong,gia,thanhtien FROM dbo.tbl_chitietdonhang INNER JOIN dbo.tbl_sanpham ON tbl_sanpham.id = tbl_chitietdonhang.id_sanpham WHERE id_dondathang LIKE'"+txtMaHD.Text+"' AND TrangThai=0");
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                _List.Add(new HoaDon
                {
                    TenSP = dr["ten"].ToString(),                  
                    SoLuong = Convert.ToInt32(dr["soluong"].ToString()),
                    Gia = Convert.ToInt32(dr["gia"].ToString()),
                    ThanhTien = Convert.ToInt32(dr["thanhtien"].ToString())
                });
            }

            cry.Load(@"C:\Users\NgocAnh\Documents\GitHub\QLBanDienThoai\BanDienThoai - Copy\BanDienThoai\Views\CR_InHoaDon.rpt");
            cry.SetDataSource(ds1);
            crystalReportViewer1.ReportSource = cry;
            //
            DataSet ds2 = dblayer.HD2("SELECT tbl_dondathang.id,id_nguoilap,ngaylap,id_khachhang,ten,SUM(thanhtien) AS TongTien FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id INNER JOIN dbo.tbl_chitietdonhang ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id WHERE id_dondathang LIKE'"+txtMaHD.Text+"' GROUP BY tbl_dondathang.id,id_nguoilap,ngaylap,id_khachhang,ten");
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                cR_InHoaDon1.SetDataSource(_List);
                cR_InHoaDon1.SetParameterValue("pMaHD", dr["id"].ToString());
                cR_InHoaDon1.SetParameterValue("pMaNV", dr["id_nguoilap"].ToString());
                cR_InHoaDon1.SetParameterValue("pNgay", dr["ngaylap"].ToString());
                cR_InHoaDon1.SetParameterValue("pMaKH", dr["id_khachhang"].ToString());
                cR_InHoaDon1.SetParameterValue("pTenKH", dr["ten"].ToString());
                cR_InHoaDon1.SetParameterValue("pTongTien", Convert.ToInt32(dr["TongTien"].ToString()));
            }
            crystalReportViewer1.ReportSource = cR_InHoaDon1;
        }
    }
}
