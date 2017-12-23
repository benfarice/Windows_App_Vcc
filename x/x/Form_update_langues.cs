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
    public partial class Form_update_langues : MetroFramework.Forms.MetroForm
    {
        public Form_update_langues(int id_candidat)
        {
            InitializeComponent();
            this.myid_candidat = id_candidat;
        }
        int myid_candidat = 1;
        int position = 0;
        ArrayList my_arry_ids = new ArrayList();
        private void Form_update_langues_Load(object sender, EventArgs e)
        {
            Class_Candidat candidat = Class_Database_app.get_candidate_by_id(myid_candidat);
            metroTextBox_update_langage_nom.Text = candidat.Nom;
            metroTextBox_update_langage_prenom.Text = candidat.Prenom;
            my_arry_ids = Class_Database_app.get_langues_by_id_candidat(myid_candidat);
            if (my_arry_ids.Count > 0)
            {
                Class_langage langue = Class_Database_app.get_langue_by_id((int)my_arry_ids[position]);
                afficher(langue);
            }
            else {
                MessageBox.Show("aucune langue à afficher");
            }
        }
        public void afficher(Class_langage langue) {
            metroTextBox_update_langage_number1.Text = langue.langue;
            metroComboBox_niveau_langage_1.SelectedItem = langue.niveau;
        }

        private void metrobuutton_modifier_search_next_Click(object sender, EventArgs e)
        {
            position++;
            if (position > my_arry_ids.Count - 1)
                position = 0;
            Class_langage langue = Class_Database_app.get_langue_by_id((int)my_arry_ids[position]);
            afficher(langue);
        }

        private void metroButton_modifier_search_last_Click(object sender, EventArgs e)
        {
            position = my_arry_ids.Count - 1;
            Class_langage langue = Class_Database_app.get_langue_by_id((int)my_arry_ids[position]);
            afficher(langue);
        }

        private void metroButton_modifier_search_precedant_Click(object sender, EventArgs e)
        {
            position--;
            Class_langage langue = Class_Database_app.get_langue_by_id((int)my_arry_ids[position]);
            afficher(langue);
        }

        private void metroButton_modifier_search_first_Click(object sender, EventArgs e)
        {
            position = 0;
            Class_langage langue = Class_Database_app.get_langue_by_id((int)my_arry_ids[position]);
            afficher(langue);
        }

        private void metroButton_add_langage_save_close_Click(object sender, EventArgs e)
        {
            if (metroButton_add_langage_save_close.Text == "Modifier") {
                metroButton_add_new.Enabled = false;
               DialogResult c = MessageBox.Show("Do you wanna to save", "save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
               if (c == DialogResult.OK)
               {
                   string query = "update langues set langue = '"+metroTextBox_update_langage_number1.Text+"' ,Niveau='"+metroComboBox_niveau_langage_1.SelectedItem.ToString()+"' where ID_langue = "+(int)my_arry_ids[position];
                   Boolean is_updated = Class_Database_app.update_diplome_infos(query);
                   if (is_updated)
                       MessageBox.Show("it is updated");
               }
                position = 0;
                Class_langage langue = Class_Database_app.get_langue_by_id((int)my_arry_ids[position]);
                afficher(langue);
                metroButton_add_langage_save_close.Text = "save";
                enable_false();
            }
            else if (metroButton_add_langage_save_close.Text == "save") {
                enable_true();
                metroButton_add_langage_save_close.Text = "Modifier";
                metroButton_add_new.Enabled = true;
            }
        }
        public void enable_true() {
            metroTextBox_update_langage_number1.ReadOnly = false;
            metroComboBox_niveau_langage_1.Enabled = true;
            metrobuutton_modifier_search_next.Enabled = false;
            metroButton_modifier_search_precedant.Enabled = false;
            metroButton_modifier_search_last.Enabled = false;
            metroButton_modifier_search_first.Enabled = false;
            metroLabel_modifier_search_label_count.Text = (position+1) + "/" + my_arry_ids.Count;
        }
        public void enable_false()
        {
            metroTextBox_update_langage_number1.ReadOnly = true;
            metroComboBox_niveau_langage_1.Enabled = false;
            metrobuutton_modifier_search_next.Enabled = true;
            metroButton_modifier_search_precedant.Enabled = true;
            metroButton_modifier_search_last.Enabled = true;
            metroButton_modifier_search_first.Enabled = true;
            metroLabel_modifier_search_label_count.Text = (position + 1) + "/" + my_arry_ids.Count;
        }

        private void metroButton_add_new_Click(object sender, EventArgs e)
        {
            if (metroButton_add_new.Text == "Ajouter Nouveau")
            {
                enable_true();
                metroButton_add_langage_save_close.Enabled = false;
               
                vider_form();
                metroButton_add_new.Text = "Save";
            }
            else if (metroButton_add_new.Text == "Save")
            {
                DialogResult x = MessageBox.Show("do you wanna save", "save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (x == DialogResult.OK)
                {
                    string query = "insert into langues(ID_candidat,langue,Niveau) values(" + (int)my_arry_ids[position] + ",'"+metroTextBox_update_langage_number1.Text+"','"+metroComboBox_niveau_langage_1.SelectedItem.ToString()+"')";
                   
                    Class_Database_app.add_data(query);
                }
                position = 0;
                Class_langage langue = Class_Database_app.get_langue_by_id((int)my_arry_ids[position]);
                afficher(langue);
                enable_false();
                metroButton_add_langage_save_close.Enabled = true;

            }
        }
        public void vider_form() {
            metroTextBox_update_langage_number1.Text = "";
            metroComboBox_niveau_langage_1.SelectedIndex = 0;
        }
    }
}
