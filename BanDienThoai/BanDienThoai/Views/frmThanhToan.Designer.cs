namespace BanDienThoai.Views
{
    partial class frmThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThanhToan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvThanhToan = new System.Windows.Forms.DataGridView();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXuatHD = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvThanhToan
            // 
            this.dgvThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThanhToan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ten,
            this.tongtien});
            this.dgvThanhToan.Location = new System.Drawing.Point(12, 12);
            this.dgvThanhToan.Name = "dgvThanhToan";
            this.dgvThanhToan.Size = new System.Drawing.Size(344, 242);
            this.dgvThanhToan.TabIndex = 26;
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(66, 283);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(117, 20);
            this.txtMaDon.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Mã phiếu";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThoat.Location = new System.Drawing.Point(305, 312);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(51, 53);
            this.btnThoat.TabIndex = 23;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXuatHD
            // 
            this.btnXuatHD.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXuatHD.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXuatHD.Location = new System.Drawing.Point(9, 312);
            this.btnXuatHD.Name = "btnXuatHD";
            this.btnXuatHD.Size = new System.Drawing.Size(51, 53);
            this.btnXuatHD.TabIndex = 22;
            this.btnXuatHD.Text = "Xuất HĐ";
            this.btnXuatHD.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXuatHD.UseVisualStyleBackColor = false;
            this.btnXuatHD.Click += new System.EventHandler(this.btnXuatHD_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Mã đơn";
            this.id.Name = "id";
            // 
            // ten
            // 
            this.ten.DataPropertyName = "ten";
            this.ten.HeaderText = "Tên KH";
            this.ten.Name = "ten";
            // 
            // tongtien
            // 
            this.tongtien.DataPropertyName = "tongtien";
            dataGridViewCellStyle1.Format = "0,000";
            this.tongtien.DefaultCellStyle = dataGridViewCellStyle1;
            this.tongtien.HeaderText = "Thanh Toán";
            this.tongtien.Name = "tongtien";
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 387);
            this.Controls.Add(this.dgvThanhToan);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXuatHD);
            this.Name = "frmThanhToan";
            this.Text = "frmThanhToan";
            this.Load += new System.EventHandler(this.frmThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvThanhToan;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXuatHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
    }
}