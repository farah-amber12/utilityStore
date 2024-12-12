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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace loginPage
{
    public partial class Products : Form
    {
        static string frhconnect = "Data Source=DESKTOP-8BL3MIG\\SQLEXPRESS;Initial Catalog=UtilityStore;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        static string equcoonect = "Data Source=DESKTOP-NJ11NR5\\SQLEXPRESS;Initial Catalog=Utility_Store;Integrated Security=True;Trust Server Certificate=True";

        public static string connectionString = frhconnect;
        public Products()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }




        private void addAndViewProducts_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            LoadCategories();
            // SetupDataGridView();
            RefreshProductGrid(new SqlConnection(connectionString));
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductName.Text) ||
       string.IsNullOrEmpty(txtStockLevel.Text) ||
       cmbUnit.SelectedIndex == -1 || // Ensure a unit is selected
       categorycombo.SelectedIndex == -1 ||
       string.IsNullOrEmpty(txtPurchasePrice.Text) ||
       string.IsNullOrEmpty(txtSellingPrice.Text) ||
       string.IsNullOrEmpty(dtpExpiryDate.Text) ||
                    suppliercombo.SelectedIndex == -1)// Ensure expiry date is selected
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get values from the form
            string productName = txtProductName.Text;
            string categoryName = categorycombo.SelectedItem.ToString();
            string supplierName = suppliercombo.SelectedItem.ToString();
            string brandName = txtBrandName.Text;
            decimal stockLevel = decimal.Parse(txtStockLevel.Text);
            string unit = cmbUnit.SelectedItem.ToString();
            decimal purchasePrice = decimal.Parse(txtPurchasePrice.Text);
            decimal sellingPrice = decimal.Parse(txtSellingPrice.Text);
            DateTime expiryDate = dtpExpiryDate.Value;



            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
              INSERT INTO Products (
                  ProductName,
                  CategoryID,
                  BrandName,
                  StockLevel,
                  Unit,
                  PurchasePrice,
                  SellingPrice,
                  ExpiryDate,
                  SupplierID
              )
              VALUES (
                  @ProductName,
                  (SELECT CategoryID FROM Categories WHERE CategoryName = @CategoryName),
                  @BrandName,
                  @StockLevel,
                  @Unit,
                  @PurchasePrice,
                  @SellingPrice,
                  @ExpiryDate,
                  (SELECT SupplierID FROM Supplier WHERE SupplierName = @SupplierName)
              );";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@ProductName", productName);
                        command.Parameters.AddWithValue("@CategoryName", categoryName);
                        command.Parameters.AddWithValue("@SupplierName", supplierName);
                        command.Parameters.AddWithValue("@BrandName", brandName);
                        command.Parameters.AddWithValue("@StockLevel", stockLevel);
                        command.Parameters.AddWithValue("@Unit", unit);
                        command.Parameters.AddWithValue("@PurchasePrice", purchasePrice);
                        command.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        command.Parameters.AddWithValue("@ExpiryDate", expiryDate);

                        // Execute query
                        command.ExecuteNonQuery();
                        //MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshProductGrid(connection);
                        // Clear fields after successful insertion
                        ClearFields();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Helper method to clear input fields
        private void ClearFields()
        {
            txtProductName.Clear();
            txtStockLevel.Clear();
            categorycombo.SelectedIndex = -1;
            txtPurchasePrice.Clear();
            txtSellingPrice.Clear();
            cmbUnit.SelectedIndex = -1; // Reset dropdown
            dtpExpiryDate.Value = DateTime.Now; // Reset date picker
            suppliercombo.SelectedIndex = -1;
        }
        private void LoadCategories()
        {


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CategoryName FROM Categories";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            categorycombo.Items.Add(reader["CategoryName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void LoadSuppliers()
        {


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT SupplierName FROM Supplier";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            suppliercombo.Items.Add(reader["SupplierName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void SetupDataGridView()
        {
            productsGridView.ColumnCount = 10;
            productsGridView.Columns[0].Name = "Product ID";
            productsGridView.Columns[1].Name = "Product Name";
            productsGridView.Columns[2].Name = "Stock level";
            productsGridView.Columns[3].Name = "Unit";
            productsGridView.Columns[4].Name = "Purchase Price";
            productsGridView.Columns[5].Name = "Selling Price";
            productsGridView.Columns[6].Name = "Supplier";
            productsGridView.Columns[7].Name = "Expiry Date";
            productsGridView.Columns[8].Name = "category ID";
            productsGridView.Columns[9].Name = "category name";
            productsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Auto-size columns
        }
        private void RefreshProductGrid(SqlConnection connection)
        {
            try
            {
                // Query to retrieve product data along with category and supplier names
                string query = @"
        SELECT 
            
                p.ProductID, 
                p.ProductName,
                c.CategoryID, c.CategoryName, p.BrandName,
                p.StockLevel,
                p.Unit,
                p.PurchasePrice,
                p.SellingPrice,
                p.ExpiryDate,
                s.SupplierName
                FROM Products p
                JOIN Categories c ON p.CategoryID = c.CategoryID
                JOIN Supplier s ON p.SupplierID = s.SupplierID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind data to the DataGridView
                    productsGridView.DataSource = dataTable;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while refreshing the grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
                // Check if a row is selected
                if (productsGridView.SelectedRows.Count > 0)
                {
                    // Get the selected row's ProductID
                    int selectedProductId = Convert.ToInt32(productsGridView.SelectedRows[0].Cells["ProductID"].Value);

                    // Confirm deletion
                    var confirmResult = MessageBox.Show(
                        "Are you sure you want to delete this product?",
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

                                // Query to delete the product
                                string query = "DELETE FROM Products WHERE ProductID = @ProductID";

                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    // Add parameter for the ProductID
                                    command.Parameters.AddWithValue("@ProductID", selectedProductId);

                                    // Execute the delete command
                                    int rowsAffected = command.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Refresh the grid to reflect changes
                                    RefreshProductGrid(connection);
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
                            MessageBox.Show($"An error occurred while deleting the product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
    }


