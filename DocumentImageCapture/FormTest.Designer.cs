namespace DocumentImageCapture
{
    partial class FormTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnekle = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.textid = new System.Windows.Forms.ToolStripTextBox();
            this.btnresimac = new System.Windows.Forms.ToolStripButton();
            this.btnfarklikaydet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cmbdatasource = new System.Windows.Forms.ToolStripComboBox();
            this.btnconnekle = new System.Windows.Forms.ToolStripButton();
            this.btnconnsil = new System.Windows.Forms.ToolStripButton();
            this.btnconnduzelt = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnekle,
            this.toolStripLabel1,
            this.textid,
            this.btnresimac,
            this.btnfarklikaydet,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.cmbdatasource,
            this.btnconnekle,
            this.btnconnsil,
            this.btnconnduzelt});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(760, 28);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnekle
            // 
            this.btnekle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnekle.Image = ((System.Drawing.Image)(resources.GetObject("btnekle.Image")));
            this.btnekle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(24, 25);
            this.btnekle.Text = "Resim Ekle";
            this.btnekle.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(66, 25);
            this.toolStripLabel1.Text = "Resim Id";
            // 
            // textid
            // 
            this.textid.Name = "textid";
            this.textid.Size = new System.Drawing.Size(100, 28);
            this.textid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox1_KeyPress);
            // 
            // btnresimac
            // 
            this.btnresimac.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnresimac.Image = ((System.Drawing.Image)(resources.GetObject("btnresimac.Image")));
            this.btnresimac.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnresimac.Name = "btnresimac";
            this.btnresimac.Size = new System.Drawing.Size(24, 25);
            this.btnresimac.Text = "Resmi Gör";
            this.btnresimac.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnfarklikaydet
            // 
            this.btnfarklikaydet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnfarklikaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnfarklikaydet.Image")));
            this.btnfarklikaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnfarklikaydet.Name = "btnfarklikaydet";
            this.btnfarklikaydet.Size = new System.Drawing.Size(24, 25);
            this.btnfarklikaydet.Text = "Farklı Kaydet";
            this.btnfarklikaydet.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(88, 25);
            this.toolStripLabel2.Text = "Data source";
            // 
            // cmbdatasource
            // 
            this.cmbdatasource.Name = "cmbdatasource";
            this.cmbdatasource.Size = new System.Drawing.Size(150, 28);
            this.cmbdatasource.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // btnconnekle
            // 
            this.btnconnekle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnconnekle.Image = ((System.Drawing.Image)(resources.GetObject("btnconnekle.Image")));
            this.btnconnekle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnconnekle.Name = "btnconnekle";
            this.btnconnekle.Size = new System.Drawing.Size(24, 25);
            this.btnconnekle.Text = "Bağlantı Ekle";
            this.btnconnekle.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // btnconnsil
            // 
            this.btnconnsil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnconnsil.Image = ((System.Drawing.Image)(resources.GetObject("btnconnsil.Image")));
            this.btnconnsil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnconnsil.Name = "btnconnsil";
            this.btnconnsil.Size = new System.Drawing.Size(24, 25);
            this.btnconnsil.Text = "Bağlantıyı Sil";
            this.btnconnsil.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // btnconnduzelt
            // 
            this.btnconnduzelt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnconnduzelt.Image = ((System.Drawing.Image)(resources.GetObject("btnconnduzelt.Image")));
            this.btnconnduzelt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnconnduzelt.Name = "btnconnduzelt";
            this.btnconnduzelt.Size = new System.Drawing.Size(24, 25);
            this.btnconnduzelt.Text = "Bağlantıyı Düzelt";
            this.btnconnduzelt.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(760, 25);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label
            // 
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(18, 20);
            this.label.Text = "...";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 554);
            this.panel2.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 554);
            this.tabControl1.TabIndex = 0;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 607);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTest";
            this.Text = "                  ";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnekle;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox textid;
        private System.Windows.Forms.ToolStripButton btnresimac;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripStatusLabel label;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cmbdatasource;
        private System.Windows.Forms.ToolStripButton btnconnekle;
        private System.Windows.Forms.ToolStripButton btnconnsil;
        private System.Windows.Forms.ToolStripButton btnconnduzelt;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripButton btnfarklikaydet;
    }
}