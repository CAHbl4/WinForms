using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu_Dialogs
{
    public enum DateTimeFormat { Data,Time}
    public partial class Form1 : Form
    {
        DateTimeFormat format;
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString();
            format = DateTimeFormat.Data;
            timer1.Start();
            trackBar1.Value = this.BackColor.R;
            trackBar2.Value = this.BackColor.G;
            trackBar3.Value = this.BackColor.B;
        }

        private void датаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString();
            format = DateTimeFormat.Data;
            
        }

        private void времяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongTimeString();
            format = DateTimeFormat.Time;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(format==DateTimeFormat.Time)
            {
                toolStripStatusLabel1.Text = DateTime.Now.ToLongTimeString();
            }
            else
            {
                toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString();
            }
           
        }
        void UpdateColor()
        {
            Color color = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            this.BackColor = color;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                trackBar1.Value = colorDialog1.Color.R;
                trackBar2.Value = colorDialog1.Color.G;
                trackBar3.Value = colorDialog1.Color.B;
            }

        }

    }
}
