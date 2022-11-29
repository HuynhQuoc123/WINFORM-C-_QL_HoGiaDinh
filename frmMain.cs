using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HoGiaDinh
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chương trình quản lý hộ gia đình " +
                "Version 1.0 \n Nhóm 08 TN207", "Giới thiệu");
        }

       

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap fDangNhap = new frmDangNhap(this);
            fDangNhap.ShowDialog();
    
        }

        private void mnuKhomAp_Click(object sender, EventArgs e)
        {
            frmKhomAp fKhomAp = new frmKhomAp();
            fKhomAp.ShowDialog();
           
        }

        private void mnuHoGD_Click(object sender, EventArgs e)
        {
            frmHoGiaDinh fHoGiaDinh = new frmHoGiaDinh();
            fHoGiaDinh.ShowDialog();
        }

        private void mnuThanhVien_Click(object sender, EventArgs e)
        {
            frmThanhVien fThanhVien = new frmThanhVien();
            fThanhVien.ShowDialog();
        }

        private void mnuGDTheoKhomAp_Click(object sender, EventArgs e)
        {
            frmHoGiaDinhTheoKhomAp f1 = new frmHoGiaDinhTheoKhomAp();
            f1.ShowDialog();
        }
        private void mnuTVTheoGiaDinh_Click(object sender, EventArgs e)
        {
            frmThanhVienTheoGiaDinh f2 = new frmThanhVienTheoGiaDinh();
            f2.ShowDialog();
        }
        private void mnuTVTheoTrinhDo_Click(object sender, EventArgs e)
        {
            frmThanhVienTheoTrinhDo f3 = new frmThanhVienTheoTrinhDo();
            f3.ShowDialog();
        }
        private void mnuTVTheoNgheNghiep_Click(object sender, EventArgs e)
        {
            frmThanhVienTheoNgheNghiep f4 = new frmThanhVienTheoNgheNghiep();
            f4.ShowDialog();
        }

        private void mnuTVTheoDoiTuong_Click(object sender, EventArgs e)
        {
            frmThanhVienTheoDoiTuong f5 = new frmThanhVienTheoDoiTuong();
            f5.ShowDialog();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuDoiMK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau fDoiMK = new frmDoiMatKhau();
            fDoiMK.ShowDialog();
        }
    }
}
