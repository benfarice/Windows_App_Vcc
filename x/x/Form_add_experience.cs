using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace x
{
    public partial class Form_add_experience : MetroFramework.Forms.MetroForm
    {
        public Form_add_experience(string nom,string prenom)
        {
            InitializeComponent();
            this.nom_ = nom;
            this.prenom_ = prenom;
        }
        string nom_;
        string prenom_;
        
        private void Form_add_experience_Load(object sender, EventArgs e)
        {
            metroComboBox_type_experience.SelectedIndex = 2;
            metroTextBox_add_exp_nom.Text = nom_;
            metroTextBox_add_exp_prenom.Text = prenom_;
        }

        private void metroPanel_add_exp_infos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void experience_proc()
        {
            Class_experience ce = new Class_experience();
            ce.date_debut = dateTimePicker_exp_debut.Value;
            ce.date_fin = dateTimePicker_exp_fin.Value;
            ce.enCours = metroCheckBox_enCours_exp_add.Checked;
            ce.poste = metroTextBox_Poste.Text;
            ce.Service = metroTextBox_service.Text;
            ce.entreprise = metroTextBox_entreprise.Text;
            ce.secteur_activite = metroTextBox_secteur_activite.Text;
            ce.ville = metroTextBox_ville.Text;
            ce.type = metroComboBox_type_experience.SelectedItem.ToString();
            Program.new_candidat_to_add.ses_experiences.Add(ce);
        }
        public void vider_proc()
        {
            dateTimePicker_exp_debut.Value = new DateTime(2011, 11, 01);
            dateTimePicker_exp_fin.Value= DateTime.Now;
            metroCheckBox_enCours_exp_add.Checked=false;
            metroTextBox_Poste.Text ="";
            metroTextBox_service.Text ="";
            metroTextBox_entreprise.Text ="";
            metroTextBox_secteur_activite.Text ="";
            metroTextBox_ville.Text ="";
            metroComboBox_type_experience.SelectedIndex=0;
         
        }

        private void metroTextBox_entreprise_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox_entreprise_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void metroTextBox_secteur_activite_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox_secteur_activite_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void metroTextBox_ville_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void metroTextBox_service_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void metroTextBox_Poste_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void metroButton_save_add_another_job_Click(object sender, EventArgs e)
        {
            experience_proc();
           
            vider_proc();
        }

        private void metroButton_save_close_Click(object sender, EventArgs e)
        {
            experience_proc();
            vider_proc();
            Close();
        }
    }
}
