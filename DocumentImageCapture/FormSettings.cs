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
            if (chkKopyala.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtHedefKlasor.Text))
                {
                    errorProvider1.SetError(txtHedefKlasor, "Hedef klasör adı boş bırakılamaz!");
                    str.AppendLine("Hedef klasör adı boş bırakılamaz!");
                }
                else
                {
                    if (!Directory.Exists(txtHedefKlasor.Text))
                    {
                        errorProvider1.SetError(txtHedefKlasor, "Hedef klasör adı hatalı!");
                        str.AppendLine("Hedef klasör adı hatalı!");
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtftpip.Text))
                {
                    errorProvider1.SetError(txtftpip, "FTP sunucu IP boş olamaz!");
                    str.AppendLine("FTP sunucu IP boş olamaz!");
                }
                if (string.IsNullOrWhiteSpace(txtftpuser.Text))
                {
                    errorProvider1.SetError(txtftpuser, "FTP user name boş olamaz!");
                    str.AppendLine("FTP user name boş olamaz!");
                }
                if (string.IsNullOrWhiteSpace(txtftppass.Text))
                {
                    errorProvider1.SetError(txtftppass, "FTP password boş olamaz!");
                    str.AppendLine("FTP password boş olamaz!");
                }
            }

            if (string.IsNullOrWhiteSpace(txtHost.Text))
            {
                errorProvider1.SetError(txtHost, "Oracle Host/IP boş olamaz!");
                str.AppendLine("Oracle Host/IP boş olamaz!");
            }

            if (string.IsNullOrWhiteSpace(txtServis.Text))
            {
                errorProvider1.SetError(txtHost, "Oracle Servis adı boş olamaz!");
                str.AppendLine("Oracle Servis adı boş olamaz!");
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
            AppSettingHelper.Default.tracelavel = trace;

            AppSettingHelper.Default.orahost = txtHost.Text;
            AppSettingHelper.Default.oraservis = txtServis.Text;
            AppSettingHelper.Default.hedefklasor = txtHedefKlasor.Text;
            AppSettingHelper.Default.ftphost = txtftpip.Text;
            AppSettingHelper.Default.ftpuser = txtftpuser.Text;
            AppSettingHelper.Default.ftppass = txtftppass.Text;
            AppSettingHelper.Default.timeout = (int)nmTimeout.Value;
            AppSettingHelper.Default.userid = (int)nmuserid.Value;
            AppSettingHelper.Default.oraport = (int)nmoraport.Value;
            AppSettingHelper.Default.coid = (int)nmcoid.Value;
            AppSettingHelper.Default.branchid = (int)nmbranchid.Value;
            AppSettingHelper.Default.ftpport = (int)nmftpport.Value;
            AppSettingHelper.Default.kopyala = chkKopyala.Checked;

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
            cmdtracelavel.Text = AppSettingHelper.Default.tracelavel.ToString();

            txtHost.Text = AppSettingHelper.Default.orahost;
            txtServis.Text = AppSettingHelper.Default.oraservis;
            txtHedefKlasor.Text = AppSettingHelper.Default.hedefklasor;
            txtftpip.Text = AppSettingHelper.Default.ftphost;
            txtftpuser.Text = AppSettingHelper.Default.ftpuser;
            txtftppass.Text = AppSettingHelper.Default.ftppass;
            nmTimeout.Value = AppSettingHelper.Default.timeout;
            nmuserid.Value = AppSettingHelper.Default.userid;
            nmoraport.Value = AppSettingHelper.Default.oraport;
            nmbranchid.Value = AppSettingHelper.Default.branchid;
            nmcoid.Value = AppSettingHelper.Default.coid;
            nmftpport.Value = AppSettingHelper.Default.ftpport;
            chkKopyala.Checked = AppSettingHelper.Default.kopyala;
        }

        private void btnHedefFold_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.Description = "Dosyaların kopyalanacağı klasörü seçin.";
            fl.ShowNewFolderButton = false;
            if (fl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtHedefKlasor.Text = fl.SelectedPath;
            }
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
                textKHost.Text = Kameralar[selectIndex].Host;
                textKDb.Text = Kameralar[selectIndex].Database;
                textKUser.Text = Kameralar[selectIndex].User;
                textKPass.Text = AppSettingHelper.Decrypt(Kameralar[selectIndex].Password);
                textKUrl.Text = Kameralar[selectIndex].Url;
                checkKAktif.Checked = Kameralar[selectIndex].Aktif;
            }
            else
            {
                textKHost.Text = "";
                textKDb.Text = "";
                textKUser.Text = "";
                textKPass.Text = "";
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
                        itm.SubItems.Add(kmr.Host);
                        itm.SubItems.Add(kmr.Url);
                        itm.SubItems.Add(kmr.Aktif ? "Ö" : "");
                        listKamera.Items.Add(itm);
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
                selectKam.Database = textKDb.Text;
                selectKam.User = textKUser.Text;
                selectKam.Password = AppSettingHelper.Encrypt(textKPass.Text);
                selectKam.Url = textKUrl.Text;
                selectKam.Host = textKHost.Text;
                Kameralar.Add(selectKam);
            }
            else
            {
                Kameralar[selectIndex].Aktif = checkKAktif.Checked;
                Kameralar[selectIndex].Database = textKDb.Text;
                Kameralar[selectIndex].User = textKUser.Text;
                Kameralar[selectIndex].Password = AppSettingHelper.Encrypt(textKPass.Text);
                Kameralar[selectIndex].Url = textKUrl.Text;
                Kameralar[selectIndex].Host = textKHost.Text;
            }

            selectIndex = -1;
            LoadSelect();
            DataProvider.SaveObj(Kameralar.XML_FILE_NAME, Kameralar);
            LoadKameralar();
        }
    }
}
