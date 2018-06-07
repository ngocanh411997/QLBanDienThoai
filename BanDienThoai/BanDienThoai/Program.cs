using BanDienThoai.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data;


namespace BanDienThoai
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string sname = "";
            string dbname = "";
            string uname = "";
            string pass = "";

            if (!File.Exists("config"))
            {
                Application.Run(new Views.frmConnect());
            }
            else
            {
                using (StreamReader read = new StreamReader("config"))
                {
                    sname = read.ReadLine();
                    dbname = read.ReadLine();
                    uname = read.ReadLine();
                    pass = read.ReadLine();
                }

                DataAccess.ThamSoKetNoi.ServerName = sname;
                DataAccess.ThamSoKetNoi.DatabaseName = dbname;

                if (uname == "")
                {
                    DataAccess.ThamSoKetNoi.WinAuthentication = true;
                }
                else
                {
                    DataAccess.ThamSoKetNoi.WinAuthentication = false;
                    DataAccess.ThamSoKetNoi.UserName = uname;
                    DataAccess.ThamSoKetNoi.Password = pass;
                }

                DataAccess.ThamSoKetNoi.TaoChuoiKetNoi();

                try
                {
                    SqlConnection conn = new SqlConnection(DataAccess.ThamSoKetNoi.stringConnect);
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        frmLogin lg = new frmLogin();
                        lg.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra lại kết nối đến CSDL");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm tra lại thông tin kết nối và ấn OK để thiết lập lại!\n Eror: " + ex.Message);
                }
            }
           
            Application.Run(new Views.frmConnect());
        }
    }
}
