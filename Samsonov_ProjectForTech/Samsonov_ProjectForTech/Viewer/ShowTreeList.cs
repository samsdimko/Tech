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
    public partial class ShowTreeList : Form
    {
        private List<string> namesToShow;
        private ContainerId containerId;
        public ShowTreeList(int[] ids, ContainerId containerId = null)
        {
            this.containerId = containerId;
            InitializeComponent();
            namesToShow = new List<string>();
            foreach (int Id in ids)
            {
                namesToShow.Add(Dataset.PersonList.First(x => x.GetId() == Id).GetFullName());
            }
            string[] names = namesToShow.ToArray();
            listBox2.Items.AddRange(names);
            
        }
        private void ShowTreeList_Load(object sender, EventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var name = listBox2.SelectedItem.ToString();
            containerId.ID = Dataset.PersonList.Find(x => x.GetFullName() == name).GetId();
            Close();
        }
    }


}
