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
            else if (Search.CheckName(textBox3.Text) == false || Search.CheckName(textBox4.Text) == false)
            {
                MessageBox.Show("Incorrect name");
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                int[] first = Search.SearchAll(textBox3.Text);
                int[] second = Search.SearchAll(textBox4.Text);
                if (first == null || second == null)
                {
                    MessageBox.Show("No such person");
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    //textBox2.Text = graph(textBox3.Text, textBox4.Text);
                }
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
