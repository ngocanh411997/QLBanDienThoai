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
    public partial class frmChiTietDonDatHang : Form
    {
        
        EntityChiTietDonDatHang obj = new EntityChiTietDonDatHang();
        BUSDonDatHang Bus = new BUSDonDatHang();
        private int fluu = 1;
        public frmChiTietDonDatHang()
        {
            InitializeComponent();
        }
        string ma = "";
        public frmChiTietDonDatHang(string text):this()
        {
            ma = text;
        }
        public void ShowDM()
        {
            DataTable dt = new DataTable();
            dt = Bus.GetListDM();
            cbDM.DataSource = dt;
            cbDM.DisplayMember = "ten";
            cbDM.ValueMember = "id";
        }
        public void ShowSP()
        {
            DataTable dt = new DataTable();
            dt = Bus.GetListSanPham("SELECT tbl_sanpham.id,tbl_sanpham.ten FROM dbo.tbl_sanpham INNER JOIN dbo.tbl_danhmuc ON tbl_danhmuc.id = tbl_sanpham.id_danhmuc WHERE tbl_danhmuc.id LIKE'" + cbDM.SelectedValue.ToString() + "' AND TrangThai=0");
            cbSanPham.DataSource = dt;
            cbSanPham.DisplayMember = "ten";
            cbSanPham.ValueMember = "id";
          
        }
        public void ShowThemSP()
        {
            DataTable dt = new DataTable();
            dt = Bus.GetListSP("SELECT * FROM dbo.tbl_sanpham  WHERE ten NOT IN (SELECT tbl_sanpham.ten FROM dbo.tbl_chitietdonhang INNER JOIN dbo.tbl_sanpham ON tbl_sanpham.id = tbl_chitietdonhang.id_sanpham INNER JOIN dbo.tbl_danhmuc ON tbl_danhmuc.id = tbl_sanpham.id_danhmuc WHERE id_dondathang LIKE '"+txtMaDon.Text+"') AND TrangThai=0 AND id_danhmuc LIKE'"+cbDM.SelectedValue.ToString()+"'");
            cbSanPham.DataSource = dt;
            cbSanPham.DisplayMember = "ten";
            cbSanPham.ValueMember = "id";
        }
        private void DisEnl(bool e)
        {
            btnThemCT.Enabled = !e;
            btnXoaCT.Enabled = !e;
            btnSuaCT.Enabled = !e;
            btnLuuCT.Enabled = e;
            btnHuy.Enabled = e;
            txtSoLuong.Enabled = e;
            cbSanPham.Enabled = e;
            cbDM.Enabled = e;

        }
        private void HienThi()
        {
            txtMaDon.Text = ma;
            dgvChiTietDDH.DataSource = Bus.DataCTDDH("SELECT id_dondathang,ten,tbl_chitietdonhang.soluong,gia,thanhtien FROM dbo.tbl_chitietdonhang INNER JOIN dbo.tbl_sanpham ON tbl_sanpham.id = tbl_chitietdonhang.id_sanpham WHERE TrangThai=0 and id_dondathang like '"+txtMaDon.Text+"'");
            txtMaDon.Enabled = false;
            ShowDM();
            ShowSP();       
        }
        private void btnThemCT_Click(object sender, EventArgs e)
        {
            fluu = 0;
            DisEnl(true);
            txtMaDon.Enabled = false;
            ShowThemSP();
           
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            fluu = 1;
            DisEnl(true);
            txtMaDon.Enabled = false;
            cbSanPham.Enabled = false;
        
        }
    

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Bus.DeleteDataCT(txtMaDon.Text, cbSanPham.SelectedValue.ToString());
                    MessageBox.Show("Xóa thành công!");
                    DisEnl(false);
                    HienThi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void btnLuuCT_Click(object sender, EventArgs e)
        {
            if (txtMaDon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã đơn! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cbSanPham.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập sản phẩm! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int _soLuong;
            int.TryParse(txtSoLuong.Text, out _soLuong);



            obj.id_sanpham = cbSanPham.SelectedValue.ToString();
            obj.id_dondathang = txtMaDon.Text;
            obj.soluong = _soLuong;


            if (txtMaDon.Text != "" && txtSoLuong.Text != "" && cbSanPham.Text != "" && fluu == 0)
            {
                try
                {
                    Bus.InsertDataCT(obj);
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    frmChiTietDonDatHang_Load(sender, e);
                   
                    DisEnl(false);
                    fluu = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
            else if (txtMaDon.Text != "" && txtSoLuong.Text != "" && cbSanPham.Text != "" && fluu != 0)
            {
                try
                {
                    Bus.UpdateDataCT(obj);
                    MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    frmChiTietDonDatHang_Load(sender, e);
                    
                    DisEnl(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                HienThi();
                DisEnl(false);
                fluu = 1;

            }
            else
                return;
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

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmThanhToan TT = new frmThanhToan(txtMaDon.Text);
            TT.ShowDialog();
        }

        private void btnDSSP_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSanPham SP = new frmSanPham();
            SP.ShowDialog();
            this.Show();
        }

        private void frmChiTietDonDatHang_Load(object sender, EventArgs e)
        {
            HienThi();
            DisEnl(false);
        }

        private void dgvChiTietDDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fluu == 0)
            {
                //cbMonAn.Text = Convert.ToString(dgvChiTietPYC.CurrentRow.Cells["TENMON"].Value);
                txtSoLuong.Text = Convert.ToString(dgvChiTietDDH.CurrentRow.Cells["soluong"].Value);

            }
            else
            {
                cbSanPham.Text = Convert.ToString(dgvChiTietDDH.CurrentRow.Cells["ten"].Value);
                txtSoLuong.Text = Convert.ToString(dgvChiTietDDH.CurrentRow.Cells["soluong"].Value);

            }

        }

        private void dgvChiTietDDH_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvChiTietDDH.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void cbDM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSP();
            ShowThemSP();
        }
    }
}
