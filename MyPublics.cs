using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_HoGiaDinh
{
    class MyPublics
    {
        public static SqlConnection conMyConnection;
        public static string strMaHo,strSTT, strQuyenSD;

        public static void ConnectDatabase()
        {
            string strConn = "Server = localhost; Database = QL_HoGiaDinh; " +
                "Integrated Security = false; UID = TN207User; PWD = TN207User";
            conMyConnection = new SqlConnection();
            conMyConnection.ConnectionString = strConn;
            try
            {
                conMyConnection.Open();
            }
            catch (Exception)
            {
            }
        }

        public static void OpenData(string strSelect, DataTable dtTable)
        {
            SqlDataAdapter daDataAdapter = new SqlDataAdapter();
            try
            {
                if (conMyConnection.State == ConnectionState.Closed)
                {
                    conMyConnection.Open();
                }
                daDataAdapter.SelectCommand = new SqlCommand(strSelect, conMyConnection);
                daDataAdapter.Fill(dtTable);
                conMyConnection.Close();
            }
            catch (Exception)
            {
            }
        }

        public static bool TonTaiKhoaChinh(String strGiaTri, string strTenTruong, string strTable)
        {
            bool blnRessult = false;
            try
            {
                string sqlSelect = "Select 1 From " + strTable + " Where " + strTenTruong
                                    + "='" + strGiaTri + "'";
                if (conMyConnection.State == ConnectionState.Closed)
                {
                    conMyConnection.Open();
                }
                SqlCommand cmdCommand = new SqlCommand(sqlSelect, conMyConnection);
                SqlDataReader drReader = cmdCommand.ExecuteReader();
                if (drReader.HasRows)
                {
                    blnRessult = true;
                }
                drReader.Close();
                conMyConnection.Close();
            }
            catch (Exception)
            {

            }
            return blnRessult;
        }
        public static bool TonTaiHaiKhoaChinh(String strGiaTri, string strTenTruong, String strGiaTri1, string strTenTruong1, string strTable)
        {
            bool blnRessult = false;
            try
            {
                string sqlSelect = "Select 1 From " + strTable + " Where " + strTenTruong
                                    + "='" + strGiaTri + "' And "+ strTenTruong1 + "='" + strGiaTri1 + "'";
                if (conMyConnection.State == ConnectionState.Closed)
                {
                    conMyConnection.Open();
                }
                SqlCommand cmdCommand = new SqlCommand(sqlSelect, conMyConnection);
                SqlDataReader drReader = cmdCommand.ExecuteReader();
                if (drReader.HasRows)
                {
                    blnRessult = true;
                }
                drReader.Close();
                conMyConnection.Close();
            }
            catch (Exception)
            {

            }
            return blnRessult;
        }
    }
}
