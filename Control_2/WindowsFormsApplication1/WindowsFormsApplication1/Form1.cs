using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 1;
            comboBox1.SelectedIndex = 0;
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = (int)numericUpDown2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            Matrix m = new Matrix(dataGridView1);
            Form2 f = new Form2();
            m.Output(f.dataGridView1);
            int rez;
            string label;
            if (comboBox1.SelectedIndex == 0)
            {
                rez = m.Min();
                label = "Минимум=";
            }
            else
            {
                rez = m.Max();
                label = "Максимум=";
            }
            f.panel1.Visible = true;
            f.textBox1.Text = rez.ToString();
            f.label2.Text = label;
            lightCells(rez, Color.Red, f.dataGridView1);
            lightCells(rez, Color.Blue, dataGridView1);
            f.ShowDialog();
            lightCells(rez, dataGridView1.DefaultCellStyle.BackColor, dataGridView1);
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }
        void lightCells(int value,Color color,DataGridView dgrv)
        {
            
            progressBar1.Maximum = dgrv.RowCount * dgrv.ColumnCount;
            for (int i = 0; i < dgrv.RowCount; i++)
                for (int j = 0; j < dgrv.ColumnCount; j++)
            {
                progressBar1.Increment(1); //progressBar1.Value++
                   if (Convert.ToInt32(dgrv[j, i].Value) == value)
                    dgrv[j, i].Style.BackColor = color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Matrix m = new Matrix(dataGridView1);
            Form2 f = new Form2();
            m.Output(f.dataGridView1);
            List<int> positiveItems=m.GetPositiveItems();
            progressBar1.Visible = true;
            progressBar1.Maximum=positiveItems.Count;
            foreach (int item in positiveItems)
            {
                progressBar1.Increment(1);
                f.listBox1.Items.Add(item);
            }
            f.groupBox1.Visible = true;
            f.ShowDialog();
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }
    }
}
