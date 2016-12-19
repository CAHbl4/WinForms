using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGraphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics painter = panel1.CreateGraphics();
            
            Pen pen = new Pen(Color.Red,9);
            pen.DashPattern=new float[] {5,3,2,3};
            pen.CompoundArray = new float[] { 0.0f, 0.2f,0.4f, 0.6f,0.8f, 1f };
            pen.EndCap = LineCap.ArrowAnchor;
            painter.DrawLine(pen, 0, 0, 30, 150);
        }
    }
}
