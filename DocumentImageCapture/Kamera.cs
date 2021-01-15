using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using mshtml;
using System.Threading;
using System.Drawing.Imaging;

namespace DocumentImageCapture
{
    [Serializable]
    public class Kamera
    {
        [NonSerialized]
        private System.Windows.Forms.Timer timer, timerCheck;
        [NonSerialized]
        private DataProvider data;
        [NonSerialized]
        private WebBrowser webBrowser;
        public const string SELECT_STRING = "SELECT TOP 1 seq FROM dbo.Weigh2 WITH (NOLOCK) WHERE WeighTime1 = '{0}'";

        private volatile static byte[] captureImage = null;
        public /*volatile*/ static byte[] CaptureImage
        {
            get { return captureImage; }
            set { captureImage = value; }
        }

        public Kamera() { }

        public string Url { get; set; }
        public string Host { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool Aktif { get; set; }

        public void Start(WebBrowser wb)
        {
            data = new DataProvider();
            data.ConnectionString = GetSqlConnectionString();
            data.CheckField();

            webBrowser = wb;
            webBrowser.Url = new Uri(this.Url);
            webBrowser.ProgressChanged += WebBrowser_ProgressChanged;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1200;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            timer.Start();
        }

        private void WebBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                timer.Enabled = false;
                if (webBrowser.Document != null)
                {
                    HtmlElementCollection elements = webBrowser.Document.GetElementsByTagName("img");
                    if (elements != null && elements.Count > 0)
                    {
                        //Monitor.Enter(lockObject);
                        IHTMLImgElement img = (IHTMLImgElement)elements[0].DomElement;
                        IHTMLElementRenderFixed render = (IHTMLElementRenderFixed)img;
                        Bitmap bitmap = new Bitmap(img.width, img.height);
                        Graphics g = Graphics.FromImage(bitmap);
                        IntPtr hdc = g.GetHdc();
                        render.DrawToDC(hdc);
                        g.ReleaseHdc(hdc);

                        //string filename = string.Concat(Application.StartupPath, "\\", this.Host, "\\CaptureImage.jpeg");
                        //bitmap.Save(filename, ImageFormat.Jpeg);

                        MemoryStream memoryStream = new MemoryStream();
                        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        Kamera.CaptureImage = memoryStream.ToArray();
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            finally
            {
                //Monitor.Exit(lockObject);
                webBrowser.Refresh();
                timer.Enabled = true;
            }
        }

        public string GetSqlConnectionString()
        {
            return string.Format("data source={0};persist security info=False;initial catalog={1};Connect Timeout=50;User={2};Password={3};", this.Host, this.Database, this.User, AppSettingHelper.Decrypt(this.Password));
        }

    }

    [Serializable]//https://picsum.photos/
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public class Kameralar : CollectionBase
    {
        public const string XML_FILE_NAME = "Captures.dat";

        public Kameralar() { }

        public int Add(Kamera kmr)
        {
            return this.InnerList.Add(kmr);
        }

        public Kamera this[int index]
        {
            get { return this.InnerList[index] as Kamera; }
        }
        public void Remove(Kamera kmr)
        {
            this.InnerList.Remove(kmr);
        }

        public static Kameralar Load()
        {
            Kameralar kmr = null;
            try
            {

                using (DataProvider data = new DataProvider())
                {
                    kmr = (Kameralar)DataProvider.ReadObj(Kameralar.XML_FILE_NAME);
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
            if (kmr == null) kmr = new Kameralar();
            return kmr;
        }
    }
}
