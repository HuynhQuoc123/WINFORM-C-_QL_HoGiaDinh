using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HoGiaDinh
{
    public partial class frmThanhVienTheoDoiTuong : Form
    {
        DataTable dtThanhVien = new DataTable("ThanhVien");
        DataView dvThanhVien = new DataView();
        DataTable dtHoGiaDinh = new DataTable("HoGiaDinh");
        DataTable dtTrinhDo = new DataTable("TrinhDo");
        DataTable dtNgheNghiep = new DataTable("NgheNghiep");
        DataTable dtDoiTuong = new DataTable("DoiTuong");
        DataTable dtQuyenSD = new DataTable("QuyenSD");
        int ViTri, ThemSua = 0;
        public frmThanhVienTheoDoiTuong()
        {
            InitializeComponent();
        }
        void DieuKhienKhiBinhThuong()
        {
            if (MyPublics.strQuyenSD == "Admin")
            {
                btnThem.Enabled = true;
                btnChinhSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
                btnChinhSua.Enabled = false;
                btnXoa.Enabled = false;
            }

            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            txtHoTen.ReadOnly = true;
            txtHoTen.BackColor = Color.White;
            txtQuanHe.ReadOnly = true;
            txtQuanHe.BackColor = Color.White;
            txtSTT.ReadOnly = true;
            txtSTT.BackColor = Color.White;
            grpPhai.Enabled = false;
            dtpNgaySinh.Enabled = false;
            cboDoiTuong.Enabled = true;
            cboNgheNghiep.Enabled = false;
            cboHoGiaDinh.Enabled = false;
            cboQuyenSD.Enabled = false;
            cboTrinhDo.Enabled = false;
            dgvThanhVien.Enabled = true;
        }

        void DieuKhienKhiThem()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            cboHoGiaDinh.Enabled = true;
            cboHoGiaDinh.SelectedIndex = 0;
            cboNgheNghiep.Enabled = true;
            cboNgheNghiep.SelectedIndex = 0;
            cboTrinhDo.Enabled = true;
            cboTrinhDo.SelectedIndex = 0;
            cboDoiTuong.Enabled = false;
            cboDoiTuong.SelectedIndex = ViTri;
            cboQuyenSD.Enabled = true;
            cboQuyenSD.SelectedIndex = 0;
            grpPhai.Enabled = true;
            dtpNgaySinh.Enabled = true;
            dtpNgaySinh.Value = DateTime.Today;
            txtHoTen.ReadOnly = false;
            txtSTT.ReadOnly = false;
            txtQuanHe.ReadOnly = false;
            dgvThanhVien.Enabled = false;
            txtHoTen.Clear();
            txtQuanHe.Clear();
            txtSTT.Clear();

        }
        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtSTT.ReadOnly = true;
            txtSTT.BackColor = Color.White;
            txtHoTen.ReadOnly = false;
            txtQuanHe.ReadOnly = false;
            grpPhai.Enabled = true;
            dtpNgaySinh.Enabled = true;
            cboHoGiaDinh.Enabled = false;
            cboDoiTuong.Enabled = true;
            cboNgheNghiep.Enabled = true;
            cboQuyenSD.Enabled = true;
            cboTrinhDo.Enabled = true;
            dgvThanhVien.Enabled = false;
            txtHoTen.Focus();

        }
        void GanDuLieu()
        {
            if (dvThanhVien.Count > 0)
            {
                cboHoGiaDinh.SelectedValue = dgvThanhVien[0, dgvThanhVien.CurrentRow.Index].Value.ToString();
                txtSTT.Text = dgvThanhVien[1, dgvThanhVien.CurrentRow.Index].Value.ToString();
                txtHoTen.Text = dgvThanhVien[2, dgvThanhVien.CurrentRow.Index].Value.ToString();
                if (dgvThanhVien[3, dgvThanhVien.CurrentRow.Index].Value.ToString() == "True")
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }
                dtpNgaySinh.Value = DateTime.Parse(dgvThanhVien[4, dgvThanhVien.CurrentRow.Index].Value.ToString());
                txtQuanHe.Text = dgvThanhVien[5, dgvThanhVien.CurrentRow.Index].Value.ToString();
                cboNgheNghiep.SelectedValue = dgvThanhVien[6, dgvThanhVien.CurrentRow.Index].Value.ToString();
                cboTrinhDo.SelectedValue = dgvThanhVien[7, dgvThanhVien.CurrentRow.Index].Value.ToString();
          /*      cboDoiTuong.SelectedValue = dgvThanhVien[8, dgvThanhVien.CurrentRow.Index].Value.ToString();*/
                cboQuyenSD.SelectedValue = dgvThanhVien[10, dgvThanhVien.CurrentRow.Index].Value.ToString();
            }
            else
            {
                txtHoTen.Clear();
                txtSTT.Clear();
                txtQuanHe.Clear();
                rdoNam.Checked = true;
                dtpNgaySinh.Value = DateTime.Today;
                cboHoGiaDinh.SelectedIndex = -1;
                cboNgheNghiep.SelectedIndex = -1;
                cboTrinhDo.SelectedIndex = -1;
                cboDoiTuong.SelectedIndex = -1;
                cboQuyenSD.SelectedIndex = -1;
            }
        }
        void NhanDuLieu()
        {
            string strSelect = "Select * From ThanhVien";
            MyPublics.OpenData(strSelect, dtThanhVien);
        }

        void ThucThiLuu()
        {
            string strSql, strMatKhau = "", strHoGiaDinh, strTrinhDo, strNgheNghiep, strDoiTuong,
               strQuyenSD;
            bool Phai = true;
            if (ThemSua == 1)
            {
                strSql = "Insert Into ThanhVien Values(@MaHo, @SttThanhVien, @HoTen, @Phai, @NgaySinh, @QuanHeVoiChuHo, " +
                    "@MaNgheNghiep, @MaTrinhDo, @MaDoiTuong, @MatKhau, @QuyenSD)";
            }
            else
            {
                strSql = "Update ThanhVien Set HoTenThanhVien = @HoTen, Phai = @Phai, NgaySinh = @NgaySinh, QuanHeVoiChuHo = @QuanHeVoiChuHo, " +
                    "MaNgheNghiep = @MaNgheNghiep, MaTrinhDo = @MaTrinhDo, MaDoiTuong = @MaDoiTuong, " +
                    "QuyenSD = @QuyenSD Where MaHo = @MaHo And SttThanhVien = @SttThanhVien";
            }
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
            {
                MyPublics.conMyConnection.Open();
            }
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            strHoGiaDinh = cboHoGiaDinh.SelectedValue.ToString();
            cmdCommand.Parameters.AddWithValue("@MaHo", strHoGiaDinh);
            cmdCommand.Parameters.AddWithValue("@SttThanhVien", txtSTT.Text);
            cmdCommand.Parameters.AddWithValue("@Hoten", txtHoTen.Text);
            if (rdoNu.Checked)
            {
                Phai = false;
            }
            cmdCommand.Parameters.AddWithValue("@Phai", Phai);
            cmdCommand.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
            cmdCommand.Parameters.AddWithValue("@QuanHeVoiChuHo", txtQuanHe.Text);
            strNgheNghiep = cboNgheNghiep.SelectedValue.ToString();
            cmdCommand.Parameters.AddWithValue("@MaNgheNghiep", strNgheNghiep);
            strTrinhDo = cboTrinhDo.SelectedValue.ToString();
            cmdCommand.Parameters.AddWithValue("@MaTrinhDo", strTrinhDo);
            strDoiTuong = cboDoiTuong.SelectedValue.ToString();
            cmdCommand.Parameters.AddWithValue("@MaDoiTuong", strDoiTuong);
            if (ThemSua == 1)
            {
                strMatKhau = txtSTT.Text;
                cmdCommand.Parameters.AddWithValue("@MatKhau", strMatKhau);
            }
            strQuyenSD = cboQuyenSD.SelectedValue.ToString();
            cmdCommand.Parameters.AddWithValue("QuyenSD", strQuyenSD);

            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();

            ThemSua = 0;
            dtThanhVien.Clear();
            NhanDuLieu();

            if (cboDoiTuong.SelectedIndex == ViTri)
            {
                dvThanhVien.Sort = "SttThanhVien";
                int curRow = dvThanhVien.Find(txtSTT.Text);
                dgvThanhVien.CurrentCell = dgvThanhVien[0, curRow];
            }
            else
            {
                cboDoiTuong.SelectedIndex = ViTri;
                if (dvThanhVien.Count > 0)
                {
                    dgvThanhVien.CurrentCell = dgvThanhVien[0, 0];
                }
            }
            DieuKhienKhiBinhThuong();
        }

        private void cboDoiTuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDoiTuong.SelectedIndex != -1 && ThemSua == 0)
            {
                dvThanhVien.RowFilter = "MaDoiTuong =" + cboDoiTuong.SelectedValue;
                dgvThanhVien.DataSource = dvThanhVien;
                GanDuLieu();
            }
        }
        private void frmThanhVienTheoDoiTuong_Load(object sender, EventArgs e)
        {
            string strSelect;
            NhanDuLieu();
            // combobox hộ gia đình
            strSelect = "Select MaHo, DiaChiNha From HoGiaDinh";
            MyPublics.OpenData(strSelect, dtHoGiaDinh);
            cboHoGiaDinh.DataSource = dtHoGiaDinh;
            cboHoGiaDinh.DisplayMember = "DiaChiNha";
            cboHoGiaDinh.ValueMember = "MaHo";
            cboHoGiaDinh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboHoGiaDinh.AutoCompleteSource = AutoCompleteSource.ListItems;
            // combobox nghề nghiệp
            strSelect = "Select * From NgheNghiep";
            MyPublics.OpenData(strSelect, dtNgheNghiep);
            cboNgheNghiep.DataSource = dtNgheNghiep;
            cboNgheNghiep.DisplayMember = "TenNgheNghiep";
            cboNgheNghiep.ValueMember = "MaNgheNghiep";
            cboNgheNghiep.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboNgheNghiep.AutoCompleteSource = AutoCompleteSource.ListItems;
            // combobox trình độ
            strSelect = "Select * From TrinhDo";
            MyPublics.OpenData(strSelect, dtTrinhDo);
            cboTrinhDo.DataSource = dtTrinhDo;
            cboTrinhDo.DisplayMember = "DienGiai";
            cboTrinhDo.ValueMember = "MaTrinhDo";
            cboTrinhDo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTrinhDo.AutoCompleteSource = AutoCompleteSource.ListItems;
            // combobox đối tượng
            strSelect = "Select * From DoiTuong";
            MyPublics.OpenData(strSelect, dtDoiTuong);
            cboDoiTuong.DataSource = dtDoiTuong;
            cboDoiTuong.DisplayMember = "TenDoiTuong";
            cboDoiTuong.ValueMember = "MaDoiTuong";
            cboDoiTuong.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDoiTuong.AutoCompleteSource = AutoCompleteSource.ListItems;
            // Tạo ComboBox Quyền sử dụng 
            dtQuyenSD.Columns.Add("QuyenSD");
            dtQuyenSD.Rows.Add("User");
            dtQuyenSD.Rows.Add("Admin");
            cboQuyenSD.DataSource = dtQuyenSD;
            cboQuyenSD.DisplayMember = "QuyenSD";
            cboQuyenSD.ValueMember = "QuyenSD";

            dvThanhVien.Table = dtThanhVien;
            cboDoiTuong.SelectedIndex = 0;
            dvThanhVien.RowFilter = "MaDoiTuong =" + cboDoiTuong.SelectedValue;
            //data gird view
            dgvThanhVien.DataSource = dvThanhVien;
            dgvThanhVien.Width = 900;
            dgvThanhVien.AllowUserToAddRows = false;
            dgvThanhVien.AllowUserToDeleteRows = false;
            dgvThanhVien.Columns[0].Width = 60;
            dgvThanhVien.Columns[0].HeaderText = "Mã Hộ";
            dgvThanhVien.Columns[1].Width = 50;
            dgvThanhVien.Columns[1].HeaderText = "STT";
            dgvThanhVien.Columns[2].Width = 150;
            dgvThanhVien.Columns[2].HeaderText = "Họ và Tên";
            dgvThanhVien.Columns[3].Width = 50;
            dgvThanhVien.Columns[3].HeaderText = "Phái";
            dgvThanhVien.Columns[4].Width = 100;
            dgvThanhVien.Columns[4].HeaderText = "Ngày sinh";
            dgvThanhVien.Columns[5].Width = 100;
            dgvThanhVien.Columns[5].HeaderText = "Quan hệ với chủ hộ";
            dgvThanhVien.Columns[6].Width = 75;
            dgvThanhVien.Columns[6].HeaderText = "Mã Nghề Nghiệp";
            dgvThanhVien.Columns[7].Width = 90;
            dgvThanhVien.Columns[7].HeaderText = "Mã Trình Độ";
            dgvThanhVien.Columns[8].Width = 80;
            dgvThanhVien.Columns[8].HeaderText = "Mã Đối Tượng";
            dgvThanhVien.Columns[9].Visible = false;
            dgvThanhVien.Columns[10].Width = 75;
            dgvThanhVien.Columns[10].HeaderText = "Quyền SD";

            dgvThanhVien.EditMode = DataGridViewEditMode.EditProgrammatically;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSua = 1;
            ViTri = cboDoiTuong.SelectedIndex;
            DieuKhienKhiThem();
        }
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            ThemSua = 2;
            ViTri = cboDoiTuong.SelectedIndex;
            DieuKhienKhiChinhSua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult blnDongY;
            blnDongY = MessageBox.Show("Bạn thực sự muốn xóa ?",
                "Xác Nhận", MessageBoxButtons.YesNo);
            if (blnDongY == DialogResult.Yes)
            {
                string strDelete = "Delete ThanhVien Where MaHo = @MaHo and SttThanhVien = @SttThanhVien";
                if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                {
                    MyPublics.conMyConnection.Open();
                }
                SqlCommand cmdCommand = new SqlCommand(strDelete, MyPublics.conMyConnection);
                string strHoGiaDinh = cboHoGiaDinh.SelectedValue.ToString();
                cmdCommand.Parameters.AddWithValue("@MaHo", strHoGiaDinh);
                cmdCommand.Parameters.AddWithValue("@SttThanhVien", txtSTT.Text);

                cmdCommand.ExecuteNonQuery();
                MyPublics.conMyConnection.Close();

                int curRow = dgvThanhVien.CurrentRow.Index;
                dvThanhVien.Delete(curRow);
                DieuKhienKhiBinhThuong();
                GanDuLieu();
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            int a;
            string strMH = cboHoGiaDinh.SelectedValue.ToString();
            if ((!int.TryParse(txtSTT.Text, out a)) || (txtSTT.Text == ""))
            {
                MessageBox.Show("Lỗi nhập STT thành viên!");
                txtSTT.Focus();
                return;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Lỗi chưa nhập họ tên!");
                txtHoTen.Focus();
                return;
            }
            if (txtQuanHe.Text == "")
            {
                MessageBox.Show("Lỗi chưa nhập quan hệ với chủ hộ!");
                txtQuanHe.Focus();
                return;
            }
            if ((ThemSua == 1) && (MyPublics.TonTaiHaiKhoaChinh(strMH, "MaHo", txtSTT.Text, "SttThanhVien", "ThanhVien")))
            {
                MessageBox.Show("STT thành viên " + txtSTT.Text + " thuộc hộ gia đình " + strMH + " đã có rồi");
            }
            else
            {
                ThucThiLuu();
            }
            DieuKhienKhiBinhThuong();
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            ThemSua = 0;
            DieuKhienKhiBinhThuong();
            GanDuLieu();
            cboNgheNghiep.SelectedIndex = ViTri;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
