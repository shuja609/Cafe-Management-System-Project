using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;



namespace cafeManagementSystem
{
    public partial class Signup : Form
    {
        private Label labelStatus;
        public Signup()
        {
            InitializeComponent();
            // Initialize and configure labelStatus
            labelStatus = new Label();
            labelStatus.Location = new System.Drawing.Point(500, 500); // Adjust the location as needed
            labelStatus.AutoSize = true;
            Controls.Add(labelStatus); // Add the label to the form
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox5.PasswordChar = '\0';
            }
            else
            {
                textBox5.PasswordChar = '*';
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            // Access the text of the password box
            string password = textBox5.Text;

            // Check if the password is more than 8 characters
            if (password.Length > 8)
            {
                // Show a message box indicating that the password is too short
                MessageBox.Show("Password must be at least 8 characters long", "Invalid Password",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Clear the password box (optional)
                textBox5.Clear();
            }
            else
            {

                
            }
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
            string query = "SELECT COUNT(*) FROM Customer WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection("Data Source= DESKTOP-R8AFJIC\\SQLEXPRESS;Initial Catalog=CafeSystem; Integrated Security=True; Encrypt=false"))
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
        bool IsValidEmail(string email)
        {
            // Regular expression for basic email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Get the entered email
            string email = textBox3.Text;

          
           

        }
       
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string contact=textBox4.Text;
            if(contact.Length>11)
            {
                MessageBox.Show("Contact No is no more than 11 digits", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
             string ConnectionString = "Data Source= DESKTOP-R8AFJIC\\SQLEXPRESS;Initial Catalog=CafeSystem; Integrated Security=True; Encrypt=false";
            string fullName = textBox1.Text;
            string username = textBox2.Text;
            string email = textBox3.Text; // Note: Hash and salt your password for security
            string contactNo = textBox4.Text;
            string password = textBox5.Text;
            string insertQuery = "INSERT INTO Customer (FullName, Email, Password, ContactNo, Username) " +
                     "VALUES (@FullName, @Email, @Password, @ContactNo, @Username)";

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(insertQuery, connection);
            // Add parameters to the query to prevent SQL injection
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@ContactNo", contactNo);
            cmd.Parameters.AddWithValue("@Username", username);
            int rowsAffected = cmd.ExecuteNonQuery();

            // Check if the query executed successfully
            if (rowsAffected > 0)
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
