using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Reflection;

namespace MainForm.FForm
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        public bool ckdangnhap;
        public bool IsSuccessfull = false;
        CS.KetNoi kketnoi = new CS.KetNoi();
        string hotendn = "";
        CS.Function funn = new CS.Function();
        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
           
        public void ghinhodangnhap()
        {
            try
            {
                int nhoten, nhomatkhau, nhotudongdn;
                if (nhotendnchk.Checked) { nhoten = 1; }
                else { nhoten = 0; }
                if (nhomkchk.Checked) 
                    nhomatkhau = 1;
                else 
                    nhomatkhau = 0;
                if (tudongdnchk.Checked) 
                    nhotudongdn = 1;
                else 
                    nhotudongdn = 0;
                string account = Application.StartupPath + "\\account.txt";
                StreamWriter sw = new StreamWriter(account, false);
                sw.WriteLine(nhoten.ToString() + nhomatkhau.ToString() + nhotudongdn.ToString());
                sw.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message ?? "", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        public void ghithongtin()

        {
            Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("Laytendn", tendntxt.Text.Trim());
            Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("Hotendn", hotendn);

            if (nhotendnchk.Checked)
            {
                Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("Tendn", tendntxt.Text.Trim());
            }
            else
            {
                Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("Tendn", "");
            }

            if (nhomkchk.Checked)
            {

                Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("Pass", funn.mahoa(Properties.Resources.KeyMaHoaDangNhap, passtxt.Text));
            }
            else
            {
                Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("Pass", "");
            }
        }

        public void laythongtin()
        {
            try
            {
                string pass;
                string tendn = Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadSubTree).GetValue("Tendn", "").ToString();
                string passtam = Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadSubTree).GetValue("Pass", "").ToString();
                if (passtam.Length < 8)
                { pass = passtam; }
                else
                { pass = funn.giaima(Properties.Resources.KeyMaHoaDangNhap, passtam); }
                tendntxt.Text = tendn;
                if (tendn.Trim() == "")
                {
                    passtxt.Text = "";
                }
                else passtxt.Text = pass;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message ?? "", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }
        public void kiemtraghinhodangnhap()
        {
            try
            {
                string nhoten, nhomatkhau, tudongdn;
                nhoten = nhomatkhau = tudongdn = "0";

                string fileName = Application.StartupPath + "\\account.txt";
                if (File.Exists(fileName) == false) { }
                else
                {
                    StreamReader sr = new StreamReader(fileName, false);
                    string kq = sr.ReadLine();
                    sr.Close();
                    nhoten = kq.Substring(0, 1);
                    nhomatkhau = kq.Substring(1, 1);
                    tudongdn = kq.Substring(2, 1);

                }

                if (nhoten.Trim() == "1")
                { nhotendnchk.Checked = true; }
                if (nhomatkhau.Trim() == "1")
                { nhomkchk.Checked = true; }
                if (tudongdn.Trim() == "1")
                { tudongdnchk.Checked = true; }

            }
             
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message ?? "", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        public string tendn
        {
            get { return tendntxt.Text; }
        }
        private void dangnhap_Load(object sender, EventArgs e)
        {

            string server = Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadSubTree).GetValue("Server", "").ToString();
                if (server.Trim() != "")
                {
                    Assembly ass = Assembly.GetEntryAssembly();
                    AssemblyName assname = ass.GetName();
                    Version ver = assname.Version;


                    string versionsql = kketnoi.Excute_Reader_Sql("select top(1) versions from Versions", CommandType.Text);
                    
                    if (ver.ToString().Trim() != versionsql.Trim())
                    {
                        if (XtraMessageBox.Show("Đã có phiên bản mới. Bạn có muốn cập nhật không???"+ver+"-"+versionsql+"", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\UpdateMainForm.exe");
                            Application.Exit();
                        }
                    }

                    else
                    {

                        kiemtraghinhodangnhap();
                        if (nhotendnchk.Checked)
                        {
                            laythongtin();
                        }
                    }

                }
                else
                { }
                
            }
         
        

        private void passtxt_TextChanged(object sender, EventArgs e)
        {

        }


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
                else
                { }

            }
        }
     
        public bool kiemtradangnhap()
        {


            try
            {
                object[] para = new object[4];
                para[0] = "@TenDangNhap";
                para[1] = tendntxt.Text.Trim();
                para[2] = "@MatKhau";
                para[3] = funn.mahoa(Properties.Resources.KeyMaHoaDangNhap, passtxt.Text.Trim());

                string sql = "select * from DangNhap where ID = @TenDangNhap and PW = @MatKhau and TrangThai = 1";
                    DataTable datatbl = kketnoi.Excute_Datatable_Sql(sql,CommandType.Text,para);

                    if (datatbl.Rows.Count > 0)
                    {
                        ckdangnhap = true;
                        hotendn = datatbl.Rows[0]["ID"].ToString();
                    }
                    else
                    {
                        ckdangnhap = false;

                    }
                   
               
            }

            catch (Exception ex)
            {
                ckdangnhap = false;
                XtraMessageBox.Show(ex.ToString());
            }
            
            return ckdangnhap;
        }


        public void dangnhapht()
        {
            if (kiemtradangnhap() == true)
            {
                
                IsSuccessfull = true;
                ghinhodangnhap();
                ghithongtin();
                MainForm from = new MainForm();
                from.Show();
                this.Close();
            
            }
            else
            { XtraMessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin"); }

        }
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            dangnhapht();
            
        }

        private void nhotendnchk_CheckedChanged(object sender, EventArgs e)
        {
            if (nhotendnchk.Checked)
            { }
            else { nhomkchk.Checked = false; tudongdnchk.Checked = false; }

        }

        private void nhomkchk_CheckedChanged(object sender, EventArgs e)
        {
            if (nhomkchk.Checked)
            { nhotendnchk.Checked = true; }
            
        }

        private void tudongdnchk_CheckedChanged(object sender, EventArgs e)
        {
            if (tudongdnchk.Checked)
            {
                XtraMessageBox.Show("Kích hoạt không thành công \n Chức năng này chỉ được dùng khi hệ thống kích hoạt kết nối cơ sở dữ liệu qua internet.");
                tudongdnchk.Checked = false;
                //nhotendnchk.Checked = nhomkchk.Checked = true; 
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tudongdnchk.Checked ==true)
            {

                simpleButton1.PerformClick();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void passtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dangnhapht();
                simpleButton1.Focus();
            }
        }

        private void labelControl4_MouseClick(object sender, MouseEventArgs e)
        {
            KetNoiDaTa ketnoi = new KetNoiDaTa();
            ketnoi.ShowDialog();
        }

        private void tendntxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                passtxt.Focus();
            }
        }
    }
}