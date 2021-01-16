using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentImageCapture
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        public FormTest(string conntr)
        {
            InitializeComponent();
            connectionstring = conntr;
        }

        private string connectionstring = "data source=127.0.0.1;persist security info=False;initial catalog=ors_test;Connect Timeout=50;User=sa;Password=20012001;";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
                {
                    Utility.Hata("Kayıt id girilmedi");
                    toolStripTextBox1.Focus();
                    return;
                }

                //using (SqlConnection conn = new SqlConnection("data source=127.0.0.1;persist security info=False;initial catalog=ors_test;Connect Timeout=50;User=sa;Password=20012001;"))
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = string.Concat("SELECT DocImage FROM dbo.Weigh2 WITH(NOLOCK) WHERE seq = ", Convert.ToInt32(toolStripTextBox1.Text));
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0][0] != null && dt.Rows[0][0] != DBNull.Value)
                            {
                                byte[] imagebytes = (byte[])dt.Rows[0][0];
                                using (var ms = new MemoryStream(imagebytes))
                                {
                                    pictureBox1.Image = Image.FromStream(ms);
                                    label.Text = imagebytes.Length.ToString();
                                }
                            }
                            else
                            {
                                label.Text = string.Concat("Resim yok ", toolStripTextBox1.Text);
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
            if(string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
            {
                Utility.Hata("Kayıt id girilmedi");
                toolStripTextBox1.Focus();
                return;
            }

            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(op.FileName);
                //using (SqlConnection conn = new SqlConnection("data source=127.0.0.1;persist security info=False;initial catalog=ors_test;Connect Timeout=50;User=sa;Password=20012001;"))
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    pictureBox1.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] image = memoryStream.ToArray();
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = "UPDATE dbo.Weigh2 SET DocImage = @DocImage WHERE seq = @Id";
                    command.Parameters.AddWithValue("Id", Convert.ToInt32(toolStripTextBox1.Text));
                    command.Parameters.AddWithValue("DocImage", image);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                e.Handled = true;
            }
        }
    }
}
