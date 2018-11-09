using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
        void SaveTable(DataGridView Save)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "Save_plants.xlsx";

            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook workbook = excelapp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i=0; i<Save.RowCount + 1; i++)
            {
                for (int j = 0; j < Save.ColumnCount + 1; j++)
                {
                    //worksheet.Rows[i].Columns[j] = Save.Rows[i - 1].Cells[j - 1].Value;
                    worksheet.Rows[i].Columns[j] = Save.Rows[i - 1].Cells[j - 1].Value;
                }
            }
            excelapp.AlertBeforeOverwriting = false;
            workbook.SaveAs(path);
            excelapp.Quit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveTable(dataGridView1);
        }
    }
}
