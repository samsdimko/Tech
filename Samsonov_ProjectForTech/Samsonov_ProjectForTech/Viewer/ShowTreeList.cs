using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samsonov_ProjectForTech.Viewer
{
    public partial class ShowTreeList : Form
    {
        List<string> namesToShow;

        public ShowTreeList(int [] ids)
        {
            namesToShow = new List<string>();
            foreach (int id in ids)
            {
                namesToShow.Add(Dataset.PersonList.First(x => x.GetId() == id).GetFullName());
            }
            listBox1.DataSource = namesToShow;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = listBox1.SelectedItem.ToString();
            var id = Dataset.PersonList.Find(x => x.GetFullName() == name).GetId();
            RunAndStrartTree runAndStrartTree = new RunAndStrartTree(id);
        }
    }


}
