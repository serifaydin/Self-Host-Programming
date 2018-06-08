namespace IQSELFHOSTAPI.WFAManager
{
    partial class MainForm
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.btnRolModul = new System.Windows.Forms.Button();
            this.btnKullaniciYonetim = new System.Windows.Forms.Button();
            this.btnFirmaYonetim = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Controls.Add(this.btnRolModul);
            this.menuPanel.Controls.Add(this.btnKullaniciYonetim);
            this.menuPanel.Controls.Add(this.btnFirmaYonetim);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(224, 744);
            this.menuPanel.TabIndex = 3;
            // 
            // btnRolModul
            // 
            this.btnRolModul.BackColor = System.Drawing.SystemColors.Control;
            this.btnRolModul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRolModul.ForeColor = System.Drawing.Color.Maroon;
            this.btnRolModul.Location = new System.Drawing.Point(12, 241);
            this.btnRolModul.Name = "btnRolModul";
            this.btnRolModul.Size = new System.Drawing.Size(197, 84);
            this.btnRolModul.TabIndex = 4;
            this.btnRolModul.Text = "ROL MODUL YETKİ";
            this.btnRolModul.UseVisualStyleBackColor = false;
            this.btnRolModul.Click += new System.EventHandler(this.btnRolModul_Click);
            // 
            // btnKullaniciYonetim
            // 
            this.btnKullaniciYonetim.BackColor = System.Drawing.SystemColors.Control;
            this.btnKullaniciYonetim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullaniciYonetim.ForeColor = System.Drawing.Color.Maroon;
            this.btnKullaniciYonetim.Location = new System.Drawing.Point(12, 122);
            this.btnKullaniciYonetim.Name = "btnKullaniciYonetim";
            this.btnKullaniciYonetim.Size = new System.Drawing.Size(197, 84);
            this.btnKullaniciYonetim.TabIndex = 4;
            this.btnKullaniciYonetim.Text = "KULLANICI YÖNETİM";
            this.btnKullaniciYonetim.UseVisualStyleBackColor = false;
            this.btnKullaniciYonetim.Click += new System.EventHandler(this.btnKullaniciYonetim_Click);
            // 
            // btnFirmaYonetim
            // 
            this.btnFirmaYonetim.BackColor = System.Drawing.SystemColors.Control;
            this.btnFirmaYonetim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirmaYonetim.ForeColor = System.Drawing.Color.Maroon;
            this.btnFirmaYonetim.Location = new System.Drawing.Point(12, 12);
            this.btnFirmaYonetim.Name = "btnFirmaYonetim";
            this.btnFirmaYonetim.Size = new System.Drawing.Size(197, 84);
            this.btnFirmaYonetim.TabIndex = 4;
            this.btnFirmaYonetim.Text = "FİRMA YÖNETİM";
            this.btnFirmaYonetim.UseVisualStyleBackColor = false;
            this.btnFirmaYonetim.Click += new System.EventHandler(this.btnFirmaYonetim_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1320, 744);
            this.Controls.Add(this.menuPanel);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IQ BackOffice Yönetim";
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button btnFirmaYonetim;
        private System.Windows.Forms.Button btnKullaniciYonetim;
        private System.Windows.Forms.Button btnRolModul;
    }
}