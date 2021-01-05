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

namespace DocumentImageCapture
{
    [Serializable]
    public class Kamera
    {
        [NonSerialized]
        private Timer timer, timerCheck;
        [NonSerialized]
        private DataProvider data;
        [NonSerialized]
        private WebBrowser webBrowser;
        public const string SELECT_STRING = "SELECT TOP 1 seq FROM dbo.Weigh2 WITH (NOLOCK) WHERE WeighTime1 = '{0}'";

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

            timerCheck = new Timer();
            timerCheck.Interval = 20000;
            timerCheck.Tick += TimerCheck_Tick;
            timerCheck.Enabled = true;
            timerCheck.Start();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            timer.Start();
        }

        private void TimerCheck_Tick(object sender, EventArgs e)
        {
            timerCheck.Enabled = false;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(string.Concat(Application.StartupPath, "\\", this.Host, "\\"));
                if (dir.Exists)
                {
                    FileInfo[] files = dir.GetFiles();
                    if (files != null && files.Length > 0)
                    {
                        foreach (FileInfo f in files)
                        {
                            long seq = data.CheckSeq(Path.GetFileNameWithoutExtension(f.FullName));
                            if (seq > 0)
                            {
                                byte[] filecontent = data.GetFileByte(f.FullName);
                                if (filecontent != null)
                                {
                                    if (data.Execute("UPDATE dbo.Weigh2 SET DocImage = @DocImage WHERE seq = @Id", new SqlParameter[] { new SqlParameter("DocImage", filecontent), new SqlParameter("Id", seq) }))
                                    {
                                        Logger.I(string.Concat("Dosya eklendi!", f.FullName, ", Id:", seq));
                                        try
                                        {
                                            File.Delete(f.FullName);
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    else
                                    {
                                        Logger.E(string.Concat("Dosya eklenemedi!", f.FullName, ", Id:", seq));
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    File.Delete(f.FullName);
                                }
                                catch 
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            finally
            {
                timerCheck.Enabled = true;
            }
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
                        IHTMLImgElement img = (IHTMLImgElement)elements[0].DomElement;
                        IHTMLElementRenderFixed render = (IHTMLElementRenderFixed)img;
                        Bitmap bmp = new Bitmap(img.width, img.height);
                        Graphics g = Graphics.FromImage(bmp);
                        IntPtr hdc = g.GetHdc();
                        render.DrawToDC(hdc);
                        g.ReleaseHdc(hdc);
                        bmp.Save(string.Concat(Application.StartupPath, "\\", this.Host, "\\", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"), ".jpg"),
                         System.Drawing.Imaging.ImageFormat.Jpeg);
                        //bmp.Save(Application.StartupPath + "\\" + Guid.NewGuid().ToString("N") + @".jpg",
                        //     System.Drawing.Imaging.ImageFormat.Jpeg);
                        webBrowser.Refresh();
                        Application.DoEvents();
                    }
                }

            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            finally
            {
                timer.Enabled = true;
            }
        }

        public string GetSqlConnectionString()
        {
            return string.Format("data source={0};persist security info=False;initial catalog={1};Connect Timeout=50;User={2};Password={3};", this.Host, this.Database, this.User, AppSettingHelper.Decrypt(this.Password));
        }

    }

    [Serializable]
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
