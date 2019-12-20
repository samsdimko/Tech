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
    public partial class Adding : Form
    {
        public Adding()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||
                textBox2.Text == "" ||
                textBox3.Text == "" ||
                textBox4.Text == "" ||
                textBox5.Text == "" ||
                textBox6.Text == "" ||
                textBox7.Text == "" ||
                textBox8.Text == "" ||
                textBox9.Text == "" ||
                textBox10.Text == "" ||
                textBox11.Text == "" ||
                textBox12.Text == "" ||
                textBox13.Text == "" ||
                textBox14.Text == "" ||
                textBox15.Text == "" ||
                textBox16.Text == "" ||
                textBox17.Text == "" ||
                textBox18.Text == "" ||
                textBox19.Text == "" ||
                textBox20.Text == "" ||
                textBox21.Text == "")
            {
                MessageBox.Show("Not all textboxes are full");
            }
            else if ((textBox6.Text != "yes" && textBox6.Text != "no") || (textBox9.Text != "yes" && textBox9.Text != "no"))
            {
                MessageBox.Show("Incorrect 'yes/no' answers");
            }
            else
            {
                Person person = new Person(textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text,
                textBox6.Text,
                textBox7.Text,
                textBox8.Text,
                textBox9.Text,
                textBox10.Text,
                textBox11.Text,
                textBox12.Text,
                textBox13.Text,
                textBox14.Text,
                textBox15.Text,
                textBox16.Text,
                textBox17.Text,
                textBox18.Text,
                textBox19.Text,
                textBox20.Text);
                Dataset.DatasetAdd(person);
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
