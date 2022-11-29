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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            string strSelect = "Select CONCAT(MaHo, '-', SttThanhVien) as ThongTin, HoTenThanhVien From ThanhVien Where MaHo = @MaHo And SttThanhVien = @STT";
            if(MyPublics.conMyConnection.State == ConnectionState.Closed)
            {
                MyPublics.conMyConnection.Open();
            }
            SqlCommand cmdCommand = new SqlCommand(strSelect, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MaHo", MyPublics.strMaHo);
            cmdCommand.Parameters.AddWithValue("@STT", MyPublics.strSTT);
            SqlDataReader drReader = cmdCommand.ExecuteReader();
            drReader.Read();
            txtMaHoSTT.Text = drReader.GetString(0);
            txtHoTen.Text = drReader.GetString(1);
            drReader.Close();
            MyPublics.conMyConnection.Close();

            txtMK1.Focus();
            txtMK1.PasswordChar = '*';
            txtMK2.PasswordChar = '*';
            txtMaHoSTT.ReadOnly = true;
            txtMaHoSTT.BackColor = Color.White;
            txtHoTen.ReadOnly = true;
            txtHoTen.BackColor = Color.White;      
        }
        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            string strMatKhau, strSelect;
            if (txtMK1.Text == "")
            {
                MessageBox.Show("Lỗi chưa nhập mật khẩu mới!");
                txtMK1.Focus();
                return;
            }
            if (txtMK1.Text != txtMK2.Text)
            {
                MessageBox.Show("Lỗi mật khẩu mới không giống nhau!");
                txtMK2.Clear();
                txtMK2.Focus();
                return;
            }
            strMatKhau = txtMK1.Text;
            strSelect = "Update ThanhVien Set MatKhau = @MatKhau Where MaHo = @MaHo And SttThanhVien = @STT";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
            {
                MyPublics.conMyConnection.Open();
            }
            SqlCommand cmdCommand = new SqlCommand(strSelect, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MatKhau", strMatKhau);
            cmdCommand.Parameters.AddWithValue("@MaHo", MyPublics.strMaHo);
            cmdCommand.Parameters.AddWithValue("@STT", MyPublics.strSTT);
            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            MessageBox.Show("Đổi mật khẩu thành công!");
            this.Close();
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
