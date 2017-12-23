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
namespace x
{
    public partial class Form_add_candidat_diploma : MetroFramework.Forms.MetroForm
    {
        public Form_add_candidat_diploma(string nom,string prenom)
        {
            InitializeComponent();
            this.nom_ = nom;
            this.prenom_ = prenom;
        }
        string nom_;
        string prenom_;
        Class_diplome diploma  = new Class_diplome();
        private void Form_add_candidat_diploma_Load(object sender, EventArgs e)
        {
            metroComboBox_add_diploma_niveau.SelectedIndex = 2;
            metroTextBox_add_diploma_nom.Text = nom_;
            metroTextBox_add_diploma_prenom.Text = prenom_;
        }
        public void valider_fomulaire()
        {
            try
            {
               
                    Regex regex = new Regex(@"[0-9.*-=]");
                    Match match = regex.Match(metroTextBox_add_diploma_specialite.Text);
                    if (!match.Success)
                    {
                    //write code here  le specialite est OK, 
                        diploma.specialite = metroTextBox_add_diploma_specialite.Text;
                        diploma.etablissement = metroTextBox_etablissement.Text;
                        diploma.niveau = metroComboBox_add_diploma_niveau.SelectedItem.ToString();
                        if (metroCheckBox_add_diploma_En_cours.Checked == false)
                        {

                            //------------
                            int d = int.Parse(metroTextBox_date_obtention.Text);
                            if (!((d <= 2030) && (d >= 1990)))
                                MessageBox.Show("La date d'obtention du diplôme doit être numérique et entre l'année 1990 et 2030", "Les Règles De Gestion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                            //write code here , here is right
                            diploma.date_obtention = d;
                        }
                        }
                        else
                        {
                        // here is wrong,la date d obtention is wrong
                        diploma.date_obtention = 0 ;
                        }
                    }
                    else
                    {
                    MessageBox.Show("La spécialité du diplôme ne doit pas contenir des chiffres ou des caractères spéciaux", "Les Règles De Gestion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
               
            }
            catch (Exception e)
            {
                MessageBox.Show("Les Règles De Gestion doit être respecter", "Les Règles De Gestion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void metroCheckBox_add_diploma_En_cours_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox_add_diploma_En_cours.Checked == true)
            {
                metroTextBox_date_obtention.Text = "";
                metroTextBox_date_obtention.Enabled = false;
            }
            else
            {
                metroTextBox_date_obtention.Enabled = true;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Etes Vous Sur", "Vouliez vous vraiment enregistrer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (x == DialogResult.OK)
            {
                valider_fomulaire();
                Program.new_candidat_to_add.son_diplomes.Add(diploma);
                diploma = new Class_diplome();
                vider_formulaire();
            }
            else
            {
                MessageBox.Show("Le procedure à ete annuler","Annuler",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
        }
        public void vider_formulaire()
        {
            metroTextBox_add_diploma_specialite.Text = "";
            metroTextBox_date_obtention.Text = "";
            metroTextBox_etablissement.Text = "";
            metroCheckBox_add_diploma_En_cours.Checked = false;
          
        }
        private void metroButton_add_diploma_save_close_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Etes Vous Sur", "Vouliez vous vraiment enregistrer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (x == DialogResult.OK)
            {
                valider_fomulaire();
                Program.new_candidat_to_add.son_diplomes.Add(diploma);
                diploma = new Class_diplome();
                vider_formulaire();
            }
            else
            {
                MessageBox.Show("Le procedure à ete annuler", "Annuler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }

        private void metroTextBox_date_obtention_Click(object sender, EventArgs e)
        {

        }
    }
}
