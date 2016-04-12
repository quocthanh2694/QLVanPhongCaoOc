  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using System.IO;
using DevExpress.XtraTab;
using Microsoft.Win32;
using DevExpress.XtraReports.UI;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using System.Data.OleDb;
using DevExpress.XtraEditors.Controls;
using System.Diagnostics;



namespace MainForm
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            SkinHelper.InitSkinGallery(rgbiSkins, true);

        }
        CS.Function funn = new CS.Function();
        CS.KetNoi kketnoi = new CS.KetNoi();
        private void kiemtraquyen()
        {
            

            string tendn = Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadSubTree).GetValue("Laytendn", "").ToString();
            object [] para = new object[2];
            para[0] = "@TenDangNhap";
            para[1] = tendn;
            //string sql1 = "select ID, IDChucNangCon,TenChucNang,MoTa,QuyenHan,IDDangNhap from ChucNangCon  join QuyenDangNhap on ChucNangCon.IDChucNangCon = QuyenDangNhap.IDChucNang  join DangNhap on QuyenDangNhap.IDDangNhap = DangNhap.ID where ID =@TenDangNhap and QuyenHan = '1'";
            string sql = "select id,IDChucNangCon,TenChucNang,MoTa,QuyenHan,IDDangNhap from ChucNangCon cnc,DangNhap dn,dbo.QuyenDangNhap qdn where cnc.IDChucNangCon =qdn.IDChucNang and qdn.IDDangNhap=dn.id	and ID=@TenDangNhap and QuyenHan='1'";

            DataTable dttb = kketnoi.Excute_Datatable_Sql(sql,CommandType.Text,para);

            if (dttb.Rows.Count > 0)
            {
                for (int i = 0; i < dttb.Rows.Count; i++)
                {
                    string tenhucnang = dttb.Rows[i]["TenChucNang"].ToString();
                    capquyen1buton(Par1, tenhucnang, true);

                }
            }

        }
        public static void capquyenbuton(RibbonPageGroup pageGroup, string name, bool enableButtons)
        {
            foreach (BarItemLink link in pageGroup.ItemLinks)
            {
                BarButtonItem bar = link.Item as BarButtonItem;
                if (bar.Name == name) dongmotungbuton(bar, enableButtons);
            }
        }

        public static void capquyen1buton(RibbonPage pageGroup, string name, bool enableButtons)
        {
            foreach (RibbonPageGroup group in pageGroup.Groups)
            {
                capquyenbuton(group, name, enableButtons);
            }

        }

        public static void dongmotungbuton(BarButtonItem bar, bool ennable)
        {

            foreach (BarItemLink link in bar.Links)
            {

                link.Item.Enabled = ennable;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            string fileName = Application.StartupPath + "\\Skins.txt";

            if (File.Exists(fileName) == false) // neu file txt chua ton tai thi tao ra file
                defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Blueprint");
            else // nguoc lai, neu co roi thi doc file txt do len
            {
                StreamReader sr = new StreamReader(fileName, false);
                defaultLookAndFeel1.LookAndFeel.SetSkinStyle(sr.ReadLine());
                sr.Close();
                string hotendn = Registry.CurrentUser.CreateSubKey("DATT", RegistryKeyPermissionCheck.ReadSubTree).GetValue("Hotendn", "").ToString();
                string versionsql = "";

                barStaticItem1.Caption = "Xin chào " + hotendn + ", ngày " + DateTime.Now.ToString("dd/MM/yyyy.") + " Form Main Version 1.0.0.0                             " ;
            }
            kiemtraquyen();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string skins = defaultLookAndFeel1.LookAndFeel.SkinName;
            string fileName = Application.StartupPath + "\\Skins.txt";
            StreamWriter sw = new StreamWriter(fileName, false);
            sw.WriteLine(skins);
            sw.Close();
        }

        public void TabCreating(XtraTabControl TabControl, string Text, Form Form)
        {
            int Index = KiemTraTonTai(TabControl, Text);
            if (Index >= 0)
            {
                TabControl.SelectedTabPage = TabControl.TabPages[Index];
                TabControl.SelectedTabPage.Text = Text;

            }
            else
            {
                XtraTabPage TabPage = new XtraTabPage { Text = Text };
                TabControl.TabPages.Add(TabPage);
                TabControl.SelectedTabPage = TabPage;

                Form.TopLevel = false;
                Form.Parent = TabPage;
                Form.Show();
                Form.Dock = DockStyle.Fill;
            }
        }

        static int KiemTraTonTai(XtraTabControl TabControlName, string TabName)
        {
            int temp = -1;
            for (int i = 0; i < TabControlName.TabPages.Count; i++)
            {
                if (TabControlName.TabPages[i].Text == TabName)
                {
                    temp = i;
                    break;
                }
            }
            return temp;
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            XtraTabControl TabControl = (XtraTabControl)sender;
            int i = TabControl.SelectedTabPageIndex;
            TabControl.TabPages.RemoveAt(TabControl.SelectedTabPageIndex);
            TabControl.SelectedTabPageIndex = i - 1;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KetNoiDaTa them = new KetNoiDaTa();
            TabCreating(this.xtraTabControl1, barButtonItem1.Caption, them);
        }
        private void iExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { Application.Exit(); }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\MainForm.exe");
                string account = Application.StartupPath + "\\account.txt";
                StreamWriter sw = new StreamWriter(account, false);
                sw.WriteLine("000");
                sw.Close();
                Application.Exit();
            }
        }
        private void barButtonItem5_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FForm.DangKy dk =new FForm.DangKy();
            dk.ShowDialog();
        }
   
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FForm.DoiPass doi = new FForm.DoiPass();
            TabCreating(this.xtraTabControl1, chid14.Caption, doi);
        }
        private void quanlytaikhoanbt18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FForm.PhanQuyen pq = new FForm.PhanQuyen();

            TabCreating(this.xtraTabControl1, chid16.Caption, pq);
        }

        private void child18_ItemClick(object sender, ItemClickEventArgs e)
        {
            FForm.BangGiaDien BGD= new FForm.BangGiaDien();
                TabCreating(this.xtraTabControl1,child18.Caption,BGD);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            FForm.BangGiaNuoc BGN = new FForm.BangGiaNuoc();
            TabCreating(this.xtraTabControl1, child19.Caption, BGN);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            FForm.BangGiaTang BGT = new FForm.BangGiaTang();
            TabCreating(this.xtraTabControl1, child20.Caption, BGT);
        }

        private void child21_ItemClick(object sender, ItemClickEventArgs e)
        {
            FForm.BangGiaDT BGDT = new FForm.BangGiaDT();
            TabCreating(this.xtraTabControl1, child21.Caption, BGDT);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            FForm.CaoOc CO = new FForm.CaoOc();
            TabCreating(this.xtraTabControl1, child22.Caption, CO);
        }

        private void barButtonItem8_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            FForm.Tang Tg = new FForm.Tang();
            TabCreating(this.xtraTabControl1, child23.Caption, Tg);
        }

        private void child24_ItemClick(object sender, ItemClickEventArgs e)
        {
            FForm.Phong Pg = new FForm.Phong();
            TabCreating(this.xtraTabControl1, child24.Caption, Pg);
        }

    }

}