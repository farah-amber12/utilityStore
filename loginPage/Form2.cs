using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using loginPage;

namespace UtilityStoreApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome to the Dashboard!";
        }

        private void btnViewCategories_Click(object sender, EventArgs e)
        {
            DisplayData("SELECT * FROM Categories");
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            DisplayData("SELECT * FROM Products");
        }

        private void btnViewCustomers_Click(object sender, EventArgs e)
        {
            DisplayData("SELECT * FROM Customers");
        }

        private void btnManageStaff_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Staff clicked.");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new loginPage.Form1();
            login.Show();
        }

        private void DisplayData(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Form1.connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    var dt = new System.Data.DataTable();
                    da.Fill(dt);
                    dataGridView.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
