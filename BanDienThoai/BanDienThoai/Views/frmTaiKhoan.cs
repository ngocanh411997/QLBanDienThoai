using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BanDienThoai.Views
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private bool them;
        public void KetNoi()
        {
            SqlConnection conn = new SqlConnection(DataAccess.ConnectionString.connectionString);
            conn.Open();
            string sql = "select id, taikhoan, matkhau, id_quyen from tbl_nguoidung";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dgvTaiKhoan.DataSource = dt;
        }

        public void LoadData()
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "id");

            txtTenDangNhap.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "taikhoan");

            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "matkhau");

            cboQuyen.DataBindings.Clear();
            cboQuyen.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "id_quyen");
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
            ShowQuyen();
            txtTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            cboQuyen.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtID.ReadOnly = true;
        }

        public void ShowQuyen()
        {
            SqlConnection con = new SqlConnection(DataAccess.ConnectionString.connectionString);
            con.Open();
            string sql = "select id, ten from tbl_quyen";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cboQuyen.DataSource = dt;
            cboQuyen.DisplayMember = "ten";
            cboQuyen.ValueMember = "id";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            txtTenDangNhap.Enabled = true;
            txtTenDangNhap.Text = "";
            txtMatKhau.Enabled = true;
            txtMatKhau.Text = "";
            cboQuyen.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            txtTenDangNhap.Enabled = true;
            txtMatKhau.Enabled = true;
            cboQuyen.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DataAccess.ConnectionString.connectionString);
            con.Open();
            string sql;
            if (them == true)
            {
                try
                {
                    sql = "INSERT INTO dbo.tbl_nguoidung( taikhoan, matkhau, id_quyen) VALUES  ( N'" + txtTenDangNhap.Text.Trim() + "', N'" + txtMatKhau.Text.Trim() + "', '" + cboQuyen.SelectedValue + "')";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    int temp = cmd.ExecuteNonQuery();
                    if (temp > 0)
                    {
                        MessageBox.Show("Đã thêm!");
                        KetNoi();
                        LoadData();
                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Chưa thêm được!");
                    }
                }
                catch
                {

                }
                
            }
            else
            {
                try
                {
                    sql = "UPDATE dbo.tbl_nguoidung SET taikhoan = '" + txtTenDangNhap.Text.Trim() + "', matkhau = '"+txtMatKhau.Text.Trim()+"', id_quyen = '"+cboQuyen.SelectedValue+"' WHERE id = '"+txtID.Text.Trim()+"'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    int temp = cmd.ExecuteNonQuery();
                    if (temp > 0)
                    {
                        MessageBox.Show("Đã sửa!");
                        KetNoi();
                        LoadData();
                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Chưa sửa được!");
                    }
                }
                catch
                {

                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
            ShowQuyen();
            txtTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            cboQuyen.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtID.ReadOnly = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản vừa chọn không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(DataAccess.ConnectionString.connectionString);
                con.Open();
                try
                {
                    string sql = "delete tbl_nguoidung where id = '"+txtID.Text.Trim()+"'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    int temp = cmd.ExecuteNonQuery();
                    if (temp > 0)
                    {
                        MessageBox.Show("Đã xóa!");
                        KetNoi();
                        LoadData();
                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Chưa xóa được!");
                    }
                }
                catch
                {

                }
            }
        }

    }
}
