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
    public partial class Inventory : Form
    {
        private string connectionString;
        public Inventory()
        {
            connectionString = "Data Source= DESKTOP-R8AFJIC\\SQLEXPRESS;Initial Catalog=CafeSystem; Integrated Security=True; Encrypt=false";
            InitializeComponent();
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



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            LoadItemsForCategory(comboBox1.Text,connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRemoveItem addremove =new AddRemoveItem();
            addremove.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CafeManager manager = new CafeManager();
            manager.Show();
            this.Hide();
        }
    }
}
