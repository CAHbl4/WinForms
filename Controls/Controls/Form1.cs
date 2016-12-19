using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
    public partial class Form1 : Form
    {
        Form2 f;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
            f = new Form2();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Array arr = new Array(dataGridView1);
            int result;
            string label;
            int loc;
            if(radioButton1.Checked)
            {
                result = arr.Sum();
                label = "Сумма=";
                loc = 0;
            }
            else
            {
                result = arr.Pro();
                label = "Произведение=";
                loc = 70;
            }
            Form3 res = new Form3();
            res.textBox1.Text = result.ToString();
            res.label1.Text = label;
            int x = res.textBox1.Location.X;
            int y = res.textBox1.Location.Y;
            res.label1.Location =new Point(x-90-loc,y);
            arr.Output(res.dataGridView1);
            res.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            f.Show();
        }
    }
}
