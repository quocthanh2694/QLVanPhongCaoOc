using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.IO;

namespace MainForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
           // DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();

            string fileName = Application.StartupPath + "\\Skins.txt"; // tao file txt de chua thong tin ve viec luu skins

            if (File.Exists(fileName) == false)
                UserLookAndFeel.Default.SetSkinStyle("Money Twins");
            else
            {
                StreamReader sr = new StreamReader(fileName, false);
                UserLookAndFeel.Default.SetSkinStyle(sr.ReadLine());
                sr.Close();
            }

            FForm.DangNhap dn = new FForm.DangNhap();

            Application.Run(dn);
            if (dn.IsSuccessfull)
                Application.Run(new MainForm());
            //Application.Run( new MainForm);

        }
    }
}