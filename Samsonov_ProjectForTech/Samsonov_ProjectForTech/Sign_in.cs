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
    public partial class Sign_in : Form
    {
        public Sign_in()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sign_up sign = new Sign_up();
            sign.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainPageSigned mainPageSigned = new MainPageSigned();
            mainPageSigned.Show();
            this.Close();
        }
    }
}
