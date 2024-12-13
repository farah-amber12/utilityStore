using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace loginPage
{
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            RefreshSupplierData();
        }

        /// <summary>
        /// Refresh data grid with supplier and debt information.
        /// </summary>
        private void RefreshSupplierData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            s.SupplierID, 
                            s.SupplierName, 
                            s.ContactNumber, 
                            s.Address, 
                            sd.DebtAmount, 
                            sd.PaymentDueDate
                        FROM Supplier s
                        LEFT JOIN SupplierDebt sd ON s.SupplierID = sd.SupplierID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewSuppliers.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add supplier along with debt information.
        /// </summary>
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
                {
                    connection.Open();

                    // Insert into the Supplier table
                    string insertSupplierQuery = "INSERT INTO Supplier (SupplierName, ContactNumber, Address) VALUES (@Name, @Contact, @Address); SELECT SCOPE_IDENTITY();";
                    SqlCommand command = new SqlCommand(insertSupplierQuery, connection);

                    command.Parameters.AddWithValue("@Name", txtSupplierName.Text);
                    command.Parameters.AddWithValue("@Contact", txtContactNumber.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);

                    int newSupplierID = Convert.ToInt32(command.ExecuteScalar());

                    // Insert into the SupplierDebt table with the corresponding SupplierID
                    string insertDebtQuery = "INSERT INTO SupplierDebt (SupplierID, DebtAmount, PaymentDueDate) VALUES (@SupplierID, @Debt, @DueDate)";
                    SqlCommand debtCommand = new SqlCommand(insertDebtQuery, connection);

                    debtCommand.Parameters.AddWithValue("@SupplierID", newSupplierID);
                    debtCommand.Parameters.AddWithValue("@Debt", decimal.Parse(txtDebtAmount.Text));
                    debtCommand.Parameters.AddWithValue("@DueDate", dateTimePickerPaymentDueDate.Value);

                    debtCommand.ExecuteNonQuery();

                    MessageBox.Show("Supplier and debt added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshSupplierData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete supplier and its associated debt
        /// </summary>
        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (dataGridViewSuppliers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewSuppliers.SelectedRows[0];
            int supplierId = Convert.ToInt32(selectedRow.Cells["SupplierID"].Value);

            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to delete this supplier and its associated debt?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
                    {
                        connection.Open();
                        // Delete debt first
                        SqlCommand deleteDebt = new SqlCommand("DELETE FROM SupplierDebt WHERE SupplierID = @SupplierID", connection);
                        deleteDebt.Parameters.AddWithValue("@SupplierID", supplierId);
                        deleteDebt.ExecuteNonQuery();

                        // Delete supplier
                        SqlCommand deleteSupplier = new SqlCommand("DELETE FROM Supplier WHERE SupplierID = @SupplierID", connection);
                        deleteSupplier.Parameters.AddWithValue("@SupplierID", supplierId);
                        deleteSupplier.ExecuteNonQuery();
                    }

                    MessageBox.Show("Supplier and associated debt deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshSupplierData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Dynamically update the supplier debt data.
        /// </summary>
        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (dataGridViewSuppliers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewSuppliers.SelectedRows[0];
            int supplierId = Convert.ToInt32(selectedRow.Cells["SupplierID"].Value);

            try
            {
                using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
                {
                    connection.Open();
                    List<string> setClauses = new List<string>();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    if (!string.IsNullOrWhiteSpace(txtDebtAmount.Text))
                    {
                        setClauses.Add("DebtAmount = @Debt");
                        command.Parameters.AddWithValue("@Debt", decimal.Parse(txtDebtAmount.Text));
                    }

                    if (dateTimePickerPaymentDueDate.Value != DateTime.MinValue)
                    {
                        setClauses.Add("PaymentDueDate = @DueDate");
                        command.Parameters.AddWithValue("@DueDate", dateTimePickerPaymentDueDate.Value);
                    }

                    if (setClauses.Count == 0)
                    {
                        MessageBox.Show("No valid fields provided to update.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string setClauseString = string.Join(", ", setClauses);
                    string query = $"UPDATE SupplierDebt SET {setClauseString} WHERE SupplierID = @SupplierID";

                    command.CommandText = query;
                    command.Parameters.AddWithValue("@SupplierID", supplierId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Supplier debt updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshSupplierData();
                    }
                    else
                    {
                        MessageBox.Show("No changes made to the supplier debt.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating supplier debt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
