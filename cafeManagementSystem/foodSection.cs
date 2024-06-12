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
    public partial class foodSection : Form
    {
         private string connectionString;
        public foodSection()
        {
            connectionString = "Data Source= DESKTOP-R8AFJIC\\SQLEXPRESS;Initial Catalog=CafeSystem; Integrated Security=True; Encrypt=false";
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Create an instance of the SignUpForm
            home signUpForm = new home();
            signUpForm.Show();
            
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            home Home = new home();
            Home.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadItemsForCategory(string categoryName, string connectionString)
        {
            // SQL query to retrieve items for a specific category
            string query = "SELECT Items.ItemID, Items.ItemName, Items.ItemDes, Items.ItemAvailibility, Items.priceid, Items.quantity " +
                           "FROM Items " +
                           "INNER JOIN CategoriesHasItems ON Items.ItemID = CategoriesHasItems.ItemID " +
                           "INNER JOIN Categories ON CategoriesHasItems.CategoryID = Categories.CategoryID " +
                           "WHERE Categories.CategoryName = @CategoryName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@CategoryName", categoryName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing rows in DataGridView
                        items.Rows.Clear();

                        // Populate DataGridView using while loop
                        while (reader.Read())
                        {
                            DataGridViewRow row = (DataGridViewRow)items.Rows[0].Clone();
                            row.Cells[0].Value = reader["ItemID"].ToString();
                            row.Cells[1].Value = reader["ItemName"].ToString();
                            row.Cells[2].Value = reader["priceid"].ToString();
                            row.Cells[3].Value = reader["quantity"].ToString();
                            items.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItemsForCategory(comboBox1.Text, connectionString);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
