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
    public partial class Cashier_Payment : Form
    {
        private int Orderid;
        private int amount;
        private int cashback;
        private int amountpaid;
        private string connectionstring;
        public Cashier_Payment(int Orderid,int Amount )
        {
            DateTime currentDateTime = DateTime.Now;

            MessageBox.Show(currentDateTime.ToString());
            connectionstring = "Data Source= DESKTOP-R8AFJIC\\SQLEXPRESS;Initial Catalog=CafeSystem; Integrated Security=True; Encrypt=false";
            InitializeComponent();
            this.amount = Amount;
            this.Orderid = Orderid;
            ShowAmount.Text = Amount.ToString();
            


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        static int InsertPaymentData(string connectionString, int orderId, int amount, int amountPaid, int cashBackToCustomer, DateTime paymentDate)
        {
            int paymentId = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Payment (OrderId, Amount, AmountPaid, CashBackToCustomer, PaymentDate) " +
                                         "OUTPUT INSERTED.PaymentID " +
                                         "VALUES (@OrderId, @Amount, @AmountPaid, @CashBackToCustomer, @PaymentDate)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@AmountPaid", amountPaid);
                        command.Parameters.AddWithValue("@CashBackToCustomer", cashBackToCustomer);
                        command.Parameters.AddWithValue("@PaymentDate", paymentDate);

                        // ExecuteScalar returns the value of the first column of the first row
                        paymentId = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return paymentId;
        }

        static void UpdatePaymentStatus(string connectionString, int orderID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Orders SET payment_status = 'Paid' WHERE OrderID = @OrderID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", orderID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (!(cashback < 0))
            {
                UpdatePaymentStatus(connectionstring, Orderid);
                MessageBox.Show("Payment Paid");
                DateTime currentDateTime = DateTime.Now;
                int paymentif=InsertPaymentData(connectionstring,Orderid,amount,amountpaid,cashback, currentDateTime);
                
                CashierOrdersSection cashierOrdersSection = new CashierOrdersSection();
                cashierOrdersSection.Show();    
                this.Hide();
            }
            else {
                MessageBox.Show("Insufficient Amount Paid");
            }
        }

        private void EnteredAmount_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(EnteredAmount.Text);
            cashback = Convert.ToInt32(EnteredAmount.Text) - amount;
            amountpaid = cashback+amount;
            CashBackOutput.Text = cashback.ToString();
            //MessageBox.Show(amountpaid.ToString());

        }

        private void ShowAmount_Click(object sender, EventArgs e)
        {
        }

        private void CashBackOutput_Click(object sender, EventArgs e)
        {

        }

        private void BackButtom_Click(object sender, EventArgs e)
        {
            CashierOrdersSection cashierOrdersSection = new CashierOrdersSection();
            cashierOrdersSection.Show();
            this.Hide();
        }

        private void Cashier_Payment_Load(object sender, EventArgs e)
        {

        }
    }
}
