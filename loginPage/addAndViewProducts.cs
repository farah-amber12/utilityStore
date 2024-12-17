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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace loginPage
{
    public partial class Products : Form
    {
        private readonly SqlConnection ProductsConnection;

        public Products()
        {
            InitializeComponent();
            ProductsConnection = new SqlConnection(loginForm.connectionString);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void addAndViewProducts_Load(object sender, EventArgs e)

        {
            RefreshProductGrid();
            LoadSuppliers();
            LoadCategories();

        }

        private void button2_Click(object sender, EventArgs e)
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
                        using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
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
                                    RefreshProductGrid();
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



        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductName.Text) ||
       string.IsNullOrEmpty(txtStockLevel.Text) ||
       cmbUnit.SelectedIndex == -1 ||
       categorycombo.SelectedIndex == -1 ||
       string.IsNullOrEmpty(txtPurchasePrice.Text) ||
       string.IsNullOrEmpty(txtSellingPrice.Text) ||
       string.IsNullOrEmpty(dtpExpiryDate.Text) ||
       suppliercombo.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                using (SqlConnection catagoriesConnection = new SqlConnection(loginForm.connectionString))
                {
                    catagoriesConnection.Open();
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

                    using (SqlCommand command = new SqlCommand(query, catagoriesConnection))
                    {
                        command.Parameters.AddWithValue("@ProductName", productName);
                        command.Parameters.AddWithValue("@CategoryName", categoryName);
                        command.Parameters.AddWithValue("@SupplierName", supplierName);
                        command.Parameters.AddWithValue("@BrandName", brandName);
                        command.Parameters.AddWithValue("@StockLevel", stockLevel);
                        command.Parameters.AddWithValue("@Unit", unit);
                        command.Parameters.AddWithValue("@PurchasePrice", purchasePrice);
                        command.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        command.Parameters.AddWithValue("@ExpiryDate", expiryDate);

                        command.ExecuteNonQuery();
                        RefreshProductGrid();
                        ClearFields();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
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
                ProductsConnection.Open();
                string query = "SELECT CategoryName FROM Categories";

                using (SqlCommand command = new SqlCommand(query, ProductsConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        categorycombo.Items.Add(reader["CategoryName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                ProductsConnection.Close();
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                ProductsConnection.Open();
                string query = "SELECT SupplierName FROM Supplier order by SupplierName ASC";

                using (SqlCommand command = new SqlCommand(query, ProductsConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        suppliercombo.Items.Add(reader["SupplierName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                ProductsConnection.Close();
            }
        }

        private void RefreshProductGrid()
        {
            try
            {

                using (SqlConnection catagoriesConnection = new SqlConnection(loginForm.connectionString))
                {
                    catagoriesConnection.Open();
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


                    using (SqlCommand command = new SqlCommand(query, catagoriesConnection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        productsGridView.DataSource = dataTable;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while refreshing the grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            manager manager = new manager();
            manager.Show();
        }

        private void productsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(loginForm.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    if (cmbFilterType.SelectedItem != null)
                    {
                        string selectedFilter = cmbFilterType.SelectedItem.ToString();

                        if (selectedFilter == "Stock Level")
                        {
                            // Check if the user selected highest or lowest stock level
                            if (radioButton1.Checked) // Highest stock level
                            {
                                cmd.CommandText = @"
                        SELECT TOP 1 * 
                        FROM Products
                        ORDER BY StockLevel DESC";
                            }
                            else if (radioButton2.Checked) // Lowest stock level
                            {
                                cmd.CommandText = @"
                        SELECT TOP 1 * 
                        FROM Products
                        ORDER BY StockLevel ASC";
                            }
                            else if (!string.IsNullOrWhiteSpace(textBox1.Text)) // Specific stock level
                            {
                                cmd.CommandText = @"
                        SELECT * 
                        FROM Products
                        WHERE StockLevel = @StockLevel";
                                cmd.Parameters.AddWithValue("@StockLevel", int.Parse(textBox1.Text));
                            }
                            else
                            {
                                MessageBox.Show("Please enter a stock level or select highest/lowest option.");
                                return;
                            }
                        }
                        else if (selectedFilter == "Expiry Date")
                        {
                            // Check if specific date or range is selected
                            if (dtpFrom.Value.Date == DateTime.Today && dtpTo.Value.Date == DateTime.Today)
                            {
                                cmd.CommandText = @"
                        SELECT p.*, s.SupplierName 
                        FROM Products p
                        INNER JOIN Supplier s ON p.SupplierID = s.SupplierID
                        WHERE p.ExpiryDate = @SpecificDate";
                                cmd.Parameters.AddWithValue("@SpecificDate", dtpSpecific.Value.Date);
                            }
                            else
                            {
                                cmd.CommandText = @"
                        SELECT p.*, s.SupplierName 
                        FROM Products p
                        INNER JOIN Supplier s ON p.SupplierID = s.SupplierID
                        WHERE p.ExpiryDate BETWEEN @FromDate AND @ToDate";
                                cmd.Parameters.AddWithValue("@FromDate", dtpFrom.Value.Date);
                                cmd.Parameters.AddWithValue("@ToDate", dtpTo.Value.Date);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a valid filter type.");
                            return;
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        productsGridView.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Please select a filter type.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterType.SelectedItem != null)
            {
                string selectedFilter = cmbFilterType.SelectedItem.ToString();

                if (selectedFilter == "Stock Level")
                {
                    radioButton1.Visible = true; // Highest stock level
                    radioButton2.Visible = true; // Lowest stock level
                    textBox1.Visible = true; // Specific stock level input

                    dtpFrom.Visible = false;
                    dtpTo.Visible = false;
                    dtpSpecific.Visible = false;
                    labelSpecific.Visible = false;
                }
                else if (selectedFilter == "Expiry Date")
                {
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    textBox1.Visible = false;

                    dtpFrom.Visible = true; // Date range 'from'
                    dtpTo.Visible = true; // Date range 'to'
                    dtpSpecific.Visible = true; // Specific date
                    labelSpecific.Visible = true;
                }
            }
        }

        public void refresh_click(object sender, EventArgs e)
        {
            RefreshProductGrid();
            radioButton1.Checked = false;
            radioButton2.Checked = false;

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}


