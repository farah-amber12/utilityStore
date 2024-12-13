using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace loginPage
{
    public partial class SupplierForm : Form
    {
        private readonly string connectionString = loginForm.connectionString;

        public SupplierForm()
        {
            InitializeComponent();
        }

        // Load data when the form opens
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            RefreshSupplierData();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            string supplierName = txtSupplierName.Text.Trim();
            string contactNumber = txtContactNumber.Text.Trim();
            string address = txtAddress.Text.Trim();
            if (!decimal.TryParse(txtDebtAmount.Text.Trim(), out decimal debtAmount) || debtAmount < 0)
            {
                MessageBox.Show("Debt amount should be a positive number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime paymentDueDate = dateTimePickerPaymentDueDate.Value;

            // Validate contact number
            if (!Regex.IsMatch(contactNumber, @"^(03[0-9]{2}-[0-9]{7}|[0-9]{3}-[0-9]{7})$"))
            {
                MessageBox.Show("Invalid contact number. Should match mobile (e.g., 0300-XXXXXXX) or landline (e.g., 042-XXXXXXX)",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Use `using` for automatic disposal
                using (SqlConnection sconnection = new SqlConnection(connectionString))
                {
                    sconnection.Open();

                    // Insert supplier data
                    string supplierInsertQuery = "INSERT INTO Supplier (SupplierName, ContactNumber, Address) OUTPUT INSERTED.SupplierID VALUES (@SupplierName, @ContactNumber, @Address)";
                    SqlCommand supplierCommand = new SqlCommand(supplierInsertQuery, sconnection);
                    supplierCommand.Parameters.AddWithValue("@SupplierName", supplierName);
                    supplierCommand.Parameters.AddWithValue("@ContactNumber", contactNumber);
                    supplierCommand.Parameters.AddWithValue("@Address", address);

                    int supplierId = (int)supplierCommand.ExecuteScalar();

                    // Insert debt data
                    string debtInsertQuery = "INSERT INTO SupplierDebt (SupplierID, DebtAmount, PaymentDueDate) VALUES (@SupplierID, @DebtAmount, @PaymentDueDate)";
                    SqlCommand debtCommand = new SqlCommand(debtInsertQuery, sconnection);
                    debtCommand.Parameters.AddWithValue("@SupplierID", supplierId);
                    debtCommand.Parameters.AddWithValue("@DebtAmount", debtAmount);
                    debtCommand.Parameters.AddWithValue("@PaymentDueDate", paymentDueDate);

                    debtCommand.ExecuteNonQuery();

                    MessageBox.Show("Supplier and debt info successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh data and clear UI
                    RefreshSupplierData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshSupplierData()
        {
            try
            {
                using (SqlConnection sconnection = new SqlConnection(connectionString))
                {
                    sconnection.Open();
                    string query = "SELECT s.SupplierID, s.SupplierName, s.ContactNumber, s.Address, sd.DebtAmount, sd.PaymentDueDate FROM Supplier s LEFT JOIN SupplierDebt sd ON s.SupplierID = sd.SupplierID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, sconnection);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewSuppliers.DataSource = table;
                    dataGridViewSuppliers.ReadOnly = true; // Make it read-only for security
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading supplier data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtSupplierName.Clear();
            txtContactNumber.Clear();
            txtAddress.Clear();
            txtDebtAmount.Clear();
            dateTimePickerPaymentDueDate.Value = DateTime.Today;
        }

        private void dataGridViewSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle clicks if necessary
        }

        private void lblPaymentDueDate_Click(object sender, EventArgs e)
        {

        }
    }
}
