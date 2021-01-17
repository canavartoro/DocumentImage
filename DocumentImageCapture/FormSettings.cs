using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentImageCapture
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private string FormValidate()
        {
            StringBuilder str = new StringBuilder();
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(textServ.Text))
            {
                errorProvider1.SetError(textServ, "Sql Server Host/IP boş olamaz!");
                str.AppendLine("Sql Server Host/IP boş olamaz!");
            }

            if (string.IsNullOrWhiteSpace(textDb.Text))
            {
                errorProvider1.SetError(textServ, "Sql Server db adı boş olamaz!");
                str.AppendLine("Sql Server db adı boş olamaz!");
            }

            return str.ToString();
        }

        private Kameralar _kameralar = null;
        public Kameralar Kameralar
        {
            get
            {
                if (_kameralar == null) _kameralar = new Kameralar();
                return _kameralar;
            }
            set { _kameralar = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string err = FormValidate();

            if (!string.IsNullOrWhiteSpace(err))
            {
                Utility.Hata(err);
                return;
            }

            TraceLevel trace = TraceLevel.Off;
            Enum.TryParse<TraceLevel>(cmdtracelavel.Text, out trace);
            AppSettingHelper.Default.TraceLavel = trace;
            AppSettingHelper.Default.SqlServer = textServ.Text;
            AppSettingHelper.Default.Database = textDb.Text;
            AppSettingHelper.Default.DbUser = textUser.Text;
            AppSettingHelper.Default.DbPassword = textPassw.Text;
            AppSettingHelper.Default.TimeOut = (int)nmTimeout.Value;

            //Properties.Settings.Default.Save();
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
            Utility.Bilgi("Ayarlar config.dat dosyasına kaydedildi");

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {

            LoadKameralar();

            string[] names = Enum.GetNames(typeof(TraceLevel));
            cmdtracelavel.Items.AddRange(names);
            cmdtracelavel.Text = AppSettingHelper.Default.TraceLavel.ToString();

            textServ.Text = AppSettingHelper.Default.SqlServer;
            textDb.Text = AppSettingHelper.Default.Database;
            textUser.Text = AppSettingHelper.Default.DbUser;
            textPassw.Text = AppSettingHelper.Default.DbPassword;
            nmTimeout.Value = AppSettingHelper.Default.TimeOut;
        }

        private int selectIndex = -1;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listKamera.SelectedIndices.Count > 0)
            {
                selectIndex = listKamera.SelectedIndices[0];
                LoadSelect();
            }
        }

        private void LoadSelect()
        {
            if (selectIndex != -1)
            {
                textKUrl.Text = Kameralar[selectIndex].Url;
                checkKAktif.Checked = Kameralar[selectIndex].Aktif;
            }
            else
            {
                textKUrl.Text = "";
                checkKAktif.Checked = false;
            }
        }

        private void LoadKameralar()
        {
            try
            {
                listKamera.Items.Clear();

                this.Kameralar = Kameralar.Load();

                if (this.Kameralar != null && this.Kameralar.Count > 0)
                {
                    int i = 1;
                    foreach (Kamera kmr in this.Kameralar)
                    {
                        ListViewItem itm = new ListViewItem();
                        itm.Text = i.ToString();
                        itm.SubItems.Add(kmr.Url);
                        itm.SubItems.Add(kmr.Aktif ? "√" : "");
                        listKamera.Items.Add(itm);
                        i++;
                    }
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
        }

        private void btnkyeni_Click(object sender, EventArgs e)
        {
            selectIndex = -1;
            LoadSelect();
            LoadKameralar();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (selectIndex != -1 && Utility.Sor("Seçilen kamera silinsin mi?"))
            {
                Kameralar.RemoveAt(selectIndex);
                DataProvider.SaveObj(Kameralar.XML_FILE_NAME, Kameralar);
                selectIndex = -1;
            }
            LoadKameralar();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (selectIndex == -1)
            {
                Kamera selectKam = new Kamera();
                selectKam.Aktif = checkKAktif.Checked;
                selectKam.Url = textKUrl.Text;
                Kameralar.Add(selectKam);
            }
            else
            {
                Kameralar[selectIndex].Aktif = checkKAktif.Checked;
                Kameralar[selectIndex].Url = textKUrl.Text;
            }

            selectIndex = -1;
            LoadSelect();
            DataProvider.SaveObj(Kameralar.XML_FILE_NAME, Kameralar);
            LoadKameralar();
        }
    }
}
