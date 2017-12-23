using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Collections;

namespace x
{
    public partial class Form_Starting : MetroFramework.Forms.MetroForm
    {


       
        public Form_Starting()
        {
            InitializeComponent();
        }
        public void not_enabeld_all()
        {
            
            metroPanel_new_account.Enabled = false;
            metroPanel_set_password.Enabled = false;
            metroPanel_delete_account.Enabled = false;
           
            metroPanel_search_for_show_update.Enabled = false;
            metroTabPage_search.Enabled = false;
            metroTabPage_add_candidat.Enabled = false;
            metroPanel_delete_search.Enabled = false;
            metroTabPage_update_candidat_data.Enabled = false;
            metroTabPage_sourcing.Enabled = false;
        }
        public void enabeld_all()
        {
            metroPanel_new_account.Enabled = true;
            metroPanel_set_password.Enabled = true;
            metroPanel_delete_account.Enabled = true;
            metroTabPage_update_candidat_data.Enabled = true;
            metroTabPage_sourcing.Enabled = true;
            metroTabPage_add_candidat.Enabled = true;
            metroPanel_search_for_show_update.Enabled = true;
            metroTabPage_search.Enabled = true;
            metroPanel_delete_search.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            not_enabeld_all();
            faire_water_mark();
            DataTable t = Class_Database_app.view_sourcing_by_date(DateTime.Now);
            dataGridView_view_sourcing.DataSource = t;
            metroTabControl_Starting.SelectedTab = metroTabPage_login;
            afficher_combo_users();
            
        }
        public void afficher_combo_users() {
            ArrayList my_all_users = Class_Database_app.get_all_users();
            foreach (string u in my_all_users)
                metroComboBox_all_users_set_password.Items.Add(u);
        }
        public void faire_water_mark()
        {
            metroTextBox_UserName.ForeColor = System.Drawing.Color.LightCyan;
            metroTextBox_UserName.Text = "Admin";
            this.metroTextBox_UserName.Leave += new System.EventHandler(this.metroTextBox_UserName_Leave);
            this.metroTextBox_UserName.Enter += new System.EventHandler(this.metroTextBox_UserName_Enter);
            metroTextBox_admin_password.ForeColor = System.Drawing.Color.LightCyan;
            metroTextBox_admin_password.Text = "Entrer le mot de passe ici";
            this.metroTextBox_admin_password.Leave += new System.EventHandler(this.metroTextBox_admin_password_Leave);
            this.metroTextBox_admin_password.Enter += new System.EventHandler(this.metroTextBox_admin_password_Enter);
        }
        private void metroTextBox_UserName_Leave(object sender, EventArgs e)
        {
            if (metroTextBox_UserName.Text.Length == 0)
            {
                metroTextBox_UserName.Text = "Admin";
                metroTextBox_UserName.ForeColor = System.Drawing.Color.LightCyan;
            }
        }

        private void metroTextBox_UserName_Enter(object sender, EventArgs e)
        {
            if (metroTextBox_UserName.Text == "Admin")
            {
                metroTextBox_UserName.Text = "";
                metroTextBox_UserName.ForeColor = SystemColors.WindowText;
            }
        }
        //----------------------------------
        private void metroTextBox_admin_password_Leave(object sender, EventArgs e)
        {
            if (metroTextBox_admin_password.Text.Length == 0)
            {
                metroTextBox_admin_password.Text = "Entrer le mot de passe ici";
                metroTextBox_admin_password.PasswordChar = '\0';
                metroTextBox_admin_password.ForeColor = System.Drawing.Color.LightCyan;
            }
        }

