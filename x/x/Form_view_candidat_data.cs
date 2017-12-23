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
    public partial class Form_view_candidat_data : MetroFramework.Forms.MetroForm
    {
        string query;
        string query_ids;
        public Form_view_candidat_data(String search_query,string search_ids)
        {
            InitializeComponent();
            this.query = search_query;
            this.query_ids = search_ids;
        }
       
        int position = 1;
        ArrayList select_ids = new ArrayList();
        ArrayList list_to_contact = new ArrayList();
        Class_Candidat myCandidat = new Class_Candidat();
        private void Form_view_candidat_data_Load(object sender, EventArgs e)
        {
            
            select_ids = Class_Database_app.get_number_count_query(query_ids);
            list_to_contact = Class_Database_app.get_number_count_query(query_ids);
            //for (int i = 0; i < select_ids.Count; i++)
            //    MessageBox.Show("s"+i+" = "+select_ids[i]);
            if (select_ids.Count >= 1)
            {
                myCandidat = Class_Database_app.get_candidat_position_query((int)select_ids[0], query);
                metroLabel_modifier_search_label_count.Text = "1/"+select_ids.Count;
                afficher_candidat();
            }
            else
            {
               MessageBox.Show("Aucune candidat exist avec ces conditions");
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form_resultat_requet f = new Form_resultat_requet(list_to_contact);
            f.Show();
        }
        public void afficher_candidat() {
            try
            {
                metroTextBox_add_candidat_CIN.Text = myCandidat.cin;
                metroTextBox_add_candidat_email.Text = myCandidat.email;
                metroTextBox_add_candidat_nom.Text = myCandidat.Nom;
                metroTextBox_add_candidat_prenom.Text = myCandidat.Prenom;
                metroTextBox_add_candidat_quartier.Text = myCandidat.quartier;
                metroTextBox_age.Text = myCandidat.date_naissace.ToString();
                metroTextBox_add_candidat_ville.Text = myCandidat.ville;
                if (myCandidat.vcc == true)
                    metroRadioButton_add_candidat_vcc_oui.Checked = true;
                else
                    metroRadioButton_add_candidat_vcc_non.Checked = true;
                if (myCandidat.genre == true)
                    metroRadioButton_add_candidat_Monsieur.Checked = true;
                else
                    metroRadioButton_add_candidat_Madame.Checked = true;
                axAcroPDF_show_cv_search.LoadFile(@"imzoughene_youssef.pdf");
            }
            catch (Exception r) {
                MessageBox.Show(r.ToString());
            }
        }

        private void metrobuutton_modifier_search_next_Click(object sender, EventArgs e)
        {
            position++;
            if (position > select_ids.Count)
            {
                metrobuutton_modifier_search_next.Enabled = false;
                position = 1;
            }
           
            myCandidat = new Class_Candidat();
            myCandidat = Class_Database_app.get_candidat_position_query((int)select_ids[position - 1], query);
            metroLabel_modifier_search_label_count.Text = position.ToString() + "/" + select_ids.Count;
            afficher_candidat();
            
            gestion_buttons();
           
        }

        private void metroButton_modifier_search_precedant_Click(object sender, EventArgs e)
        {
            position--;
            if (position < 1)
            {
                position = select_ids.Count;
            }
           
            myCandidat = new Class_Candidat();
            myCandidat = Class_Database_app.get_candidat_position_query((int)select_ids[position-1], query);
            metroLabel_modifier_search_label_count.Text = position.ToString() + "/" + select_ids.Count;
            afficher_candidat();
            
            gestion_buttons();
        }

        private void metroButton_modifier_search_last_Click(object sender, EventArgs e)
        {
            myCandidat = new Class_Candidat();
            position = select_ids.Count ;
            myCandidat = Class_Database_app.get_candidat_position_query((int)select_ids[position-1], query);
            metroLabel_modifier_search_label_count.Text = position.ToString() + "/" + select_ids.Count;
            afficher_candidat();
            gestion_buttons();
        }

        private void metroButton_modifier_search_first_Click(object sender, EventArgs e)
        {
            myCandidat = new Class_Candidat();
            position = 1;
            myCandidat = Class_Database_app.get_candidat_position_query((int)select_ids[0], query);
            metroLabel_modifier_search_label_count.Text = position.ToString() + "/" + select_ids.Count;
            afficher_candidat();
            gestion_buttons();
        }
        public void gestion_buttons() {
            if (position < 1) {
                metroButton_modifier_search_precedant.Enabled = false;
                metrobuutton_modifier_search_next.Enabled = true;
            }
            else if (position > select_ids.Count)
            {
                metroButton_modifier_search_precedant.Enabled = true;
                metrobuutton_modifier_search_next.Enabled = false;
            }
            else {
                metroButton_modifier_search_precedant.Enabled = true;
                metrobuutton_modifier_search_next.Enabled = true;
            }
            conntacter_moi();
        
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            conntacter_moi();
        }
        public void conntacter_moi() {
            if (metroRadioButton_contacter_oui.Checked)
            {
                if (!list_to_contact.Contains(position))
                    list_to_contact.Add(position);
            }
            else
            {
                if (list_to_contact.Contains(position))
                list_to_contact.Remove(position);
            }
            if (metroRadioButton_contcter_non.Checked){
                if (list_to_contact.Contains(position))
                list_to_contact.Remove(position);
            }
            else
            {
                if (!list_to_contact.Contains(position))
                list_to_contact.Add(position);
            }
        
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            conntacter_moi();
            
        }

        private void metroButton_view_infos_details_Click(object sender, EventArgs e)
        {
            Form_view_candidat_details f = new Form_view_candidat_details((int)select_ids[position - 1]);
            f.Show();
        }
    }
}
