using loginPage;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Runtime.CompilerServices;



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
                Location = new Point(this.ClientSize.Width / 2, 0), // Start at the middle of the form
                Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height), // Cover the right half
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right, // Responsive anchoring
                BorderStyle = BorderStyle.Fixed3D,
                BackgroundColor = Color.White
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
           StaffForm staffForm = new StaffForm();
            this.Close();
            staffForm.ShowDialog();
            staffForm.Show();
            

        }
            

        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            Categories catForm = new Categories();
            this.Close();
            catForm.ShowDialog();
            catForm.Show();

        }

        #region Event Handlers
        private void btnManageSupplierDebt_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm();
            this.Close();
            supplierForm.ShowDialog();
            supplierForm.Show();
            

        }

        private void btnManageCustomerDebt_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            this.Close();
            customerForm.ShowDialog();
            customerForm.Show();
        }
        #endregion

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            var data = ExecuteQuery("SELECT * FROM Products");
            LoadDataToGrid(data);
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
           viewOrders vo = new viewOrders();
            this.Close();
            vo.ShowDialog();
            vo.Show();

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}