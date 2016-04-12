using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Net.Mail;



namespace MainForm.CS
{
    class Function
    {
       
        public string thang2chuso(string thangnhap)
        {
            int thang1 = int.Parse(thangnhap);
            string thangxuly;
            if (thang1 == 1 || thang1 == 2)
            {
                thangxuly = thang1.ToString("00");

            }
            else
            {
                thangxuly =thangnhap; 
            }
            return thangxuly;
        }
        public string chuanhoaten(string tencanchuanhoa)
        {
            string ketqua = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tencanchuanhoa);
            return ketqua;
        }
        public string catho(string str)
        {
            string ho;
            str = str.Trim();
            
            if (str.LastIndexOf(' ') == -1)
            { ho = ""; }
            else
            {
                ho = str.Substring(0, str.LastIndexOf(' '));
            }

            return ho;
        }
        public string catten(string str)
        {   string ten;
            str = str.Trim();
            if (str.LastIndexOf(' ') == -1)
            { ten = str; }
            else
            {
                ten = str.Substring(str.LastIndexOf(' ') + 1);
            }
            return ten;
        }



        public string mahoa(string key, string toEncrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider tdes =
             new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                  toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public string giaima(string key, string toDecrypt)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(
                 toEncryptArray, 0, toEncryptArray.Length);
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return toDecrypt; 
            }
        }


        public bool kiemtraemail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public string laytenvanban(string duongdan)
        {
            string str = duongdan.ToUpper().Trim();

            string tenvanban = System.IO.Path.GetFileName(duongdan);

            return tenvanban;
        }

        
        
    }
}
