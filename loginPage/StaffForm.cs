using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using loginPage;

namespace loginPage
{
    public partial class StaffForm : Form
    {
        private readonly SqlConnection scconnection;

        public StaffForm()
        {
            scconnection = new SqlConnection(loginForm.connectionString);

            InitializeComponent();
            LoadRoles();
            LoadStaffData();
            LoadRolesSearch();
            LoadFilterTypeDropdown();


        }

        /// <summary>
        /// Clear and load roles into the ComboBox
        /// </summary>
        private void LoadRoles()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Owner");
            cmbRole.Items.Add("Manager");
            cmbRole.Items.Add("Helper");
            cmbRole.Items.Add("Organizer");
            cmbRole.Items.Add("Cashier");
        }

        /// <summary>
        /// Handle the click event for adding new staff
        /// </summary>
        private void BtnAddStaff_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                if (CheckUsernameExists(txtUsername.Text.Trim()))
                {
                    MessageBox.Show("Username already exists.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(loginForm.connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Staff (FirstName, LastName, Role, Salary, Username, UserPassword, ContactNumber, Address) 
                                     VALUES (@FirstName, @LastName, @Role, @Salary, @Username, @UserPassword, @ContactNumber, @Address)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Binding parameters
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Salary", decimal.Parse(txtSalary.Text));
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff added successfully!");
                    LoadStaffData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Checks if the given username already exists in the database
        /// </summary>
        private bool CheckUsernameExists(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(loginForm.connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Staff WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // True if the username already exists
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
                return true;
            }
        }


        /// <summary>
        /// Validate user input fields
        /// </summary>
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || !Regex.IsMatch(txtFirstName.Text.Trim(), @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("First Name must only contain alphabets.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text) || !Regex.IsMatch(txtLastName.Text.Trim(), @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Last Name must only contain alphabets.");
                return false;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role.");
                return false;
            }

            if (!decimal.TryParse(txtSalary.Text, out _))
            {
                MessageBox.Show("Salary must contain only numbers.");
                return false;
            }

            if (!Regex.IsMatch(txtContactNumber.Text.Trim(), @"^(03\d{2}-\d{7}|04\d{3}-\d{6})$"))
            {
                MessageBox.Show("Contact Number must follow the pattern 03XX-XXXXXXX or 04X-XXXXXXXX.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username & Password fields cannot be empty.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Load staff data into DataGridView
        /// </summary>
        private void LoadStaffData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(loginForm.connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Staff", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvStaff.DataSource = dt;
                    dgvStaff.ReadOnly = false;
                    dgvStaff.SelectionChanged += dgvStaff_SelectionChanged;
                }


                if (dgvStaff.Columns.Contains("StaffID"))
                {
                    dgvStaff.Columns["StaffID"].ReadOnly = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data: {ex.Message}");
            }
        }

        /// <summary>
        /// Clear all input fields
        /// </summary>
        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtSalary.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtContactNumber.Clear();
            txtAddress.Clear();
            cmbRole.SelectedIndex = -1;
        }



        // Delete button click event
        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dgvStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            // Confirm deletion
            var result = MessageBox.Show(
                "Are you sure you want to delete the selected record?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // Get the selected row's StaffID from the DataGridView
                int staffID = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells["StaffID"].Value);

                try
                {
                    // Delete the record from the database
                    DeleteRecordFromDatabase(staffID);

                    // Remove the selected row from the DataGridView
                    dgvStaff.Rows.RemoveAt(dgvStaff.SelectedRows[0].Index);

                    MessageBox.Show("Record deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        // Function to delete a record from the database
        private void DeleteRecordFromDatabase(int staffID)
        {
            using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Staff WHERE StaffID = @StaffID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StaffID", staffID);
                    cmd.ExecuteNonQuery();
                }
            }
        }




        private bool CheckUsernameExistsForUpdate(string username, int staffID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(loginForm.connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Staff WHERE Username = @Username AND StaffID != @StaffID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@StaffID", staffID);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // True if another user with the same username exists
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
                return true; // Return true to prevent update in case of error
            }
        }

        private void BtnUpdateStaff_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStaff.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a staff member to update.");
                    return;
                }

                int staffID = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells["StaffID"].Value);

                // Compare current data with the selected row's original values
                string originalFirstName = dgvStaff.SelectedRows[0].Cells["FirstName"].Value.ToString();
                string originalLastName = dgvStaff.SelectedRows[0].Cells["LastName"].Value.ToString();
                string originalRole = dgvStaff.SelectedRows[0].Cells["Role"].Value.ToString();
                string originalSalary = dgvStaff.SelectedRows[0].Cells["Salary"].Value.ToString();
                string originalUsername = dgvStaff.SelectedRows[0].Cells["Username"].Value.ToString();

                bool isChangeDetected =
                    txtFirstName.Text.Trim() != originalFirstName ||
                    txtLastName.Text.Trim() != originalLastName ||
                    cmbRole.SelectedItem?.ToString() != originalRole ||
                    txtSalary.Text.Trim() != originalSalary ||
                    txtUsername.Text.Trim() != originalUsername;

                if (!isChangeDetected)
                {
                    MessageBox.Show("No changes detected. Please modify some details before updating.");
                    return;
                }

                if (!ValidateInputs()) return;

