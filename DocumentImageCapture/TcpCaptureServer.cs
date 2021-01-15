using DevExpress.XtraReports.UI;
using DocumentImageCapture;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
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
        private string sqlconnectionstring = "data source=127.0.0.1;persist security info=False;initial catalog=ors_test;Connect Timeout=50;User=sa;Password=20012001;";

        public TcpCaptureServer(string sqlconnstr)
        {
            sqlconnectionstring = sqlconnstr;
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
                Thread.Sleep(1000);
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
                                            if (Kamera.CaptureImage != null)
                                            {
                                                byte[] byteimage = Kamera.CaptureImage.ToArray();

                                                try
                                                {
                                                    using (SqlConnection conn = new SqlConnection(sqlconnectionstring))
                                                    {
                                                        conn.Open();
                                                        SqlCommand command = conn.CreateCommand();
                                                        command.CommandText = "UPDATE dbo.Weigh2 SET DocImage = @DocImage, [Desc] = @Desc WHERE seq = @Id";
                                                        command.Parameters.AddWithValue("Id", Convert.ToInt32(strarr[1]));
                                                        command.Parameters.AddWithValue("DocImage", byteimage);
                                                        command.Parameters.AddWithValue("Desc", "Ekleme");
                                                        command.ExecuteNonQuery();
                                                        conn.Close();
                                                    }
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
                                                stream.Write(byteimage, 0, byteimage.Length);
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
