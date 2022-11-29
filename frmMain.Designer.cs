
namespace QL_HoGiaDinh
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.mnuQuanLyHoGD = new System.Windows.Forms.MenuStrip();
            this.mnuDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhomAp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoGD = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThanhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGDTheoKhomAp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTVTheoGiaDinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTVTheoTrinhDo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTVTheoNgheNghiep = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTVTheoDoiTuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTienIch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMK = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuQuanLyHoGD.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuQuanLyHoGD
            // 
            this.mnuQuanLyHoGD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuQuanLyHoGD.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuQuanLyHoGD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDuLieu,
            this.mnuTienIch});
            this.mnuQuanLyHoGD.Location = new System.Drawing.Point(0, 0);
            this.mnuQuanLyHoGD.Name = "mnuQuanLyHoGD";
            this.mnuQuanLyHoGD.Padding = new System.Windows.Forms.Padding(11, 3, 0, 3);
            this.mnuQuanLyHoGD.Size = new System.Drawing.Size(1095, 32);
            this.mnuQuanLyHoGD.TabIndex = 1;
            this.mnuQuanLyHoGD.Text = "menuStrip1";
            // 
            // mnuDuLieu
            // 
            this.mnuDuLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKhomAp,
            this.mnuHoGD,
            this.mnuThanhVien,
            this.mnuGDTheoKhomAp,
            this.mnuTVTheoGiaDinh,
            this.mnuTVTheoTrinhDo,
            this.mnuTVTheoNgheNghiep,
            this.mnuTVTheoDoiTuong});
            this.mnuDuLieu.Name = "mnuDuLieu";
            this.mnuDuLieu.Size = new System.Drawing.Size(89, 26);
            this.mnuDuLieu.Text = "Dữ Liệu";
            // 
            // mnuKhomAp
            // 
            this.mnuKhomAp.Name = "mnuKhomAp";
            this.mnuKhomAp.Size = new System.Drawing.Size(320, 26);
            this.mnuKhomAp.Text = "Khóm Ấp";
            this.mnuKhomAp.Click += new System.EventHandler(this.mnuKhomAp_Click);
            // 
            // mnuHoGD
            // 
            this.mnuHoGD.Name = "mnuHoGD";
            this.mnuHoGD.Size = new System.Drawing.Size(320, 26);
            this.mnuHoGD.Text = "Hộ Gia Đình";
            this.mnuHoGD.Click += new System.EventHandler(this.mnuHoGD_Click);
            // 
            // mnuThanhVien
            // 
            this.mnuThanhVien.Name = "mnuThanhVien";
            this.mnuThanhVien.Size = new System.Drawing.Size(320, 26);
            this.mnuThanhVien.Text = "Thành Viên";
            this.mnuThanhVien.Click += new System.EventHandler(this.mnuThanhVien_Click);
            // 
            // mnuGDTheoKhomAp
            // 
            this.mnuGDTheoKhomAp.Name = "mnuGDTheoKhomAp";
            this.mnuGDTheoKhomAp.Size = new System.Drawing.Size(320, 26);
            this.mnuGDTheoKhomAp.Text = "Hộ gia đình theo khóm ấp";
            this.mnuGDTheoKhomAp.Click += new System.EventHandler(this.mnuGDTheoKhomAp_Click);
            // 
            // mnuTVTheoGiaDinh
            // 
            this.mnuTVTheoGiaDinh.Name = "mnuTVTheoGiaDinh";
            this.mnuTVTheoGiaDinh.Size = new System.Drawing.Size(320, 26);
            this.mnuTVTheoGiaDinh.Text = "Thành viên theo hộ gia đình";
            this.mnuTVTheoGiaDinh.Click += new System.EventHandler(this.mnuTVTheoGiaDinh_Click);
            // 
            // mnuTVTheoTrinhDo
            // 
            this.mnuTVTheoTrinhDo.Name = "mnuTVTheoTrinhDo";
            this.mnuTVTheoTrinhDo.Size = new System.Drawing.Size(320, 26);
            this.mnuTVTheoTrinhDo.Text = "Thành viên theo trình độ";
            this.mnuTVTheoTrinhDo.Click += new System.EventHandler(this.mnuTVTheoTrinhDo_Click);
            // 
            // mnuTVTheoNgheNghiep
            // 
            this.mnuTVTheoNgheNghiep.Name = "mnuTVTheoNgheNghiep";
            this.mnuTVTheoNgheNghiep.Size = new System.Drawing.Size(320, 26);
            this.mnuTVTheoNgheNghiep.Text = "Thành viên theo nghề nghiệp";
            this.mnuTVTheoNgheNghiep.Click += new System.EventHandler(this.mnuTVTheoNgheNghiep_Click);
            // 
            // mnuTVTheoDoiTuong
            // 
            this.mnuTVTheoDoiTuong.Name = "mnuTVTheoDoiTuong";
            this.mnuTVTheoDoiTuong.Size = new System.Drawing.Size(320, 26);
            this.mnuTVTheoDoiTuong.Text = "Thành Viên Theo Đối Tượng";
            this.mnuTVTheoDoiTuong.Click += new System.EventHandler(this.mnuTVTheoDoiTuong_Click);
            // 
            // mnuTienIch
            // 
            this.mnuTienIch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGioiThieu,
            this.mnuDoiMK,
            this.mnuThoat});
            this.mnuTienIch.Name = "mnuTienIch";
            this.mnuTienIch.Size = new System.Drawing.Size(88, 26);
            this.mnuTienIch.Text = "Tiện ích";
            // 
            // mnuGioiThieu
            // 
            this.mnuGioiThieu.Name = "mnuGioiThieu";
            this.mnuGioiThieu.Size = new System.Drawing.Size(224, 26);
            this.mnuGioiThieu.Text = "Giới Thiệu";
            this.mnuGioiThieu.Click += new System.EventHandler(this.mnuGioiThieu_Click);
            // 
            // mnuDoiMK
            // 
            this.mnuDoiMK.Name = "mnuDoiMK";
            this.mnuDoiMK.Size = new System.Drawing.Size(224, 26);
            this.mnuDoiMK.Text = "Đổi mật khẩu";
            this.mnuDoiMK.Click += new System.EventHandler(this.mnuDoiMK_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(224, 26);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QL_HoGiaDinh.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(1095, 676);
            this.Controls.Add(this.mnuQuanLyHoGD);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuQuanLyHoGD;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Hệ thống quản lý hộ gia đình";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuQuanLyHoGD.ResumeLayout(false);
            this.mnuQuanLyHoGD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuQuanLyHoGD;
        public System.Windows.Forms.ToolStripMenuItem mnuDuLieu;
        private System.Windows.Forms.ToolStripMenuItem mnuKhomAp;
        private System.Windows.Forms.ToolStripMenuItem mnuHoGD;
        private System.Windows.Forms.ToolStripMenuItem mnuThanhVien;
        private System.Windows.Forms.ToolStripMenuItem mnuGDTheoKhomAp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuTVTheoGiaDinh;
        private System.Windows.Forms.ToolStripMenuItem mnuTienIch;
        private System.Windows.Forms.ToolStripMenuItem mnuGioiThieu;
        private System.Windows.Forms.ToolStripMenuItem mnuTVTheoTrinhDo;
        private System.Windows.Forms.ToolStripMenuItem mnuTVTheoNgheNghiep;
        private System.Windows.Forms.ToolStripMenuItem mnuTVTheoDoiTuong;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiMK;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
    }
}

