using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DocumentImageCapture
{
    public partial class FormDatasource : Form
    {
        public FormDatasource()
        {
            InitializeComponent();
        }

        public DataSource DataSource { get; set; }

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

        private void btnok_Click(object sender, EventArgs e)
        {
            if (DataSource == null)
            {
                DataSource = new DataSource();
                DataSource.Name = textName.Text;
                DataSource.Server = textserver.Text;
                DataSource.Database = textDb.Text;
                DataSource.User = textUser.Text;
                DataSource.Password = AppSettingHelper.Encrypt(textPassword.Text);
                Sources.Add(textName.Text, DataSource);
            }
            else
            {
                Sources[DataSource.Name].Name = textName.Text;
                Sources[DataSource.Name].Server = textserver.Text;
                Sources[DataSource.Name].Database = textDb.Text;
                Sources[DataSource.Name].User = textUser.Text;
                Sources[DataSource.Name].Password = AppSettingHelper.Encrypt(textPassword.Text);
            }
            DataProvider.SaveObj(DataSources.XML_FILE_NAME, Sources);
            DialogResult = DialogResult.OK;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FormDatasource_Load(object sender, EventArgs e)
        {
            if (DataSource != null)
            {
                textName.Text = DataSource.Name;
                textName.Enabled = false;
                textserver.Text = DataSource.Server;
                textDb.Text = DataSource.Database;
                textUser.Text = DataSource.User;
                textPassword.Text = AppSettingHelper.Decrypt(DataSource.Password);
            }
        }
    }

    [Serializable]
    [DebuggerDisplay("Server = {Server}, Database = {Database}")]
    public class DataSource
    {
        public DataSource() { }

        public string Name { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return string.Format("data source={0};persist security info=False;initial catalog={1};Connect Timeout=50;User={2};Password={3};", this.Server, this.Database, this.User, AppSettingHelper.Decrypt(this.Password));
        }

    }

    [Serializable]//https://picsum.photos/
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public class DataSources : DictionaryBase
    {
        public const string XML_FILE_NAME = "Connections.dat";

        public int SelectedIndex { get; set; } = -1;

        public DataSource this[string key]
        {
            get
            {
                return ((DataSource)Dictionary[key]);
            }
            set
            {
                Dictionary[key] = value;
            }
        }

        public ICollection Keys
        {
            get
            {
                return (Dictionary.Keys);
            }
        }

        public ICollection Values
        {
            get
            {
                return (Dictionary.Values);
            }
        }

        public void Add(String key, DataSource value)
        {
            Dictionary.Add(key, value);
        }

        public bool Contains(String key)
        {
            return (Dictionary.Contains(key));
        }

        public void Remove(String key)
        {
            Dictionary.Remove(key);
        }

        public static DataSources Load()
        {
            DataSources sources = null;
            try
            {

                using (DataProvider data = new DataProvider())
                {
                    sources = (DataSources)DataProvider.ReadObj(DataSources.XML_FILE_NAME);
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
            if (sources == null) sources = new DataSources();
            return sources;
        }
    }
}
