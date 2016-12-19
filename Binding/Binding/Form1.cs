using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binding
{
    public partial class Form1 : Form
    {
        List<Dog> dogs = new List<Dog>();
        BindingSource source = new BindingSource();
        public Form1()
        {
            InitializeComponent();                     
            source.DataSource = dogs;
            dataGridView1.DataSource = source;
            dataGridView1.Columns[0].HeaderText = "Кличка";
            dataGridView1.Columns[1].HeaderText = "Владелец";
            dataGridView1.Columns[2].HeaderText = "Высота в холке";
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                source.Clear();
                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] temp = reader.ReadLine().Split(';');
                        source.Add(new Dog { Name = temp[0], Owner = temp[1], Height = double.Parse(temp[2]) });
                    }

                }

            }
           
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
                using(StreamWriter writer=new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (var item in dogs)
                    {
                        writer.WriteLine(item.Name + ";" + item.Owner + ";" + item.Height); 
                    }
                }
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
           textBox1.Text= dogs.Count<Dog>(d => d.Height > 25).ToString();
           dataGridView1[0,0].Style.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            source.Add(new Dog());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
