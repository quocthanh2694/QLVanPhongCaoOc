using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace MainForm
{
    public partial class KetNoiDaTa : DevExpress.XtraEditors.XtraForm
    {
        public KetNoiDaTa()
        {
            InitializeComponent();
        }
        CS.Function funn = new CS.Function();
        CS.KetNoi kketnoi = new CS.KetNoi();
        private void ketnoidata_Load(object sender, EventArgs e)
        {
            servertxt.Text = Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadSubTree).GetValue("Server", "").ToString();
            servertxt.Focus();
            servertxt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (servertxt.Text == "" | logintxt.Text =="" | passtxt.Text =="")
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại thông tin");
                servertxt.Focus();
                return;
            }
            else
            {
                splashScreenManager2.ShowWaitForm();

                if (kketnoi.ketnoiserver("Data Source=" + servertxt.Text + ";Initial Catalog=DATT;User ID=" + logintxt.Text + ";Password=" + passtxt.Text + "") == true)
                {
                    splashScreenManager2.CloseWaitForm();
                    ketnoiclick.DialogResult = DialogResult.OK;
                    Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("Server", servertxt.Text);
                    Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("ConnectionString", funn.mahoa(Properties.Resources.KeyMaHoaDaTa, "Data Source=" + servertxt.Text + ";Initial Catalog=DATT;User ID=" + logintxt.Text + ";Password=" + passtxt.Text + ""));
                    XtraMessageBox.Show("Kết nối đến máy chủ thành công");
                    this.Close();
                }
                else
                {
                    splashScreenManager2.CloseWaitForm();
                    ketnoiclick.DialogResult = DialogResult.None;
                     XtraMessageBox.Show("Máy chủ " + servertxt.Text + " không tồn tại", "Thông báo");
                    servertxt.Focus();
                }
              
            }
        }

        private void Duongdantext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13) ketnoiclick.Focus();
        }

        private void Duongdantext_Validated(object sender, EventArgs e)
        {
            if (servertxt.Text == "") ketnoiclick.DialogResult = DialogResult.None;
        }
    }
}