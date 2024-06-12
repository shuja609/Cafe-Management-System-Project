using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cafeManagementSystem
{
    public partial class AddaCashier : Form
    {
        public AddaCashier()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddaCashier_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Get the entered values from your form's controls
            string cashierName = textBox1.Text;
            string username = textBox2.Text;
            string contactNo = textBox4.Text;
            string password = textBox3.Text;
            string email = textBox5.Text;
            int controllerCashRegistered = 1; 

            // SQL query to insert a new record into the Cashier table
            string query = "INSERT INTO Cashier (CashierName, Username, CashierContactno, Password, CashierEmail) " +
                           "VALUES (@CashierName, @Username, @CashierContactno, @Password, @CashierEmail)";

            using (SqlConnection connection = new SqlConnection("Data Source=Moeedspc\\SQLEXPRESS;Initial Catalog=CafeSystem;Integrated Security=True"))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                
                cmd.Parameters.AddWithValue("@CashierName", cashierName);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@CashierContactno", contactNo);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@CashierEmail", email);
                cmd.Parameters.AddWithValue("@ControllerCashRegistered", controllerCashRegistered);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cashier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add cashier. Please check the entered values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string username = textBox2.Text;

            // Check if the username already exists
            if (IsUsernameExists(username))
            {
                // Username already exists, show a message or perform an action
                MessageBox.Show("Username already exists. Please choose a different username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Optionally, clear the username textbox or take other actions
                textBox2.Text = string.Empty;
            }

        }
        private bool IsUsernameExists(string username)
        {
            // SQL query to check if the username already exists
            string query = "SELECT COUNT(*) FROM Cashier WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection("Data Source=Moeedspc\\SQLEXPRESS;Initial Catalog=CafeSystem;Integrated Security=True"))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                // Add parameters to the query to prevent SQL injection
                cmd.Parameters.AddWithValue("@Username", username);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query
                    int count = (int)cmd.ExecuteScalar();

                    // If count is greater than 0, the username already exists
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; // Assume an error, you might want to handle it differently
                }
            }
        }
            private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StaffManagement back=new StaffManagement();
            back.Show();
            this.Hide();
        }
    }
}
