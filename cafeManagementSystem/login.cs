using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeManagementSystem
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
            {
            }

        private void button2_Click(object sender, EventArgs e)
        {

            // Create an instance of the SignUpForm
            Signup signUpForm = new Signup();
            signUpForm.Show();
            // Optionally, you can hide the current form (assuming it's a login form)
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.PasswordChar= '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        static int GetCustomerIdByUsername( string username)
        {
            string query = "SELECT CustomerId FROM Customer WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection("Data Source= DESKTOP-R8AFJIC\\SQLEXPRESS;Initial Catalog=CafeSystem; Integrated Security=True; Encrypt=false"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        // If a record is found, return the CustomerId
                        return (int)result;
                    }
                    else
                    {
                        // If no record is found, return -1 or any other suitable indicator
                        return -1;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the entered username and password
            string username = textBox1.Text;
            string password = textBox2.Text;


            // Check each user table one by one
            if (IsUserExists(username, password, "Customer"))
            {
                // Customer login logic
                int Customerid=GetCustomerIdByUsername(username);
                foodSectionCustomerView foodsection = new foodSectionCustomerView(Customerid);    
                foodsection.Show();
                this.Hide();
                //MessageBox.Show("Customer logged in!");
            }
            else if (IsUserExists(username, password, "Cashier"))
            {
                // Cashier login logic
                //MessageBox.Show("Cashier logged in!");
                Cashier cashier = new Cashier();
                cashier.Show();
                this.Hide();
            }
            else if (IsUserExists(username, password, "CafeManager"))
            {
                // Cafe Manager login logic
               // MessageBox.Show("Cafe Manager logged in!");
                CafeManager cafeManager=new CafeManager();
                cafeManager.Show();
                this.Hide();
            }
            else if (IsUserExists(username, password, "InventoryManager"))
            {
                // Inventory Manager login logic
                // MessageBox.Show("Inventory Manager logged in!");
                IManagerhome inventoryManager = new IManagerhome();
                inventoryManager.Show();
                this.Hide();
            }
            else
            {
                // No match found
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsUserExists(string username, string password, string tableName)
        {
            // SQL query to check if the user exists in the specified table
            string query = $"SELECT 1 FROM {tableName} WHERE Username = @Username AND Password = @CPassword";

            using (SqlConnection connection = new SqlConnection("Data Source= DESKTOP-R8AFJIC\\SQLEXPRESS;Initial Catalog=CafeSystem; Integrated Security=True; Encrypt=false"))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            { 
                // Add parameters to the query to prevent SQL injection
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@CPassword", password);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query
                    object result = cmd.ExecuteScalar();

                    // If result is not null, the user exists
                    return result != null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; // Assume an error, you might want to handle it differently
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home back = new home();
            back.Show();
            this.Hide();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
