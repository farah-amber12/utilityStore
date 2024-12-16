using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using UtilityStoreApp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Diagnostics.Eventing.Reader;

namespace loginPage
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()

        {
            InitializeComponent();
            RefreshCustomerData();
        }


        /// <summary>
        /// Refresh data grid with supplier and debt information.
        /// </summary>


        /// <summary>
        /// Add supplier along with debt information
        /// </summary>




        /// <summary>
        /// Delete supplier and its associated debt
        /// </summary>
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewCustomers.SelectedRows[0];
            int customerId = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);

            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to delete this customer and their associated debt?",
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

                        // Delete associated debt first
                        SqlCommand deleteCustomerDebt = new SqlCommand("DELETE FROM CustomerDebt WHERE CustomerID = @CustomerID", connection);
                        deleteCustomerDebt.Parameters.AddWithValue("@CustomerID", customerId);
                        deleteCustomerDebt.ExecuteNonQuery();

                        // Delete the customer
                        SqlCommand deleteCustomer = new SqlCommand("DELETE FROM Customers WHERE CustomerID = @CustomerID", connection);
                        deleteCustomer.Parameters.AddWithValue("@CustomerID", customerId);
                        deleteCustomer.ExecuteNonQuery();
                    }

                    MessageBox.Show("Customer and their associated debt deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCustomerData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles both Add and Update logic for customer and debt data.
        /// </summary>
        private void RefreshCustomerData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    c.CustomerID, 
                    c.FirstName, 
                    c.LastName, 
                    c.Phone, 
                    cd.DebtAmount, 
                    cd.DueDate
                FROM Customers c
                LEFT JOIN CustomerDebt cd ON c.CustomerID = cd.CustomerID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewCustomers.DataSource = dataTable;

                    if (dataGridViewCustomers.Columns["CustomerID"] != null)
                    {
                        dataGridViewCustomers.Columns["CustomerID"].ReadOnly = true;
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
            // Validate First Name (Only letters allowed)
            if (selectedRow.Cells["FirstName"]?.Value != null &&
                !Regex.IsMatch(selectedRow.Cells["FirstName"].Value.ToString(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First Name should only contain letters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Last Name (Only letters allowed)
            if (selectedRow.Cells["LastName"]?.Value != null &&
                !Regex.IsMatch(selectedRow.Cells["LastName"].Value.ToString(), @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Last Name should only contain letters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Phone Number (specific format for Pakistani numbers)
            if (selectedRow.Cells["Phone"]?.Value != null &&
                !Regex.IsMatch(selectedRow.Cells["Phone"].Value.ToString(), @"^(03\d{2}-\d{7}|04\d-\d{7})$"))
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
        /// Handles the customer update logic upon button click.
        /// </summary>
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a customer row is selected
                if (dataGridViewCustomers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a customer row to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dataGridViewCustomers.SelectedRows[0];

                // Validate Inputs
                if (!ValidateInputs(selectedRow))
                {
                    return;
                }

                // Database connection
                using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
                {
                    connection.Open();

                    bool isCustomerUpdated = false;
                    bool isDebtUpdated = false;

                    // Update customer information
                    SqlCommand updateCustomerCommand = new SqlCommand
                    {
                        Connection = connection
                    };
                    List<string> customerSetClauses = new List<string>();

                    if (!string.IsNullOrWhiteSpace(selectedRow.Cells["FirstName"]?.Value?.ToString()))
                    {
                        customerSetClauses.Add("FirstName = @FirstName");
                        updateCustomerCommand.Parameters.AddWithValue("@FirstName", selectedRow.Cells["FirstName"].Value.ToString());
                    }

                    if (!string.IsNullOrWhiteSpace(selectedRow.Cells["LastName"]?.Value?.ToString()))
                    {
                        customerSetClauses.Add("LastName = @LastName");
                        updateCustomerCommand.Parameters.AddWithValue("@LastName", selectedRow.Cells["LastName"].Value.ToString());
                    }

                    if (!string.IsNullOrWhiteSpace(selectedRow.Cells["Phone"]?.Value?.ToString()))
                    {
                        customerSetClauses.Add("Phone = @Phone");
                        updateCustomerCommand.Parameters.AddWithValue("@Phone", selectedRow.Cells["Phone"].Value.ToString());
                    }

                    if (customerSetClauses.Count > 0)
                    {
                        string updateCustomerQuery = $"UPDATE Customers SET {string.Join(", ", customerSetClauses)} WHERE CustomerID = @CustomerID";
                        updateCustomerCommand.CommandText = updateCustomerQuery;
                        updateCustomerCommand.Parameters.AddWithValue("@CustomerID", selectedRow.Cells["CustomerID"].Value.ToString());
                        int customerRowsAffected = updateCustomerCommand.ExecuteNonQuery();
                        isCustomerUpdated = customerRowsAffected > 0;
                    }

                    // Handle Debt logic here
                    SqlCommand updateDebtCommand = new SqlCommand
                    {
                        Connection = connection
                    };

                    string debtAmountValue = selectedRow.Cells["DebtAmount"]?.Value?.ToString();
                    string paymentDueDateValue = dateTimePickerPaymentDueDate.Value.Date.ToString();

                    if (string.IsNullOrWhiteSpace(debtAmountValue))
                    {
                        // Clear the debt entry if DebtAmount is empty
                        updateDebtCommand.CommandText = "DELETE FROM CustomerDebt WHERE CustomerID = @CustomerID";
                        updateDebtCommand.Parameters.AddWithValue("@CustomerID", selectedRow.Cells["CustomerID"].Value.ToString());
                    }
                    else
                    {
                        // Insert/Update debt only when debt amount is provided
                        updateDebtCommand.CommandText = $"IF EXISTS (SELECT 1 FROM CustomerDebt WHERE CustomerID = @CustomerID) " +
                                                          $"UPDATE CustomerDebt SET DebtAmount = @Debt, DueDate = @DueDate WHERE CustomerID = @CustomerID " +
                                                          "ELSE INSERT INTO CustomerDebt (CustomerID, DebtAmount, DueDate) VALUES (@CustomerID, @Debt, @DueDate)";
                        updateDebtCommand.Parameters.AddWithValue("@Debt", debtAmountValue);
                        updateDebtCommand.Parameters.AddWithValue("@DueDate", dateTimePickerPaymentDueDate.Value.Date);
                        updateDebtCommand.Parameters.AddWithValue("@CustomerID", selectedRow.Cells["CustomerID"].Value.ToString());
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

                    if (isDebtUpdated || isCustomerUpdated)
                    {
                        MessageBox.Show("Update Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshCustomerData();
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
                dateTimePickerSingle.Visible = true;
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
                dateTimePickerSingle.Visible = false;
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
                    string query = "SELECT * FROM Customers"; // Default query (All)
                    bool hasConditions = false;

                    SqlCommand cmd = new SqlCommand();

                    if (selectedFilter == "Filter by Name")
                    {
                        query = "SELECT * FROM Customers WHERE FirstName LIKE @SearchText OR LastName LIKE @SearchText";
                        cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                        hasConditions = true;

                        if (radioButtonAZ.Checked)
                            query += " ORDER BY FirstName ASC, LastName ASC";
                        else if (radioButtonZA.Checked)
                            query += " ORDER BY FirstName DESC, LastName DESC";
                    }
                    else if (selectedFilter == "Filter by Address")
                    {
                        query = "SELECT * FROM Customers WHERE Address LIKE @SearchText";
                        cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                        hasConditions = true;
                    }
                    else if (selectedFilter == "With Debt")
                    {
                        query = "SELECT sd.*, c.FirstName, c.LastName FROM CustomerDebt sd INNER JOIN Customers c ON sd.CustomerID = c.CustomerID";

                        // Prioritize "From-To" range over single search text
                        if (!string.IsNullOrEmpty(textBoxDebtFrom.Text) && !string.IsNullOrEmpty(textBoxDebtTo.Text))
                        {
                            if (decimal.TryParse(textBoxDebtFrom.Text, out decimal debtFrom) &&
                                decimal.TryParse(textBoxDebtTo.Text, out decimal debtTo))
                            {
                                query += " WHERE sd.DebtAmount BETWEEN @DebtFrom AND @DebtTo";
                                cmd.Parameters.AddWithValue("@DebtFrom", debtFrom);
                                cmd.Parameters.AddWithValue("@DebtTo", debtTo);
                                hasConditions = true;
                            }
                            else
                            {
                                MessageBox.Show("Please enter valid numeric values for debt range.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else if (!string.IsNullOrEmpty(textBoxSearch.Text))
                        {
                            if (decimal.TryParse(textBoxSearch.Text, out decimal debtAmount))
                            {
                                query += " WHERE sd.DebtAmount = @DebtAmount";
                                cmd.Parameters.AddWithValue("@DebtAmount", debtAmount);
                                hasConditions = true;
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid numeric value for debt.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    else if (selectedFilter == "Filter by Date")
                    {
                        query = "SELECT sd.*, c.FirstName, c.LastName FROM CustomerDebt sd INNER JOIN Customers c ON sd.CustomerID = c.CustomerID";

                        DateTime today = DateTime.Today;

                        // Prioritize From-To directly only if NOT today's date
                        if (dateTimePickerFrom.Value.Date != today || dateTimePickerTo.Value.Date != today)
                        {
                            query += " WHERE sd.DueDate BETWEEN @DateFrom AND @DateTo";
                            cmd.Parameters.AddWithValue("@DateFrom", dateTimePickerFrom.Value.Date);
                            cmd.Parameters.AddWithValue("@DateTo", dateTimePickerTo.Value.Date);
                            hasConditions = true;
                        }
                        else if (dateTimePickerSingle.Value.Date != today)
                        {
                            // Search if the text box contains today's date
                            query += " WHERE sd.DueDate = @dateTimePickerSingle";
                            cmd.Parameters.AddWithValue("@dateTimePickerSingle", dateTimePickerSingle.Value.Date);
                            hasConditions = true;
                        }
                        else
                        {
                            // Handle incorrect date format or invalid user input
                            MessageBox.Show("No data for this date found", "No Reocrd Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (string.IsNullOrEmpty(searchText) && !hasConditions)
                    {
                        query = "SELECT * FROM Customers"; // Default case (All records)
                    }

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewCustomers.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("No results found for your query.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void refresh_Click(object sender, EventArgs e)
        {
            RefreshCustomerData();
            textBoxDebtFrom.Clear();
            textBoxDebtTo.Clear();
            textBoxSearch.Clear();
        }

     
    }
}
