namespace DocumentImageCapture
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textPassw = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmdtracelavel = new System.Windows.Forms.ComboBox();
            this.nmTimeout = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.textDb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textServ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnkyeni = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.checkKAktif = new System.Windows.Forms.CheckBox();
            this.textKUrl = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.listKamera = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTimeout)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 437);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(756, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(415, 23);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(159, 48);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Kaydet";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(581, 23);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(159, 48);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Vazgeç";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(756, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textPassw);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textUser);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.cmdtracelavel);
            this.tabPage1.Controls.Add(this.nmTimeout);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.textDb);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textServ);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(748, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ayarlar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textPassw
            // 
            this.textPassw.Location = new System.Drawing.Point(143, 106);
            this.textPassw.Margin = new System.Windows.Forms.Padding(4);
            this.textPassw.Name = "textPassw";
            this.textPassw.PasswordChar = '*';
            this.textPassw.Size = new System.Drawing.Size(199, 22);
            this.textPassw.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 22);
            this.label6.TabIndex = 19;
            this.label6.Text = "Parola";
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(143, 76);
            this.textUser.Margin = new System.Windows.Forms.Padding(4);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(199, 22);
            this.textUser.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 79);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 22);
            this.label5.TabIndex = 19;
            this.label5.Text = "Kullanıcı";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(375, 48);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 17);
            this.label19.TabIndex = 18;
            this.label19.Text = "Log Seviyesi :";
            // 
            // cmdtracelavel
            // 
            this.cmdtracelavel.FormattingEnabled = true;
            this.cmdtracelavel.Location = new System.Drawing.Point(529, 44);
            this.cmdtracelavel.Margin = new System.Windows.Forms.Padding(4);
            this.cmdtracelavel.Name = "cmdtracelavel";
            this.cmdtracelavel.Size = new System.Drawing.Size(159, 24);
            this.cmdtracelavel.TabIndex = 4;
            // 
            // nmTimeout
            // 
            this.nmTimeout.Location = new System.Drawing.Point(529, 81);
            this.nmTimeout.Margin = new System.Windows.Forms.Padding(4);
            this.nmTimeout.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmTimeout.Name = "nmTimeout";
            this.nmTimeout.Size = new System.Drawing.Size(160, 22);
            this.nmTimeout.TabIndex = 5;
            this.nmTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(375, 84);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 22);
            this.label15.TabIndex = 0;
            this.label15.Text = "Bekleme Süresi (sn):";
            // 
            // textDb
            // 
            this.textDb.Location = new System.Drawing.Point(143, 46);
            this.textDb.Margin = new System.Windows.Forms.Padding(4);
            this.textDb.Name = "textDb";
            this.textDb.Size = new System.Drawing.Size(199, 22);
            this.textDb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Veri tabanı ";
            // 
            // textServ
            // 
            this.textServ.Location = new System.Drawing.Point(143, 14);
            this.textServ.Margin = new System.Windows.Forms.Padding(4);
            this.textServ.Name = "textServ";
            this.textServ.Size = new System.Drawing.Size(199, 22);
            this.textServ.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sql Server:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnkyeni);
            this.tabPage2.Controls.Add(this.btnsil);
            this.tabPage2.Controls.Add(this.btnkaydet);
            this.tabPage2.Controls.Add(this.checkKAktif);
            this.tabPage2.Controls.Add(this.textKUrl);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.listKamera);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(748, 408);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kameralar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnkyeni
            // 
            this.btnkyeni.Image = ((System.Drawing.Image)(resources.GetObject("btnkyeni.Image")));
            this.btnkyeni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkyeni.Location = new System.Drawing.Point(439, 362);
            this.btnkyeni.Name = "btnkyeni";
            this.btnkyeni.Size = new System.Drawing.Size(99, 33);
            this.btnkyeni.TabIndex = 3;
            this.btnkyeni.Text = "Yeni";
            this.btnkyeni.UseVisualStyleBackColor = true;
            this.btnkyeni.Click += new System.EventHandler(this.btnkyeni_Click);
            // 
            // btnsil
            // 
            this.btnsil.Image = ((System.Drawing.Image)(resources.GetObject("btnsil.Image")));
            this.btnsil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsil.Location = new System.Drawing.Point(538, 362);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(99, 33);
            this.btnsil.TabIndex = 4;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnkaydet
            // 
            this.btnkaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnkaydet.Image")));
            this.btnkaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkaydet.Location = new System.Drawing.Point(637, 362);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(99, 33);
            this.btnkaydet.TabIndex = 5;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.UseVisualStyleBackColor = true;
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // checkKAktif
            // 
            this.checkKAktif.AutoSize = true;
            this.checkKAktif.Location = new System.Drawing.Point(65, 362);
            this.checkKAktif.Name = "checkKAktif";
            this.checkKAktif.Size = new System.Drawing.Size(57, 21);
            this.checkKAktif.TabIndex = 2;
            this.checkKAktif.Text = "Aktif";
            this.checkKAktif.UseVisualStyleBackColor = true;
            // 
            // textKUrl
            // 
            this.textKUrl.Location = new System.Drawing.Point(65, 323);
            this.textKUrl.Name = "textKUrl";
            this.textKUrl.Size = new System.Drawing.Size(671, 22);
            this.textKUrl.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 323);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 17);
            this.label12.TabIndex = 9;
            this.label12.Text = "Url:";
            // 
            // listKamera
            // 
            this.listKamera.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4});
            this.listKamera.FullRowSelect = true;
            this.listKamera.Location = new System.Drawing.Point(8, 16);
            this.listKamera.MultiSelect = false;
            this.listKamera.Name = "listKamera";
            this.listKamera.Size = new System.Drawing.Size(728, 287);
            this.listKamera.TabIndex = 0;
            this.listKamera.UseCompatibleStateImageBehavior = false;
            this.listKamera.View = System.Windows.Forms.View.Details;
            this.listKamera.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sıra";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Url";
            this.columnHeader3.Width = 450;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Aktif";
            this.columnHeader4.Width = 40;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(756, 523);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTimeout)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textDb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textServ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmTimeout;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmdtracelavel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listKamera;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox textKUrl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkKAktif;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.Button btnkyeni;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPassw;
        private System.Windows.Forms.Label label6;
    }
}