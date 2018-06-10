using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanDienThoai.BUS;
using BanDienThoai.Entity;
using BanDienThoai.Helper;

namespace BanDienThoai.Views
{
    public partial class frmKhachHang : Form
    {
        EntityKhachHang obj = new EntityKhachHang();
        BUSKhachHang Bus = new BUSKhachHang();
        private int fluu = 1;

        public frmKhachHang()
        {
            InitializeComponent();
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
            txtDiaChi.Enabled = e;
            txtEmail.Enabled = e;
            txtSDT.Enabled = e;
           
        }
        private void clearData()
        {
            txtID.Text = "";
            txtTen.Text = "";
            txtTimKiem.Text = "";
            cbTimKiem.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }
        private void HienThi()
        {
            dgvKH.DataSource = Bus.GetDataProc();
            dgvKH.AutoResizeColumns();
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            HienThi();
            DisEnl(false);
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fluu == 0)
            {
                txtTen.Text = Convert.ToString(dgvKH.CurrentRow.Cells["ten"].Value);
                txtEmail.Text = Convert.ToString(dgvKH.CurrentRow.Cells["email"].Value);
                txtSDT.Text = Convert.ToString(dgvKH.CurrentRow.Cells["sdt"].Value);
                txtDiaChi.Text = Convert.ToString(dgvKH.CurrentRow.Cells["diachi"].Value);

            }
            else
            {
                txtID.Text = Convert.ToString(dgvKH.CurrentRow.Cells["id"].Value);
                txtTen.Text = Convert.ToString(dgvKH.CurrentRow.Cells["ten"].Value);
                txtEmail.Text = Convert.ToString(dgvKH.CurrentRow.Cells["email"].Value);
                txtSDT.Text = Convert.ToString(dgvKH.CurrentRow.Cells["sdt"].Value);
                txtDiaChi.Text = Convert.ToString(dgvKH.CurrentRow.Cells["diachi"].Value);
            }

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
            if(MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                try
                {
                    Bus.DeleteData(txtID.Text);
                    MessageBox.Show("Xóa thành công!");
                    clearData();
                    DisEnl(false);
                    HienThi();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (txtID.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập SĐT khách hàng! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Email khách hàng! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ khách hàng ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            int _SDT;
            int.TryParse(txtSDT.Text, out _SDT);

            obj.id = txtID.Text;
            obj.ten = txtTen.Text;
            obj.sdt = _SDT;
            obj.email = txtEmail.Text;
            obj.diachi = txtDiaChi.Text;

           


            if (txtID.Text != "" && txtTen.Text != "" && txtSDT.Text != "" && txtEmail.Text != "" &&txtDiaChi.Text != "" && fluu == 0)
            {
                try
                {
                    Bus.InsertData(obj);
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    frmKhachHang_Load(sender, e);
                    clearData();
                    DisEnl(false);
                    fluu = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
            else if (txtID.Text != "" && txtTen.Text != "" && txtSDT.Text != "" && txtEmail.Text !=""&& txtDiaChi.Text !=   "" && fluu != 0)
            {
                try
                {
                    Bus.UpdateData(obj);
                    MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    frmKhachHang_Load(sender, e);
                    clearData();
                    DisEnl(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void dgvKH_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvKH.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
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
            files.ExportToExcel(dgvKH);
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
                if (cbTimKiem.Text == "Mã KH")
                {
                    dgvKH.DataSource = Bus.TimKiem("SELECT * FROM tbl_khachhang where id LIKE'%" + txtTimKiem.Text + "%'");
                }
                if (cbTimKiem.Text == "Tên KH")
                {
                    dgvKH.DataSource = Bus.TimKiemTen("EXEC dbo.TKTenKH @Ten = N'" + txtTimKiem.Text + "'");
                }
               
                if (cbTimKiem.Text == "SĐT")
                {
                    dgvKH.DataSource = Bus.TimKiemTen("SELECT * FROM tbl_khachhang where sdt LIKE'%" + txtTimKiem.Text + "%'");
                }
                if (cbTimKiem.Text == "Email")
                {
                    dgvKH.DataSource = Bus.TimKiemTen("SELECT * FROM tbl_khachhang where email LIKE'%" + txtTimKiem.Text + "%'");
                }
                if (cbTimKiem.Text == "Địa Chỉ")
                {
                    dgvKH.DataSource = Bus.TimKiemTen("SELECT * FROM tbl_khachhang where diachi  LIKE N'%" + txtTimKiem.Text + "%'");
                }
            }
        }
    }
}
