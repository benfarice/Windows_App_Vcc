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
    public partial class Form_add_sourcing : MetroFramework.Forms.MetroForm
    {
        ArrayList my_list_contact = new ArrayList();
        public Form_add_sourcing(ArrayList my_list)
        {
            InitializeComponent();
            this.my_list_contact = my_list;
        }

        private void Form_add_sourcing_Load(object sender, EventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton_save_sourcing_Click(object sender, EventArgs e)
        {
            Boolean it_is_ok = false;
            foreach (int id in my_list_contact)
            {
                string query_sourcing = "insert into sourcing(ID_candidat,date_soorcing,poste,Entreprise,resultat)";
                query_sourcing += "values("+id+",'"+dateTimePicker_sourcing_date.Value
                    +"','"+metroTextBox_add_sourcing_poste.Text+"','"+
                    metroTextBox_add_sourcing_entreprise.Text+"','EnCours')";
                it_is_ok = Class_Database_app.add_sourcing(query_sourcing);

            }
            if (it_is_ok)
            {
                DialogResult c = MessageBox.Show("tout a bien faite","ok",MessageBoxButtons.OK);
                if (c == DialogResult.OK) {
                    Close();
                }
            }
        }
    }
}
