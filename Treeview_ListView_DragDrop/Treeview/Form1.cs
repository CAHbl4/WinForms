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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            treeView1.Nodes.Add(new TreeNode(@"d:\АЙТИШАГ"));
            BuildTree(treeView1.Nodes[0], @"d:\АЙТИШАГ");
            
            richTextBox1.AllowDrop = true;

            
            richTextBox1.DragEnter+=richTextBox1_DragEnter;
            richTextBox1.DragDrop+=richTextBox1_DragDrop;
        }

        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            textBox2.Text = e.Data.GetData(DataFormats.StringFormat).ToString();
            string fileName = textBox1.Text +@"\"+ textBox2.Text;
            using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
            {
                
                richTextBox1.Text = sr.ReadToEnd();
            }
        }

        private void richTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            //if (e.Data.GetDataPresent(DataFormats.StringFormat))
            //    e.Effect = DragDropEffects.Copy;
            //else
            //    e.Effect = DragDropEffects.None;
        }

        

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void BuildTree(TreeNode node,string dirName)
        {
            DirectoryInfo dir = new DirectoryInfo(dirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach(DirectoryInfo d in dirs)
            {
                TreeNode   currentNode =   new    TreeNode(d.Name);
                currentNode.ImageIndex = 0;
                node.Nodes.Add(currentNode);
                BuildTree(currentNode, d.FullName);
            }
            foreach(FileInfo f in dir.GetFiles())
            {
                TreeNode currentNode = new TreeNode(f.Name);
                
                node.Nodes.Add(currentNode);
            }
        }
       

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
             listView1.Items.Clear();
             if (e.Node.Nodes.Count != 0)
             {
                 textBox1.Text =  e.Node.FullPath;
                 foreach (TreeNode n in e.Node.Nodes)
                 {
                     
                     listView1.Items.Add(n.Text, n.ImageIndex);

                     listView1.Items[listView1.Items.Count - 1].SubItems.Add(File.GetCreationTime( n.FullPath).ToShortDateString());
                     //MessageBox.Show(listView1.Items[listView1.Items.Count - 1].SubItems[1].Text);

                 }
             }
             else
                 textBox1.Text = "";
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void deatailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                //if (listView1.SelectedItems.Count > 0)
                if (listView1.GetItemAt(e.X, e.Y) != null)
                listView1.DoDragDrop( listView1.GetItemAt(e.X,e.Y).Text, DragDropEffects.All);
        }

       
    }
}
