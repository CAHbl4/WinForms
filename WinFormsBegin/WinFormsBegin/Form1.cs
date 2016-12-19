using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsBegin
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            
            InitializeComponent();
            timer1.Start();
            Text = DateTime.Now.ToLongTimeString();
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal rubli = Convert.ToDecimal(textBox1.Text);
                decimal dollary = rubli / 1.9m;
                textBox2.Text = dollary.ToString();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X + " : " + e.Y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongTimeString();
        }

        
    }
}
