using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using loginPage;

namespace UtilityStoreApp
{
    public partial class Form2 : Form
    {
        private readonly SqlConnection dbConnection;

        public Form2()
        {
            InitializeComponent();
            dbConnection = new SqlConnection(Form1.connectionString);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, Owner!";
        }

        private void LoadTableData(string tableName)
        {
            try
            {
                dbConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {tableName}", dbConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {tableName}: {ex.Message}");
            }
            finally
            {
                if (dbConnection.State == System.Data.ConnectionState.Open) dbConnection.Close();
            }
        }

        private void btnViewCategories_Click(object sender, EventArgs e) => LoadTableData("Categories");
        private void btnViewProducts_Click(object sender, EventArgs e) => LoadTableData("Products");
        private void btnViewCustomers_Click(object sender, EventArgs e) => LoadTableData("Customers");
        private void btnManageStaff_Click(object sender, EventArgs e) => LoadTableData("Staff");
        private void btnViewOrderDetail_Click(object sender, EventArgs e) => LoadTableData("OrderDetail");

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are logged out!");
            Application.Exit();
        }
    }
}
