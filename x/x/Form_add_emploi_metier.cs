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
    public partial class Form_add_emploi_metier : MetroFramework.Forms.MetroForm
    {
        public Form_add_emploi_metier(string nom,string prenom)
        {
            InitializeComponent();
            this.nom_ = nom;
            this.prenom_ = prenom;
        }
        string nom_;
        string prenom_;
        private void Form_add_emploi_metier_Load(object sender, EventArgs e)
        {
            metroTextBox_add_emploi_visee_nom.Text = nom_;
            metroTextBox_add_emploi_visee_prenom.Text = prenom_;

        }
        public void metirs_proc()
        {
            Class_emploi_metier x = new Class_emploi_metier();
            x.emploi_metier = metroTextBox_add_emploi_visee_number1.Text;
            Program.new_candidat_to_add.son_emplois_metiers.Add(x);
            x = new Class_emploi_metier();
            x.emploi_metier = metroTextBox_add_emploi_visee_number2.Text;
            Program.new_candidat_to_add.son_emplois_metiers.Add(x);
            x = new Class_emploi_metier();
            x.emploi_metier = metroTextBox_add_emploi_visee_number3.Text;
            Program.new_candidat_to_add.son_emplois_metiers.Add(x);
        }
        
        private void metroButton_add_phone_save_close_Click(object sender, EventArgs e)
        {
            metirs_proc();
            Close();
        }
    }
}
