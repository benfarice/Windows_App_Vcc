namespace x
{
    partial class Form_resultat_requet
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
            this.dataGridView_requete = new System.Windows.Forms.DataGridView();
            this.metroButton_send_mail = new MetroFramework.Controls.MetroButton();
            this.metroButton_extract_excel = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_requete)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_requete
            // 
            this.dataGridView_requete.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_requete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_requete.Location = new System.Drawing.Point(23, 110);
            this.dataGridView_requete.Name = "dataGridView_requete";
            this.dataGridView_requete.Size = new System.Drawing.Size(944, 150);
            this.dataGridView_requete.TabIndex = 0;
            // 
            // metroButton_send_mail
            // 
            this.metroButton_send_mail.Location = new System.Drawing.Point(23, 72);
            this.metroButton_send_mail.Name = "metroButton_send_mail";
            this.metroButton_send_mail.Size = new System.Drawing.Size(310, 25);
            this.metroButton_send_mail.TabIndex = 1;
            this.metroButton_send_mail.Text = "Envoyer Un Mail à Tous Les Candidats";
            this.metroButton_send_mail.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton_send_mail.Click += new System.EventHandler(this.metroButton_send_mail_Click);
            // 
            // metroButton_extract_excel
            // 
            this.metroButton_extract_excel.Location = new System.Drawing.Point(657, 72);
            this.metroButton_extract_excel.Name = "metroButton_extract_excel";
            this.metroButton_extract_excel.Size = new System.Drawing.Size(310, 25);
            this.metroButton_extract_excel.TabIndex = 2;
            this.metroButton_extract_excel.Text = "Produire Un Fichier Excel ";
            this.metroButton_extract_excel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton_extract_excel.Click += new System.EventHandler(this.metroButton_extract_excel_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(339, 72);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(310, 25);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Remplir Les Données des sourcing";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Form_resultat_requet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 280);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton_extract_excel);
            this.Controls.Add(this.metroButton_send_mail);
            this.Controls.Add(this.dataGridView_requete);
            this.Name = "Form_resultat_requet";
            this.Text = "Le résultat du requête";
            this.Load += new System.EventHandler(this.Form_resultat_requet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_requete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_requete;
        private MetroFramework.Controls.MetroButton metroButton_send_mail;
        private MetroFramework.Controls.MetroButton metroButton_extract_excel;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}