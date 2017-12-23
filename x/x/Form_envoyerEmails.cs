using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Collections;
namespace x
{
    public partial class Form_envoyerEmails : MetroFramework.Forms.MetroForm
    {
        public Form_envoyerEmails()
        {
            InitializeComponent();
        }
        ArrayList Emails = new ArrayList();
        private void Form_envoyerEmails_Load(object sender, EventArgs e)
        {
            Emails.Add("nabidi @careercenter.ma");
            Emails.Add("mmaaroufi @careercenter.ma");
            Emails.Add("ihoumani@careercenter.ma");
            Emails.Add("youssef.imzoughene@gmail.com");
        }

        private void metroButton_envoyer_Click(object sender, EventArgs e)
        {
            ArrayList t = new ArrayList();
            t = Class_Database_app.get_ALL_emails();
            //foreach (string v in t)
            //    MessageBox.Show(v);
            try
            {
                foreach (String x in t)
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(x);
                    mail.Subject = metroTextBox_objet.Text;
                    mail.From = new MailAddress("careercenterofppt@gmail.com");
                    mail.Body = richTextBox_message.Text;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("careercenterofppt@gmail.com", "Global16");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                }
                MessageBox.Show("Votre message à ete envoyer", "Envoyer", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.ToString());
            }

        }
    }
}
