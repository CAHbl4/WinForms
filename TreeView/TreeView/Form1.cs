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

namespace TreeView
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        void BuildTree(string directoryName,TreeNode parent)
        {
            DirectoryInfo dir = new DirectoryInfo(directoryName);
            DirectoryInfo[] directories = dir.GetDirectories();
            
                foreach(DirectoryInfo d in directories)
                {
                    //try
                    //{
                        TreeNode node = new TreeNode(d.Name);
                        parent.Nodes.Add(node);
                        BuildTree(d.FullName, node);
                        if (parent == treeView1.Nodes[0])
                            progressBar1.Value++;
                    //}
                    //catch (Exception e)
                    //{

                    //    parent.Nodes.Add(e.Message);
                    //}
                }
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo item in files)
                {
                    TreeNode node = new TreeNode(item.Name);
                    node.ImageIndex = 2;
                    parent.Nodes.Add(node);
                }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            progressBar1.Value = 0;
            string dirName = comboBox1.SelectedItem.ToString();
            progressBar1.Maximum = Directory.GetDirectories(dirName).Length;
            treeView1.Nodes.Add(dirName);
            BuildTree(dirName, treeView1.Nodes[0]);
            
        }
    }
}
