using BanDienThoai.BUS;
using BanDienThoai.Entity;
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
    public partial class frmDonDatHang : Form
    {
        EntityDonDatHang obj = new EntityDonDatHang();
        
        BUSDonDatHang Bus = new BUSDonDatHang();
        private int fluu = 1;
        public frmDonDatHang()
        {
            InitializeComponent();
        }
        public void ShowNVLap()
        {
            DataTable dt = new DataTable();
            dt = Bus.GetListNVLap();
            cbNVLap.DataSource = dt;
            cbNVLap.DisplayMember = "id";
            cbNVLap.ValueMember = "id";
        }
        public void ShowNVShipper()
        {
            DataTable dt = new DataTable();
            dt = Bus.GetListNVShipper();
            cbShipper.DataSource = dt;
            cbShipper.DisplayMember = "id";
            cbShipper.ValueMember = "id";
        }
        public void ShowKH()
        {
            DataTable dt = new DataTable();
            dt = Bus.GetListKH();
            cbKH.DataSource = dt;
            cbKH.DisplayMember = "id";
            cbKH.ValueMember = "id";
        }
        private void DisEnl(bool e)
        {
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            txtID.Enabled = e;
            cbKH.Enabled = e;
            cbNVLap.Enabled = e;
            cbShipper.Enabled = e;
            dtNgayNhap.Enabled = e;
            txtNoiNhan.Enabled = e;
            txtGhiChu.Enabled = e;            
        }
        private void clearData()
        {
            txtID.Text = "";
            cbKH.Text = "";
            cbNVLap.Text = "";
            cbShipper.Text = "";
            dtNgayNhap.Value = DateTime.Now;
            txtGhiChu.Text = "";
            txtNoiNhan.Text = "";
            txtTimKiem.Text = "";
        }
        private void HienThi()
        {
            dgvDDH.DataSource = Bus.GetDataProc();
            dgvDDH.AutoResizeColumns();
            ShowNVLap();
            ShowNVShipper();
            ShowKH();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fluu = 0;
            txtID.Text = Bus.TangMa();
            DisEnl(true);
            txtID.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            fluu = 1;
            DisEnl(true);
            txtID.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Bus.DeleteData(txtID.Text);
                    MessageBox.Show("Xóa thành công!");
                    clearData();
                    DisEnl(false);
                    HienThi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            files.ExportToExcel(dgvDDH);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu yêu cầu! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cbKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập khách hàng! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cbNVLap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nhân viên lập! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cbShipper.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nhân viên shipper! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if (dtNgayNhap.Value != DateTime.Now)
            //{
            //    MessageBox.Show("Bạn nhập sai ngày! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            obj.id = txtID.Text;
            obj.id_khachhang = cbKH.Text;
            obj.id_nguoilap = cbNVLap.Text;
            obj.id_shipper = cbShipper.Text;
            obj.ngaylap = dtNgayNhap.Value;
            obj.noinhan = txtNoiNhan.Text;
            obj.ghichu = txtGhiChu.Text;
            if (txtID.Text != "" && cbKH.Text != "" && cbNVLap.Text != "" && cbShipper.Text !="" && fluu == 0)
            {
                try
                {

                    Bus.InsertData(obj);
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    frmDonDatHang_Load(sender, e);
                    clearData();
                    DisEnl(false);
                    fluu = 1;
                }
                catch
                {

                }
            }
            else if (txtID.Text != "" && cbKH.Text != "" && cbNVLap.Text != "" && cbShipper.Text != "" && fluu != 0)
            {
                try
                {
                    Bus.UpdateData(obj);
                    MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    frmDonDatHang_Load(sender, e);
                    clearData();
                    DisEnl(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            clearData();
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn kiểu tìm kiếm!", "Thông báo");
            }
            else if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập từ khóa!", "Thông báo");
            }
            else
            {
                if (cbTimKiem.Text == "Mã Đơn")
                {
                    dgvDDH.DataSource = Bus.TimKiemPYC("SELECT tbl_dondathang.id,tbl_khachhang.ten,id_shipper,id_nguoilap,ngaylap,noinhan,ghichu FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id WHERE id_tinhtrang = 0 AND tbl_dondathang.id LIKE '%"+txtTimKiem.Text+"%'");
                }
                if (cbTimKiem.Text == "Khách Hàng")
                {
                    dgvDDH.DataSource = Bus.TimKiemTen("EXEC dbo.TK_KH @Ten = N'" + txtTimKiem.Text + "'");
                }
                if (cbTimKiem.Text == "Nhân Viên")
                {
                    dgvDDH.DataSource = Bus.TimKiemPYC("SELECT tbl_dondathang.id,tbl_khachhang.ten,id_shipper,id_nguoilap,ngaylap,noinhan,ghichu FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id WHERE id_tinhtrang = 0 AND id_shipper LIKE '%" + txtTimKiem.Text + "%' or id_nguoilap LIKE '%" + txtTimKiem.Text + "%'");
                }
               
                if (cbTimKiem.Text == "Ngày Nhập")
                {
                    dgvDDH.DataSource = Bus.TimKiemPYC("SELECT tbl_dondathang.id,tbl_khachhang.ten,id_shipper,id_nguoilap,ngaylap,noinhan,ghichu FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id WHERE id_tinhtrang = 0 AND ngaylap LIKE '%" + txtTimKiem.Text+"%'");
                }
            }

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void dgvDDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fluu == 0)
            {
                cbShipper.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["id_shipper"].Value);
                cbNVLap.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["id_nguoilap"].Value);
                cbKH.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["id_khachhang"].Value);               
                dtNgayNhap.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["ngaylap"].Value);
                txtNoiNhan.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["noinhan"].Value);
                txtGhiChu.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["ghichu"].Value);
            }
            else if (fluu != 0 && fluu != -1)
            {
                txtID.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["id"].Value);
                cbShipper.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["id_shipper"].Value);
                cbNVLap.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["id_nguoilap"].Value);
                cbKH.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["id_khachhang"].Value);
                dtNgayNhap.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["ngaylap"].Value);
                txtNoiNhan.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["noinhan"].Value);
                txtGhiChu.Text = Convert.ToString(dgvDDH.CurrentRow.Cells["ghichu"].Value);
            }
        }

        private void dgvDDH_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvDDH.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
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

        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            HienThi();
            DisEnl(false);
        }

        private void btnMuaHang_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã phiếu! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                frmChiTietDonDatHang CT = new frmChiTietDonDatHang(txtID.Text);
                CT.ShowDialog();
                this.Show();
                HienThi();
            }
        }
    }
}
