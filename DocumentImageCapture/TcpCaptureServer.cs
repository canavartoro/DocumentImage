using DevExpress.XtraReports.UI;
using DocumentImageCapture;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentImageCapture
{
    public class TcpCaptureServer : IDisposable
    {
        bool abortListener = false;
        TcpListener server = null;
        Thread threadlisten = null;
        Kameralar _kameralar = null;

        public TcpCaptureServer(Kameralar kams)
        {
            _kameralar = kams;
        }

        public void Start()
        {
            try
            {
                abortListener = true;
                int port = 8888;
                server = new TcpListener(IPAddress.Loopback, port);
                server.Start();

                threadlisten = new Thread(new ThreadStart(Listening));
                threadlisten.Start();

                Logger.I(" >> Server Started");

            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void Stop()
        {
            try
            {
                abortListener = false;

                try
                {
                    Thread.Sleep(1000);
                    if (server != null) server.Stop();
                }
                catch (Exception excstop) { Logger.E(excstop); }

                try
                {
                    Thread.Sleep(1000);
                    if (threadlisten != null && threadlisten.IsAlive) threadlisten.Abort();
                }
                catch (ThreadAbortException exctabort) { Logger.E(exctabort); }
                catch (Exception excabort) { Logger.E(excabort); }

                Logger.I("Server durduruldu");
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
        }

        private void Listening()
        {
            byte[] bytesFrom = new byte[2048];

            while (abortListener)
            {
                try
                {
                    using (System.Net.Sockets.TcpClient client = server.AcceptTcpClient())
                    {
                        Logger.I("New request");
                        using (NetworkStream stream = client.GetStream())
                        {
                            stream.Read(bytesFrom, 0, bytesFrom.Length);
                            try
                            {
                                String strdata = Encoding.GetEncoding("Windows-1254").GetString(bytesFrom);
                                if (strdata != null)
                                {
                                    Logger.I(string.Concat("Command:", strdata));
                                    string[] strarr = strdata.Split('|');
                                    if (strarr != null && strarr.Length > 1)
                                    {
                                        if (stream.CanWrite)
                                        {
                                            if (_kameralar != null && _kameralar.Count > 0)
                                            {
                                                long id = 0;
                                                if (long.TryParse(strarr[1], out id))
                                                {
                                                    List<byte[]> images = new List<byte[]>();
                                                    for (int loop = 0; loop < _kameralar.Count; loop++)
                                                    {
                                                        if (_kameralar[loop].CaptureImage != null)
                                                        {
                                                            byte[] byteimage = _kameralar[loop].CaptureImage.ToArray();
                                                            images.Add(byteimage);
                                                        }
                                                    }
                                                    Task.Run(() => AddImage(Convert.ToInt64(strarr[1]), images));
                                                }
                                                else
                                                {
                                                    Logger.E("Gelen bilgiler hatalı (seq)!");
                                                }
                                                byte[] nullbyt = new byte[512];
                                                stream.Write(nullbyt, 0, nullbyt.Length);
                                                stream.Flush();
                                                stream.Close();
                                            }
                                            else
                                            {
                                                byte[] resp = new byte[1024];
                                                stream.Write(resp, 0, resp.Length);
                                                stream.Flush();
                                                stream.Close();
                                            }
                                        }
                                        client.Close();
                                        Logger.I("Socket closed");
                                    }
                                }
                            }
                            catch (IOException ioex)
                            {
                                Logger.E(ioex);
                            }
                            catch (Exception e1)
                            {
                                Logger.E(e1);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.E(ex);
                }
            }

            Logger.E(" >> exit");
        }

        private readonly Font font = new Font("Tahoma", 14, FontStyle.Bold, GraphicsUnit.Pixel);
        readonly SolidBrush brush = new SolidBrush(Color.DeepSkyBlue);

        private void AddImage(long seq, List<byte[]> images)
        {
            try
            {
                using (WeighProvider db = new WeighProvider(AppSettingHelper.Default.GetSqlConnectionString()))
                {
                    Image bitmap;
                    WeighModel weigh = db.GetWeigh(seq);
                    for (int loop = 0; loop < images.Count; loop++)
                    {
                        byte[] imagebuff = images[loop];
                        if (weigh != null)
                        {
                            using (var ms = new MemoryStream(images[loop]))
                            {
                                bitmap = Image.FromStream(ms);
                            }
                            using (Graphics graphics = Graphics.FromImage(bitmap))
                            {
                                SolidBrush brush = new SolidBrush(Color.White);
                                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                                int y = 152, x = 110;

                                graphics.DrawString(weigh.FirmNameText, font, brush, new Point(x, y));
                                y += Convert.ToInt32(graphics.MeasureString(weigh.FirmNameText, font).Height + 2);

                                graphics.DrawString(weigh.PlateText, font, brush, new Point(x, y));
                                y += Convert.ToInt32(graphics.MeasureString(weigh.PlateText, font).Height + 2);

                                graphics.DrawString(weigh.WaybillNoText, font, brush, new Point(x, y));
                                y += Convert.ToInt32(graphics.MeasureString(weigh.WaybillNoText, font).Height + 2);

                                graphics.DrawString(weigh.MaterialNameText, font, brush, new Point(x, y));
                                y += Convert.ToInt32(graphics.MeasureString(weigh.MaterialNameText, font).Height + 2);

                                graphics.DrawString(weigh.Weight1Text, font, brush, new Point(x, y));
                                y += Convert.ToInt32(graphics.MeasureString(weigh.Weight1Text, font).Height + 2);

                                graphics.DrawString(weigh.Weight2Text, font, brush, new Point(x, y));
                                y += Convert.ToInt32(graphics.MeasureString(weigh.Weight2Text, font).Height + 2);

                                graphics.DrawString(weigh.NetText, font, brush, new Point(x, y));

                                graphics.Flush();
                                graphics.Dispose();
                                MemoryStream m = new MemoryStream();
                                bitmap.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);

                                MemoryStream memoryStream = new MemoryStream();
                                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                imagebuff = memoryStream.ToArray();
                            }
                            db.AddImage(seq, imagebuff);
                        }
                    }
                }
            }
            catch (NullReferenceException nullexcinsert)
            {
                Logger.E(nullexcinsert);
            }
            catch (SqlException sqlexcinsert)
            {
                Logger.E(sqlexcinsert);
            }
            catch (Exception excinsert)
            {
                Logger.E(excinsert);
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }

        #region IDisposable
        ~TcpCaptureServer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (server != null)
                {
                    server.Stop();
                }
            }

            disposed = true;
        }

        #endregion
    }

}
