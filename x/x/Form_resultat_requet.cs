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
using Excel = Microsoft.Office.Interop.Excel;
namespace x
{
    public partial class Form_resultat_requet : MetroFramework.Forms.MetroForm
    {
        public Form_resultat_requet(ArrayList the_list_to_contact)
        {
            InitializeComponent();
            this.my_list = the_list_to_contact;
        }
        ArrayList my_list = new ArrayList();
        private void Form_resultat_requet_Load(object sender, EventArgs e)
        {
            System.Data.DataTable t0 = new System.Data.DataTable();
            t0 = Class_Database_app.get_INFOS_to_contact(my_list);
            dataGridView_requete.DataSource = t0;
           
        }

        private void metroButton_send_mail_Click(object sender, EventArgs e)
        {
            Form_envoyerEmails f = new Form_envoyerEmails();
            f.Show();
           
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form_add_sourcing f = new Form_add_sourcing(my_list);
        }

        private void metroButton_extract_excel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
     
        public void ExportToExcel() 
        { 
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application(); 
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing); 
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null; 
 
            try 
            { 
 
                worksheet = workbook.ActiveSheet; 
 
                worksheet.Name = "ExportedFromDatGrid"; 
 
                int cellRowIndex = 1; 
                int cellColumnIndex = 1; 
 
                //Loop through each row and read value from each column. 
                for (int i = 0; i < dataGridView_requete.Rows.Count ; i++) 
                {
                    for (int j = 0; j < dataGridView_requete.Columns.Count ; j++) 
                    { 
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1 && dataGridView_requete.Columns[j].HeaderText != null) 
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView_requete.Columns[j].HeaderText; 
                        }
                        if (dataGridView_requete.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView_requete.Rows[i].Cells[j].Value.ToString(); 
                        } 
                        cellColumnIndex++; 
                    } 
                    cellColumnIndex = 1; 
                    cellRowIndex++; 
                } 
 
                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog(); 
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"; 
                saveDialog.FilterIndex = 2; 
 
                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
                { 
                    workbook.SaveAs(saveDialog.FileName); 
                    MessageBox.Show("Export Successful"); 
                } 
            } 
            catch (System.Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            } 
            finally 
            { 
                excel.Quit(); 
                workbook = null; 
                excel = null; 
            } 
 
        } 
 
    }
}
