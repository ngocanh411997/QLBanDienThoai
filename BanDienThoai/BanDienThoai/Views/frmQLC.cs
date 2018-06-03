﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanDienThoai.Views
{
    public partial class frmQLC : Form
    {
        public frmQLC()
        {
            InitializeComponent();
        }

        private void btnBoPhan_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhiemVu NVu = new frmNhiemVu();
            NVu.ShowDialog();
            this.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhanVien NV = new frmNhanVien();
            NV.ShowDialog();
            this.Show();
        }

        private void btnPhieuYC_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDonDatHang DDH = new frmDonDatHang();
            DDH.ShowDialog();
            this.Show();
        }

        private void btnHoaDonTT_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHoaDonDaThanhToan HDDTT = new frmHoaDonDaThanhToan();
            HDDTT.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                this.Show();
        }

        private void btnNhaCC_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhaSanXuat NV = new frmNhaSanXuat();
            NV.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDanhMuc NV = new frmDanhMuc();
            NV.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Xóa thông tin tài khoản đã lưu? \nBạn sẽ phải thiết đặt lại thông tin trong lần đăng nhập tới!", "Xóa thông tin đã lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                File.Delete("config");
                File.Delete("info.ini");
                MessageBox.Show("Đã xóa thông tin tài khoản!");
                Views.frmConnect lg = new frmConnect();
                this.Hide();
                lg.ShowDialog();
            }
        }
    }
}
