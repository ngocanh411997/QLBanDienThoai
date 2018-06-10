namespace BanDienThoai.Views
{
    partial class frmHoaDonDaThanhToan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoaDonDaThanhToan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDDH = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCTDDH = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_nguoilap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaylap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TONGTIEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._thanhtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDDH)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDDH)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXuatFile.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatFile.Image")));
            this.btnXuatFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXuatFile.Location = new System.Drawing.Point(900, 9);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(51, 53);
            this.btnXuatFile.TabIndex = 31;
            this.btnXuatFile.Text = "Xuất File";
            this.btnXuatFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXuatFile.UseVisualStyleBackColor = false;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.Items.AddRange(new object[] {
            "Mã đơn",
            "Khách Hàng",
            "Nhân Viên",
            "Ngày lập"});
            this.cbTimKiem.Location = new System.Drawing.Point(269, 26);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(121, 21);
            this.cbTimKiem.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.Image")));
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(408, 23);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(74, 25);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(86, 26);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(177, 20);
            this.txtTimKiem.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTimKiem);
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Controls.Add(this.txtTimKiem);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Location = new System.Drawing.Point(18, 436);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 64);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(6, 22);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(74, 26);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(72, 404);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(100, 20);
            this.txtMaDon.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Mã đơn";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThoat.Location = new System.Drawing.Point(957, 9);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(51, 53);
            this.btnThoat.TabIndex = 27;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 33);
            this.label1.TabIndex = 26;
            this.label1.Text = "Hóa đơn đã thanh toán";
            // 
            // dgvDDH
            // 
            this.dgvDDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDDH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.id,
            this.ten,
            this.id_nguoilap,
            this.ngaylap,
            this.TONGTIEN});
            this.dgvDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDDH.Location = new System.Drawing.Point(3, 16);
            this.dgvDDH.Name = "dgvDDH";
            this.dgvDDH.Size = new System.Drawing.Size(505, 295);
            this.dgvDDH.TabIndex = 0;
            this.dgvDDH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDDH_CellClick);
            this.dgvDDH.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDDH_RowPrePaint);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.dgvDDH);
            this.groupBox3.Location = new System.Drawing.Point(12, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(511, 314);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông Tin Hóa Đơn Đã Thanh Toán";
            // 
            // dgvCTDDH
            // 
            this.dgvCTDDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTDDH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._STT,
            this._id,
            this._ten,
            this.SoLuong,
            this._gia,
            this._thanhtien});
            this.dgvCTDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCTDDH.Location = new System.Drawing.Point(3, 16);
            this.dgvCTDDH.Name = "dgvCTDDH";
            this.dgvCTDDH.Size = new System.Drawing.Size(476, 295);
            this.dgvCTDDH.TabIndex = 0;
            this.dgvCTDDH.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvCTDDH_RowPrePaint);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.dgvCTDDH);
            this.groupBox7.Location = new System.Drawing.Point(529, 62);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(482, 314);
            this.groupBox7.TabIndex = 25;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Chi Tiết Hóa Đơn";
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 35;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Mã đơn";
            this.id.Name = "id";
            this.id.Width = 80;
            // 
            // ten
            // 
            this.ten.DataPropertyName = "ten";
            this.ten.HeaderText = "Tên KH";
            this.ten.Name = "ten";
            // 
            // id_nguoilap
            // 
            this.id_nguoilap.DataPropertyName = "id_nguoilap";
            this.id_nguoilap.HeaderText = "NV lập";
            this.id_nguoilap.Name = "id_nguoilap";
            this.id_nguoilap.Width = 80;
            // 
            // ngaylap
            // 
            this.ngaylap.DataPropertyName = "ngaylap";
            this.ngaylap.HeaderText = "Ngày lập";
            this.ngaylap.Name = "ngaylap";
            this.ngaylap.Width = 90;
            // 
            // TONGTIEN
            // 
            this.TONGTIEN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TONGTIEN.DataPropertyName = "tongtien";
            dataGridViewCellStyle1.Format = "0,000";
            this.TONGTIEN.DefaultCellStyle = dataGridViewCellStyle1;
            this.TONGTIEN.HeaderText = "Tổng tiền";
            this.TONGTIEN.Name = "TONGTIEN";
            // 
            // _STT
            // 
            this._STT.HeaderText = "STT";
            this._STT.Name = "_STT";
            this._STT.Width = 50;
            // 
            // _id
            // 
            this._id.DataPropertyName = "id_dondathang";
            this._id.HeaderText = "Mã Phiếu";
            this._id.Name = "_id";
            this._id.Width = 80;
            // 
            // _ten
            // 
            this._ten.DataPropertyName = "ten";
            this._ten.HeaderText = "Sản phẩm";
            this._ten.Name = "_ten";
            this._ten.Width = 90;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "soluong";
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 70;
            // 
            // _gia
            // 
            this._gia.DataPropertyName = "gia";
            this._gia.HeaderText = "Giá";
            this._gia.Name = "_gia";
            this._gia.Width = 60;
            // 
            // _thanhtien
            // 
            this._thanhtien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._thanhtien.DataPropertyName = "thanhtien";
            dataGridViewCellStyle2.Format = "0,000";
            this._thanhtien.DefaultCellStyle = dataGridViewCellStyle2;
            this._thanhtien.HeaderText = "Thành Tiền";
            this._thanhtien.Name = "_thanhtien";
            // 
            // frmHoaDonDaThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 536);
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox7);
            this.Name = "frmHoaDonDaThanhToan";
            this.Text = "frmHoaDonDaThanhToan";
            this.Load += new System.EventHandler(this.frmHoaDonDaThanhToan_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDDH)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDDH)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDDH;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCTDDH;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_nguoilap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaylap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TONGTIEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn _STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn _id;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn _gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn _thanhtien;
    }
}