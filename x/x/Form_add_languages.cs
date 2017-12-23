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
    public partial class Form_add_languages : MetroFramework.Forms.MetroForm
    {
        public Form_add_languages(string nom,string prenom)
        {
            InitializeComponent();
            this.nom_ = nom;
            this.prenom_ = prenom;
        }
        string nom_;
        string prenom_;
        List<Class_langage> c = new List<Class_langage>();
        private void Form_add_languages_Load(object sender, EventArgs e)
        {
            metroComboBox_niveau_langage_1.SelectedIndex = 1;
            metroComboBox_niveau_langage_2.SelectedIndex = 1;
            metroComboBox_niveau_langage_3.SelectedIndex = 1;
            metroTextBox_add_langage_nom.Text = nom_;
            metroTextBox_add_langage_prenom.Text = prenom_;
        }

        private void metroTextBox_add_langage_number1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void metroTextBox_add_langage_number2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void metroTextBox_add_langage_number3_TextChanged(object sender, EventArgs e)
        {
           
        }
        public void proc_langages()
        {
            Class_langage v = new Class_langage();
            if (metroTextBox_add_langage_number1.Text != "")
            {
                v.langue = metroTextBox_add_langage_number1.Text;
                v.niveau = metroComboBox_niveau_langage_1.SelectedItem.ToString();
                c.Add(v);
            }
            v = new Class_langage();
            if (metroTextBox_add_langage_number2.Text != "")
            {
                v.langue = metroTextBox_add_langage_number2.Text;
                v.niveau = metroComboBox_niveau_langage_2.SelectedItem.ToString();
                c.Add(v);
            }
            v = new Class_langage();
            if (metroTextBox_add_langage_number3.Text != "")
            {
                v.langue = metroTextBox_add_langage_number3.Text;
                v.niveau = metroComboBox_niveau_langage_3.SelectedItem.ToString();
                c.Add(v);
            }
        }

        private void metroButton_save_another_langage_Click(object sender, EventArgs e)
        {
            proc_langages();
            vider();
        }

        private void metroButton_add_langage_save_close_Click(object sender, EventArgs e)
        {
            proc_langages();
            Program.new_candidat_to_add.son_langages = c;
            Close();
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void vider()
        {
            metroTextBox_add_langage_number1.Text = "";
            metroTextBox_add_langage_number2.Text = "";
            metroTextBox_add_langage_number3.Text = "";
        }
    }
}
