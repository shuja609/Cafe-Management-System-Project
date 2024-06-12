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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Create an instance of the SignUpForm
            Signup signUpForm = new Signup();
            signUpForm.Show();
            // Optionally, you can hide the current form (assuming it's a login form)
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            // Create an instance of the SignUpForm
            login signUpForm = new login();
            signUpForm.Show();
            // Optionally, you can hide the current form (assuming it's a login form)
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Create an instance of the SignUpForm
            foodSection main = new foodSection();
            main.Show();
            // Optionally, you can hide the current form (assuming it's a login form)
            this.Hide();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }
    }
}
