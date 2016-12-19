using Presentention.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP
{
    public partial class Form1 : Form,IMainView
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<string> Surnames
        {
            get;
            set;
        }

        public List<string> Names
        {
            get;
            set;
        }

        public List<double> Heights
        {
            get;
            set;
        }

        public List<int> Balls
        {
            get;
            set;
        }

        public event Action Open;

        public void ShowAll()
        {
            dataGridView1.RowCount = Surnames.Count;
            for(int i=0; i<dataGridView1.RowCount; i++)
            {
                dataGridView1[0, i].Value = Surnames[i];
                dataGridView1[1, i].Value = Names[i];
                dataGridView1[2, i].Value = Heights[i];
                dataGridView1[3, i].Value = Balls[i];

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Open();
        }
        public new void Show()
        {
            Application.Run(this);
        }
    }
}
