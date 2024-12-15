using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using UtilityStoreApp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace loginPage
{
    public partial class SupplierForm : Form
    {
        public SupplierForm()

        {
            InitializeComponent();
        }

      
        /// <summary>
        /// Refresh data grid with supplier and debt information.
        /// </summary>


        /// <summary>
        /// Add supplier along with debt information
        /// </summary>
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate supplier name - only alphabets and not empty
                if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
                {
                    MessageBox.Show("Please enter the supplier name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtSupplierName.Text, @"^[A-Za-z\s]+$"))
                {
                    MessageBox.Show("Supplier name should only contain alphabets.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate contact number
                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    MessageBox.Show("Please enter the contact number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtContactNumber.Text, @"^(03\d{2}-\d{7}|042-\d{8})$"))
                {
                    MessageBox.Show("Invalid contact number format. Use 03XX-XXXXXXXX or 042-XXXXXXXX.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Please enter the supplier address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
                {
                    connection.Open();

                    // Validate debt conditions only when debt amount is entered
                    if (!string.IsNullOrWhiteSpace(txtDebtAmount.Text))
                    {
                        if (dateTimePickerPaymentDueDate.Value == DateTime.MinValue) // No date selected
                        {
                            MessageBox.Show("Please select a payment due date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (dateTimePickerPaymentDueDate.Value.Date <= DateTime.Today) // Invalid date
                        {
                            MessageBox.Show("The payment due date must be greater than today's date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Only proceed if debt is either valid or optional debt case
                    string insertSupplierQuery = "INSERT INTO Supplier (SupplierName, ContactNumber, Address) VALUES (@Name, @Contact, @Address); SELECT SCOPE_IDENTITY();";
                    SqlCommand command = new SqlCommand(insertSupplierQuery, connection);

                    command.Parameters.AddWithValue("@Name", txtSupplierName.Text);
                    command.Parameters.AddWithValue("@Contact", txtContactNumber.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);

                    // Insert supplier only if debt validation is either passed or debt is optional
                    int newSupplierID = Convert.ToInt32(command.ExecuteScalar());

                    if (!string.IsNullOrWhiteSpace(txtDebtAmount.Text)) // Handle debt validation only if debt entered
                    {
                        string insertDebtQuery = "INSERT INTO SupplierDebt (SupplierID, DebtAmount, PaymentDueDate) VALUES (@SupplierID, @Debt, @DueDate)";
                        SqlCommand debtCommand = new SqlCommand(insertDebtQuery, connection);

                        debtCommand.Parameters.AddWithValue("@SupplierID", newSupplierID);
                        debtCommand.Parameters.AddWithValue("@Debt", decimal.Parse(txtDebtAmount.Text));
                        debtCommand.Parameters.AddWithValue("@DueDate", dateTimePickerPaymentDueDate.Value);

                        debtCommand.ExecuteNonQuery();
                        MessageBox.Show("Supplier and debt added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Supplier added successfully without debt.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    RefreshSupplierData();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid debt amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /// Handles both Add and Update logic for supplier and debt data.
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

                    if (dataGridViewSuppliers.Columns["SupplierID"] != null)
                    {
                        dataGridViewSuppliers.Columns["SupplierID"].ReadOnly = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Input validation method
        private bool ValidateInputs(DataGridViewRow selectedRow)
        {
            // Validate Supplier Name (Only letters allowed)
            if (selectedRow.Cells["SupplierName"]?.Value != null &&
                !Regex.IsMatch(selectedRow.Cells["SupplierName"].Value.ToString(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Supplier Name should only contain letters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Contact Number (specific format for Pakistani numbers)
            if (selectedRow.Cells["ContactNumber"]?.Value != null &&
                !Regex.IsMatch(selectedRow.Cells["ContactNumber"].Value.ToString(), @"^(03\d{2}-\d{7}|04\d-\d{7})$"))
            {
                MessageBox.Show("Invalid Contact Number. It must be in the format 03XX-XXXXXXX or 04X-XXXXXXXX.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Debt Amount - ensure only numbers or is blank
            if (selectedRow.Cells["DebtAmount"]?.Value != null &&
                !string.IsNullOrWhiteSpace(selectedRow.Cells["DebtAmount"].Value.ToString()) &&
                !Regex.IsMatch(selectedRow.Cells["DebtAmount"].Value.ToString(), @"^\d+$"))
            {
                MessageBox.Show("Debt Amount should only contain numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; // Return true only if all inputs are valid
        }


        /// <summary>
        /// Handles the supplier update logic upon button click.
        /// </summary>
        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a supplier row is selected
                if (dataGridViewSuppliers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a supplier row to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dataGridViewSuppliers.SelectedRows[0];

                // Validate Inputs
                if (!ValidateInputs(selectedRow))
                {
                    return;
                }

                // Database connection
                using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
                {
                    connection.Open();

                    bool isSupplierUpdated = false;
                    bool isDebtUpdated = false;

                    // Update supplier information
                    SqlCommand updateSupplierCommand = new SqlCommand
                    {
                        Connection = connection
                    };
                    List<string> supplierSetClauses = new List<string>();

                    if (!string.IsNullOrWhiteSpace(selectedRow.Cells["SupplierName"].Value?.ToString()))
                    {
                        supplierSetClauses.Add("SupplierName = @Name");
                        updateSupplierCommand.Parameters.AddWithValue("@Name", selectedRow.Cells["SupplierName"].Value.ToString());
                    }

                    if (!string.IsNullOrWhiteSpace(selectedRow.Cells["ContactNumber"].Value?.ToString()))
                    {
                        supplierSetClauses.Add("ContactNumber = @Contact");
                        updateSupplierCommand.Parameters.AddWithValue("@Contact", selectedRow.Cells["ContactNumber"].Value.ToString());
                    }

                    if (!string.IsNullOrWhiteSpace(selectedRow.Cells["Address"].Value?.ToString()))
                    {
                        supplierSetClauses.Add("Address = @Address");
                        updateSupplierCommand.Parameters.AddWithValue("@Address", selectedRow.Cells["Address"].Value.ToString());
                    }

                    if (supplierSetClauses.Count > 0)
                    {
                        string updateSupplierQuery = $"UPDATE Supplier SET {string.Join(", ", supplierSetClauses)} WHERE SupplierID = @SupplierID";
                        updateSupplierCommand.CommandText = updateSupplierQuery;
                        updateSupplierCommand.Parameters.AddWithValue("@SupplierID", selectedRow.Cells["SupplierID"].Value.ToString());
                        int supplierRowsAffected = updateSupplierCommand.ExecuteNonQuery();
                        isSupplierUpdated = supplierRowsAffected > 0;
                    }

                    // Handle Debt logic here
                    SqlCommand updateDebtCommand = new SqlCommand
                    {
                        Connection = connection
                    };

                    string debtAmountValue = selectedRow.Cells["DebtAmount"].Value?.ToString();
                    string paymentDueDateValue = dateTimePickerPaymentDueDate.Value.Date.ToString();

                    if (string.IsNullOrWhiteSpace(debtAmountValue))
                    {
                        // Clear the PaymentDueDate if DebtAmount is empty
                        updateDebtCommand.CommandText = "DELETE FROM SupplierDebt WHERE SupplierID = @SupplierID";
                        updateDebtCommand.Parameters.AddWithValue("@SupplierID", selectedRow.Cells["SupplierID"].Value.ToString());
                    }
                    else
                    {
                        // Insert/Update debt only when debt amount is provided and payment due date is valid
                        updateDebtCommand.CommandText = $"IF EXISTS (SELECT 1 FROM SupplierDebt WHERE SupplierID = @SupplierID) " +
                                                          $"UPDATE SupplierDebt SET DebtAmount = @Debt, PaymentDueDate = @DueDate WHERE SupplierID = @SupplierID " +
                                                          "ELSE INSERT INTO SupplierDebt (SupplierID, DebtAmount, PaymentDueDate) VALUES (@SupplierID, @Debt, @DueDate)";
                        updateDebtCommand.Parameters.AddWithValue("@Debt", debtAmountValue);
                        updateDebtCommand.Parameters.AddWithValue("@DueDate", dateTimePickerPaymentDueDate.Value.Date);
                        updateDebtCommand.Parameters.AddWithValue("@SupplierID", selectedRow.Cells["SupplierID"].Value.ToString());
                    }

                    try
                    {
                        int debtRowsAffected = updateDebtCommand.ExecuteNonQuery();
                        isDebtUpdated = debtRowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while updating debt/payment information: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (isDebtUpdated || isSupplierUpdated)
                    {
                        MessageBox.Show("Update Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshSupplierData();
                    }
                    else
                    {
                        MessageBox.Show("No changes were made.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = comboBoxFilter.SelectedItem?.ToString();

            // Hide all additional inputs by default
            textBoxDebtFrom.Visible = false;
            textBoxDebtTo.Visible = false;
            dateTimePickerFrom.Visible = false;
            dateTimePickerTo.Visible = false;
            radioButtonAZ.Visible = false;
            radioButtonZA.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            dateTimePickerSingle.Visible = false;


            if (selectedFilter == "With Debt")
            {
                dateTimePickerSingle.Visible = false;
                textBoxSearch.Visible = true;
                textBoxDebtFrom.Visible = true;
                textBoxDebtTo.Visible = true;
                dateTimePickerFrom.Visible = false;
                dateTimePickerTo.Visible = false;
                radioButtonAZ.Visible = false;
                radioButtonZA.Visible = false;
                label3.Visible = true;
                label4.Visible = true;
            }
            else if (selectedFilter == "Without Debt")
            {
                dateTimePickerSingle.Visible = false;
                textBoxSearch.Visible = true;
                textBoxDebtFrom.Visible = false;
                textBoxDebtTo.Visible = false;
                dateTimePickerFrom.Visible = false;
                dateTimePickerTo.Visible = false;
                radioButtonAZ.Visible = false;
                radioButtonZA.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }
            else if (selectedFilter == "Filter by City")
            {
                dateTimePickerSingle.Visible = false;
                textBoxSearch.Visible = true;
                textBoxDebtFrom.Visible = false;
                textBoxDebtTo.Visible = false;
                dateTimePickerFrom.Visible = false;
                dateTimePickerTo.Visible = false;
                radioButtonAZ.Visible = false;
                radioButtonZA.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }
            else if (selectedFilter == "Filter by Date")
            {
                dateTimePickerSingle.Visible = false;
                textBoxSearch.Visible = false;
                dateTimePickerSingle.Visible = true;
                dateTimePickerFrom.Visible = true;
                dateTimePickerTo.Visible = true;
                radioButtonAZ.Visible = false;
                radioButtonZA.Visible = false;
                textBoxDebtFrom.Visible = false;
                textBoxDebtTo.Visible = false;
                label3.Visible = true;
                label4.Visible = true;
            }
            else if (selectedFilter == "Filter by Name")

            {
                textBoxSearch.Visible = true;
                radioButtonAZ.Visible = true;
                radioButtonZA.Visible = true;
                textBoxDebtFrom.Visible = false;
                textBoxDebtTo.Visible = false;
                dateTimePickerFrom.Visible = false;
                dateTimePickerTo.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBoxSearch.Text.Trim();
                string selectedFilter = comboBoxFilter.SelectedItem?.ToString();

                using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
                {
                    connection.Open();
                    string query = "";

                    if (selectedFilter == "Filter by Name")
                    {
                        query = "SELECT * FROM Supplier WHERE SupplierName LIKE @SearchText";
                        if (radioButtonAZ.Checked)
                        {
                            query += " ORDER BY SupplierName ASC";
                        }
                        else if (radioButtonZA.Checked)
                        {
                            query += " ORDER BY SupplierName DESC";
                        }
                    }
                    else if (selectedFilter == "Filter by Address")
                    {
                        query = "SELECT * FROM Supplier WHERE Address LIKE @SearchText";
                    }
                    else if (selectedFilter == "With Debt")
                    {
                        query = "SELECT sd.*, s.SupplierName FROM SupplierDebt sd INNER JOIN Supplier s ON sd.SupplierID = s.SupplierID WHERE sd.DebtAmount BETWEEN @DebtFrom AND @DebtTo";
                    }
                    else if (selectedFilter == "Without Debt")
                    {
                        query = "SELECT * FROM Supplier WHERE SupplierID NOT IN (SELECT DISTINCT SupplierID FROM SupplierDebt)";
                    }
                    else if (selectedFilter == "Filter by Date")
                    {
                        if (dateTimePickerFrom.Value != null && dateTimePickerTo.Value != null)
                        {
                            query = @"
                    SELECT sd.*, s.SupplierName 
                    FROM SupplierDebt sd 
                    INNER JOIN Supplier s ON sd.SupplierID = s.SupplierID
                    WHERE sd.PaymentDueDate BETWEEN @DateFrom AND @DateTo";
                        }
                        else
                        {
                            MessageBox.Show("Please select a valid date range for the search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Bind parameters safely
                    if (selectedFilter == "Filter by Name" || selectedFilter == "Filter by City")
                    {
                        cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    }

                    if (selectedFilter == "With Debt")
                    {
                        cmd.Parameters.AddWithValue("@DebtFrom", decimal.Parse(textBoxDebtFrom.Text));
                        cmd.Parameters.AddWithValue("@DebtTo", decimal.Parse(textBoxDebtTo.Text));
                    }

                    if (selectedFilter == "Filter by Date")
                    {
                        cmd.Parameters.AddWithValue("@DateFrom", dateTimePickerFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@DateTo", dateTimePickerTo.Value.Date);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found for the selected search criteria.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dataGridViewSuppliers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Hide the current form
            OwnerForm ownerForm = new OwnerForm();
            this.Hide();
            ownerForm.ShowDialog();
            ownerForm.Show(); // Show the owner form
        }

      
    }
}
