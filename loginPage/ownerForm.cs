﻿using loginPage;
using System.Data;
using Microsoft.Data.SqlClient;



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

        #region Event Handlers
        private void btnManageSupplierDebt_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            SupplierDebt.SupplierDebtID, 
            Supplier.SupplierName, 
            Supplier.ContactNumber, 
            Supplier.Address, 
            SupplierDebt.DebtAmount, 
            SupplierDebt.PaymentDueDate
        FROM 
            SupplierDebt
        INNER JOIN 
            Supplier ON SupplierDebt.SupplierID = Supplier.SupplierID";

            var data = ExecuteQuery(query);
            LoadDataToGrid(data);
        }

        private void btnManageCustomerDebt_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            CustomerDebt.CustomerDebtID, 
            Customers.FirstName + ' ' + Customers.LastName AS CustomerName, 
            Customers.Phone, 
            CustomerDebt.DebtAmount, 
            CustomerDebt.DueDate
        FROM 
            CustomerDebt
        INNER JOIN 
            Customers ON CustomerDebt.CustomerID = Customers.CustomerID";

            var data = ExecuteQuery(query);
            LoadDataToGrid(data);
        }
        #endregion

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        
    }
}