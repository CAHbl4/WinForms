using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu__23_11
{
    public partial class Form1 : Form
    {
        bool isMenuAbleAdd;
        string textButton2english;
        string textButton2rusian;
        public Form1()
        {
            InitializeComponent();
            isMenuAbleAdd = true;
            textButton2english = "Add editing";
            textButton2rusian = "Добавить редактирование";
        }
        private void changeMenu(string language,MenuStrip menuVisible,MenuStrip menuUnvisible,string textButton)
        {
            button1.Text = language;
            button2.Text = textButton;
            menuUnvisible.Visible = false;
            menuVisible.Visible = true;
            this.MainMenuStrip = menuVisible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text.CompareTo("English")==0)
            {
                changeMenu("Русский", menuStrip2, menuStrip1,textButton2english);
                
            }
            else
            {
                changeMenu("English", menuStrip1, menuStrip2,textButton2rusian);
                
            }
        }

        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Red;
        }

        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Blue;
        }

        private void желтыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Yellow;
        }

        private void зеленыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Green;
            button1.BackColor = Color.Yellow;
        }

        private void черныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            button1.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            if (isMenuAbleAdd)
            {
                menuStrip1.Items.Add("Редактировать");
                menuStrip2.Items.Add("Edit");
                isMenuAbleAdd = false;
                textButton2rusian = "Отменить редактирование";
                textButton2english = "Cancel editing";
               
            }
            else
            {
                menuStrip1.Items.RemoveAt(menuStrip1.Items.Count-1);
                menuStrip2.Items.RemoveAt(menuStrip2.Items.Count - 1);
                isMenuAbleAdd = true;
                textButton2english = "Add editing";
                textButton2rusian = "Добавить редактирование";

            }//if (isMenuAbleAdd)
            if (button1.Text == "English")
                button2.Text = textButton2rusian;
            else
                button2.Text = textButton2english; 
        }
    }
}
