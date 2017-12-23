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
    public partial class Form_add_bac : MetroFramework.Forms.MetroForm
    {
        public Form_add_bac(String nom,String prenom)
        {
            InitializeComponent();
            this.nom_ = nom;
            this.prenom_ = prenom;
        }
        String nom_ = "";
        String prenom_ = "";
        Class_bac bac = new Class_bac();
        private void Form_add_bac_Load(object sender, EventArgs e)
        {
            metroTextBox_add_bac_nom.Text = nom_;
            metroTextBox_add_bac_prenom.Text = prenom_;
        }
        public void valider()
        {
            try {
                int x = int.Parse(metroTextBox_add_bac_annee_obtention.Text);
                if(x<1990 || x > 2030)
                {
                    //here is wrong
                    MessageBox.Show("La date d'obtention du baccalauréat doit être numérique et entre l'année 1960 et 2030", "Les Règles De Gestion", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    //write code here , here is Okay
                    bac.annee_obtention =int.Parse(metroTextBox_add_bac_annee_obtention.Text);
                    bac.Type = metroTextBox_add_bac_type.Text;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Les Règles De Gestion doit être respecter", "Les Règles De Gestion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void metroButton_add_bac_save_another_Click(object sender, EventArgs e)
        {
            valider();
            Program.new_candidat_to_add.son_bac.Add(bac);
            bac = new Class_bac();
            vider_form();
        }

        private void metroButton_add_bac_save_close_Click(object sender, EventArgs e)
        {
            valider();
            Program.new_candidat_to_add.son_bac.Add(bac);
            bac = new Class_bac();
            vider_form();
            Close();
        }
        public void vider_form()
        {
            metroTextBox_add_bac_annee_obtention.Text = "";
            metroTextBox_add_bac_type.Text = "";
        }
    }
}
