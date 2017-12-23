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
    public partial class Form_add_phone : MetroFramework.Forms.MetroForm
    {
        public Form_add_phone(string nom,string prenom)
        {
            InitializeComponent();
            this.nom_ = nom;
            this.prenom_ = prenom;
        }
        String nom_;
        String prenom_;
       
        List<int> my_phones = new List<int>();
        List<Class_telephone> c = new List<Class_telephone>();
        public void phone_proc()
        {
            try
            {
                if (metroTextBox_add_phone_number1.Text != "")
                { 
                    int x =  int.Parse(metroTextBox_add_phone_number1.Text);
                    if(x > 100000000)
                    my_phones.Add(x); 
                
                }
                if (metroTextBox_add_phone_number2.Text != "")
                {
                    int x = int.Parse(metroTextBox_add_phone_number2.Text);
                    if (x > 100000000)
                    my_phones.Add(x);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            

        }
        private void Form_add_phone_Load(object sender, EventArgs e)
        {
            metroTextBox_add_phone_nom.Text = nom_;
            metroTextBox_add_phone_prenom.Text = prenom_;
        }

        private void metroButton_add_phone_save_close_Click(object sender, EventArgs e)
        {
            
            phone_proc();
            foreach (int p in my_phones)
            {
                Class_telephone t = new Class_telephone();
                t.numero = p;
                c.Add(t);
            }
            Program.new_candidat_to_add.Son_telephones = c;
            Close();
        }

        private void metroButton_add_phone_save_another_Click(object sender, EventArgs e)
        {
            phone_proc();
            metroTextBox_add_phone_number1.Text = "";
            metroTextBox_add_phone_number2.Text = "";
            
        }

        private void metroTextBox_add_phone_number1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void metroTextBox_add_phone_number2_TextChanged(object sender, EventArgs e)
        {
           
        }
        
        private void metroTextBox_add_phone_nom_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox_add_phone_number2_Click(object sender, EventArgs e)
        {

        }
    }
}
