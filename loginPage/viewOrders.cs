using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using loginPage;

namespace loginPage
{
    public partial class viewOrders : Form
    {
        public viewOrders()
        {
            InitializeComponent();
        }

        private void viewOrders_Load(object sender, EventArgs e)
        {
            LoadAllOrders();

        }

        private void LoadAllOrders()
        {
            try
            {
                // Connection string for the database
                string connectionString = loginForm.connectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Command to execute the stored procedure
                    using (SqlCommand cmd = new SqlCommand("GetOrderDetails", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Use SqlDataAdapter to fetch data into a DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Bind the DataTable to DataGridView
                            ordersDataGridView.DataSource = dataTable;
                            ordersDataGridView.Columns["CustomerFirstName"].Width = 180;
                            ordersDataGridView.Columns["CustomerLastName"].Width = 180;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}");
            }
        }


    }
}
