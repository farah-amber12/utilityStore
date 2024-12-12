using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using loginPage;

namespace UtilityStoreApp
{
    public partial class OwnerForm : Form
    {
        private readonly SqlConnection connection;

        public OwnerForm()
        {
            InitializeComponent();
            connection = new SqlConnection(loginForm.connectionString);

            // Set up the DataGridView dynamically
            InitializeDataGridView();
        }

        #region UI Initialization
        private DataGridView dataGridView;

        private void InitializeDataGridView()
        {
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Bottom,
                Height = 300
            };

            this.Controls.Add(dataGridView);
        }
        #endregion

        #region Database Query Execution
        private DataTable ExecuteQuery(string query)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return new DataTable();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        #endregion

        #region Event Handlers
        private void btnManageStaff_Click(object sender, EventArgs e)
        {
            var data = ExecuteQuery("SELECT * FROM Staff");
            LoadDataToGrid(data);
        }

        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            var data = ExecuteQuery("SELECT * FROM Categories");
            LoadDataToGrid(data);
        }

        private void btnManageSupplierDebts_Click(object sender, EventArgs e)
        {
            var data = ExecuteQuery("SELECT * FROM SupplierDebts");
            LoadDataToGrid(data);
        }

        private void btnManageCustomerDebts_Click(object sender, EventArgs e)
        {
            var data = ExecuteQuery("SELECT * FROM CustomerDebts");
            LoadDataToGrid(data);
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            var data = ExecuteQuery("SELECT * FROM Products");
            LoadDataToGrid(data);
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            var data = ExecuteQuery("SELECT * FROM Orders");
            LoadDataToGrid(data);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have successfully logged out.");
            this.Close();
        }
        #endregion

        private void LoadDataToGrid(DataTable data)
        {
            dataGridView.DataSource = data;
        }

        private void OwnerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
