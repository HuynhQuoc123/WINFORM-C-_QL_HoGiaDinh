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
    public partial class frmKhomAp : Form
    {
        DataTable dtKhomAp = new DataTable("KhomAp");
        bool blnThem = false;
        public frmKhomAp()
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
            txtMaAp.ReadOnly = true;
            txtMaAp.BackColor = Color.White;
            txtTenAp.ReadOnly = true;
            txtTenAp.BackColor = Color.White;
            txtSoTo.ReadOnly = true;
            txtSoTo.BackColor = Color.White;
            txtDacDiem.ReadOnly = true;
            txtDacDiem.BackColor = Color.White;
            dgvKhomAp.Enabled = true;

        }
        void DieuKhienKhiThem()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtMaAp.ReadOnly = false;
            txtTenAp.ReadOnly = false;
            txtSoTo.ReadOnly = false;
            txtDacDiem.ReadOnly = false;

            txtMaAp.Clear();
            txtTenAp.Clear();
            txtSoTo.Clear();
            txtDacDiem.Clear();
            dgvKhomAp.Enabled = false;
            txtMaAp.Focus();
        }
        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;

            txtTenAp.ReadOnly = false;
            txtSoTo.ReadOnly = false;
            txtDacDiem.ReadOnly = false;
            txtTenAp.Focus();
        }
        void GanDuLieu()
        {
            if(dtKhomAp.Rows.Count > 0)
            {
                txtMaAp.Text = dgvKhomAp[0, dgvKhomAp.CurrentRow.Index].Value.ToString();
                txtTenAp.Text = dgvKhomAp[1, dgvKhomAp.CurrentRow.Index].Value.ToString();
                txtSoTo.Text = dgvKhomAp[2, dgvKhomAp.CurrentRow.Index].Value.ToString();
                txtDacDiem.Text = dgvKhomAp[3, dgvKhomAp.CurrentRow.Index].Value.ToString();
            }
            else
            {
                btnChinhSua.Enabled = false;
                btnXoa.Enabled = false;
                txtMaAp.Clear();
                txtTenAp.Clear();
                txtSoTo.Clear();
                txtDacDiem.Clear();
            }
        }
        void ThucThiLuu()
        {
            string strSql;
            if (blnThem)
            {
                strSql = "Insert Into KhomAp Values (@MaAp, @TenAp, @SoTo, @DacDiem)";
            }
            else
            {
                strSql = "Update KhomAp Set TenAp = @TenAp, SoTo = @SoTo, DacDiem = @DacDiem Where MaAp = @MaAp ";
            }
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
            {
                MyPublics.conMyConnection.Open();
            }
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MaAp", txtMaAp.Text);
            cmdCommand.Parameters.AddWithValue("@TenAp", txtTenAp.Text);
            cmdCommand.Parameters.AddWithValue("@SoTo", txtSoTo.Text);
            cmdCommand.Parameters.AddWithValue("@DacDiem", txtDacDiem.Text);

            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();

            if (blnThem)
            {
                dtKhomAp.Rows.Add(txtMaAp.Text, txtTenAp.Text, txtSoTo.Text, txtDacDiem.Text);
                dgvKhomAp.CurrentCell = dgvKhomAp[0, dgvKhomAp.Rows.Count - 1];
                GanDuLieu();
                blnThem = false;
            }
            else
            {
                int curRow = dgvKhomAp.CurrentRow.Index;
                dtKhomAp.Rows[curRow][1] = txtTenAp.Text;
                dtKhomAp.Rows[curRow][2] = txtSoTo.Text;
                dtKhomAp.Rows[curRow][3] = txtDacDiem.Text;
            }
            DieuKhienKhiBinhThuong();
        }
 
        private void frmKhomAp_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * From KhomAp";
            MyPublics.OpenData(strSelect, dtKhomAp);
            dgvKhomAp.DataSource = dtKhomAp;
            GanDuLieu();
            dgvKhomAp.Width = 565;
            dgvKhomAp.Columns[0].Width = 100;
            dgvKhomAp.Columns[0].HeaderText = "Mã Ấp";
            dgvKhomAp.Columns[1].Width = 150;
            dgvKhomAp.Columns[1].HeaderText = "Tên Ấp";
            dgvKhomAp.Columns[2].Width = 100;
            dgvKhomAp.Columns[2].HeaderText = "Số Tổ";
            dgvKhomAp.Columns[3].Width = 150;
            dgvKhomAp.Columns[3].HeaderText = "Đặc điểm";
            dgvKhomAp.AllowUserToAddRows = false;
            dgvKhomAp.AllowUserToDeleteRows = false;
            dgvKhomAp.EditMode = DataGridViewEditMode.EditProgrammatically;
            DieuKhienKhiBinhThuong();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MyPublics.TonTaiKhoaChinh(txtMaAp.Text, "MaAp", "HoGiaDinh"))
            {
                MessageBox.Show("Phải xóa hộ gia đình thuộc ấp trước!");
            }
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn thật sự muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo);
                if (blnDongY == DialogResult.Yes)
                {
                    string strDelete = "Delete KhomAp Where MaAp = @MaAp";
                    if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                    {
                        MyPublics.conMyConnection.Open();
                    }
                    SqlCommand cmdCommand = new SqlCommand(strDelete, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MaAp", txtMaAp.Text);

                    cmdCommand.ExecuteNonQuery();
                    MyPublics.conMyConnection.Close();

                    dtKhomAp.Rows.RemoveAt(dgvKhomAp.CurrentRow.Index);
                    GanDuLieu();
                }

            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaAp.Text == "")
            {
                MessageBox.Show("Lỗi chưa nhập mã ấp!");
                txtMaAp.Focus();
                return;
            }
            if (txtTenAp.Text == "")
            {
                MessageBox.Show("Lỗi chưa nhập tên ấp!");
                txtTenAp.Focus();
                return;
            }
            int a;
            if ((txtSoTo.Text == "") || (!int.TryParse(txtSoTo.Text, out a)))
            {
                MessageBox.Show("Lỗi nhập số tổ!");
                txtSoTo.Focus();
                return;
            }
            if (txtDacDiem.Text == "")
            {
                MessageBox.Show("Lỗi chưa nhập đặc điểm!");
                txtDacDiem.Focus();
                return;
            }

            if (blnThem && MyPublics.TonTaiKhoaChinh(txtMaAp.Text, "MaAp", "KhomAp"))
            {
                    MessageBox.Show("Mã số ấp này đã có rồi !");
                    txtMaAp.Focus();
            }
            else
            {
               ThucThiLuu();
            }       
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            blnThem = false;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvKhomAp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }
    }
}
