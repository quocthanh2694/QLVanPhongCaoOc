using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using Microsoft.Win32;
using DevExpress.XtraEditors;

namespace MainForm.CS
{

    class KetNoi
    {
        public SqlConnection conn;
        public SqlCommand comd;
        public SqlDataAdapter ada;
        public SqlDataReader rdr;
        public bool isketnoi;
        CS.Function funn = new CS.Function();
        public bool ketnoiserver(string connectionstring)
        {
            try
            {
                conn = new SqlConnection(connectionstring);
                conn.Open();
                isketnoi = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                isketnoi = false;
            }

            return isketnoi;
        }
        public void connectdulieu()
        {
            string connectionstring = funn.giaima(Properties.Resources.KeyMaHoaDaTa, Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadSubTree).GetValue("ConnectionString", "").ToString());
            try
            {
                conn = new SqlConnection(connectionstring);
                conn.Open();
                isketnoi = true;

            }
            catch
            {
                isketnoi = false;
            }
        }

        public void closeketnoi_sql()
        {
            conn.Close();
        }
        public DataTable Excute_Datatable_Sql(string procedure, CommandType commandType, params object[] pars)
        {
            DataTable datatbl = new DataTable();
            try
            {
                connectdulieu();
                comd = new SqlCommand(procedure, conn);
                comd.CommandType = commandType;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    comd.Parameters.Add(par);
                }
                ada = new SqlDataAdapter();
                ada.SelectCommand = comd;
                comd.ExecuteScalar();
                ada.Fill(datatbl);
                ada.Dispose();
                closeketnoi_sql();
                return datatbl;

            }
            catch (SqlException ex)
            {

                XtraMessageBox.Show(ex.ToString());
                return datatbl;
            }
        }

        public string Excute_Reader_Sql(string procedure, CommandType commandType, params object[] pars)
        {

            try
            {
                connectdulieu();
                comd = new SqlCommand(procedure, conn);
                comd.CommandType = commandType;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    comd.Parameters.Add(par);
                }
                rdr = comd.ExecuteReader();
                string vResult = rdr.Read() ? rdr[0].ToString() : "";
                rdr.Dispose();
                closeketnoi_sql();
                return vResult;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return "";
            }

        }
        public bool Excute_Nonquery_Sql(string procedure, CommandType commandType, params object[] pars)
        {
            bool kq = false;
            try
            {

                connectdulieu();
                comd = new SqlCommand(procedure, conn);
                comd.CommandType = commandType;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    comd.Parameters.Add(par);
                }
                comd.ExecuteNonQuery();
                closeketnoi_sql();
                kq = true;
                return kq;
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.ToString());
                kq = false;
                return kq;
            }
        }

        public DataTable ReadExcelContents(string fileName, string causql)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                if (fileName.Trim().EndsWith(".xls"))
                {
                    connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source=" + fileName);
                }
                else
                {
                    connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Excel 12.0;Data Source=" + fileName);
                }

                connection.Open();
                OleDbCommand cmd = new OleDbCommand(causql, connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Không thể truy cập đến file excel. " + ex.Message, "Lỗi");
                return null;
            }
        }
        public string laydata_dong(string str)// lay gia tri 1 ô
        {
            connectdulieu();
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            string v = reader.Read() ? reader[0].ToString() : "";
            reader.Dispose();
            closeketnoi_sql();
            return v;
        }
    }
}

