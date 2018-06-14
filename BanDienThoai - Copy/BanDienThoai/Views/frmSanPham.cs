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
using BanDienThoai.Views;



namespace BanDienThoai.Views
{
    public partial class frmSanPham : Form
    {
        EntitySanPham obj = new EntitySanPham();
        BUSSanPham Bus = new BUSSanPham();
        private int HD = 1;
        public frmSanPham()
        {
            InitializeComponent();
        }
        private void DisEnl(bool e)
        {
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnThoat.Enabled = !e;
            btnRef.Enabled = e;
            //dgvSanPham.Enabled = !e;

            txtID.Enabled = e;
            txtIDKM.Enabled = e;
            txtIDDM.Enabled = e;

            txttenSP.Enabled = e;
            txtLinkAnh.Enabled = e;
            txtGia.Enabled = e;
            txtSL.Enabled = e;
            txtTrongLg.Enabled = e;
            txtROM.Enabled = e;
            txtRAM.Enabled = e;
            txtTheNho.Enabled = e;
            txtCamTrc.Enabled = e;
            txtCamSau.Enabled = e;
            txtPin.Enabled = e;
            txtBH.Enabled = e;
            txtBluetooth.Enabled = e;
            txtIDNSX.Enabled = e;
           
        }
        private void Clear()
        {
           // txtID.Text = "";
            txtIDKM.Text = "";
            txtIDDM.Text = "";

            txttenSP.Text = "";
            txtLinkAnh.Text = "";
            txtGia.Text = "";
            txtSL.Text = "";
            txtTrongLg.Text = "";
            txtROM.Text = "";
            txtRAM.Text = "";
            txtTheNho.Text = "";
            txtCamTrc.Text = "";
            txtCamSau.Text = "";
            txtPin.Text = "";
            txtBH.Text = "";
            txtBluetooth.Text = "";
            txtIDNSX.Text = "";
           
        }

