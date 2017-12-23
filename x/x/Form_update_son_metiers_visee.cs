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
    public partial class Form_update_son_metiers_visee : MetroFramework.Forms.MetroForm
    {
        public Form_update_son_metiers_visee(int id_candidat)
        {
            InitializeComponent();
            my_id_candidat = id_candidat;
           
        }
        int my_id_candidat = 1;
        private void Form_update_son_metiers_visee_Load(object sender, EventArgs e)
        {
            //metroTextBox_update_emploi_visee_nom.Text = nom_;
            //metroTextBox_update_emploi_visee_prenom.Text = prenom_;
        }
    }
}
