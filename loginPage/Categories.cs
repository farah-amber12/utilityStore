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
using loginPage;

namespace loginPage
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            RefreshCategoryGrid();
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
                using (SqlConnection catagoriesConnection = new SqlConnection(loginForm.connectionString))
                {
                    string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                    using (SqlCommand command = new SqlCommand(query, catagoriesConnection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", categoryName);
                        catagoriesConnection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            RefreshCategoryGrid();
                            categoryfield.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCategoryGrid()
        {
            try
            {
                using (SqlConnection catagoriesConnection = new SqlConnection(loginForm.connectionString))
                {
                    string query = @"
                    SELECT 
                        CategoryID, 
                        CategoryName
                    FROM Categories;";

                    using (SqlCommand command = new SqlCommand(query, catagoriesConnection))
                    {
                        catagoriesConnection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvCategory.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while refreshing the category grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                int selectedCategoryId = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["CategoryID"].Value);

                var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this category?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection catagoriesConnection = new SqlConnection(loginForm.connectionString))
                        {
                            string query = "DELETE FROM Categories WHERE CategoryID = @CategoryID";

                            using (SqlCommand command = new SqlCommand(query, catagoriesConnection))
                            {
                                command.Parameters.AddWithValue("@CategoryID", selectedCategoryId);
                                catagoriesConnection.Open();
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    RefreshCategoryGrid();
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
            // Placeholder for potential edit logic.
        }
    }
}
