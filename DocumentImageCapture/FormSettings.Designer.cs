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
            this.label19 = new System.Windows.Forms.Label();
            this.cmdtracelavel = new System.Windows.Forms.ComboBox();
            this.nmbranchid = new System.Windows.Forms.NumericUpDown();
            this.nmTimeout = new System.Windows.Forms.NumericUpDown();
            this.nmcoid = new System.Windows.Forms.NumericUpDown();
            this.nmoraport = new System.Windows.Forms.NumericUpDown();
            this.nmuserid = new System.Windows.Forms.NumericUpDown();
            this.btnHedefFold = new System.Windows.Forms.Button();
            this.txtHedefKlasor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnkyeni = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.checkKAktif = new System.Windows.Forms.CheckBox();
            this.textKUrl = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textKDb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textKPass = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textKUser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textKHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listKamera = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmbranchid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmoraport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuserid)).BeginInit();
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
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.cmdtracelavel);
            this.tabPage1.Controls.Add(this.nmbranchid);
            this.tabPage1.Controls.Add(this.nmTimeout);
            this.tabPage1.Controls.Add(this.nmcoid);
            this.tabPage1.Controls.Add(this.nmoraport);
            this.tabPage1.Controls.Add(this.nmuserid);
            this.tabPage1.Controls.Add(this.btnHedefFold);
            this.tabPage1.Controls.Add(this.txtHedefKlasor);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtServis);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtHost);
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
            this.cmdtracelavel.TabIndex = 7;
            // 
            // nmbranchid
            // 
            this.nmbranchid.Location = new System.Drawing.Point(143, 143);
            this.nmbranchid.Margin = new System.Windows.Forms.Padding(4);
            this.nmbranchid.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmbranchid.Name = "nmbranchid";
            this.nmbranchid.Size = new System.Drawing.Size(160, 22);
            this.nmbranchid.TabIndex = 4;
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
            this.nmTimeout.TabIndex = 8;
            this.nmTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmcoid
            // 
            this.nmcoid.Location = new System.Drawing.Point(143, 111);
            this.nmcoid.Margin = new System.Windows.Forms.Padding(4);
            this.nmcoid.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmcoid.Name = "nmcoid";
            this.nmcoid.Size = new System.Drawing.Size(160, 22);
            this.nmcoid.TabIndex = 3;
            // 
            // nmoraport
            // 
            this.nmoraport.Location = new System.Drawing.Point(143, 79);
            this.nmoraport.Margin = new System.Windows.Forms.Padding(4);
            this.nmoraport.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmoraport.Name = "nmoraport";
            this.nmoraport.Size = new System.Drawing.Size(160, 22);
            this.nmoraport.TabIndex = 2;
            // 
            // nmuserid
            // 
            this.nmuserid.Location = new System.Drawing.Point(143, 175);
            this.nmuserid.Margin = new System.Windows.Forms.Padding(4);
            this.nmuserid.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmuserid.Name = "nmuserid";
            this.nmuserid.Size = new System.Drawing.Size(160, 22);
            this.nmuserid.TabIndex = 5;
            // 
            // btnHedefFold
            // 
            this.btnHedefFold.Location = new System.Drawing.Point(690, 359);
            this.btnHedefFold.Margin = new System.Windows.Forms.Padding(4);
            this.btnHedefFold.Name = "btnHedefFold";
            this.btnHedefFold.Size = new System.Drawing.Size(40, 25);
            this.btnHedefFold.TabIndex = 10;
            this.btnHedefFold.Text = "...";
            this.btnHedefFold.UseVisualStyleBackColor = true;
            this.btnHedefFold.Click += new System.EventHandler(this.btnHedefFold_Click);
            // 
            // txtHedefKlasor
            // 
            this.txtHedefKlasor.Location = new System.Drawing.Point(144, 361);
            this.txtHedefKlasor.Margin = new System.Windows.Forms.Padding(4);
            this.txtHedefKlasor.Name = "txtHedefKlasor";
            this.txtHedefKlasor.Size = new System.Drawing.Size(545, 22);
            this.txtHedefKlasor.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 364);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hedef Klasör:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 177);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Oluşturan :";
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
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "İş Yeri Id:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Firma Id:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Oracle Port:";
            // 
            // txtServis
            // 
            this.txtServis.Location = new System.Drawing.Point(143, 46);
            this.txtServis.Margin = new System.Windows.Forms.Padding(4);
            this.txtServis.Name = "txtServis";
            this.txtServis.Size = new System.Drawing.Size(199, 22);
            this.txtServis.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Oracle Servis:";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(143, 14);
            this.txtHost.Margin = new System.Windows.Forms.Padding(4);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(199, 22);
            this.txtHost.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oracle Host:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnkyeni);
            this.tabPage2.Controls.Add(this.btnsil);
            this.tabPage2.Controls.Add(this.btnkaydet);
            this.tabPage2.Controls.Add(this.checkKAktif);
            this.tabPage2.Controls.Add(this.textKUrl);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.textKDb);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.textKPass);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.textKUser);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.textKHost);
            this.tabPage2.Controls.Add(this.label3);
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
            this.btnkyeni.Location = new System.Drawing.Point(503, 372);
            this.btnkyeni.Name = "btnkyeni";
            this.btnkyeni.Size = new System.Drawing.Size(75, 23);
            this.btnkyeni.TabIndex = 8;
            this.btnkyeni.Text = "Yeni";
            this.btnkyeni.UseVisualStyleBackColor = true;
            this.btnkyeni.Click += new System.EventHandler(this.btnkyeni_Click);
            // 
            // btnsil
            // 
            this.btnsil.Location = new System.Drawing.Point(582, 372);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(75, 23);
            this.btnsil.TabIndex = 7;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnkaydet
            // 
            this.btnkaydet.Location = new System.Drawing.Point(661, 372);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(75, 23);
            this.btnkaydet.TabIndex = 6;
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
            this.checkKAktif.TabIndex = 11;
            this.checkKAktif.Text = "Aktif";
            this.checkKAktif.UseVisualStyleBackColor = true;
            // 
            // textKUrl
            // 
            this.textKUrl.Location = new System.Drawing.Point(65, 323);
            this.textKUrl.Name = "textKUrl";
            this.textKUrl.Size = new System.Drawing.Size(671, 22);
            this.textKUrl.TabIndex = 5;
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
            // textKDb
            // 
            this.textKDb.Location = new System.Drawing.Point(275, 295);
            this.textKDb.Name = "textKDb";
            this.textKDb.Size = new System.Drawing.Size(118, 22);
            this.textKDb.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(227, 295);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 17);
            this.label11.TabIndex = 7;
            this.label11.Text = "Db:";
            // 
            // textKPass
            // 
            this.textKPass.Location = new System.Drawing.Point(626, 295);
            this.textKPass.Name = "textKPass";
            this.textKPass.PasswordChar = '*';
            this.textKPass.Size = new System.Drawing.Size(110, 22);
            this.textKPass.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(581, 295);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "Pass";
            // 
            // textKUser
            // 
            this.textKUser.Location = new System.Drawing.Point(457, 295);
            this.textKUser.Name = "textKUser";
            this.textKUser.Size = new System.Drawing.Size(118, 22);
            this.textKUser.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(409, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "User:";
            // 
            // textKHost
            // 
            this.textKHost.Location = new System.Drawing.Point(65, 295);
            this.textKHost.Name = "textKHost";
            this.textKHost.Size = new System.Drawing.Size(151, 22);
            this.textKHost.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Host:";
            // 
            // listKamera
            // 
            this.listKamera.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listKamera.FullRowSelect = true;
            this.listKamera.Location = new System.Drawing.Point(8, 47);
            this.listKamera.MultiSelect = false;
            this.listKamera.Name = "listKamera";
            this.listKamera.Size = new System.Drawing.Size(728, 237);
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
            // columnHeader2
            // 
            this.columnHeader2.Text = "Host";
            this.columnHeader2.Width = 140;
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
            ((System.ComponentModel.ISupportInitialize)(this.nmbranchid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmoraport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmuserid)).EndInit();
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
        private System.Windows.Forms.TextBox txtServis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHedefKlasor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHedefFold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nmuserid;
        private System.Windows.Forms.NumericUpDown nmbranchid;
        private System.Windows.Forms.NumericUpDown nmcoid;
        private System.Windows.Forms.NumericUpDown nmoraport;
        private System.Windows.Forms.NumericUpDown nmTimeout;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmdtracelavel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listKamera;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox textKHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textKDb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textKPass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textKUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textKUrl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkKAktif;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.Button btnkyeni;
    }
}