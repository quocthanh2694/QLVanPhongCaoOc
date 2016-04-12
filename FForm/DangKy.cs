using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;


namespace MainForm.FForm
{
    public partial class DangKy : DevExpress.XtraEditors.XtraForm
    {
        public DangKy()
        {
            InitializeComponent();
        }

        CS.Function funn = new CS.Function();
        private void passtxt_Validated(object sender, EventArgs e)
        {
           
            if (tendntxt.Text.Length < 1)
            {
                XtraMessageBox.Show("Vui lòng nhập tên đăng nhập");
                tendntxt.Focus();

            }
            else
            {
                if (passtxt.Text.Length < 1)
                {
                    XtraMessageBox.Show("Vui lòng nhập mật khẩu");
                    passtxt.Focus();
                }

            }
        
        }
        CS.KetNoi kketnoi = new CS.KetNoi();


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tendntxt.Text.Trim() == "" | passtxt.Text.Trim() == "")
                { }
                else
                {
                   
                    string sql = "select * from DangNhap where ID ='" + tendntxt.Text.Trim() + "'";
                    DataTable datatbl = kketnoi.Excute_Datatable_Sql(sql,CommandType.Text);
                    if (datatbl.Rows.Count > 0)
                    {
                        XtraMessageBox.Show("Tài khoản đã tồn tại");
                    }
                    else
                    {
                        if (passtxt.Text.Trim() != passnhaplaitxt.Text.Trim())
                        { XtraMessageBox.Show("mật khẩu nhập lại không đúng"); }
                        else
                        {
                          
                            string sql1 = "insert DangNhap(ID,PW,Hoten,TrangThai) values (@TenDangNhap,@MatKhau,@Hoten,@TrangThai)";
                            kketnoi.connectdulieu();
                            SqlCommand comd = new SqlCommand(sql1, kketnoi.conn);
                            comd.Parameters.AddWithValue("@TenDangNhap", tendntxt.Text.Trim());
                            comd.Parameters.AddWithValue("@MatKhau",funn.mahoa(Properties.Resources.KeyMaHoaDangNhap, passtxt.Text.Trim()));
                            comd.Parameters.AddWithValue("@Hoten", funn.chuanhoaten(hotentxt.Text.Trim()));
                            comd.Parameters.AddWithValue("@TrangThai", '1');
                            comd.ExecuteNonQuery();
                            kketnoi.closeketnoi_sql();
                            XtraMessageBox.Show("Đăng ký tài khoản thành công");
                            this.Close();
                        }


                    }
                }

            }
            catch (SqlException ex)
            {
                ex.ToString();
                
            }


        }
    }
}