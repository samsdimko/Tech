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
    public partial class MainPageUnsigned : Form
    {
        public MainPageUnsigned()
        {
            InitializeComponent();
            listBox1.Items.Add(TableMain.SetList());
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sign_in sign_in = new Sign_in();
            sign_in.Show();
            this.Hide();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var searchQuery = textBox1.Text;

            int[] find = Dataset.PersonList.Where(x => x.GetFullName().Contains(searchQuery) ||
                                                       x.GetAddress().Contains(searchQuery) ||
                                                       x.GetPlaceOfBirth().Contains(searchQuery))
                                                       .Select(x => x.GetId()).ToArray();
            if (find == null)
            {
                MessageBox.Show("No such person");
                textBox1.Text = "";
            }
            else
            {
                RunAndStrartTree runAndStrartTree = new RunAndStrartTree(find[0]);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Select two persons");
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else if (false)//TODO Check for correct names//Search.CheckName(textBox3.Text) == false || Search.CheckName(textBox4.Text) == false)
            {
                MessageBox.Show("Incorrect name");
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                var firstPerson = Dataset.GetPersonByName(textBox3.Text);
                var secondPerson = Dataset.GetPersonByName(textBox4.Text);
                if (secondPerson == null || firstPerson == null)
                {
                    MessageBox.Show("No such person");
                    textBox3.Text = "";
                    textBox4.Text = "";
                    return;
                }
                int firstId = firstPerson.GetId();
                int secondId = secondPerson.GetId();

                //TODO Stuff with 2 persons
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainPageUnsigned_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
