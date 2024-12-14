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


    }
}