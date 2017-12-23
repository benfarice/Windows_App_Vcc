namespace x
{
    partial class Form_envoyerEmails
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
            this.metroTextBox_objet = new MetroFramework.Controls.MetroTextBox();
            this.richTextBox_message = new System.Windows.Forms.RichTextBox();
            this.metroButton_envoyer = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroTextBox_objet
            // 
            this.metroTextBox_objet.Location = new System.Drawing.Point(23, 73);
            this.metroTextBox_objet.Name = "metroTextBox_objet";
            this.metroTextBox_objet.PromptText = "Objet";
            this.metroTextBox_objet.Size = new System.Drawing.Size(394, 23);
            this.metroTextBox_objet.TabIndex = 0;
            this.metroTextBox_objet.Text = "Objet";
            // 
            // richTextBox_message
            // 
            this.richTextBox_message.Location = new System.Drawing.Point(23, 121);
            this.richTextBox_message.Name = "richTextBox_message";
            this.richTextBox_message.Size = new System.Drawing.Size(905, 110);
            this.richTextBox_message.TabIndex = 1;
            this.richTextBox_message.Text = "Message";
            // 
            // metroButton_envoyer
            // 
            this.metroButton_envoyer.Location = new System.Drawing.Point(688, 73);
            this.metroButton_envoyer.Name = "metroButton_envoyer";
            this.metroButton_envoyer.Size = new System.Drawing.Size(240, 23);
            this.metroButton_envoyer.TabIndex = 2;
            this.metroButton_envoyer.Text = "Envoyer";
            this.metroButton_envoyer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton_envoyer.Click += new System.EventHandler(this.metroButton_envoyer_Click);
            // 
            // Form_envoyerEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 280);
            this.Controls.Add(this.metroButton_envoyer);
            this.Controls.Add(this.richTextBox_message);
            this.Controls.Add(this.metroTextBox_objet);
            this.Name = "Form_envoyerEmails";
            this.Text = "Envoyer Email vers Tous Les Candidats";
            this.Load += new System.EventHandler(this.Form_envoyerEmails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox metroTextBox_objet;
        private System.Windows.Forms.RichTextBox richTextBox_message;
        private MetroFramework.Controls.MetroButton metroButton_envoyer;
    }
}