                if (CheckUsernameExistsForUpdate(txtUsername.Text.Trim(), staffID))
                {
                    MessageBox.Show("Username already exists for another user.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(loginForm.connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Staff 
                       SET FirstName = @FirstName, 
                           LastName = @LastName, 
                           Role = @Role, 
                           Salary = @Salary, 
                           Username = @Username, 
                           UserPassword = @UserPassword, 
                           ContactNumber = @ContactNumber, 
                           Address = @Address
                       WHERE StaffID = @StaffID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Binding parameters
                    cmd.Parameters.AddWithValue("@StaffID", staffID);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Salary", decimal.Parse(txtSalary.Text));
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff updated successfully!");
                    LoadStaffData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void dgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0)
            {
                txtFirstName.Text = dgvStaff.SelectedRows[0].Cells["FirstName"].Value.ToString();
                txtLastName.Text = dgvStaff.SelectedRows[0].Cells["LastName"].Value.ToString();
                cmbRole.SelectedItem = dgvStaff.SelectedRows[0].Cells["Role"].Value.ToString();
                txtSalary.Text = dgvStaff.SelectedRows[0].Cells["Salary"].Value.ToString();
                txtUsername.Text = dgvStaff.SelectedRows[0].Cells["Username"].Value.ToString();
                txtContactNumber.Text = dgvStaff.SelectedRows[0].Cells["ContactNumber"].Value.ToString();
                txtAddress.Text = dgvStaff.SelectedRows[0].Cells["Address"].Value.ToString();
            }
        }





        private void LoadRolesSearch()
        {
            cmbSearchRole.Items.Clear();
            cmbSearchRole.Items.Add("Owner");
            cmbSearchRole.Items.Add("Manager");
            cmbSearchRole.Items.Add("Helper");
            cmbSearchRole.Items.Add("Organizer");
            cmbSearchRole.Items.Add("Cashier");

            cmbSearchRole.Visible = true; // Hidden initially
        }

        private void LoadFilterTypeDropdown()
        {
            cmbFilterType.Items.Clear();
            cmbFilterType.Items.Add("Name");
            cmbFilterType.Items.Add("Role");
            cmbFilterType.Items.Add("Salary");
            cmbFilterType.Visible = true;

            cmbFilterType.SelectedIndex = 0; // Default to "Name"
                                             // Ensure visibility
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputSearch())
                {
                    return; // Stop execution if validation fails
                }

                using (SqlConnection conn = new SqlConnection(loginForm.connectionString))
                {
                    conn.Open();
                    string query = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    switch (cmbFilterType.SelectedItem?.ToString())
                    {
                        case "Name":
                            string nameFilter = txtSearchName.Text.Trim();
                            string sortOrder = rbtnSortAZ.Checked ? "ASC" : "DESC";
                            query = @"
                    SELECT * 
                    FROM Staff 
                    WHERE FirstName LIKE @NameFilter OR LastName LIKE @NameFilter
                    ORDER BY FirstName " + sortOrder;
                            cmd.Parameters.AddWithValue("@NameFilter", $"%{nameFilter}%");
                            break;

                        case "Role":
                            string roleFilter = cmbSearchRole.SelectedItem?.ToString();
                            query = @"
                    SELECT * 
                    FROM Staff 
                    WHERE Role = @RoleFilter";
                            cmd.Parameters.AddWithValue("@RoleFilter", roleFilter);
                            break;

                        case "Salary":
                            decimal minSalary = decimal.Parse(txtMinSalary.Text);
                            decimal maxSalary = decimal.Parse(txtMaxSalary.Text);
                            query = @"
                    SELECT * 
                    FROM Staff 
                    WHERE Salary >= @MinSalary AND Salary <= @MaxSalary";
                            cmd.Parameters.AddWithValue("@MinSalary", minSalary);
                            cmd.Parameters.AddWithValue("@MaxSalary", maxSalary);
                            break;

                        default:
                            MessageBox.Show("Please select a valid filter option.");
                            return;
                    }

                    cmd.CommandText = query;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvStaff.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}");
            }
        }

        private bool ValidateInputSearch()
        {
            string filterType = cmbFilterType.SelectedItem?.ToString();

            switch (filterType)
            {
                case "Name":
                    if (!Regex.IsMatch(txtSearchName.Text, @"^[a-zA-Z\s]+$"))
                    {
                        MessageBox.Show("Please enter valid name (letters only).");
                        return false;
                    }
                    break;

                case "Role":
                    if (!cmbSearchRole.Items.Contains(cmbSearchRole.SelectedItem))
                    {
                        MessageBox.Show("Invalid role selected.");
                        return false;
                    }
                    break;

                case "Salary":
                    if (!decimal.TryParse(txtMinSalary.Text, out decimal minSalary) ||
                        !decimal.TryParse(txtMaxSalary.Text, out decimal maxSalary))
                    {
                        MessageBox.Show("Please enter valid numbers for salary range.");
                        return false;
                    }

                    if (minSalary > maxSalary)
                    {
                        MessageBox.Show("Minimum salary cannot be greater than maximum salary.");
                        return false;
                    }
                    break;
            }

            return true; // Input is valid
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterType = cmbFilterType.SelectedItem?.ToString();

            // Hide all filter-related UI components by default
            txtSearchName.Visible = false;
            cmbSearchRole.Visible = false;
            txtMinSalary.Visible = false;
            txtMaxSalary.Visible = false;
            rbtnSortAZ.Visible = false;
            rbtnSortZA.Visible = false;
            label4.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            switch (filterType)
            {
                case "Name":
                    txtSearchName.Visible = true;
                    rbtnSortAZ.Visible = true;
                    rbtnSortZA.Visible = true;
                    break;

                case "Role":

                    label4.Visible = true;
                    txtSearchName.Visible = true;
                    cmbSearchRole.Visible = true;
                    break;

                case "Salary":
                    txtSearchName.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    txtMinSalary.Visible = true;
                    txtMaxSalary.Visible = true;
                    break;
            }
        }



        private void ClrBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}