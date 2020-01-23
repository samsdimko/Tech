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
    public partial class GenealogicalTreeTable : Form
    {
        private RunAndStrartTree runAndStrartTree;
        private string[] table;
        public GenealogicalTreeTable(string[] table, RunAndStrartTree runAndStrartTree)
        {
            InitializeComponent();
            this.runAndStrartTree = runAndStrartTree;
            this.table = table;
            listBox1.Items.AddRange(table);            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            runAndStrartTree.StartTree();
        }
    }
}
