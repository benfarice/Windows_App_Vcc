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
    public partial class Form_add_niveau_bac : MetroFramework.Forms.MetroForm
    {
        public Form_add_niveau_bac(string nom,string prenom)
        {
            InitializeComponent();
            this.nom_ = nom;
            this.prenom_ = prenom;
        }
        string nom_;
        string prenom_;
        List<Class_niveau_bac> myLIST = new List<Class_niveau_bac>();
        private void Form_add_niveau_bac_Load(object sender, EventArgs e)
        {
            metroTextBox_add_niveau_bac_nom.Text = nom_;
            metroTextBox_add_niveau_bac_prenom.Text = prenom_;
        }

        private void metroTextBox_add_niveau_bac_type_Click(object sender, EventArgs e)
        {

        }
        public void niveau_bac_proc()
        {
            Class_niveau_bac x = new Class_niveau_bac();
            try
            {
                int a = int.Parse(metroTextBox_add_year_niveau_bac.Text);
                if(a>1990 && a<2030)
                x.annee = metroTextBox_add_year_niveau_bac.Text;
                else
                {
                    MessageBox.Show("error typing in the year");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                x.annee = "Null";
            }

            
            x.type = metroTextBox_add_niveau_bac_type.Text;
            //MessageBox.Show(x.Niveau);
            myLIST.Add(x);
        }
        private void metroTextBox_add_niveau_bac_type_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void metroButton_add_niveau_bac_save_another_Click(object sender, EventArgs e)
        {
            niveau_bac_proc();
            vider_form();
        }

        private void metroButton_add_niveau_bac_save_close_Click(object sender, EventArgs e)
        {
            niveau_bac_proc();
            Program.new_candidat_to_add.ses_niveau_bac = myLIST;
            vider_form();
            Close();
        }
        public void vider_form()
        {
            metroTextBox_add_niveau_bac_type.Text = "";
            metroTextBox_add_year_niveau_bac.Text = "";
        }
    }
}
