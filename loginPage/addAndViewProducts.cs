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
            LoadSuppliers();
            LoadCategories();
            RefreshProductGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
                ProductsConnection.Open();
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

                using (SqlCommand command = new SqlCommand(query, ProductsConnection))
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

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ProductsConnection.Close();
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
                string query = "SELECT SupplierName FROM Supplier";

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
                ProductsConnection.Open();
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

                using (SqlCommand command = new SqlCommand(query, ProductsConnection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    productsGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while refreshing the grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ProductsConnection.Close();
            }
        }
    }
}
