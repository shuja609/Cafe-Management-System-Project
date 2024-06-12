using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeManagementSystem
{
    public partial class CashierOrdersSection : Form
    {
        string connectionString = "Data Source= DESKTOP-R8AFJIC\\SQLEXPRESS;Initial Catalog=CafeSystem; Integrated Security=True; Encrypt=false";

        public CashierOrdersSection()
        {
            InitializeComponent();
            PopulateDataGridView();
        }


        private void PopulateDataGridView()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT O.OrderID, C.FullName AS CustomerName, SUM(P.BasePrice * OI.quantity) AS PaymentAmount " +
                                   "FROM Orders O " +
                                   "JOIN Customer C ON O.Customerid = C.CustomerId " +
                                   "LEFT JOIN OrderedItems OI ON O.OrderID = OI.OrderID " +
                                   "LEFT JOIN Items I ON OI.itemID = I.ItemID " +
                                   "LEFT JOIN Pricing P ON I.priceid = P.PricingID " +
                                   "WHERE O.payment_status = 'Pending' " +
                                   "GROUP BY O.OrderID, C.FullName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int orderID = reader.GetInt32(reader.GetOrdinal("OrderID"));
                                string customerName = reader["CustomerName"].ToString();
                                decimal paymentAmount = Convert.ToDecimal(reader["PaymentAmount"].ToString());

                                dataGridView1.Rows.Add(orderID, customerName, paymentAmount);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cashier cashier = new Cashier();
            cashier.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Proceed Payment")
            {
                int orderId =Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["order_no"].Value);

                int amount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PaymentAmount"].Value);
                Cashier_Payment cashier_Payment = new Cashier_Payment(orderId, amount);
                cashier_Payment.Show(); 
                this.Hide();
            }
        }

        private void CashierOrdersSection_Load(object sender, EventArgs e)
        {

        }
    }
}
