using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using loginPage;
using Microsoft.Data.SqlClient;

namespace loginPage
{
    public partial class profit_information : Form
    {
        public profit_information()
        {
            InitializeComponent();
            LoadDailyProfitData();
        }

        private void DailyProfit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadDailyProfitData()
        {
            try
            {
                // Define the connection string (replace with your actual connection string)
                string connectionString = loginForm.connectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Define the query to fetch data from dailyProfit table
                    string query = "SELECT Dates, ProfitAmount FROM dailyProfit";

                    // Create a data adapter
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the data from the database
                    dataAdapter.Fill(dataTable);

                    // Bind the DataTable to the GridView
                    DailyProfit.DataSource = dataTable;
                    DailyProfit.Columns[0].Width = 320;

                    // Increase the width of the second column (e.g., ProfitAmount)
                    DailyProfit.Columns[1].Width = 320;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}
