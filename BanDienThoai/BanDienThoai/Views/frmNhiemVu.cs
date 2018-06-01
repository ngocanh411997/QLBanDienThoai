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
    public partial class frmNhiemVu : Form
    {
        EntityNhiemVu obj = new EntityNhiemVu();
        BUSNhiemVu Bus = new BUSNhiemVu();
        private int fluu = 1;
        public frmNhiemVu()
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
            txtNhiemVu.Enabled = e;     
        }
        private void clearData()
        {
            txtID.Text = "";
            txtNhiemVu.Text = "";           
            txtTimKiem.Text = "";   
            cbTimKiem.Text = "";
        }
        private void HienThi()
        {
            dgvNhVu.DataSource = Bus.GetDataProc();
            dgvNhVu.AutoResizeColumns();
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
                MessageBox.Show("Bạn chưa nhập mã nhiệm vụ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtNhiemVu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhiệm vụ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
          

            obj.nhiemvu = txtNhiemVu.Text;
            obj.id = txtID.Text;
        

            if (txtID.Text != "" && txtNhiemVu.Text != "" && fluu == 0)
            {
                try
                {
                    Bus.InsertData(obj);
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    frmNhiemVu_Load(sender, e);
                    clearData();
                    DisEnl(false);
                    fluu = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
            else if (txtID.Text != "" && txtNhiemVu.Text != "" && fluu != 0)
            {
                try
                {
                    Bus.UpdateData(obj);
                    MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    frmNhiemVu_Load(sender, e);
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
            files.ExportToExcel(dgvNhVu);
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
                if (cbTimKiem.Text == "Mã")
                {
                    dgvNhVu.DataSource = Bus.TimKiem("SELECT * FROM dbo.tbl_nhiemvu WHERE id LIKE '%"+txtTimKiem.Text+"%'");
                }
                if (cbTimKiem.Text == "Nhiệm vụ")
                {
                    dgvNhVu.DataSource = Bus.TimKiemTen("EXEC dbo.TKTenNVu @Ten = N'" + txtTimKiem.Text + "'");
                }
               
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void frmNhiemVu_Load(object sender, EventArgs e)
        {
            HienThi();
            DisEnl(false);      
        }

        private void dgvNhVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fluu == 0)
            {
                txtNhiemVu.Text = Convert.ToString(dgvNhVu.CurrentRow.Cells["nhiemvu"].Value);            
            }
            else
            {
                txtID.Text = Convert.ToString(dgvNhVu.CurrentRow.Cells["id"].Value);
                txtNhiemVu.Text = Convert.ToString(dgvNhVu.CurrentRow.Cells["nhiemvu"].Value);             
            }
        }

        private void dgvNhVu_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvNhVu.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }
    }
}
