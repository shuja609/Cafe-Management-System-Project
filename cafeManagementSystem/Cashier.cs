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
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            home Home = new home();
            Home.Show();
            this.Hide();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CashierOrdersSection payment = new CashierOrdersSection();
            payment.Show();
            this.Hide();

        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
