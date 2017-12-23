namespace x
{
    partial class Form_add_sourcing
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
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroButton_save_sourcing = new MetroFramework.Controls.MetroButton();
            this.metroTextBox_add_sourcing_entreprise = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox_add_sourcing_poste = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dateTimePicker_sourcing_date = new System.Windows.Forms.DateTimePicker();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.dateTimePicker_sourcing_date);
            this.metroPanel2.Controls.Add(this.metroLabel4);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(504, 57);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(475, 140);
            this.metroPanel2.TabIndex = 3;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            this.metroPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.metroPanel2_Paint);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(29, 15);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(36, 19);
            this.metroLabel4.TabIndex = 33;
            this.metroLabel4.Text = "Date";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.metroButton_save_sourcing);
            this.metroPanel1.Controls.Add(this.metroTextBox_add_sourcing_entreprise);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.metroTextBox_add_sourcing_poste);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(13, 57);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(475, 140);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroButton_save_sourcing
            // 
            this.metroButton_save_sourcing.Location = new System.Drawing.Point(12, 103);
            this.metroButton_save_sourcing.Name = "metroButton_save_sourcing";
            this.metroButton_save_sourcing.Size = new System.Drawing.Size(391, 23);
            this.metroButton_save_sourcing.TabIndex = 33;
            this.metroButton_save_sourcing.Text = "Enregistrer et fermer";
            this.metroButton_save_sourcing.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton_save_sourcing.Click += new System.EventHandler(this.metroButton_save_sourcing_Click);
            // 
            // metroTextBox_add_sourcing_entreprise
            // 
            this.metroTextBox_add_sourcing_entreprise.Location = new System.Drawing.Point(175, 11);
            this.metroTextBox_add_sourcing_entreprise.Name = "metroTextBox_add_sourcing_entreprise";
            this.metroTextBox_add_sourcing_entreprise.ReadOnly = true;
            this.metroTextBox_add_sourcing_entreprise.Size = new System.Drawing.Size(228, 23);
            this.metroTextBox_add_sourcing_entreprise.TabIndex = 32;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(12, 51);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(40, 19);
            this.metroLabel3.TabIndex = 31;
            this.metroLabel3.Text = "Poste";
            // 
            // metroTextBox_add_sourcing_poste
            // 
            this.metroTextBox_add_sourcing_poste.Location = new System.Drawing.Point(175, 43);
            this.metroTextBox_add_sourcing_poste.Name = "metroTextBox_add_sourcing_poste";
            this.metroTextBox_add_sourcing_poste.ReadOnly = true;
            this.metroTextBox_add_sourcing_poste.Size = new System.Drawing.Size(228, 23);
            this.metroTextBox_add_sourcing_poste.TabIndex = 30;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(12, 19);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(67, 19);
            this.metroLabel2.TabIndex = 29;
            this.metroLabel2.Text = "Entreprise";
            // 
            // dateTimePicker_sourcing_date
            // 
            this.dateTimePicker_sourcing_date.Location = new System.Drawing.Point(184, 14);
            this.dateTimePicker_sourcing_date.Name = "dateTimePicker_sourcing_date";
            this.dateTimePicker_sourcing_date.Size = new System.Drawing.Size(279, 20);
            this.dateTimePicker_sourcing_date.TabIndex = 34;
            // 
            // Form_add_sourcing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 220);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "Form_add_sourcing";
            this.Text = "Sourcing";
            this.Load += new System.EventHandler(this.Form_add_sourcing_Load);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton metroButton_save_sourcing;
        private MetroFramework.Controls.MetroTextBox metroTextBox_add_sourcing_entreprise;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox metroTextBox_add_sourcing_poste;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_sourcing_date;
    }
}