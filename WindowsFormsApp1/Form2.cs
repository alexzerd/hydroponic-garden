using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string heater = textBox1.Text;
            string conditioner = textBox2.Text;
            string lamp = textBox3.Text;
            string humidifier = textBox4.Text;
            string irrigation = textBox5.Text;
            string dispenser = textBox6.Text;
            dataGridView1.Rows.Add(heater, conditioner, lamp, humidifier, irrigation, dispenser);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ind = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(ind);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                if((myStream=saveFileDialog1.OpenFile())!=null)
                {
                    StreamWriter myWriter = new StreamWriter(myStream);
                    try
                    {
                        for(int i=0; i<dataGridView1.RowCount-1; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                myWriter.Write(dataGridView1.Rows[i].Cells[j].Value.ToString()+" ");
                                    }
                            myWriter.WriteLine();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWriter.Close();
                    }
                    myStream.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader myReader = new StreamReader(myStream);
                    string[] str;
                    int num = 0;
                    try
                    {
                        string[] str1 = myReader.ReadToEnd().Split('\n');
                        num = str1.Count();
                        dataGridView1.RowCount = num;
                        for (int i = 0; i < num; i++)
                        {
                            str = str1[i].Split(' ');
                            for(int j=0; j<dataGridView1.ColumnCount; j++)
                            {
                                try
                                {
                                    dataGridView1.Rows[i].Cells[j].Value = str[j];
                                }
                                catch { }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myReader.Close();
                    }
                    myStream.Close();
                }
            }
        }
    }
}
