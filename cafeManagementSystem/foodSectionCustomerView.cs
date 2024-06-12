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
    public partial class foodSectionCustomerView : Form
    {
        private int Customerid;
        private int OrderID;
        private string connectionString;
        private bool flag = false;
        public foodSectionCustomerView(int Customerid=1)
        {
            connectionString = "Data Source= DESKTOP-R8AFJIC\\SQLEXPRESS;Initial Catalog=CafeSystem; Integrated Security=True; Encrypt=false";
            this.Customerid = Customerid;
            //MessageBox.Show(Customerid.ToString());
            InitializeComponent();

            //FoodSection.BackColor = Color.FromArgb(250, Color.Black);
            
            PopulateData();
            
            OrderID =InsertOrderData(connectionString,Customerid, 1);



        }


        
        public void PopulateData()
        {
           


            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();



            string query = "select * from Items";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                int size = 0;

                List<string> ItemID = new List<string>();
                List<string> ItemName = new List<string>();
                List<string> Descreption = new List<string>();
                List<string> Availibility = new List<string>();

                string in_cart = 0.ToString();
                while (reader.Read())
                {
                    ItemID.Add(reader["itemID"].ToString());
                    ItemName.Add(reader["itemName"].ToString());
                    Descreption.Add(reader["ItemDes"].ToString());
                    Availibility.Add(reader["ItemAvailibility"].ToString());
                   size++;
                }
                reader.Close();
               

                int i = 0;
                while (i < size) {
                    string Price_query = "select BasePrice from Pricing join Items on Pricing.PricingID = Items.priceid where Items.itemID = " + ItemID[i].ToString() ;
                    using (SqlCommand command = new SqlCommand(Price_query, sql))
                    {
                        command.Parameters.AddWithValue("@ItemID", ItemID[i]);

                        using (SqlDataReader Pricereader = command.ExecuteReader())
                        {
                           
                            if (Pricereader.Read())
                            {
                                string Price = Pricereader["BasePrice"].ToString();
                                //MessageBox.Show(size.ToString());
                                FoodSection.Rows.Add(ItemID[i], ItemName[i], Descreption[i], Availibility[i], Price, in_cart);

                            }
                            else
                            {
                                MessageBox.Show("No data found for the specified item ID.");
                            }
                        }
                    }

                    i++;
                }
     
              
            }
            else
            {
                MessageBox.Show("No Data");
            }



        }
        private void button1_Click(object sender, EventArgs e)
        {

            // Create an instance of the SignUpForm
            home signUpForm = new home();
            signUpForm.Show();
            // Optionally, you can hide the current form (assuming it's a login form)
            this.Hide();
        }


        static void UpdatePaymentStatusToPending(string connectionString, int orderId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Replace with your UPDATE query
                    string updateQuery = "UPDATE Orders SET payment_status = 'Pending' WHERE OrderID = @OrderId";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete from OrderedItems first
                DeleteOrderedItemsByOrderID(connectionString, OrderID);

                // Delete from Orders
                DeleteOrderByOrderID(connectionString, OrderID);

                Console.WriteLine("Rows deleted for OrderID: " + OrderID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            home Home = new home();
            Home.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FoodList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FoodSection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        static int InsertOrderData(string connectionString, int customerId, int iManagerId)
        {
            string insertQuery = "INSERT INTO Orders (Customerid, IManagerId) OUTPUT INSERTED.OrderID VALUES (@Customerid, @IManagerId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Customerid", customerId);
                    command.Parameters.AddWithValue("@IManagerId", iManagerId);

                    // ExecuteScalar returns the value of the first column of the first row
                    return (int)command.ExecuteScalar();
                }
            }
        }




        static bool TupleExists(int orderId, int itemId)
        {
            string query = "SELECT 1 FROM OrderedItems WHERE OrderID = @OrderID AND itemID = @itemID";

            using (SqlConnection connection = new SqlConnection("Data Source= DESKTOP-R8AFJIC\\SQLEXPRESS;Initial Catalog=CafeSystem; Integrated Security=True; Encrypt=false"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    command.Parameters.AddWithValue("@itemID", itemId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        static void InsertTuple(int orderId, int itemId, int quantity=0)
        {
            string insertQuery = "INSERT INTO OrderedItems (OrderID, itemID, quantity) VALUES (@OrderID, @itemID, @quantity)";

            using (SqlConnection connection = new SqlConnection("Data Source= DESKTOP-R8AFJIC\\SQLEXPRESS;Initial Catalog=CafeSystem; Integrated Security=True; Encrypt=false"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    command.Parameters.AddWithValue("@itemID", itemId);
                    command.Parameters.AddWithValue("@quantity", quantity);

                    command.ExecuteNonQuery();
                }
            }
        }

        static void UpdateQuantity(string connectionString, int orderId, int itemId, int quantityIncrement)
        {
            string updateQuery = "UPDATE OrderedItems SET quantity = quantity + @QuantityIncrement " +
                                 "WHERE OrderID = @OrderID AND itemID = @ItemID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@QuantityIncrement", quantityIncrement);
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    command.Parameters.AddWithValue("@ItemID", itemId);

                    command.ExecuteNonQuery();
                }
            }
        }


        static void DeleteOrderedItemsByOrderID(string connectionString, int orderId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM OrderedItems WHERE OrderID = @OrderId";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting from OrderedItems: " + ex.Message);
            }
        }

        static void DeleteOrderByOrderID(string connectionString, int orderId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Orders WHERE OrderID = @OrderId";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting from Orders: " + ex.Message);
            }
        }

        private void FoodSection_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int itemID = Convert.ToInt32(FoodSection.Rows[e.RowIndex].Cells["item_ID"].Value);
            int quantity = 1;

            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            if (FoodSection.Columns[e.ColumnIndex].HeaderText == "Add to Cart") //id add to cart is clicked
            {

               
                // Check if the tuple exists
                if (!TupleExists(OrderID, itemID))
                {
                    // If the tuple doesn't exist, insert a new one
                    InsertTuple( OrderID, itemID);
                    //Console.WriteLine("New tuple inserted!");
                }
                else
                {
                    FoodSection.Rows[e.RowIndex].Cells["cart"].Value = (Convert.ToInt32(FoodSection.Rows[e.RowIndex].Cells["cart"].Value) + 1).ToString();
                   

                    // Update and increment the quantity in the OrderedItems table
                    UpdateQuantity(connectionString, OrderID, itemID, 1);

                    //Console.WriteLine("Tuple already exists.");
                }


            }
            else if (FoodSection.Columns[e.ColumnIndex].HeaderText == "Remove from Cart") { //if Remove from cart is clicked
                
                if (Convert.ToInt32(FoodSection.Rows[e.RowIndex].Cells["cart"].Value) > 0 && flag) { 
                    UpdateQuantity(connectionString, OrderID, itemID, -1);
                    FoodSection.Rows[e.RowIndex].Cells["cart"].Value = (Convert.ToInt32(FoodSection.Rows[e.RowIndex].Cells["cart"].Value)-1 ).ToString();
                }
                flag = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Call the function to update payment_status
                UpdatePaymentStatusToPending(connectionString, OrderID);

                Console.WriteLine("Payment_status updated to 'Pending'");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            MessageBox.Show("Order Placed successfully");
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Delete from OrderedItems first
                DeleteOrderedItemsByOrderID(connectionString, OrderID);

                // Delete from Orders
                DeleteOrderByOrderID(connectionString, OrderID);

                Console.WriteLine("Rows deleted for OrderID: " + OrderID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            this.Close();


        }

        private void foodSectionCustomerView_Load(object sender, EventArgs e)
        {

        }
    }
}
