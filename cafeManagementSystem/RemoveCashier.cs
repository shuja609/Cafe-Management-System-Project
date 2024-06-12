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

namespace cafeManagementSystem
{
    public partial class RemoveCashier : Form
    {
        public RemoveCashier()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                // Get the username to identify the cashier to be removed
                string usernameToRemove = textBox1.Text;

                // SQL query to remove the cashier based on the username
                string query = "DELETE FROM Cashier WHERE Username = @Username";

                using (SqlConnection connection = new SqlConnection("Data Source=Moeedspc\\SQLEXPRESS;Initial Catalog=CafeSystem;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Add parameters to the query to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Username", usernameToRemove);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cashier removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No cashier found with the specified username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            StaffManagement goback=new StaffManagement();
            goback.Show();
            this.Hide();
        }

        private void RemoveCashier_Load(object sender, EventArgs e)
        {

        }
    }
    }

