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
    public partial class frmDoanhThu : Form
    {
        private Entity.EntityDoanhThu doanhthu;
        private BUS.BUSDoanhThu bus = new BUS.BUSDoanhThu();
        private DataTable dt = new DataTable();
        private BindingSource bs = new BindingSource();

        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            //set date
            this.doanhthu = new Entity.EntityDoanhThu(this.dtpStart.Value, this.dtpEnd.Value);
            //this.doanhthu.startdate = this.dtpStart.Value;
            //this.doanhthu.enddate = this.dtpEnd.Value;
            //bus

            this.dt = bus.GetDataProc(doanhthu);
            this.bs.DataSource = dt;
            //tong tien
            this.lblDoanhThu.Text = TongTien().ToString("N0") + " VNĐ";
        }

        private long TongTien()
        {
            var TongTien = 0;
            if (this.bs == null || this.bs.Count == 0)
            {
                return TongTien;
            }
            else
            {
                var rows = this.dgvData.Rows;
                
                for(int i = 0; i<rows.Count-1;i++) /*(DataGridViewRow row in rows)*/
                {
                    var row = rows[i];
                    var cell = row.Cells["tongtien"];
                    TongTien += int.Parse(cell.ValueType == typeof(int) ? cell.Value.ToString() : "0");

                }
                return TongTien;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            this.bnDoanhThu.BindingSource = this.bs;
            this.dgvData.DataSource = this.bs;
        }

        private void tstxtKey_Click(object sender, EventArgs e)
        {

        }

        private void tstxtKey_TextChanged(object sender, EventArgs e)
        {
            if (this.tscboType.SelectedIndex == 0)
            {
                this.bs.Filter = "nhanvien Like'*" + this.tstxtKey.Text.Trim() + "*'";
            }
            this.lblDoanhThu.Text = TongTien().ToString("N0") + " VNĐ";
            // this.lblDoanhThu.Text = TongTien().ToString("N0") + " VNĐ";
        }

        private void frmDoanhThu_Shown(object sender, EventArgs e)
        {
            this.lblDoanhThu.Text = TongTien().ToString("N0") + " VNĐ";

        }

        private void tsbtnSaveToFile_ButtonClick(object sender, EventArgs e)
        {
            files.ExportToExcel(this.dgvData);
        }
    }
}
