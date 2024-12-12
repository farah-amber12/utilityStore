using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace loginPage
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }
        static string frhconnect = "Data Source=DESKTOP-8BL3MIG\\SQLEXPRESS;Initial Catalog=UtilityStore;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        static string equcoonect = "Data Source=DESKTOP-NJ11NR5\\SQLEXPRESS;Initial Catalog=Utility_Store;Integrated Security=True;Trust Server Certificate=True";

        public static string connectionString = frhconnect;

        private void Categories_Load(object sender, EventArgs e)
        {
            RefreshCategoryGrid(new SqlConnection(connectionString));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string categoryName = categoryfield.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CategoryName", categoryName);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        //MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);\
                        RefreshCategoryGrid(connection);
                        categoryfield.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshCategoryGrid(SqlConnection connection)
        {
            try
            {
                // Query to retrieve category data
                string query = @"
        SELECT 
            CategoryID, 
            CategoryName
        FROM Categories;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    // Bind data to the DataGridView
                    dgvCategory.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while refreshing the category grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Check if a row is selected
            if (dgvCategory.SelectedRows.Count > 0)
            {
                // Get the selected row's CategoryID
                int selectedCategoryId = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["CategoryID"].Value);

                // Confirm deletion
                var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this category?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Perform deletion
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Query to delete the category
                            string query = "DELETE FROM Categories WHERE CategoryID = @CategoryID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Add parameter for the CategoryID
                                command.Parameters.AddWithValue("@CategoryID", selectedCategoryId);

                                // Execute the delete command
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Refresh the grid to reflect changes
                                    RefreshCategoryGrid(connection);

                                }
                                else
                                {
                                    MessageBox.Show("Deletion failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting the category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            /*   try
               {
                   // Get the edited row
                   DataGridViewRow row = dgvCategory.Rows[e.RowIndex];

                   // Extract data from the row
                   int categoryId = Convert.ToInt32(row.Cells["CategoryID"].Value);
                   string categoryName = row.Cells["CategoryName"].Value.ToString();

                   // Update the database
                   using (SqlConnection connection = new SqlConnection(connectionString))
                   {
                       connection.Open();
                       string query = @"
                   UPDATE Categories
                   SET CategoryName = @CategoryName
                   WHERE CategoryID = @CategoryID";

                       using (SqlCommand command = new SqlCommand(query, connection))
                       {
                           // Add parameters
                           command.Parameters.AddWithValue("@CategoryID", categoryId);
                           command.Parameters.AddWithValue("@CategoryName", categoryName);

                           // Execute the update
                           command.ExecuteNonQuery();
                       }
                   }

                   MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
               catch (Exception ex)
               {
                   MessageBox.Show($"An error occurred while updating the category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }

             */
        }

    }
}



