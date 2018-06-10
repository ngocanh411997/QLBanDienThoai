using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDienThoai.DataAccess
{
    class ThamSoKetNoi
    {
        public static string ServerName = "";
        public static string DatabaseName = "";
        public static string UserName = "";
        public static string Password = "";
        public static bool WinAuthentication = true;

        public static string stringConnect = "";

        public static void TaoChuoiKetNoi()
        {
            string Temp = "";
            Temp = "Data Source=" + ServerName + ";";
            Temp += "Initial Catalog=" + DatabaseName + ";";

            if (WinAuthentication == true)
            {
                Temp += "Integrated security=true";
            }
            else
            {
                Temp += "Persist Security Info=True; User ID= " + UserName + ";" + "Password =" + Password;

            }
            stringConnect = Temp;
        }
    }
}
