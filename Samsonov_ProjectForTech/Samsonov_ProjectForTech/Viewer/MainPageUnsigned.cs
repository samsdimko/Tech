using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Samsonov_ProjectForTech
{
    public partial class MainPageUnsigned : Form
    {
        Thread t1;
        public MainPageUnsigned()
        {
            InitializeComponent();            
            listBox1.Items.AddRange(TableMain.SetList());
            t1 = new Thread(time);
            t1.IsBackground = true; 
            t1.Priority = ThreadPriority.Lowest;
            t1.Start();

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPageSigned mainPageSigned = new MainPageSigned();
            mainPageSigned.Show();
            this.Hide();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchPresenter searchPresenter = new SearchPresenter(listBox1.SelectedItem.ToString());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("No such person");
            }
            else
            {
                SearchPresenter searchPresenter = new SearchPresenter(textBox1.Text);
                textBox1.Text = "";
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
            else 
            {
                string a = textBox2.Text;
                SearchPresenter searchPresenter = new SearchPresenter(textBox3.Text, textBox4.Text, ref a);
                textBox3.Text = "";
                textBox4.Text = "";
                textBox2.Text = a;
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

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            
        }
        private void time()
        {
            while (true)
            {
                toolStripStatusLabel1.Text = DateTime.Now.ToString() + "  Число зарегистрированных: " + Dataset.GetID().ToString();                
            }
        }
    }
}
