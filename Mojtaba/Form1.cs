using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mojtaba
{
    public partial class Form1 : Form
    {

        const int NUM_OF_COLUMN = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] matris = new int[dataGridView1.Rows.Count - 1, NUM_OF_COLUMN];
            
            foreach (DataGridViewRow row in dataGridView1.Rows) // ROWS
            {  
                foreach( DataGridViewCell cells in row.Cells ) { // CELLS
                    if (cells.Value != null)
                    {
                        matris[row.Index, cells.ColumnIndex] = int.Parse(cells.Value.ToString());
                    }
                   
                }
            }

            // DECODE
            this.decodedGrid.Rows.Clear();
            this.decodedGrid.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            int rowNumber = dataGridView1.Rows.Count;
            label1.Text = string.Format("Rows : {0}", (rowNumber + 1 ).ToString());
            int[,] matrisDecode = new int[dataGridView1.Rows.Count - 1, 3];

            for (int i = 0; i < rowNumber  - 1; i++)
            {
                DataGridViewRow row = new DataGridViewRow();

                for (int j = 0; j < NUM_OF_COLUMN; j++)
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    //newRow.CreateCells(
                    // decodedGrid.Rows.AddRange(new 0));
                    var value = matris[i, j];
                    if(value != null && value != 0) {
                        row.CreateCells(this.decodedGrid);
                        row.CreateCells(this.decodedGrid);
                        row.CreateCells(this.decodedGrid);

                        /*matrisDecode[i, 0] = i;
                        matrisDecode[i, 0] = j;
                        matrisDecode[i, 0] = value;*/

                        row.Cells[0].Value = i;
                        row.Cells[1].Value = j;
                        row.Cells[2].Value = value;

                        this.decodedGrid.Rows.Add(row);
                    }
                }   
            }
            // decodedGrid.Rows.AddRange();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView2.Rows.Count > 4)
            {
                MessageBox.Show("Your row more than 3 number please delete a rows!!");
                return;
            }
            // TARANAHADE
            this.dataGridView3.Rows.Clear();

            int[,] matris = new int[3, 3];

            foreach (DataGridViewRow row in dataGridView2.Rows) // ROWS
            {
                dataGridView3.Rows.Add(new DataGridViewRow());
                foreach (DataGridViewCell cells in row.Cells)
                { // CELLS
                    if (cells.Value != null)
                    {
                        matris[row.Index, cells.ColumnIndex] = int.Parse(cells.Value.ToString());
                    }

                }
            }

           


            for (int i = 0; i < 3; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                for (int j = 0; j < 3; j++)
                {
                    dataGridView3.Rows[j].Cells[i].Value = matris[i, j].ToString();
                }
            }
        }
    }
}
