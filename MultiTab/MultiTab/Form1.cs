using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testing;

namespace MultiTab
{
    public partial class Form1 : Form
    {
        

        Test test;
        public Form1()
        {
            InitializeComponent();
            test = Test.Get();
            test.Mode = TestMode.Trening;
            test.MinNumber = 1;
            test.MaxNumber = 10;
            test.QuestionCountExam = 5;
            test.TimeTest = 5;
            test.Generator = new RandomMultiGenrator(test.MinNumber, test.MaxNumber);
            
        }

        private void случайныеЧислаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void обучениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Text = "";
            groupBox1.Text = "Тренировка";
            test.Mode = TestMode.Trening;
            test.Run();
            
                label1.Text = test.GetQuestion();
                panel1.Visible = false;
             groupBox1.Visible = true;
             chart1.Visible = false;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = test.CheckAnswer(textBox1.Text);          
        }
        //кнопка еще
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Text = "";
            textBox1.Focus();
            if (test.State == TestState.Run)
                label1.Text = test.GetQuestion(); 
        }
        //завершение экзамена
        private void button3_Click(object sender, EventArgs e)
        {
            test.Stop();
            chart1.Series[0].Points.Clear();
            label2.Text = test.Result();
            chart1.Series[0].Points.AddY(test.CorrectAnswerCount);
            chart1.Series[0].Points[0].Label = "правильные ответы";
            chart1.Series[0].Points.AddY(test.QuestionCount-test.CorrectAnswerCount);
            chart1.Series[0].Points[1].Label = "неправильные ответы";
            chart1.Visible = true;
        }

        private void экзаменToolStripMenuItem_Click(object sender, EventArgs e)
        {
            test.Mode = TestMode.Exam;
            groupBox1.Text = "Экзамен";
            label2.Text = "";
            textBox1.Text = "";
            
            test.Run();

            label1.Text = test.GetQuestion();
            groupBox1.Visible = true;
            textBox1.Focus();
            
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            groupBox1.Visible = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            test.MinNumber = (int)numericUpDown1.Value;
            test.MaxNumber = (int)numericUpDown3.Value;
            test.TimeTest = (int)numericUpDown4.Value;
            test.QuestionCountExam = (int)numericUpDown5.Value;
            test.Generator = new RandomMultiGenrator(test.MinNumber, test.MaxNumber);
            panel1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (test.Mode == TestMode.Trening)
            {
                List<string> help = test.GetHelp();
                Form2 formHelp = new Form2();
                formHelp.dataGridView1.RowCount = help.Count();
                for (int i = 0; i < help.Count(); i++)
                {
                    formHelp.dataGridView1[0, i].Value = help[i];
                }
                formHelp.ShowDialog();
            }
        }
    }
}
