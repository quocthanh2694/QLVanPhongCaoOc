using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace MainForm.FForm
{
    public partial class DoiPass : DevExpress.XtraEditors.XtraForm
    {
        CS.KetNoi kketnoi = new CS.KetNoi();
        CS.Function funn = new CS.Function();
        public DoiPass()
        {
            InitializeComponent();
        }
        private void passtxt_Validated(object sender, EventArgs e)
        {

            if (matkhaucutxt.Text.Length < 1)
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu cũ");
                matkhaucutxt.Focus();

            }
            else
            {
                if (matkhaumoitxt.Text.Length < 1)
                {
                    XtraMessageBox.Show("Vui lòng nhập mật khẩu mới");
                    matkhaumoitxt.Focus();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (matkhaucutxt.Text == "" | matkhaumoitxt.Text == "")
                { }
                else
                {

                    string sql = "select * from DangNhap where ID  ='" + tendn + "' and PW = '" + funn.mahoa(Properties.Resources.KeyMaHoaDangNhap, matkhaucutxt.Text.Trim()) + "'";
                    DataTable datatbl = kketnoi.Excute_Datatable_Sql(sql,CommandType.Text);
                   
                    if (datatbl.Rows.Count < 1)
                    {
                        XtraMessageBox.Show("mật khẩu không đúng");
                    }
                    else
                    {
                        if (nhaplaimatkhaumoitxt.Text.Trim() != matkhaumoitxt.Text.Trim())
                        {
                            XtraMessageBox.Show("mật khẩu nhập lại không đúng");
                        }
                        else
                        {
                            kketnoi.connectdulieu();
                            string sql1 = "Update DangNhap set PW = '" + funn.mahoa(Properties.Resources.KeyMaHoaDangNhap, matkhaumoitxt.Text.Trim()) + "' where ID ='" + tendn + "'";
                            SqlCommand comd = new SqlCommand(sql1, kketnoi.conn);
                            comd.ExecuteNonQuery();
                            kketnoi.closeketnoi_sql();
                            XtraMessageBox.Show("Thay đổi mật khẩu thành công");
                            Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("Pass", "");
                            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\MainForm.exe");
                            Application.Exit();
                        }
                    }

                }
            }
            catch{ }
        }
        string tendn = Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadSubTree).GetValue("Laytendn", "").ToString();
        private void doipass_Load(object sender, EventArgs e)
        {
            tentaikhoanlbl.Text = tendn;
        }
    }
}