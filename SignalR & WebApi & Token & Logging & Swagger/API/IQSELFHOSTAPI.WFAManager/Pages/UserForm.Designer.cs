namespace IQSELFHOSTAPI.WFAManager.Pages
{
    partial class UserForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKullanıcıGuncelle = new System.Windows.Forms.Button();
            this.btnUserInsert = new System.Windows.Forms.Button();
            this.dataGridUser = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnKullanıcıGuncelle);
            this.panel1.Controls.Add(this.btnUserInsert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 61);
            this.panel1.TabIndex = 2;
            // 
            // btnKullanıcıGuncelle
            // 
            this.btnKullanıcıGuncelle.Location = new System.Drawing.Point(165, 8);
            this.btnKullanıcıGuncelle.Name = "btnKullanıcıGuncelle";
            this.btnKullanıcıGuncelle.Size = new System.Drawing.Size(136, 43);
            this.btnKullanıcıGuncelle.TabIndex = 1;
            this.btnKullanıcıGuncelle.Text = "Kullanıcı Güncelle";
            this.btnKullanıcıGuncelle.UseVisualStyleBackColor = true;
            this.btnKullanıcıGuncelle.Click += new System.EventHandler(this.btnKullanıcıGuncelle_Click);
            // 
            // btnUserInsert
            // 
            this.btnUserInsert.Location = new System.Drawing.Point(9, 8);
            this.btnUserInsert.Name = "btnUserInsert";
            this.btnUserInsert.Size = new System.Drawing.Size(136, 43);
            this.btnUserInsert.TabIndex = 1;
            this.btnUserInsert.Text = "Kullanıcı Ekle";
            this.btnUserInsert.UseVisualStyleBackColor = true;
            this.btnUserInsert.Click += new System.EventHandler(this.btnUserInsert_Click);
            // 
            // dataGridUser
            // 
            this.dataGridUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridUser.Location = new System.Drawing.Point(0, 61);
            this.dataGridUser.Name = "dataGridUser";
            this.dataGridUser.RowTemplate.Height = 24;
            this.dataGridUser.Size = new System.Drawing.Size(976, 498);
            this.dataGridUser.TabIndex = 4;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 559);
            this.Controls.Add(this.dataGridUser);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Yönetim";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUserInsert;
        private System.Windows.Forms.DataGridView dataGridUser;
        private System.Windows.Forms.Button btnKullanıcıGuncelle;
    }
}