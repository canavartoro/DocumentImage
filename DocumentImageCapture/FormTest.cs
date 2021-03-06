﻿using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace DocumentImageCapture
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private DataSources dataSources = null;
        public DataSources Sources
        {
            get
            {
                if (dataSources == null) dataSources = DataSources.Load();
                return dataSources;
            }
            set { dataSources = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.TabPages.Clear();
                if (string.IsNullOrWhiteSpace(textid.Text))
                {
                    Utility.Hata("Kayıt id girilmedi");
                    textid.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbdatasource.Text))
                {
                    Utility.Hata("Data source seçilmedi");
                    cmbdatasource.Focus();
                    return;
                }

                DataSource src = Sources[cmbdatasource.Text];

                //using (SqlConnection conn = new SqlConnection("data source=127.0.0.1;persist security info=False;initial catalog=ors_test;Connect Timeout=50;User=sa;Password=20012001;"))
                using (SqlConnection conn = new SqlConnection(src.ToString()))
                {
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = string.Concat("SELECT DocImage,Description,CreateDate FROM dbo.Weigh_Image WITH (NOLOCK) WHERE WaybillId = ", Convert.ToInt32(textid.Text));
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[i][0] != null && dt.Rows[i][0] != DBNull.Value)
                                {
                                    Image bitmap;
                                    PictureBox pcb = new PictureBox();
                                    pcb.Dock = DockStyle.Fill;
                                    pcb.SizeMode = PictureBoxSizeMode.StretchImage;
                                    byte[] imagebytes = (byte[])dt.Rows[i][0];
                                    using (var ms = new MemoryStream(imagebytes))
                                    {
                                        bitmap = Image.FromStream(ms);
                                        label.Text = FileSizeString(imagebytes.Length);
                                    }

                                    #region Text
                                    /*
                                    Font font = new Font("Tahoma", 14, FontStyle.Bold, GraphicsUnit.Pixel);
                                    Point atpoint = new Point(bitmap.Width / 2, bitmap.Height / 2);
                                    SolidBrush brush = new SolidBrush(Color.DeepSkyBlue);//new SolidBrush(Color.FromArgb(255, 255, 0, 0));
                                    Graphics graphics = Graphics.FromImage(bitmap);
                                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                    graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    StringFormat sf = new StringFormat();
                                    sf.Alignment = StringAlignment.Center;
                                    sf.LineAlignment = StringAlignment.Center;
                                    graphics.DrawString("VO-00000010304", font, brush, atpoint, sf);

                                    //Image logo = Image.FromFile(@"C:\Users\huseyin.celik\Downloads\hc.png");
                                    //graphics.DrawImage(logo, bitmap.Width - 50, 0, 50, 50);

                                    //RectangleF rectF1 = new RectangleF(10, 8, 100, 30);
                                    //graphics.DrawRectangle(Pens.DeepSkyBlue, Rectangle.Round(rectF1));
                                    //graphics.DrawString("Canavar.Toro", font, brush, new Point(12, 12));

                                    graphics.Flush();
                                    graphics.Dispose();
                                    MemoryStream m = new MemoryStream();
                                    bitmap.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    pcb.Image = bitmap;
                                    //bitmap.Save(string.Concat(Application.StartupPath, "\\tom.jpg"));*/
                                    #endregion

                                    pcb.Image = bitmap;
                                    TabPage tp = new TabPage();
                                    tp.Text = string.Concat(dt.Rows[i]["CreateDate"].ToString(), " ", dt.Rows[i]["Description"].ToString(), " ", FileSizeString(imagebytes.Length));
                                    tp.Controls.Add(pcb);
                                    tp.AutoScroll = true;
                                    tabControl1.TabPages.Add(tp);
                                }
                                else
                                {
                                    label.Text = string.Concat("Resim yok ", textid.Text);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            if (string.IsNullOrWhiteSpace(textid.Text))
            {
                Utility.Hata("Kayıt id girilmedi");
                textid.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbdatasource.Text))
            {
                Utility.Hata("Data source seçilmedi");
                cmbdatasource.Focus();
                return;
            }

            DataSource src = Sources[cmbdatasource.Text];

            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                //using (SqlConnection conn = new SqlConnection("data source=127.0.0.1;persist security info=False;initial catalog=ors_test;Connect Timeout=50;User=sa;Password=20012001;"))
                using (SqlConnection conn = new SqlConnection(src.ToString()))
                {
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = string.Concat("SELECT Plate,Weight1,Weight2,Net,FirmName,MaterialName,WaybillNo FROM dbo.Weigh2 WITH (NOLOCK) WHERE seq = 4068");
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    string materialText = string.Concat("Material:", dt.Rows[0]["MaterialName"].GetString());

                    string weightText = string.Concat("Weight1:", dt.Rows[0]["Weight1"].GetDecimal().ToString("N"));

                    string weight2Text = string.Concat("Weight2:", dt.Rows[0]["Weight2"].GetDecimal().ToString("N"));

                    string netText = string.Concat("Net:", dt.Rows[0]["Net"].GetDecimal().ToString("N"));

                    string firmText = string.Concat("Firm Name:", dt.Rows[0]["FirmName"].GetString());
                    string plateText = string.Concat("Plate:", dt.Rows[0]["Plate"].GetString());
                    string waybillText = string.Concat("Waybill No:", dt.Rows[0]["WaybillNo"].GetString());

                    Image bitmap = Image.FromFile(op.FileName);
                    #region Text

                    Font font = new Font("Tahoma", 44, FontStyle.Bold, GraphicsUnit.Pixel);
                    Point atpoint = new Point(bitmap.Width / 2, bitmap.Height / 2);
                    SolidBrush brush = new SolidBrush(Color.White);//new SolidBrush(Color.FromArgb(255, 255, 0, 0));
                    Graphics graphics = Graphics.FromImage(bitmap);
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    int y = 152, x = 110;
                    graphics.DrawString(firmText, font, brush, new Point(x, y));
                    y += Convert.ToInt32(graphics.MeasureString(firmText, font).Height + 2);

                    graphics.DrawString(plateText, font, brush, new Point(x, y));
                    y += Convert.ToInt32(graphics.MeasureString(plateText, font).Height + 2);

                    graphics.DrawString(waybillText, font, brush, new Point(x, y));
                    y += Convert.ToInt32(graphics.MeasureString(waybillText, font).Height + 2);

                    graphics.DrawString(materialText, font, brush, new Point(x, y));
                    y += Convert.ToInt32(graphics.MeasureString(materialText, font).Height + 2);

                    graphics.DrawString(weightText, font, brush, new Point(x, y));
                    y += Convert.ToInt32(graphics.MeasureString(weightText, font).Height + 2);

                    graphics.DrawString(weight2Text, font, brush, new Point(x, y));
                    y += Convert.ToInt32(graphics.MeasureString(weight2Text, font).Height + 2);

                    graphics.DrawString(netText, font, brush, new Point(x, y));

                    //Bitmap qrimg = GenerateQR(150, 150, "5691gs01|14700|39700|25000|ASSOH FA MOAYE|5/15 gravier|s1");
                    //if(qrimg != null)
                    //{
                    //    graphics.DrawImage(qrimg, bitmap.Width - 155, 5, 150, 150);
                    //}


                    graphics.Flush();
                    graphics.Dispose();
                    MemoryStream m = new MemoryStream();
                    bitmap.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //bitmap.Save(string.Concat(Application.StartupPath, "\\tom.jpg"));
                    #endregion

                    long len = new FileInfo(op.FileName).Length;
                    PictureBox pcb = new PictureBox();
                    pcb.Dock = DockStyle.Fill;
                    pcb.Image = bitmap;
                    pcb.SizeMode = PictureBoxSizeMode.StretchImage;
                    TabPage tp = new TabPage();
                    tp.Text = string.Concat(Path.GetFileNameWithoutExtension(op.FileName), " ", FileSizeString(len));
                    tp.Controls.Add(pcb);
                    tabControl1.TabPages.Add(tp);
                    label.Text = FileSizeString(len);

                    MemoryStream memoryStream = new MemoryStream();
                    pcb.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] image = memoryStream.ToArray();
                    conn.Open();

                    command.CommandText = "INSERT INTO dbo.Weigh_Image (WaybillId,DocImage,Description,CreateDate) VALUES (@Waybill,@DocImage,'Manuel eklendi',GETDATE())";
                    command.Parameters.AddWithValue("Waybill", Convert.ToInt32(textid.Text));
                    command.Parameters.AddWithValue("DocImage", image);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Sources.Contains("(default)") && !string.IsNullOrWhiteSpace(AppSettingHelper.Default.SqlServer))
                {
                    DataSource ds = new DataSource();
                    ds.Name = "(default)";
                    ds.Server = AppSettingHelper.Default.SqlServer;
                    ds.Database = AppSettingHelper.Default.Database;
                    ds.User = AppSettingHelper.Default.DbUser;
                    ds.Password = AppSettingHelper.Encrypt(AppSettingHelper.Default.DbPassword);
                    Sources.Add("(default)", ds);
                    Sources.SelectedIndex = 0;
                    DataProvider.SaveObj(DataSources.XML_FILE_NAME, Sources);
                }
                if (Sources.Count > 0)
                {
                    cmbdatasource.Items.Clear();
                    foreach (string s in Sources.Keys) cmbdatasource.Items.Add(s);
                    cmbdatasource.SelectedIndex = Sources.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                Utility.Hata(ex);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormDatasource src = new FormDatasource();
            if (src.ShowDialog() == DialogResult.OK)
            {
                dataSources = DataSources.Load();
                cmbdatasource.Items.Clear();
                foreach (string s in Sources.Keys) cmbdatasource.Items.Add(s);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbdatasource.Text) && Utility.Sor("Seçilen bağlantı bilgisi silinecek onaylıyor musunuz?"))
            {
                if (Sources.Contains(cmbdatasource.Text)) Sources.Remove(cmbdatasource.Text);
                DataProvider.SaveObj(DataSources.XML_FILE_NAME, Sources);
                dataSources = DataSources.Load();
                cmbdatasource.Items.Clear();
                cmbdatasource.Text = "";
                foreach (string s in Sources.Keys) cmbdatasource.Items.Add(s);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbdatasource.Text))
            {
                if (Sources.Contains(cmbdatasource.Text))
                {
                    DataSource src = Sources[cmbdatasource.Text];
                    FormDatasource source = new FormDatasource();
                    source.DataSource = src;
                    if (source.ShowDialog() == DialogResult.OK)
                    {
                        dataSources = DataSources.Load();
                        cmbdatasource.Items.Clear();
                        foreach (string s in Sources.Keys) cmbdatasource.Items.Add(s);
                    }
                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count > 0)
                {
                    if (string.IsNullOrWhiteSpace(cmbdatasource.Text))
                    {
                        Utility.Hata("Data source seçilmedi");
                        cmbdatasource.Focus();
                        return;
                    }

                    DataSource src = Sources[cmbdatasource.Text];

                    SaveFileDialog sv = new SaveFileDialog();
                    if (sv.ShowDialog() == DialogResult.OK)
                    {
                        string filepath = sv.FileName;

                        using (SqlConnection conn = new SqlConnection(src.ToString()))
                        {
                            SqlCommand comm = conn.CreateCommand();
                            comm.CommandText = string.Concat("SELECT DocImage,Description,CreateDate FROM dbo.Weigh_Image WITH (NOLOCK) WHERE WaybillId = ", Convert.ToInt32(textid.Text));
                            SqlDataAdapter da = new SqlDataAdapter(comm);
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        if (dt.Rows[i][0] != null && dt.Rows[i][0] != DBNull.Value)
                                        {
                                            byte[] imagebytes = (byte[])dt.Rows[0][0];

                                            //using (var ms = new MemoryStream(imagebytes))
                                            //{
                                            //    Image img = Image.FromStream(ms);
                                            //    img.Save(string.Concat(filepath, "-", i, ".jpeg"));
                                            //}

                                            using (var image = new MagickImage(imagebytes))
                                            {
                                                image.Format = MagickFormat.Jpg;
                                                image.Quality = 100;
                                                image.Write(string.Concat(filepath, "-", i, ".jpeg"));
                                            }

                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnconnduzelt.Enabled =
            btnconnsil.Enabled = cmbdatasource.Text != "(default)";
            Sources.SelectedIndex = cmbdatasource.SelectedIndex;
            DataProvider.SaveObj(DataSources.XML_FILE_NAME, Sources);
        }

        private string FileSizeString(long size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = size;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }

        public static Bitmap GenerateQR(int width, int height, string js)
        {
            try
            {
                if (js != null)
                {
                    IBarcodeWriter barcodeWriter = new BarcodeWriter();
                    barcodeWriter.Format = BarcodeFormat.QR_CODE;
                    QrCodeEncodingOptions options = new QrCodeEncodingOptions();
                    options = new QrCodeEncodingOptions
                    {
                        Width = width,
                        Height = height,
                        Margin = 0
                    };
                    options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
                    barcodeWriter.Options = options;
                    var result = new Bitmap(barcodeWriter.Write(js));
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
