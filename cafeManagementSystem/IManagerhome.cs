using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeManagementSystem
{
    public partial class IManagerhome : Form
    {
        public IManagerhome()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            home Home = new home();
            Home.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inventory inshow = new Inventory();
            inshow.Show();
            this.Hide();
        }

        private void IManagerhome_Load(object sender, EventArgs e)
        {

        }
    }
}