        private void HienThi()
        {
            dgvSanPham.DataSource = Bus.GetDataProc();
            dgvSanPham.AutoResizeColumns();

        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            HienThi();
            DisEnl(false);
            btnRef.Enabled = true;
            dgvSanPham.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HD = 0;
            txtID.Text = Bus.TangMa();
            DisEnl(true);
            txtID.Enabled = false;
            btnThoat.Enabled = true;
            btnThem.Enabled = true;
            Clear();
            dgvSanPham.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HD = 1;
            DisEnl(true);
            btnThoat.Enabled = true;
            btnSua.Enabled = true;
            dgvSanPham.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã SP! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtIDNSX.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập id NSX! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txttenSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ten SP! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtBH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập bao hanh! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtGia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhap gia! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           


            int _id_NSX;
            int.TryParse(txtIDNSX.Text, out _id_NSX);
            int _BaoHanh;
            int.TryParse(txtBH.Text, out _BaoHanh);
            int _Gia;
            int.TryParse(txtGia.Text, out _Gia);
            int _id_KM;
            int.TryParse(txtIDKM.Text, out _id_KM);
            int _id_DM;
            int.TryParse(txtIDDM.Text, out _id_DM);
            int _Soluong;
            int.TryParse(txtSL.Text, out _Soluong);
            int _Trongluong;
            int.TryParse(txtTrongLg.Text, out _Trongluong);
            int _ROM;
            int.TryParse(txtROM.Text, out _ROM);
            int _RAM;
            int.TryParse(txtRAM.Text, out _RAM);
            int _Thenho;
            int.TryParse(txtTheNho.Text, out _Thenho);
            int _Camtrc;
            int.TryParse(txtCamTrc.Text, out _Camtrc);
            int _Camsau;
            int.TryParse(txtCamSau.Text, out _Camsau);
            int _pin;
            int.TryParse(txtPin.Text, out _pin);
            int _Bluetooth;
            int.TryParse(txtBluetooth.Text, out _Bluetooth);


            obj.id = txtID.Text;
            obj.id_KM = _id_KM;
            obj.id_DanhMuc = _id_DM;
            obj.ten = txttenSP.Text;
            obj.linkanh = txtLinkAnh.Text;
            obj.gia = _Gia;
            obj.SoLg = _Soluong;
            obj.TrongLg = _Trongluong;
            obj.ROM = _ROM;
            obj.RAM = _RAM;
            obj.TheNho = _Thenho;
            obj.Cam_Trc = _Camtrc;
            obj.Cam_Sau = _Camsau;
            obj.Pin = _pin;
            obj.BaoHanh = _BaoHanh;
            obj.Bluetooth = _Bluetooth;
            obj.id_NSX = _id_NSX;
            



            if (txtID.Text != "" && txtIDNSX.Text != "" && txttenSP.Text != "" && txtBH.Text != "" && txtGia.Text != "" && HD == 0)
            {
                try
                {
                    Bus.InsertData(obj);
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();

                    dgvSanPham.DataSource = Bus.GetDataProc();
                    dgvSanPham.AutoResizeColumns();
                    btnThoat.Enabled = true;
                    btnRef.Enabled = true;
                    //DisEnl(false);
                    HD = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
            else if (txtID.Text != "" && txtIDNSX.Text != "" && txttenSP.Text != "" && txtBH.Text != "" && txtGia.Text != "" && HD == 1)
            {
                try
                {
                    Bus.UpdateData(obj);
                    MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    
                    frmSanPham_Load(sender, e);

                    DisEnl(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnRef.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Bus.DeleteData(txtID.Text);
                    MessageBox.Show("Xóa thành công!");

                    DisEnl(false);
                    HienThi();
                    btnRef.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            HienThi();
            DisEnl(false);
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnRef.Enabled = true;
            btnThoat.Enabled = true;
            dgvSanPham.Enabled = true;
            txtTimKiem.Text = "--Nhập từ khóa";
            Clear();
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

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(HD==0)
            {
                txtIDKM.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["id_khuyenmai"].Value);
                txtIDDM.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["id_danhmuc"].Value);

                txttenSP.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["ten"].Value);
                txtLinkAnh.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["link_anh"].Value);
                txtGia.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["gia"].Value);
                txtSL.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["SoLuong"].Value);
                txtTrongLg.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["TrongLuong"].Value);
                txtROM.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["ROM"].Value);
                txtRAM.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["RAM"].Value);
                txtTheNho.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["thenho"].Value);
                txtCamTrc.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["camera_truoc"].Value);
                txtCamSau.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["camera_sau"].Value);
                txtPin.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["pin"].Value);
                txtBH.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["baohanh"].Value);
                txtBluetooth.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["bluetooth"].Value);
                txtIDNSX.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["id_nhasanxuat"].Value);
            }
            else
            {
                txtID.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["id"].Value);
                txtIDKM.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["id_khuyenmai"].Value);
                txtIDDM.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["id_danhmuc"].Value);

                txttenSP.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["ten"].Value);
                txtLinkAnh.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["link_anh"].Value);
                txtGia.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["gia"].Value);
                txtSL.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["SoLuong"].Value);
                txtTrongLg.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["TrongLuong"].Value);
                txtROM.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["ROM"].Value);
                txtRAM.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["RAM"].Value);
                txtTheNho.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["thenho"].Value);
                txtCamTrc.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["camera_truoc"].Value);
                txtCamSau.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["camera_sau"].Value);
                txtPin.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["pin"].Value);
                txtBH.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["baohanh"].Value);
                txtBluetooth.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["bluetooth"].Value);
                txtIDNSX.Text = Convert.ToString(dgvSanPham.CurrentRow.Cells["id_nhasanxuat"].Value);

            }

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
                if (cbTimKiem.Text == "Tên sản phẩm")
                {
                    dgvSanPham.DataSource = Bus.TimKiem("SELECT * FROM tbl_sanpham WHERE ten LIKE'%" + txtTimKiem.Text + "%'");
                }
                if (cbTimKiem.Text == "ID Khuyến mại")
                {
                    dgvSanPham.DataSource = Bus.TimKiem("SELECT * FROM tbl_sanpham WHERE id_khuyenmai LIKE'%" + txtTimKiem.Text + "%'");
                }
                if (cbTimKiem.Text == "ID Nhà sản xuất")
                {
                    dgvSanPham.DataSource = Bus.TimKiem("SELECT * FROM tbl_sanpham WHERE id_nhasanxuat LIKE'%" + txtTimKiem.Text + "%'");
                }
                if (cbTimKiem.Text == "Trạng thái")
                {
                    dgvSanPham.DataSource = Bus.TimKiem("SELECT * FROM tbl_sanpham WHERE TrangThai LIKE'%" + txtTimKiem.Text + "%'");
                }


            }
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }
    }
}
