using BanDienThoai.BUS;
using BanDienThoai.Helper;
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

    public partial class frmHoaDonDaThanhToan : Form
    {
        BUSDonDatHang Bus = new BUSDonDatHang();
        public frmHoaDonDaThanhToan()
        {
            InitializeComponent();
        }
        private void HienThi()
        {
            dgvDDH.DataSource = Bus.GetDataHoaDonTT();
            dgvDDH.AutoResizeColumns();
        }
        private void HienThiCT()
        {
            dgvCTDDH.DataSource = Bus.DataCTDDH("SELECT id_dondathang,ten,tbl_chitietdonhang.soluong,gia,thanhtien FROM dbo.tbl_chitietdonhang INNER JOIN dbo.tbl_sanpham ON tbl_sanpham.id = tbl_chitietdonhang.id_sanpham WHERE TrangThai=0 and id_dondathang like '" + txtMaDon.Text + "'");
            dgvCTDDH.AutoResizeColumns();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                HienThi();
        }

        private void dgvDDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDon.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["id"].Value);
            HienThiCT();
        }

        private void dgvDDH_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvDDH.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgvCTDDH_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvCTDDH.Rows[e.RowIndex].Cells["_STT"].Value = e.RowIndex + 1;
        }

        private void frmHoaDonDaThanhToan_Load(object sender, EventArgs e)
        {
            HienThi();
            txtMaDon.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThi();
            txtMaDon.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbTimKiem.Text == "Mã đơn")
            {
                dgvDDH.DataSource = Bus.TimKiemPYC("SELECT tbl_dondathang.id,ten,id_nguoilap,ngaylap,SUM(thanhtien) AS tongtien FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id INNER JOIN dbo.tbl_chitietdonhang ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id WHERE id_tinhtrang = 1 AND tbl_dondathang.id LIKE '%"+txtTimKiem.Text+"%' GROUP BY tbl_dondathang.id, ten, id_nguoilap, ngaylap");
            }
            if (cbTimKiem.Text == "Khách Hàng")
            {
                dgvDDH.DataSource = Bus.TimKiemPYC("SELECT tbl_dondathang.id,ten,id_nguoilap,ngaylap,SUM(thanhtien) AS tongtien FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id INNER JOIN dbo.tbl_chitietdonhang ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id WHERE id_tinhtrang = 1 AND ten LIKE N'%" + txtTimKiem.Text + "%' GROUP BY tbl_dondathang.id, ten, id_nguoilap, ngaylap");
            }
            if (cbTimKiem.Text == "Nhân Viên")
            {
                dgvDDH.DataSource = Bus.TimKiemPYC("SELECT tbl_dondathang.id,ten,id_nguoilap,ngaylap,SUM(thanhtien) AS tongtien FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id INNER JOIN dbo.tbl_chitietdonhang ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id WHERE id_tinhtrang = 1 AND id_nguoilap LIKE '%" + txtTimKiem.Text + "%' GROUP BY tbl_dondathang.id, ten, id_nguoilap, ngaylap");
            }
            if (cbTimKiem.Text == "Ngày lập")
            {
                dgvDDH.DataSource = Bus.TimKiemPYC("SELECT tbl_dondathang.id,ten,id_nguoilap,ngaylap,SUM(thanhtien) AS tongtien FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id INNER JOIN dbo.tbl_chitietdonhang ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id WHERE id_tinhtrang = 1 AND ngaylap LIKE '%" + txtTimKiem.Text + "%' GROUP BY tbl_dondathang.id, ten, id_nguoilap, ngaylap");
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            files.ExportToExcel(dgvDDH);
        }
    }
}
