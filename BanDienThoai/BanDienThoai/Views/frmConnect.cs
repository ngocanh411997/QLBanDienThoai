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
using System.IO;
namespace BanDienThoai.Views
{
    public partial class frmConnect : Form
    {
        public frmConnect()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmConnect_Load(object sender, EventArgs e)
        {
            if (cbxChonTaiKhoan.Text == "Window Authentication")
            {
                txtTenDangNhap.Enabled = false;
                txtMK.Enabled = false;
            }

        }
     

      
        
      

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            try
            {
                string Host = txtTenMayChu.Text.Trim();
                string DB = txtTenCSDL.Text.Trim();
                string UN = txtTenDangNhap.Text.Trim();
                string PW = txtMK.Text.Trim();

                if (Host == "")
                {
                    MessageBox.Show("Bạn phải nhập tên máy chủ");
                    ActiveControl = txtTenMayChu;
                    return;
                }

                if (DB == "")
                {
                    MessageBox.Show("Bạn phải nhập tên CSDL");
                    ActiveControl = txtTenCSDL;
                    return;
                }

                if (cbxChonTaiKhoan.Text == "SQL Server Authentication")
                {
                    //neu xac thuc sql thi bat buoc phải nhập 
                    if (UN == "")
                    {
                        MessageBox.Show("Ban phai nhap ten dang nhap");
                        ActiveControl = txtTenDangNhap;
                        return;
                    }

                    if (PW == "")
                    {
                        MessageBox.Show("Ban phai nhap mat khau");
                        ActiveControl = txtMK;
                        return;
                    }
                    DataAccess.ThamSoKetNoi.WinAuthentication = false;
                }
                else
                {
                    DataAccess.ThamSoKetNoi.WinAuthentication = true;
                }

                //TAO CHUOI KET NOI
                DataAccess.ThamSoKetNoi.DatabaseName = DB;
                DataAccess.ThamSoKetNoi.ServerName = Host;
                DataAccess.ThamSoKetNoi.UserName = UN;
                DataAccess.ThamSoKetNoi.Password = PW;

                DataAccess.ThamSoKetNoi.TaoChuoiKetNoi();

                SqlConnection myConnect = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                myConnect.Open();

                if (myConnect.State == ConnectionState.Open)
                {

                    using (StreamWriter write = new StreamWriter("config"))
                    {
                        write.WriteLine(DataAccess.ThamSoKetNoi.ServerName);
                        write.WriteLine(DataAccess.ThamSoKetNoi.DatabaseName);
                        write.WriteLine(DataAccess.ThamSoKetNoi.UserName);
                        write.WriteLine(DataAccess.ThamSoKetNoi.Password);
                    }

                    Views.frmLogin lg = new frmLogin();
                    this.Hide();
                    lg.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Không kết nối được đến cơ sở dữ liệu!");
                    return;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được đến cơ sở dữ liệu " + ex.Message);
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbxChonTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChonTaiKhoan.Text == "Window Authentication")
            {
                txtTenDangNhap.Enabled = false;
                txtMK.Enabled = false;
            }
            if (cbxChonTaiKhoan.Text == "SQL Server Authentication")
            {
                txtTenDangNhap.Enabled = true;
                txtMK.Enabled = true;
            }
        }

        private void frmConnect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
