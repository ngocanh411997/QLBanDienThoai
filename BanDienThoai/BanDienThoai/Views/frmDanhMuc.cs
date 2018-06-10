using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanDienThoai.Helper;
using System.Data.SqlClient;
namespace BanDienThoai.Views
{
    public partial class frmDanhMuc : Form
    {
        public frmDanhMuc()
        {
            InitializeComponent();
        }
        private void ketnoi()
        {
            try
            {
                SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                kn.Open();

                string sql = "select * from tbl_danhmuc";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thuc thi cac cau lenh trong sql
                SqlDataAdapter com = new SqlDataAdapter(commandsql);//van chuyen du lieu
                DataTable table = new DataTable();//tao 1 bang ao trong he thong 
                com.Fill(table);//do du lieu vao bang ao
                dgvDanhMuc.DataSource = table;//bang ao nay duoc do vao datagrirdview
            }
            catch
            {
                MessageBox.Show("Loi Ket Noi Vui Long Kiem Tra Lai !");

            }
            finally
            {
                SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                kn.Close();

            }
        }
        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            ketnoi();
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                this.Hide();
            }
            else
                frmDanhMuc_Load(sender, e);
        }

        private void dgvDanhMuc_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvDanhMuc.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }
        int index;
        private void dgvDanhMuc_Click(object sender, EventArgs e)
        {
            index = dgvDanhMuc.CurrentRow.Index;
            txtMaDM.Text = dgvDanhMuc.Rows[index].Cells[1].Value.ToString();
            txtTenDM.Text = dgvDanhMuc.Rows[index].Cells[2].Value.ToString();
            txtIcon.Text = dgvDanhMuc.Rows[index].Cells[3].Value.ToString();
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            files.ExportToExcel(dgvDanhMuc);
        }
        string sqlTimKiem;
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                conn.Open();
                //SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC\SQLSERVEREXPRESS;Initial Catalog=QL_GV_HS_THPT;Integrated Security=True");
                // conn.Open();
                sqlTimKiem = "SELECT *FROM tbl_danhmuc where id = '" + txtTimKiem.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlTimKiem, conn);
                cmd.Parameters.AddWithValue("id", txtTimKiem.Text.Trim());
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvDanhMuc.DataSource = dt;
            }
            catch
            {
                MessageBox.Show(" không tìm thấy!");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                kn.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            ketnoi();
            dgvDanhMuc_Click(sender, e);
        }
        string xoa;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa Danh Mục '" + txtTenDM.Text.Trim() + "'" + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                    kn.Open();

                    xoa = "delete  tbl_danhmuc where id='" + txtMaDM.Text + "'";
                    SqlCommand commandxoa = new SqlCommand(xoa, kn);

                    int temp = commandxoa.ExecuteNonQuery();

                    if (temp != 0)
                    {
                        ketnoi();
                        MessageBox.Show("Đã xóa!");
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi, không xóa được!");
                }
                finally
                {
                    SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                    kn.Close();
                }
            }
        }
        string them;
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                kn.Open();
                them = "insert into tbl_danhmuc values('" + txtMaDM.Text + "',N'" + txtTenDM.Text + "','" + txtIcon.Text + "')";
                SqlCommand commandthem = new SqlCommand(them, kn);
                int temp = commandthem.ExecuteNonQuery();
                if (temp != 0)
                {
                    MessageBox.Show("Đã thêm!");
                    ketnoi();
                }
                else
                {
                    MessageBox.Show("Lỗi!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                kn.Close();

            }
        }
        string sua;
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                kn.Open();
                sua = "update  tbl_danhmuc set ten=N'" + txtTenDM.Text.Trim() + "',icon=N'" + txtIcon.Text.Trim() + "' where id='" + txtMaDM.Text.Trim() + "'";
                SqlCommand commandsua = new SqlCommand(sua, kn);
                commandsua.ExecuteNonQuery();
                ketnoi();
            }
            catch
            {
                MessageBox.Show("Lỗi, không sửa được!");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                kn.Close();

            }
        }
    }
}
