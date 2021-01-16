﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;
using System.Diagnostics;

namespace DocumentImageCapture
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private TcpCaptureServer server = null;
        private Kameralar _kameralar = null;
        public Kameralar Kameralar
        {
            get
            {
                if (_kameralar == null) _kameralar = Kameralar.Load();
                return _kameralar;
            }
            set { _kameralar = value; }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTrace.Text = "";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Process.Start(string.Format("\"{0}\"", Utility.TraceName));
            System.Diagnostics.Process.Start("Explorer.exe", string.Format("/select,\"{0}\"", Utility.TraceName));
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            FormSettings ayar = new FormSettings();
            if (ayar.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void timerStartup_Tick(object sender, EventArgs e)
        {
            try
            {
                Trace.Listeners.Add(new TextTraceListener(richTrace));
                timerStartup.Enabled = false;
                timerStartup.Stop();
                if (Kameralar.Count > 0)
                {
                    tabControl1.TabPages.Clear();
                    //for (int i = 0; i < Kameralar.Count; i++)
                    {
                        int i = 0;
                        if (!Kameralar[i].Aktif) return;

                        try
                        {
                            if (!Directory.Exists(string.Concat(Application.StartupPath, "\\", Kameralar[i].Host)))
                                Directory.CreateDirectory(string.Concat(Application.StartupPath, "\\", Kameralar[i].Host));
                        }
                        catch (Exception exc)
                        {
                            Utility.Hata(exc);
                        }

                        TabPage page = new TabPage();
                        page.Text = Kameralar[i].Host;
                        WebBrowser wbrowser = new WebBrowser();
                        wbrowser.Dock = DockStyle.Fill;
                        Kameralar[i].Start(wbrowser);
                        page.Controls.Add(wbrowser);
                        page.Tag = Kameralar[i];
                        tabControl1.TabPages.Add(page);
                    }

                    Logger.I(Kameralar[0].GetSqlConnectionString());
                    server = new TcpCaptureServer(Kameralar[0].GetSqlConnectionString());
                    server.Start();
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            timerStartup.Enabled = true;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Kameralar != null && Kameralar.Count > 0)
            {
                FormTest test = new FormTest(Kameralar[0].GetSqlConnectionString());
                test.Show();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.Size = new Size(800, 600);
                this.Show();
                this.notifyIcon1.Visible = false;
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            finally
            {
                Application.DoEvents();
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            try
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    this.Hide();
                    this.notifyIcon1.Visible = true;
                    this.notifyIcon1.ShowBalloonTip(600, "Dosya Izleme", "Uygulama çalışıyor.", ToolTipIcon.Info);
                }
                else if (WindowState == FormWindowState.Normal)
                {
                    this.Show();
                    this.notifyIcon1.Visible = false;
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            Application.DoEvents();
        }
    }
}
