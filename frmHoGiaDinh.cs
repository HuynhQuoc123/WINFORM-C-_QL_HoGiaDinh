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
    public partial class frmHoGiaDinh : Form
    {
        DataTable dtHoGiaDinh = new DataTable("HoGiaDinh");
        DataTable dtKhomAp = new DataTable("KhomAp");
        bool blnThem = false;
        public frmHoGiaDinh()
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
            cboKhomAp.Enabled = false;
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
            txtDiaChi.ReadOnly = false;
            dtpNgayLapHo.Value = DateTime.Today;
            cboKhomAp.Enabled = true;
            dgvHoGiaDinh.Enabled = false;
            txtMaHo.ReadOnly = true;
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
            if (dtHoGiaDinh.Rows.Count > 0)
            {
                txtMaHo.Text = dgvHoGiaDinh[0, dgvHoGiaDinh.CurrentRow.Index].Value.ToString();
                txtDiaChi.Text = dgvHoGiaDinh[1, dgvHoGiaDinh.CurrentRow.Index].Value.ToString();
                dtpNgayLapHo.Value = DateTime.Parse(dgvHoGiaDinh[2, dgvHoGiaDinh.CurrentRow.Index].Value.ToString());
                cboKhomAp.SelectedValue = dgvHoGiaDinh[3, dgvHoGiaDinh.CurrentRow.Index].Value.ToString();
            }
            else
            {
                btnChinhSua.Enabled = false;
                btnXoa.Enabled = false;

                txtDiaChi.Clear();
                dtpNgayLapHo.Value = DateTime.Today;
                cboKhomAp.SelectedIndex = -1;
            }
        }
        void ThucThiLuu()
        {
            string strSql, strMaAp;
            if (blnThem)
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
            if (blnThem)
            {
                dtHoGiaDinh.Rows.Add(null, txtDiaChi.Text, dtpNgayLapHo.Value, strMaAp);
                string strSelect = "Select * From HoGiaDinh";
                MyPublics.OpenData(strSelect, dtHoGiaDinh);
                dgvHoGiaDinh.CurrentCell = dgvHoGiaDinh[0, dgvHoGiaDinh.Rows.Count - 1];
                GanDuLieu();
                blnThem = false;
            }
            else
            {
                int curRow = dgvHoGiaDinh.CurrentRow.Index;
                dtHoGiaDinh.Rows[curRow][1] = txtDiaChi.Text;
                dtHoGiaDinh.Rows[curRow][2] = dtpNgayLapHo.Value;
                dtHoGiaDinh.Rows[curRow][3] = strMaAp;
            }
        }
        private void frmHoGiaDinh_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * From HoGiaDinh";
            MyPublics.OpenData(strSelect, dtHoGiaDinh);
            //khoa ngoai
            strSelect = "Select MaAp, TenAp From KhomAp";
            MyPublics.OpenData(strSelect, dtKhomAp);
            cboKhomAp.DataSource = dtKhomAp;
            cboKhomAp.DisplayMember = "TenAp";
            cboKhomAp.ValueMember = "MaAp";
            cboKhomAp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboKhomAp.AutoCompleteSource = AutoCompleteSource.ListItems;

            dgvHoGiaDinh.DataSource = dtHoGiaDinh;
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
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHoGiaDinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            DieuKhienKhiThem();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            DieuKhienKhiChinhSua();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Lỗi chưa nhập địa chỉ!");
                txtDiaChi.Focus();
                return;
            }
            if (cboKhomAp.SelectedIndex == -1)
            {
                MessageBox.Show("Lỗi chưa chọn khóm ấp!");
                cboKhomAp.Focus();
                return;
            }
            else
            {
                ThucThiLuu();
            }
            DieuKhienKhiBinhThuong();
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            blnThem = false;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
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

                    dtHoGiaDinh.Rows.RemoveAt(dgvHoGiaDinh.CurrentRow.Index);
                    GanDuLieu();
                }

            }
        }
    }
}
