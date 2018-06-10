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
    public partial class frmNhanVien : Form
    {
        EntityNhanVien obj = new EntityNhanVien();
        BUSNhanVien Bus = new BUSNhanVien();
        private int fluu = 1;
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public void ShowNV()
        {
            DataTable dt = new DataTable();
            dt = Bus.GetListNV();
            cbNhiemVu.DataSource = dt;
            cbNhiemVu.DisplayMember = "nhiemvu";
            cbNhiemVu.ValueMember = "id";
        }
        private void DisEnl(bool e)
        {
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            txtID.Enabled = e;
            txtTen.Enabled = e;
            cbNhiemVu.Enabled = e;
            txtEmail.Enabled = e;
            txtSDT.Enabled = e;
            dtNgaySinh.Enabled = e;
        }
        private void clearData()
        {
            txtID.Text = "";
            txtTen.Text = "";
            txtTimKiem.Text = "";
            cbTimKiem.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            dtNgaySinh.Value = DateTime.Parse("01/01/1997");
            cbNhiemVu.Text = "";
        }
        private void HienThi()
        {
            dgvNV.DataSource = Bus.GetDataProc();
            dgvNV.AutoResizeColumns();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cbNhiemVu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhiệm vụ cho nhân viên! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập SĐT nhân viên! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Email nhân viên! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dtNgaySinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh nhân viên! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            int _SDT;
            int.TryParse(txtSDT.Text, out _SDT);

            obj.id = txtID.Text;
            obj.ten = txtTen.Text;
            obj.sdt = _SDT;
            obj.email = txtEmail.Text;
            obj.id_nhiemvu = cbNhiemVu.SelectedValue.ToString();
            obj.ngaysinh = dtNgaySinh.Value;


            if (txtID.Text != "" && txtTen.Text != ""&& txtSDT.Text !="" && txtEmail.Text!="" && cbNhiemVu.Text !="" && fluu == 0)
            {
                try
                {
                    Bus.InsertData(obj);
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    frmNhanVien_Load(sender, e);
                    clearData();
                    DisEnl(false);
                    fluu = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
            else if (txtID.Text != "" && txtTen.Text != "" && txtSDT.Text != "" && txtEmail.Text != "" && cbNhiemVu.Text != "" && fluu != 0)
            {
                try
                {
                    Bus.UpdateData(obj);
                    MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    frmNhanVien_Load(sender, e);
                    clearData();
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

        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            files.ExportToExcel(dgvNV);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                this.Hide();
            }
            else
                HienThi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThi();
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
                if (cbTimKiem.Text == "Mã NV")
                {
                    dgvNV.DataSource = Bus.TimKiem("SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu WHERE tbl_nhanvien.id LIKE'%"+txtTimKiem.Text+"%'");
                }
                if (cbTimKiem.Text == "Tên NV")
                {
                    dgvNV.DataSource = Bus.TimKiemTen("EXEC dbo.TKTenNV @Ten = N'" + txtTimKiem.Text + "'");
                }
                if (cbTimKiem.Text == "Nhiệm vụ")
                {
                    dgvNV.DataSource = Bus.TimKiemTen("EXEC dbo.TK_NVu @Ten = N'" + txtTimKiem.Text + "'");
                }
                if (cbTimKiem.Text == "SĐT")
                {
                    dgvNV.DataSource = Bus.TimKiemTen("SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu WHERE sdt LIKE'%" + txtTimKiem.Text + "%'");
                }
                if (cbTimKiem.Text == "Email")
                {
                    dgvNV.DataSource = Bus.TimKiemTen("SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu WHERE email LIKE'%" + txtTimKiem.Text + "%'");
                }
                if (cbTimKiem.Text == "Ngày sinh")
                {
                    dgvNV.DataSource = Bus.TimKiemTen("SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu WHERE ngaysinh LIKE'%" + txtTimKiem.Text + "%'");
                }
            }
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fluu == 0)
            {
                txtTen.Text = Convert.ToString(dgvNV.CurrentRow.Cells["ten"].Value);
                cbNhiemVu.Text = Convert.ToString(dgvNV.CurrentRow.Cells["nhiemvu"].Value);
                txtEmail.Text = Convert.ToString(dgvNV.CurrentRow.Cells["email"].Value);
                txtSDT.Text = Convert.ToString(dgvNV.CurrentRow.Cells["sdt"].Value);
                dtNgaySinh.Text = Convert.ToString(dgvNV.CurrentRow.Cells["ngaysinh"].Value);
            }
            else
            {
                txtID.Text = Convert.ToString(dgvNV.CurrentRow.Cells["id"].Value);
                txtTen.Text = Convert.ToString(dgvNV.CurrentRow.Cells["ten"].Value);
                cbNhiemVu.Text = Convert.ToString(dgvNV.CurrentRow.Cells["nhiemvu"].Value);
                txtEmail.Text = Convert.ToString(dgvNV.CurrentRow.Cells["email"].Value);
                txtSDT.Text = Convert.ToString(dgvNV.CurrentRow.Cells["sdt"].Value);
                dtNgaySinh.Text = Convert.ToString(dgvNV.CurrentRow.Cells["ngaysinh"].Value);
            }
        }

        private void dgvNV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvNV.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            HienThi();
            DisEnl(false);
            ShowNV();
        }
    }
}
