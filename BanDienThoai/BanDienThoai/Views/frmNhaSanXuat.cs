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
    public partial class frmNhaSanXuat : Form
    {
        public frmNhaSanXuat()
        {
            InitializeComponent();
        }
        private void ketnoi()
        {
            try
            {
                SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                kn.Open();

                string sql = "select * from tbl_nhasanxuat";
                SqlCommand commandsql = new SqlCommand(sql, kn);//thuc thi cac cau lenh trong sql
                SqlDataAdapter com = new SqlDataAdapter(commandsql);//van chuyen du lieu
                DataTable table = new DataTable();//tao 1 bang ao trong he thong 
                com.Fill(table);//do du lieu vao bang ao
                dgvNhaSanXuat.DataSource = table;//bang ao nay duoc do vao datagrirdview
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
        private void frmNhaSanXuat_Load(object sender, EventArgs e)
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
                frmNhaSanXuat_Load(sender,e);
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            files.ExportToExcel(dgvNhaSanXuat);
        }
       

        private void dgvNhaSanXuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvNhaSanXuat_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvNhaSanXuat.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        int index;
        private void dgvNhaSanXuat_Click(object sender, EventArgs e)
        {
            index = dgvNhaSanXuat.CurrentRow.Index;
            txtMaNSX.Text = dgvNhaSanXuat.Rows[index].Cells[1].Value.ToString();
            txtTenNSX.Text = dgvNhaSanXuat.Rows[index].Cells[2].Value.ToString();
            
        }
        string them;
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                kn.Open();
                them = "insert into tbl_nhasanxuat values('" + txtMaNSX.Text + "',N'" + txtTenNSX.Text + "')";
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
                sua = "update  tbl_nhasanxuat set ten=N'" + txtTenNSX.Text + "' where id='" + txtMaNSX.Text + "'";
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
        string xoa;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhà sản xuất '" + txtTenNSX.Text.Trim() + "'" + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection kn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                    kn.Open();

                    xoa = "delete  tbl_nhasanxuat where id='" + txtMaNSX.Text + "'";
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ketnoi();
            dgvNhaSanXuat_Click(sender, e);
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
                sqlTimKiem = "SELECT *FROM tbl_nhasanxuat where id = '" + txtTimKiem.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlTimKiem, conn);
                cmd.Parameters.AddWithValue("id", txtTimKiem.Text.Trim());
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvNhaSanXuat.DataSource = dt;
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
    }
}