        private void metroTextBox_admin_password_Enter(object sender, EventArgs e)
        {
            if (metroTextBox_admin_password.Text == "Entrer le mot de passe ici")
            {
                metroTextBox_admin_password.Text = "";
                metroTextBox_admin_password.PasswordChar = '*';
                metroTextBox_admin_password.ForeColor = SystemColors.WindowText;
            }
        }
        //----------------------------------------
        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
            Regex regex = new Regex(@"^[a-zA-Z]{0,}[0-9]{1,}[a-zA-Z]{0,}[0-9]{1,}[a-zA-Z]{0,}[0-9]{1,}[a-zA-Z]{0,}$");
            Match match = regex.Match(metroTextBox_admin_password.Text);
            if (match.Success)
            {
                //code here password is match
                //MessageBox.Show("Okay");
                Regex regex_username = new Regex(@"^[a-zA-Z]{0,10}$");
                Match match_user = regex_username.Match(metroTextBox_UserName.Text);
                if (match_user.Success)
                {
                    //here username and password is okay
                    Boolean is_ok = Class_Database_app.is_a_user(metroTextBox_UserName.Text, metroTextBox_admin_password.Text);
                    if (is_ok == true)
                    {
                        enabeld_all();
                        MessageBox.Show("Soyez bienvenue", "la connexion est réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        metroTextBox_UserName.Text = "";
                        metroTextBox_admin_password.Text = "";
                    }
                    else {
                        MessageBox.Show("votre username ou mot de passe est incorrect","incorrect",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //code here is not okay username not okay
                    MessageBox.Show("Le nom d'utilisateur doit composer au maximum de 10 caractères alphabétiques, ni numériques ni spéciaux", "Les Règles De Gestion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //code here erreur password not match
                MessageBox.Show("Le mot de passe d'utilisateur doit composer au maximum de 20 caractères avec trois chiffres au minimum, pas de caractères spéciaux", "Les Règles De Gestion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MetroFramework.MetroMessageBox.Show(this, "Warning", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void metroButton_add_candidat_cv_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF File (.pdf)|*.pdf";
            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                Program.new_candidat_to_add.cv_fileName = fileDialog.FileName;
                //code here
                // use filedialog.filename attribute
                // use filedialog.dispose method
            }
        }

        private void pictureBox_add_candidat_save_Click(object sender, EventArgs e)
        {
            add_candidat_procedure();
            Regex regex = new Regex(@"[\w-]+@([\w-]+\.)+[\w-]+");
            Match match = regex.Match(metroTextBox_add_candidat_email.Text);
            if (match.Success)
            {
                //code here email is valid do the work here
                //MessageBox.Show("Okay");
                Class_Database_app.add_new_candidat();
            }
            else
            {
                //code here erreur email not valid
                MessageBox.Show("L’email du candidat doit être en le format standard", "Les Règles De Gestion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Program.new_candidat_to_add = new Class_Candidat();
            reset_form_adding();
        }
        public void reset_form_adding()
        {
            metroTextBox_add_candidat_nom.Text = "";
            metroTextBox_add_candidat_prenom.Text = "";
            metroRadioButton_add_candidat_Monsieur.Checked = true;
            metroRadioButton_add_candidat_Madame.Checked = false;
            dateTimePicker_add_candidat_naissance.Value = new DateTime(1993, 05, 25);
            metroTextBox_add_candidat_ville.Text = "";
            metroTextBox_add_candidat_quartier.Text = "";
            metroTextBox_add_candidat_CIN.Text = "";
            metroTextBox_add_candidat_email.Text = "";
            metroRadioButton_add_candidat_vcc_oui.Checked = false;
            metroRadioButton_add_candidat_vcc_non.Checked = true;
           
            metroButton_add_candidat_bac.Enabled = true;
            metroButton_add_niveau_bac.Enabled = true;
        }
        private void pictureBox_add_candidat_cancel_Click(object sender, EventArgs e)
        {
            Program.new_candidat_to_add = new Class_Candidat();
            reset_form_adding();
            
        }

        private void metroButton_modifier_infos_Click(object sender, EventArgs e)
        {
            metroPanel_update_candidat_data.Enabled = true;
        }

        private void metroButton_save_update_infos_Click(object sender, EventArgs e)
        {
            
            
            DialogResult d = MessageBox.Show("Voulez vraiment entregistrer", "Enregistrer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (d == DialogResult.OK)
            {
                //update infos here
                string query_to_update_infos = "update Candidat set ";
                query_to_update_infos+=" Nom = '"+metroTextBox_show_update_candidat_nom.Text+"' ,Prenom = '"+metroTextBox_show_updat_candidat_prenom.Text+"' , ";
                string genre = "";
                if(metroRadioButton_show_update_candidat_monsieur.Checked)
                    genre="True";
                else
                    genre="False";
                query_to_update_infos+=" Genre = '"+genre+"' ,DateNaissance = '"+dateTimePicker_show_update_candidat_naissance.Value+"',";
                query_to_update_infos+=" Ville = '"+metroTextBox_show_update_candidat_ville.Text+"' ,Quartier = '"+metroTextBox_show_update_candidat_quartier.Text+"',";
                query_to_update_infos+="  CIN = '"+metroTextBox_show_update_candidat_CIN.Text+"' ,Email = '"+metroTextBox_show_update_candidat_email.Text+"' , ";
                string vcc = "";
                if(metroRadioButton_show_update_candidat_vcc_oui.Checked)
                    vcc = "True";
                else
                    vcc = "False";
                query_to_update_infos+=" vcc = '"+vcc+"' where ID = "+(int)chercher_for_update_ids[position_to_update];
                MessageBox.Show(query_to_update_infos);
                Boolean is_updated_ok = Class_Database_app.update_candidat_infos(query_to_update_infos);
                //code here to save updating data
                if (is_updated_ok)
                {
                    MessageBox.Show("Enregister bien fait", "Enregistrer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("procedure n'a pas ressu");
                }
            }
            else
            {
                MessageBox.Show("Le produre d'enregistrer à ete annuler", "Annuler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            metroPanel_update_candidat_data.Enabled = false;
            vider_panel_update_candidate_data();
        }
        public void vider_panel_update_candidate_data()
        {
            metroTextBox_show_update_candidat_CIN.Text = "";
            metroTextBox_show_update_candidat_email.Text = "";
            metroTextBox_show_update_candidat_nom.Text = "";
            metroTextBox_show_update_candidat_quartier.Text = "";
            metroTextBox_show_update_candidat_ville.Text = "";
            metroTextBox_show_updat_candidat_prenom.Text = "";
           
            metroRadioButton_show_update_candidat_monsieur.Checked = false;
            metroRadioButton_show_updat_candidat_madame.Checked = false;
            metroRadioButton_show_update_candidat_vcc_non.Checked = false;
            metroRadioButton_show_update_candidat_vcc_oui.Checked = false;
            dateTimePicker_show_update_candidat_naissance.Value = new DateTime(1993, 05, 25);
        }
        public void add_candidat_procedure()
        {
            Program.new_candidat_to_add.Nom = metroTextBox_add_candidat_nom.Text;
            Program.new_candidat_to_add.Prenom = metroTextBox_add_candidat_prenom.Text;
            Boolean x = true;
            if (metroRadioButton_add_candidat_Madame.Checked)
                x = false;
            Program.new_candidat_to_add.genre = x;
            Program.new_candidat_to_add.date_naissace = dateTimePicker_add_candidat_naissance.Value;
            Program.new_candidat_to_add.ville = metroTextBox_add_candidat_ville.Text;
            Program.new_candidat_to_add.quartier = metroTextBox_add_candidat_quartier.Text;
            Program.new_candidat_to_add.cin = metroTextBox_add_candidat_CIN.Text;
            Program.new_candidat_to_add.email = metroTextBox_add_candidat_email.Text;
            Boolean y = false;
            if (metroRadioButton_add_candidat_vcc_non.Checked)
                y = false;
            else
                y = true;
            Program.new_candidat_to_add.vcc = y;

        }
        private void pictureBox_annuler_update_candidat_data_Click(object sender, EventArgs e)
        {
            vider_panel_update_candidate_data();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
           /* */
        }

        private void metroButton_chercher_Click(object sender, EventArgs e)
        {
            try
            {
                int age1 = int.Parse(metroTextBox_searche_age_min_value.Text);
                int age2 = int.Parse(metroTextBox_search_age_max_value.Text);
                Boolean genre = true;
                if (metroRadioButton_search_Madame.Checked)
                    genre = false;
                String search_query = "select c.CIN,c.Genre,c.DateNaissance,c.Nom,c.Prenom,c.vcc,c.Ville,c.Quartier,c.Email,c.CV from Candidat c   ";
                
                if (metroCheckBox_search_target_job.Checked && !metroCheckBox_search_Diploma.Checked)
                    search_query += ",emploi_metier m  where  m.ID_candidat = c.ID ";
                if (!metroCheckBox_search_target_job.Checked && metroCheckBox_search_Diploma.Checked)
                    search_query += ",diplome d where d.ID_candidat = c.ID ";
                if (metroCheckBox_search_target_job.Checked && metroCheckBox_search_Diploma.Checked)
                    search_query += ",diplome d ,emploi_metier m  where d.ID_candidat = c.ID and m.ID_candidat = c.ID ";
                if (!metroCheckBox_search_target_job.Checked && !metroCheckBox_search_Diploma.Checked)
                    search_query += " where c.ID != -1  ";
                if (metroCheckBox_search_age.Checked)
                    search_query += "and DATEDIFF(year,c.DateNaissance,getdate()) between "+age1+" and "+age2 +" ";
                if (metroCheckBox_search_ville.Checked)
                    search_query += "and c.Ville = '"+metroTextBox_search_ville.Text+"' ";
                if (metroCheckBox_search_Quartier.Checked)
                    search_query += "and c.Quartier = '"+metroTextBox_search_quartier.Text+"' ";
                if (metroCheckBox_search_Diploma.Checked)
                    search_query += "and d.specialite = '"+metroTextBox_search_diploma.Text+"' ";
                if (metroCheckBox_search_target_job.Checked)
                    search_query += "and m.emploi_metier = '"+metroTextBox_search_target_job.Text +"' ";
                if (metroCheckBox_search_Genre.Checked)
                    search_query += "and c.Genre = '"+genre.ToString()+"'";
                String search_query_ids = "select distinct c.ID from Candidat c  ";
                if (metroCheckBox_search_target_job.Checked && !metroCheckBox_search_Diploma.Checked)
                    search_query_ids += ",emploi_metier m  where  m.ID_candidat = c.ID ";
                if (!metroCheckBox_search_target_job.Checked && metroCheckBox_search_Diploma.Checked)
                    search_query_ids += ",diplome d where d.ID_candidat = c.ID ";
                if (metroCheckBox_search_target_job.Checked && metroCheckBox_search_Diploma.Checked)
                    search_query_ids += ",diplome d ,emploi_metier m  where d.ID_candidat = c.ID and m.ID_candidat = c.ID ";
                if (!metroCheckBox_search_target_job.Checked && !metroCheckBox_search_Diploma.Checked)
                    search_query_ids += " where c.ID > -1 ";
                if (metroCheckBox_search_age.Checked)
                    search_query_ids += "and DATEDIFF(year,c.DateNaissance,getdate()) between " + age1 + " and " + age2 + " ";
                if (metroCheckBox_search_ville.Checked)
                    search_query_ids += "and c.Ville = '" + metroTextBox_search_ville.Text + "' ";
                if (metroCheckBox_search_Quartier.Checked)
                    search_query_ids += "and c.Quartier = '" + metroTextBox_search_quartier.Text + "' ";
                if (metroCheckBox_search_Diploma.Checked)
                    search_query_ids += "and d.specialite = '" + metroTextBox_search_diploma.Text + "' ";
                if (metroCheckBox_search_target_job.Checked)
                    search_query_ids += "and m.emploi_metier = '" + metroTextBox_search_target_job.Text + "' ";
                if (metroCheckBox_search_Genre.Checked)
                    search_query_ids += "and c.Genre = '" + genre.ToString() + "'";
                Form_view_candidat_data f_sdhow = new Form_view_candidat_data(search_query,search_query_ids);
                f_sdhow.Show();
            }
            catch (Exception y)
            {
                MessageBox.Show("Error\n"+y.ToString());
            }
        }

        private void metroButton_delete_candidat_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Voulez vous vraiment supprimer ce candidat", "Supprission", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (x == DialogResult.OK)
            {
                Boolean is_delete_ok = Class_Database_app.delete_a_candidat((int)chercher_for_delete_ids[position_to_delete]);
                if (is_delete_ok)
                {
                    MessageBox.Show("Le Candidat bien supprimer", "Bien Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("le procedure delete annuler");
                }
            }
            else
            {
                MessageBox.Show("La supprision a éte annuler", "Annulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroButton_add_candidat_diploma_Click(object sender, EventArgs e)
        {
            Form_add_candidat_diploma f = new Form_add_candidat_diploma(metroTextBox_add_candidat_nom.Text,metroTextBox_add_candidat_prenom.Text);
            f.Show();
        }

        private void metroButton_add_candidat_bac_Click(object sender, EventArgs e)
        {
            metroButton_add_niveau_bac.Enabled = false;
            Form_add_bac form_add_bac = new Form_add_bac(metroTextBox_add_candidat_nom.Text,metroTextBox_add_candidat_prenom.Text);
            form_add_bac.Show();
        }

        private void metroTextBox_add_candidat_nom_Leave(object sender, EventArgs e)
        {
            metroTextBox_add_candidat_nom.Text = metroTextBox_add_candidat_nom.Text.ToUpper();
            add_candidat_procedure();
        }

        private void metroTextBox_add_candidat_nom_MouseLeave(object sender, EventArgs e)
        {
            metroTextBox_add_candidat_nom.Text = metroTextBox_add_candidat_nom.Text.ToUpper();
            add_candidat_procedure();
        }

        private void metroButton_add_niveau_bac_Click(object sender, EventArgs e)
        {
            metroButton_add_candidat_bac.Enabled = false;
            Form_add_niveau_bac f = new Form_add_niveau_bac(metroTextBox_add_candidat_nom.Text,metroTextBox_add_candidat_prenom.Text);
            f.Show();
        }

        private void metroButton_add_candidat_experience_Click(object sender, EventArgs e)
        {
            Form_add_experience f = new Form_add_experience(metroTextBox_add_candidat_nom.Text,metroTextBox_add_candidat_prenom.Text);
            f.Show();
        }

        private void metroTextBox_UserName_Click(object sender, EventArgs e)
        {

        }

        private void metroButton_new_compte_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z]{0,}[0-9]{1,}[a-zA-Z]{0,}[0-9]{1,}[a-zA-Z]{0,}[0-9]{1,}[a-zA-Z]{0,}$");
            Match match = regex.Match(metroTextBox_new_account_password.Text);
            if (match.Success)
            {
                //code here password is match
                //MessageBox.Show("Okay");
                Regex regex_username = new Regex(@"^[a-zA-Z]{0,10}$");
                Match match_user = regex_username.Match(metroTextBox_new_account_username.Text);
                if (match_user.Success)
                {
                    //here username and password is okay
                     DialogResult x =  MessageBox.Show("voulez vous vraiment Ajouter le nouveau utilisateur", "Etes-vous sûr", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (x == DialogResult.OK)
                    {
                        //write code here for add new user
                        Boolean ok = Class_Database_app.add_application_user(metroTextBox_new_account_username.Text, metroTextBox_new_account_password.Text);
                        if (ok)
                        {
                            MessageBox.Show("le nouveau utilisateur à éte bien ajouter", "ajouter avec succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            metroTextBox_new_account_username.Text = "";
                            metroTextBox_new_account_password.Text = "";
                            afficher_combo_users();
                        }
                        else {
                            MessageBox.Show("ajouter annuler");
                        }
                    }
                    else
                    {
                        MessageBox.Show("l'ajout a ete annulé", "Annuler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                }
                else
                {
                    //code here is not okay username not okay
                    MessageBox.Show("Le nom d'utilisateur doit composer au maximum de 10 caractères alphabétiques, ni numériques ni spéciaux", "Les Règles De Gestion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //code here erreur password not match
                MessageBox.Show("Le mot de passe d'utilisateur doit composer au maximum de 20 caractères avec trois chiffres au minimum, pas de caractères spéciaux", "Les Règles De Gestion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MetroFramework.MetroMessageBox.Show(this, "Warning", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void metroButton_set_password_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z]{0,}[0-9]{1,}[a-zA-Z]{0,}[0-9]{1,}[a-zA-Z]{0,}[0-9]{1,}[a-zA-Z]{0,}$");
            Match match = regex.Match(metroTextBox_set_password_new_pass.Text);
            if (match.Success)
            {
                DialogResult x= MessageBox.Show("voulez vous vraiment modifier le mot de passe", "Etes-vous sûr", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (x == DialogResult.OK)
                {
                    Boolean is_updated = Class_Database_app.update_password(metroTextBox_set_password_new_pass.Text, metroTextBox_set_password_actuel_pass.Text, metroComboBox_all_users_set_password.SelectedItem.ToString());
                    if (is_updated == true)
                    {
                        MessageBox.Show("le mot de passe a ete modifier", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        MessageBox.Show("le procedure set password has annuler");
                    }
                }
                else
                {
                    MessageBox.Show("La modification a ete annule", "Annuler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Le mot de passe d'utilisateur doit composer au maximum de 20 caractères avec trois chiffres au minimum, pas de caractères spéciaux", "Les Règles De Gestion", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void metroButton_add_candidat_telephone_Click(object sender, EventArgs e)
        {
            Form_add_phone f = new Form_add_phone(metroTextBox_add_candidat_nom.Text,metroTextBox_add_candidat_prenom.Text);
            f.Show();
        }

        private void metroButton_add_candidat_ateliers_Click(object sender, EventArgs e)
        {
            Form_add_atelier f = new Form_add_atelier(metroTextBox_add_candidat_nom.Text,metroTextBox_add_candidat_prenom.Text);
            f.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Form_add_emploi_metier f = new Form_add_emploi_metier(metroTextBox_add_candidat_nom.Text,metroTextBox_add_candidat_prenom.Text);
            f.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Form_add_languages f = new Form_add_languages(metroTextBox_add_candidat_nom.Text,metroTextBox_add_candidat_prenom.Text);
            f.Show();
        }

        private void metroTextBox_add_candidat_CIN_MouseLeave(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroTextBox_add_candidat_CIN_Leave(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroTextBox_add_candidat_CIN_TextChanged(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroRadioButton_add_candidat_Monsieur_CheckedChanged(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroRadioButton_add_candidat_Madame_CheckedChanged(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroTextBox_add_candidat_nom_TextChanged(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroTextBox_add_candidat_prenom_MouseLeave(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroTextBox_add_candidat_prenom_TextChanged(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void dateTimePicker_add_candidat_naissance_ValueChanged(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroTextBox_add_candidat_ville_MouseLeave(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroTextBox_add_candidat_ville_TextChanged(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroTextBox_add_candidat_email_MouseLeave(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroTextBox_add_candidat_email_TextChanged(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable t = Class_Database_app.view_sourcing_by_date(dateTimePicker1.Value);
            dataGridView_view_sourcing.DataSource = t;
        }

        private void metroRadioButton_add_candidat_vcc_oui_CheckedChanged(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroRadioButton_add_candidat_vcc_non_CheckedChanged(object sender, EventArgs e)
        {
            add_candidat_procedure();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Vouliez vraiment supprimer", "Suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (x == DialogResult.OK)
            {
                Boolean is_deleted_ok = Class_Database_app.delete_a_user(metroTextBox_account_to_delete.Text);
                if (is_deleted_ok)
                {
                    MessageBox.Show("deleted");
                    afficher_combo_users();
                    metroTextBox_account_to_delete.Text = "";
                }
                else
                    MessageBox.Show("procedure delete annuler");
                //code to delete user here
            }
            else
            {
                MessageBox.Show("Le procedure à ete annuler", "Annulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroButton_update_emploi_visee_Click(object sender, EventArgs e)
        {
            Form_update_son_metiers_visee f = new Form_update_son_metiers_visee((int)chercher_for_update_ids[position_to_update]);
        }

        private void metroButton_update_langue_Click(object sender, EventArgs e)
        {
            Form_update_langues f = new Form_update_langues((int)chercher_for_update_ids[position_to_update]);
            f.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        ArrayList chercher_for_update_ids = new ArrayList();
        int position_to_update = 0;
        private void metroButton_chercher_modifier_Click(object sender, EventArgs e)
        {
            chercher_for_update_ids = new ArrayList();
            string query_to_update = "select c.ID from Candidat c where c.ID > -1 ";
            if (metroTextBox_update_cin_search.Text != "")
                query_to_update += "and c.CIN = '"+metroTextBox_update_cin_search.Text+"' ";
            if (metroTextBox_update_email_search.Text != "")
                query_to_update += "and c.Email='"+metroTextBox_update_email_search.Text+"' ";
            if (metroTextBox_update_nom_search.Text != "")
                query_to_update += "and c.Nom='"+metroTextBox_update_nom_search.Text+"' ";
            if (metroTextBox_update_prenom_search.Text != "")
                query_to_update += "and c.Prenom = '"+metroTextBox_update_prenom_search.Text+"'";
            chercher_for_update_ids = Class_Database_app.get_ids_to_update(query_to_update);
            if (chercher_for_update_ids.Count >= 1)
            {
                afficher_candidat_to_update((int)chercher_for_update_ids[position_to_update]);
            }
            else {
                MessageBox.Show("aucune candidate avec ses conditions");
            }
        }
        public void afficher_candidat_to_update(int id) {

            Class_Candidat candidat = new Class_Candidat();
            candidat = Class_Database_app.get_candidate_by_id(id);
            metroTextBox_show_update_candidat_CIN.Text = candidat.cin;
            metroTextBox_show_update_candidat_nom.Text = candidat.Nom;
            metroTextBox_show_updat_candidat_prenom.Text = candidat.Prenom;
            metroTextBox_show_update_candidat_email.Text = candidat.email;
            metroTextBox_show_update_candidat_quartier.Text = candidat.quartier;
            metroTextBox_show_update_candidat_ville.Text = candidat.ville;
            dateTimePicker_show_update_candidat_naissance.Value = candidat.date_naissace;
            if (candidat.genre)
                metroRadioButton_show_update_candidat_monsieur.Checked = true;
            else
                metroRadioButton_show_updat_candidat_madame.Checked = true;
            if (candidat.vcc)
                metroRadioButton_show_update_candidat_vcc_oui.Checked = true;
            else
                metroRadioButton_show_update_candidat_vcc_non.Checked = true;

        }
        public void afficher_candidat_to_delete(int id)
        {

            Class_Candidat candidat = new Class_Candidat();
            candidat = Class_Database_app.get_candidate_by_id(id);
            metroTextBox_delete_candidat_cin.Text= candidat.cin;
            metroTextBox_delete_candidat_nom.Text = candidat.Nom;
            metroTextBox_delete_candidat_prenom.Text = candidat.Prenom;
            metroTextBox_delete_candidat_email.Text= candidat.email;
            metroTextBoxdelete_candidat_quartier.Text = candidat.quartier;
            metroTextBox_delete_candidat_ville.Text = candidat.ville;
            dateTimePicker_delete_candidat_date_naissance.Value = candidat.date_naissace;
            if (candidat.genre)
                metroRadioButton_delete_candidat_monsieur.Checked= true;
            else
                metroRadioButton_delete_candidat_madame.Checked = true;
            if (candidat.vcc)
                metroRadioButton_delete_candidat_vcc_oui.Checked = true;
            else
                metroRadioButton_delete_candidat_vcc_non.Checked = true;
        }
        ArrayList chercher_for_delete_ids = new ArrayList();
        int position_to_delete = 0;
        private void metroButton_serch_delete_Click(object sender, EventArgs e)
        {
            chercher_for_delete_ids = new ArrayList();
            string query_to_delete = "select c.ID from Candidat c where c.ID > -1 ";
            if (metroTextBox_delete_search_cin.Text != "")
                query_to_delete += "and c.CIN = '"+metroTextBox_delete_search_cin.Text+"' ";
            if (metroTextBox_delete_candidat_search_nom.Text != "")
                query_to_delete += "and c.Nom='"+metroTextBox_delete_candidat_search_nom.Text+ "' ";
            if (metroTextBox_delete_candidat_search_prenom.Text != "")
                query_to_delete += "and c.Prenom = '"+metroTextBox_delete_candidat_search_prenom.Text+"' ";
            if (metroTextBox_delete_candidat_email_search.Text != "")
                query_to_delete += "and c.Email='"+metroTextBox_delete_candidat_email_search.Text+"' ";
            chercher_for_delete_ids = Class_Database_app.get_ids_to_update(query_to_delete);
            if (chercher_for_delete_ids.Count < 1)
            {
                MessageBox.Show("aucune candidat avec ses conditions");
            }
            else
            {
                afficher_candidat_to_delete((int)chercher_for_delete_ids[position_to_delete]);
            }
        }

        private void metrobuutton_modifier_search_next_Click(object sender, EventArgs e)
        {
            position_to_update++;
            if (position_to_update >= chercher_for_update_ids.Count) {
                position_to_update = 0;
            }
            afficher_candidat_to_update((int)chercher_for_update_ids[position_to_update]);
            gestion_buttons_update();
           
        }

        private void metroButton_modifier_search_last_Click(object sender, EventArgs e)
        {
            position_to_update = chercher_for_update_ids.Count - 1;
            afficher_candidat_to_update((int)chercher_for_update_ids[position_to_update]);
            gestion_buttons_update();
        }

        private void metroButton_modifier_search_precedant_Click(object sender, EventArgs e)
        {
            position_to_update--;
            if (position_to_update < 0)
                position_to_update = chercher_for_update_ids.Count - 1;
            afficher_candidat_to_update((int)chercher_for_update_ids[position_to_update]);
            gestion_buttons_update();
        }

        private void metroButton_modifier_search_first_Click(object sender, EventArgs e)
        {
            position_to_update = 0;
            afficher_candidat_to_update((int)chercher_for_update_ids[position_to_update]);
            gestion_buttons_update();
        }
        public void gestion_buttons_update() {
            if (position_to_update <= 0) {
                metrobuutton_modifier_search_next.Enabled = true;
                metroButton_modifier_search_precedant.Enabled = false;
            }
            else if (position_to_update >= chercher_for_update_ids.Count - 1) {
                metrobuutton_modifier_search_next.Enabled = false;
                metroButton_modifier_search_precedant.Enabled = true;
            }
        
        }

        private void metroButton_update_diploma_Click(object sender, EventArgs e)
        {
            Form_update_diploma f = new Form_update_diploma((int)chercher_for_update_ids[position_to_update]);
            f.Show();
        }
    }
}
