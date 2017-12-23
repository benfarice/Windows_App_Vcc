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
    public partial class Form_view_candidat_details : MetroFramework.Forms.MetroForm
    {
        int id_candidat = 1;
        ArrayList diploma_ids = new ArrayList();
        ArrayList bac_ids = new ArrayList();
        ArrayList niveu_bac_ids = new ArrayList();
        ArrayList telephone_ids = new ArrayList();
        ArrayList emploi_ids = new ArrayList();
        ArrayList experience_ids = new ArrayList();
        ArrayList ateliers_ids = new ArrayList();
        ArrayList langues_ids = new ArrayList();
        public Form_view_candidat_details(int id)
        {
            InitializeComponent();
            this.id_candidat = id;
        }
        Class_Candidat my_candidat = new Class_Candidat();
        private void Form_view_candidat_details_Load(object sender, EventArgs e)
        {
            my_candidat = Class_Database_app.get_candidate_by_id(id_candidat);
            afficher();
            diploma_ids = Class_Database_app.get_diploma_ids_by_id_candidat(id_candidat);
            bac_ids = Class_Database_app.get_bac_ids_by_id_candidat(id_candidat);
            niveu_bac_ids = Class_Database_app.get_niveau_bac_ids_by_id_candidat(id_candidat);
            telephone_ids = Class_Database_app.get_telephone_ids_by_id_candidat(id_candidat);
            emploi_ids = Class_Database_app.get_emploi_metier_ids_by_id_candidat(id_candidat);
            experience_ids = Class_Database_app.get_experience_ids_by_id_candidat(id_candidat);
            ateliers_ids = Class_Database_app.get_ateliers_ids_by_id_candidat(id_candidat);
            langues_ids = Class_Database_app.get_langues_by_id_candidat(id_candidat);
            afficher_diplomas();
            afficher_bac();
            afficher_tel();
            afficher_emploi_metier();
            afficher_experience();
            afficher_atelier();
            afficher_langues();
        }
        public void afficher() {
            metroLabel_cin.Text = my_candidat.cin;
            if (my_candidat.genre)
                metroRadioButton_monsieur.Checked = true;
            else
                metroRadioButton_madame.Checked = true;
            metroLabel_nom.Text = my_candidat.Nom;
            metroLabel_prenom.Text = my_candidat.Prenom;
            dateTimePicker_date_naissance.Value = my_candidat.date_naissace;
            metroLabel_ville.Text = my_candidat.ville;
            metroLabel_quartier.Text = my_candidat.quartier;
            metroLabel_email.Text = my_candidat.email;
            if (my_candidat.vcc)
                metroRadioButton_vcc_oui.Checked = true;
            else
                metroRadioButton_vcc_non.Checked = false;
        }
        public void afficher_diplomas() {
            foreach (int id_diploma in diploma_ids) {
                Class_diplome diploma = Class_Database_app.get_diploma_by_id(id_diploma);
                richTextBox_formation.Text += diploma.specialite + "\t"+diploma.etablissement +"\n";
                richTextBox_formation.Text += diploma.niveau + "\t" + diploma.date_obtention ;
                richTextBox_formation.Text += "\n -------------------------- \n";
            }
        
        }
        public void afficher_bac() {
            if (bac_ids.Count > 0) {
                foreach (int i in bac_ids) {
                    Class_bac bac = Class_Database_app.get_bac_by_id(i);
                    richTextBox_baccalaureat.Text += bac.Type+ "\t"+bac.annee_obtention;
                    richTextBox_baccalaureat.Text += "\n ------------------ \n";
                }
            }
            else if (niveu_bac_ids.Count > 0) {
                foreach (int i in niveu_bac_ids) {
                    Class_niveau_bac niveau = Class_Database_app.get_niveau_bac_by_id(i);
                    richTextBox_baccalaureat.Text += "Niveau Bac :"+niveau.type + "\t" + niveau.annee;
                    richTextBox_baccalaureat.Text += "\n --------------------- \n";
                }
            }
        }
        public void afficher_tel() {
            foreach (int i in telephone_ids) {
                Class_telephone tel = Class_Database_app.get_telephone_by_id(i);
                richTextBox_telephone.Text += "Tel : 0" + tel.numero.ToString()+"\n" ;
            }
        }
        public void afficher_emploi_metier() {
            foreach (int i in emploi_ids) {
                Class_emploi_metier metier = Class_Database_app.get_emploi_metier_by_id(i);
                richTextBox_emploi_metier.Text += metier.emploi_metier +"\n";
            }
        }
        public void afficher_experience() {
            foreach (int i in experience_ids) {
                Class_experience exp = Class_Database_app.get_experience_by_id(i);
                string experience = exp.entreprise + "\t" + exp.poste + "\t" + exp.secteur_activite +"\n";
                experience += exp.ville+"\t"+exp.type+"\t"+exp.Service+"\n";
                if (exp.enCours)
                    experience += exp.date_debut.ToString() + " \t enCours \n";
                else
                    experience += exp.date_debut.ToString() + "\t" + exp.date_fin.ToString() + "\n";
                richTextBox_experience.Text += experience;
            }
        }
        public void afficher_langues() {
            foreach (int i in langues_ids) {
                Class_langage langue = Class_Database_app.get_langue_by_id(i);
                richTextBox_langues.Text += langue.langue + "\t" + langue.niveau + "\n";
            }
        }
        public void afficher_atelier() {
            foreach (int i in ateliers_ids) { 
            Class_ateliers atelier = Class_Database_app.get_atelier_by_id(i);
            richTextBox_ateliers.Text += atelier.theme + "\t" + atelier.observation + "\n";
            richTextBox_ateliers.Text += atelier.date_debut.ToString() + "\t" + atelier.date_Fin.ToString() + "\n";
            }
        }
        private void metroLabel6_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel_email_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel_ville_Click(object sender, EventArgs e)
        {

        }
    }
}
