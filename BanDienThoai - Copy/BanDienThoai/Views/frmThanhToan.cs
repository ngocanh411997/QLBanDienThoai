using BanDienThoai.BUS;
using BanDienThoai.Entity;
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
    public partial class frmThanhToan : Form
    {
        EntityDonDatHang obj = new EntityDonDatHang();
        BUSDonDatHang Bus = new BUSDonDatHang();
        public frmThanhToan()
        {
            InitializeComponent();
        }
        string ma = "";
        public frmThanhToan(string text): this()
        {
            ma = text;
        }
        private void HienThi()
        {
            txtMaDon.Text = ma;
            txtMaDon.Enabled = false;
            dgvThanhToan.DataSource = Bus.GetDataThanhToan("SELECT tbl_dondathang.id,ten,SUM(thanhtien) AS tongtien FROM dbo.tbl_chitietdonhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id = tbl_chitietdonhang.id_dondathang INNER JOIN dbo.tbl_khachhang ON tbl_khachhang.id = tbl_dondathang.id_khachhang WHERE tbl_dondathang.id LIKE '"+txtMaDon.Text+"' GROUP BY tbl_dondathang.id, ten");           
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

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            obj.id = txtMaDon.Text;
            Bus.UpdateDataTT(obj);
            MessageBox.Show("Xuất hóa đơn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            frmInHoaDon HD = new frmInHoaDon(txtMaDon.Text);
            HD.ShowDialog();
            this.Show();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            HienThi();
        }
    }
}
