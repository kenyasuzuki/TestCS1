using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace TestCS1
{
    public partial class CyclicAccess : Form
    {
        private HtmlDocument doc= null;
        private int n = 0;

        public CyclicAccess()
        {
            InitializeComponent();
            //webView.Navigate("http://www5.airnet.ne.jp/kenya/");
            //webView.DocumentText = "<html><head><title>AA</title></head><body>ABC</body></html>";
            Uri url = new Uri(Path.Combine(Environment.CurrentDirectory, @"HTMLPage1.html"));
            webView.Navigate(url);
            doc = webView.Document;

            //String str = Properties.Settings.Default.Filename;
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            //aes.BlockSize = 128;
            //aes.KeySize = 128;
            var ivBlock = new byte[aes.BlockSize/8];
            if (Properties.Settings.Default.IV.CompareTo("") == 0)
            {
                //var ivBlockRfc = new Rfc2898DeriveBytes("IVの初期値です", Encoding.UTF8.GetBytes("saltというキー"));
                //ivBlock = ivBlockRfc.GetBytes(aes.BlockSize/8);
                aes.GenerateIV();
                ivBlock = aes.IV;
                Properties.Settings.Default.IV = Convert.ToBase64String(ivBlock);
                Properties.Settings.Default.Save();
            }
            else
            {
                ivBlock = Convert.FromBase64String(Properties.Settings.Default.IV);
            }
            var keyRfc = new Rfc2898DeriveBytes("password", Encoding.UTF8.GetBytes("saltというキー"));
            var key = keyRfc.GetBytes(aes.BlockSize/8);
            var key_str = Convert.ToBase64String(key);
            ICryptoTransform enc = aes.CreateEncryptor(key, ivBlock);
            byte[] src = Encoding.UTF8.GetBytes("暗号化されるデータ");
            var edata = enc.TransformFinalBlock(src, 0, src.Length);
            var edata_b64 = Convert.ToBase64String(edata);
            ICryptoTransform dec = aes.CreateDecryptor(key, ivBlock);
            var data = dec.TransformFinalBlock(edata, 0, edata.Length);
            var data_b64 = Convert.ToBase64String(data);
            var data_str = Encoding.UTF8.GetString(data);

            timer.Interval = 1000; //ms
            timer.Start();
        }

        private void webView_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //webView.DocumentText = "BBB";
            //doc.BackColor = Color.FromArgb(0,255,255);
            doc.GetElementById("UserID").InnerText = "user@id";
            //doc.GetElementsByTagName("form")[0].AttachEventHandler("onsubmit", form_Submit);
            //doc.GetElementById("Submit1").InvokeMember("click");
            //doc.GetElementsByTagName("form")[0].InvokeMember("submit");
        }

        private void OnTick(object sender, EventArgs e)
        {
            n++;
            if (checkAccess.Checked) return;

            HtmlElement elem = doc.CreateElement("p");
            elem.InnerText = n.ToString();
            doc.Body.AppendChild(elem);

            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bmp.Size);
            g.Dispose();
            //bmp.Save(Properties.Settings.Default.Filename, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp.Save(Properties.Settings.Default.Filename, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void form_Submit(object sender, EventArgs e)
        {

        }
    }
}
