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

namespace Primer_16_11
{
    public partial class Form1 : Form
    {
        List<Student> students=new List<Student>() ;
        DateTime startTime;
        //DialogResult resForMessage=DialogResult.None; 
        int forMes = 0;
        public Form1()
        {
            InitializeComponent();
            startTime = DateTime.Now;
            timer1.Start();
            openFileDialog1.Filter = "Текстовые файлы|*.txt|Все файлы|*.*|Файлы C#|*.cs";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                using(StreamReader f=new StreamReader(openFileDialog1.FileName))
                {
                    students.Clear();
                   
                    while(!f.EndOfStream)
                    {
                        string[] s = f.ReadLine().Split(';');
                        students.Add(new Student { LastName = s[0], Age = int.Parse(s[1]), Ball = int.Parse(s[2]) });
                    }
                }
                dataGridView1.RowCount = students.Count;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1[0, i].Value = students[i].LastName;
                    dataGridView1[1, i].Value = students[i].Age;
                    dataGridView1[2, i].Value = students[i].Ball;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if((DateTime.Now-startTime).TotalMinutes>0.3)
            {
                //if (resForMessage == DialogResult.OK || resForMessage == DialogResult.Cancel)
                //{
                if(forMes==0)
                {
                    int days = (dateTimePicker1.Value - DateTime.Now).Days;
                    startTime = DateTime.Now;
                    forMes = 1;
                    MessageBox.Show("До экзамена осталось " + days+"  дней");
                    forMes = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult .OK)
            {
                using(StreamWriter f=new StreamWriter(saveFileDialog1.FileName))
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        string temp = dataGridView1[0, i].Value + ";" + dataGridView1[1, i].Value + ";" + dataGridView1[2, i].Value;
                        f.WriteLine(temp);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount++;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
    }
}
