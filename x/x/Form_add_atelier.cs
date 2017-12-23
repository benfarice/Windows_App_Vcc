using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace x
{
    public partial class Form_add_atelier : MetroFramework.Forms.MetroForm
    {
        public Form_add_atelier(string nom,string prenom)
        {
            InitializeComponent();
            this.nom = nom;
            this.prenom = prenom;
        }
        string nom;
        string prenom;
        private void Form_add_atelier_Load(object sender, EventArgs e)
        {
            metroTextBox_add_atelier_nom.Text = nom;
            metroTextBox_add_atelier_prenom.Text = prenom;
        }
        public void atelier_proc()
        {
            Class_ateliers atelier = new Class_ateliers();
            atelier.date_debut = dateTimePicker_add_atelier_debut.Value;
            atelier.date_Fin = dateTimePicker_add_atelier_fin.Value;
            atelier.observation = metroTextBox_add_atelier_observation.Text;
            atelier.theme = metroTextBox_add_atelier_theme.Text;
            Program.new_candidat_to_add.son_ateliers.Add(atelier);
        }
        public void vider_form()
        {
            dateTimePicker_add_atelier_debut.Value = new DateTime(2011, 11, 11);
            dateTimePicker_add_atelier_fin.Value = DateTime.Now;
            metroTextBox_add_atelier_observation.Text = "";
            metroTextBox_add_atelier_theme.Text = "";
        }

        private void metroButton_add_atelier_save_another_Click(object sender, EventArgs e)
        {
            atelier_proc();
            vider_form();
        }

        private void metroButton_add_atelier_save_close_Click(object sender, EventArgs e)
        {
            atelier_proc();
            vider_form();
            Close();
        }
    }
}
