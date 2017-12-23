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
    public partial class Form_update_diploma : MetroFramework.Forms.MetroForm
    {
        int my_id = 0;
        public Form_update_diploma(int id_candidat)
        {
            InitializeComponent();
            this.my_id = id_candidat;
        }
        ArrayList my_list_diploma = new ArrayList();
        int position = 0;
        private void Form_update_diploma_Load(object sender, EventArgs e)
        {
            Class_Candidat candidat = Class_Database_app.get_candidate_by_id(my_id);
            metroTextBox_update_diploma_nom.Text = candidat.Nom;
            metroTextBox_update_diploma_prenom.Text = candidat.Prenom;
            string query_diploma = "select ID_diplome from diplome where ID_candidat = "+my_id;
            my_list_diploma = Class_Database_app.get_ids_diploma_update(query_diploma);
            if (my_list_diploma.Count > 0)
            {
                Class_diplome diplome = Class_Database_app.get_diploma_by_id((int)my_list_diploma[position]);
                afficher(diplome);
            }
            else {
                MessageBox.Show("aucune diplome à afficher");
            }
        }
        public void afficher(Class_diplome dp) {
            metroComboBox_add_diploma_niveau.SelectedItem = dp.niveau;
            metroTextBox_add_diploma_specialite.Text = dp.specialite;
            if (dp.date_obtention != 0)
            {
                metroTextBox_date_obtention.Text = dp.date_obtention.ToString();
                metroCheckBox_add_diploma_En_cours.Checked = false;
            }
            else
            {
                metroTextBox_etablissement.Text = "";
                metroCheckBox_add_diploma_En_cours.Checked = true;
            }
            metroTextBox_etablissement.Text = dp.etablissement;
        }

        private void metrobuutton_modifier_search_next_Click(object sender, EventArgs e)
        {
            position++;
            if (position > my_list_diploma.Count - 1)
                position = 0;
            Class_diplome diplome = Class_Database_app.get_diploma_by_id((int)my_list_diploma[position]);
            afficher(diplome);

        }

        private void metroButton_modifier_search_last_Click(object sender, EventArgs e)
        {
            position = my_list_diploma.Count - 1;
            Class_diplome diplome = Class_Database_app.get_diploma_by_id((int)my_list_diploma[position]);
            afficher(diplome);
        }

        private void metroButton_modifier_search_precedant_Click(object sender, EventArgs e)
        {
            position--;
            if (position < 0)
                position = my_list_diploma.Count - 1;
            Class_diplome diplome = Class_Database_app.get_diploma_by_id((int)my_list_diploma[position]);
            afficher(diplome);
        }

        private void metroButton_modifier_search_first_Click(object sender, EventArgs e)
        {
            position = 0;
            Class_diplome diplome = Class_Database_app.get_diploma_by_id((int)my_list_diploma[position]);
            afficher(diplome);
        }

        private void metroButton_update_Click(object sender, EventArgs e)
        {
           
           
            if (metroButton_update.Text == "Save")
            {
                DialogResult c = MessageBox.Show("Do you wanna to save", "save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (c == DialogResult.OK)
                {
                    string query = "update diplome  set Niveau = '"+metroComboBox_add_diploma_niveau.SelectedItem.ToString()+"',";
                    query+="specialite='"+metroTextBox_add_diploma_specialite.Text+"',Etablissement='"+metroTextBox_etablissement.Text+
                    "',date_obtention='"+metroTextBox_date_obtention.Text+"' ";
                    query += "where ID_diplome = " + (int)my_list_diploma[position];
                    Boolean is_updated = Class_Database_app.update_diplome_infos(query);
                    if (is_updated)
                        MessageBox.Show("it is updated");
                    //----------------------
                }
                position = 0;
                Class_diplome diplome = Class_Database_app.get_diploma_by_id((int)my_list_diploma[position]);
                afficher(diplome);
                metroButton_update.Text = "Modifier";
                disable_false_all();
                enable_true_nav_buttons();
                metroButton_add_new.Enabled = true;
            }
            else if (metroButton_update.Text == "Modifier")
            {
                metroButton_update.Text = "Save";
                disable_true_all();
                enable_false_nav_buttons();
                metroButton_add_new.Enabled = false;
            }
           

        }
        public void disable_true_all() {
            metroComboBox_add_diploma_niveau.Enabled = true;
            metroTextBox_etablissement.ReadOnly = false;
            metroTextBox_date_obtention.ReadOnly = false;
            metroTextBox_add_diploma_specialite.ReadOnly = false;
            metroCheckBox_add_diploma_En_cours.Enabled = true;
        }
        public void disable_false_all()
        {
            metroComboBox_add_diploma_niveau.Enabled = false;
            metroTextBox_etablissement.ReadOnly = true;
            metroTextBox_date_obtention.ReadOnly = true;
            metroTextBox_add_diploma_specialite.ReadOnly = true;
            metroCheckBox_add_diploma_En_cours.Enabled = false;
        }
        public void enable_false_nav_buttons() {
            metrobuutton_modifier_search_next.Enabled = false;
            metroButton_modifier_search_precedant.Enabled = false;
            metroButton_modifier_search_last.Enabled = false;
            metroButton_modifier_search_first.Enabled = false;
           
        }
        public void enable_true_nav_buttons()
        {
            metrobuutton_modifier_search_next.Enabled = true;
            metroButton_modifier_search_precedant.Enabled = true;
            metroButton_modifier_search_last.Enabled = true;
            metroButton_modifier_search_first.Enabled = true;
           
        }

        private void metroButton_add_new_Click(object sender, EventArgs e)
        {
            
            if (metroButton_add_new.Text == "Ajouter Nouveau")
            {
                enable_false_nav_buttons();
                metroButton_update.Enabled = false;
                vider_form();
                metroButton_add_new.Text = "Save";
            }
            else if (metroButton_add_new.Text=="Save"){
                DialogResult x = MessageBox.Show("do you wanna save","save",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (x == DialogResult.OK) {
                    string query = "";
                    if(!metroCheckBox_add_diploma_En_cours.Checked)
                    query = "insert into diplome(ID_candidat,Niveau,specialite,Etablissement,date_obtention) values(" + my_id + ",'" +metroComboBox_add_diploma_niveau.SelectedItem.ToString()+"',"+
                        "'"+metroTextBox_add_diploma_specialite.Text+"','"+metroTextBox_etablissement.Text+"','"+metroTextBox_date_obtention.Text+"')";
                    else
                        query = "insert into diplome(ID_candidat,Niveau,specialite,Etablissement,date_obtention) values(" + my_id + ",'" + metroComboBox_add_diploma_niveau.SelectedItem.ToString() + "'," +
                        "'" + metroTextBox_add_diploma_specialite.Text + "','" + metroTextBox_etablissement.Text + "','0')";
                    Class_Database_app.add_data(query);
                }
                position = 0;
                Class_diplome diplome = Class_Database_app.get_diploma_by_id((int)my_list_diploma[position]);
                afficher(diplome);
                enable_true_nav_buttons();
                metroButton_update.Enabled = true;
            
            }
        }
        public void vider_form() {
            metroTextBox_add_diploma_specialite.Text = "";
            metroTextBox_date_obtention.Text = "";
            metroTextBox_etablissement.Text = "";
            metroComboBox_add_diploma_niveau.SelectedIndex = 0;
            metroCheckBox_add_diploma_En_cours.Checked = false;
        }
    }
}
