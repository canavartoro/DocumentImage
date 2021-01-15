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

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("data source=127.0.0.1;persist security info=False;initial catalog=ors_test;Connect Timeout=50;User=sa;Password=20012001;"))
            {
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = string.Concat("SELECT DocImage FROM dbo.Weigh2 WITH(NOLOCK) WHERE seq = ", Convert.ToInt32(numericUpDown1.Value));
                SqlDataAdapter da = new SqlDataAdapter(comm);
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        byte[] imagebytes = (byte[])dt.Rows[0][0];
                        using (var ms = new MemoryStream(imagebytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(op.FileName);
                using (SqlConnection conn = new SqlConnection("data source=127.0.0.1;persist security info=False;initial catalog=ors_test;Connect Timeout=50;User=sa;Password=20012001;"))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    pictureBox1.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] image = memoryStream.ToArray();
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = "UPDATE dbo.Weigh2 SET DocImage = @DocImage, [Desc] = @Desc WHERE seq = @Id";
                    command.Parameters.AddWithValue("Id", Convert.ToInt32(numericUpDown1.Value));
                    command.Parameters.AddWithValue("DocImage", image);
                    command.Parameters.AddWithValue("Desc", "Ekleme");
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
