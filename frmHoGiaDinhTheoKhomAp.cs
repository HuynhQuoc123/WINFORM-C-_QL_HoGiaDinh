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
    public partial class frmHoGiaDinhTheoKhomAp : Form
    {

        DataTable dtHGD = new DataTable("HoGiaDinh");
        DataView dvHGD = new DataView();
        DataTable dtKA = new DataTable("KhomAp");
        int ThemSua = 0, ViTriKA;
        public frmHoGiaDinhTheoKhomAp()
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
            txtMaHo.ReadOnly = true;
            txtMaHo.BackColor = Color.White;
            txtDiaChi.ReadOnly = true;
            txtDiaChi.BackColor = Color.White;
            cboKhomAp.Enabled = true;
            dgvHoGiaDinh.Enabled = true;
        }
        void DieuKhienKhiThem()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;

            txtMaHo.ReadOnly = true;
            txtMaHo.Enabled = false;

            txtDiaChi.ReadOnly = false;
            dtpNgayLapHo.Value = DateTime.Today;
            cboKhomAp.Enabled = false;
            dgvHoGiaDinh.Enabled = false;

            txtMaHo.Text = null;
            txtMaHo.Clear();
            txtDiaChi.Clear();
        }
        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtDiaChi.ReadOnly = false;
            cboKhomAp.Enabled = true;
            dgvHoGiaDinh.Enabled = false;
            txtDiaChi.Focus();
        }
        void GanDuLieu()
        {
            if (dvHGD.Count > 0)
            {
                txtMaHo.Text = dgvHoGiaDinh[0, dgvHoGiaDinh.CurrentRow.Index].Value.ToString();
                txtDiaChi.Text = dgvHoGiaDinh[1, dgvHoGiaDinh.CurrentRow.Index].Value.ToString();
                dtpNgayLapHo.Value = DateTime.Parse(dgvHoGiaDinh[2, dgvHoGiaDinh.CurrentRow.Index].Value.ToString());
            }
            else
            {
                txtMaHo.Clear();
                txtDiaChi.Clear();
                dtpNgayLapHo.Value = DateTime.Today;
            }
        }
        void NhanDuLieu()
        {
            string strSelect = "Select * From HoGiaDinh";
            MyPublics.OpenData(strSelect, dtHGD);
        }

        void ThucThiLuu()
        {
            string strSql, strMaAp;
            if (ThemSua == 1)
            {
                strSql = "Insert Into HoGiaDinh Values (@DiaChiNha, @NgayLapHo, @MaAp)";
            }
            else
            {
                strSql = "Update HoGiaDinh Set DiaChiNha = @DiaChiNha, NgayLapHo = @NgayLapHo, MaAp = @MaAp Where MaHo = @MaHo";
            }
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
            {
                MyPublics.conMyConnection.Open();
            }

            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MaHo", txtMaHo.Text);
            cmdCommand.Parameters.AddWithValue("@DiaChiNha", txtDiaChi.Text);
            cmdCommand.Parameters.AddWithValue("@NgayLapHo", dtpNgayLapHo.Value);
            strMaAp = cboKhomAp.SelectedValue.ToString();
            cmdCommand.Parameters.AddWithValue("@MaAp", strMaAp);

            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();

            ThemSua = 0;
            dtHGD.Clear();
            NhanDuLieu();
            dgvHoGiaDinh.CurrentCell = dgvHoGiaDinh[0, dgvHoGiaDinh.Rows.Count - 1];
            DieuKhienKhiBinhThuong();
        }

        private void frmHoGiaDinhTheoKhomAp_Load(object sender, EventArgs e)
        {
            NhanDuLieu();

            string strSelect = "Select MaAp, TenAp From KhomAp";
            MyPublics.OpenData(strSelect, dtKA);

            cboKhomAp.DataSource = dtKA;
            cboKhomAp.DisplayMember = "TenAp";
            cboKhomAp.ValueMember = "MaAp";
            cboKhomAp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboKhomAp.AutoCompleteSource = AutoCompleteSource.ListItems;

            dvHGD.Table = dtHGD;
            dvHGD.RowFilter = "MaAp like '" + cboKhomAp.SelectedValue + "'";
            dgvHoGiaDinh.DataSource = dvHGD;

            dgvHoGiaDinh.Width = 550;
            dgvHoGiaDinh.AllowUserToAddRows = false;
            dgvHoGiaDinh.AllowUserToDeleteRows = false;
            dgvHoGiaDinh.Columns[0].Width = 90;
            dgvHoGiaDinh.Columns[0].HeaderText = "Mã Hộ";
            dgvHoGiaDinh.Columns[1].Width = 150;
            dgvHoGiaDinh.Columns[1].HeaderText = "Địa Chỉ Nhà";
            dgvHoGiaDinh.Columns[2].Width = 150;
            dgvHoGiaDinh.Columns[2].HeaderText = "Ngày Lập";
            dgvHoGiaDinh.Columns[3].Width = 100;
            dgvHoGiaDinh.Columns[3].HeaderText = "Mã Ấp";
            dgvHoGiaDinh.EditMode = DataGridViewEditMode.EditProgrammatically;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }
        private void cboKhomAp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboKhomAp.SelectedIndex != -1) && (ThemSua == 0))
            {
                dvHGD.RowFilter = "MaAp like '" + cboKhomAp.SelectedValue + "'";
                dgvHoGiaDinh.DataSource = dvHGD;
                GanDuLieu();
            }
        }
        private void dgvHoGiaDinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSua = 1;
            ViTriKA = cboKhomAp.SelectedIndex;
            DieuKhienKhiThem();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            ThemSua = 2;
            ViTriKA = cboKhomAp.SelectedIndex;
            DieuKhienKhiChinhSua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MyPublics.TonTaiKhoaChinh(txtMaHo.Text, "MaHo", "ThanhVien"))
            {
                MessageBox.Show("Phải xóa thành viên thuộc hộ gia đình trước!");
            }
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn thật sự muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo);
                if (blnDongY == DialogResult.Yes)
                {
                    string strDelete = "Delete HoGiaDinh Where MaHo = @MaHo";
                    if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                    {
                        MyPublics.conMyConnection.Open();
                    }
                    SqlCommand cmdCommand = new SqlCommand(strDelete, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MaHo", txtMaHo.Text);

                    cmdCommand.ExecuteNonQuery();
                    MyPublics.conMyConnection.Close();

                    int curRow = dgvHoGiaDinh.CurrentRow.Index;
                    dvHGD.Delete(curRow);
                    GanDuLieu();
                }

            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThucThiLuu();
        }   

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

    }
}
