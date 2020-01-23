using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samsonov_ProjectForTech
{
    public partial class GenealogicalTree : Form
    {
        private Graph graph;
        private RunAndStrartTree runAndStrartTree;
        public GenealogicalTree(Tree tree, Graph graph, RunAndStrartTree runAndStrartTree)
        {
            InitializeComponent();
            this.graph = graph;
            pictureBox1.Size = new System.Drawing.Size(140, 140);
            pictureBox1.Image = tree.GetTree();
            this.runAndStrartTree = runAndStrartTree;

        }

        private void GenealogicalTree_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            runAndStrartTree.StartTable(graph);
        }
    }
}
