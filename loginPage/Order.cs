using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using loginPage;
using Microsoft.Data.SqlClient; // Import this namespace for database connection

namespace loginPage
{
    public partial class Order : Form
    {
        private readonly SqlConnection orderdbconnection;

        public Order()
        {
            InitializeComponent();
            orderdbconnection = new SqlConnection(loginForm.connectionString);
            LoadCategories();
            PopulateStaffDropdown();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            categoryselection.Focus();
        }

        private void categoryselection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryselection.SelectedItem != null)
            {
                string selectedCategory = categoryselection.SelectedItem.ToString();
                LoadProducts(selectedCategory);
            }
        }
        private void LoadCategories()
        {
            try
            {
                orderdbconnection.Open();
                string query = "SELECT CategoryName FROM Categories";

                using (SqlCommand command = new SqlCommand(query, orderdbconnection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        categoryselection.Items.Add(reader["CategoryName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                orderdbconnection.Close();
            }
        }
        private void LoadProducts(string categoryName)
        {
            try
            {
                // Open the database connection
                orderdbconnection.Open();

                // Query to fetch products based on the selected category name
                string query = @"SELECT ProductName 
                          FROM Products p
                          JOIN Categories c ON p.CategoryID = c.CategoryID
                          WHERE c.CategoryName = @CategoryName";

                using (SqlCommand command = new SqlCommand(query, orderdbconnection))
                {
                    // Add the category name parameter to prevent SQL injection
                    command.Parameters.AddWithValue("@CategoryName", categoryName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in the product combo box
                        productselection.Items.Clear();

                        // Read the products and add them to the product combo box
                        while (reader.Read())
                        {
                            productselection.Items.Add(reader["ProductName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Close the database connection
                orderdbconnection.Close();
            }
        }
        private int ValidateProductSelection(string productName)
        {
            int productId = -1; // Default value for ProductID if not found or an issue occurs

            try
            {
                orderdbconnection.Open();

                // First, retrieve the ProductID for the given ProductName
                using (SqlCommand idCommand = new SqlCommand("SELECT ProductID FROM Products WHERE ProductName = @ProductName", orderdbconnection))
                {
                    idCommand.Parameters.AddWithValue("@ProductName", productName);

                    object result = idCommand.ExecuteScalar();
                    if (result != null)
                    {
                        productId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Product not found in the database.");
                        return productId; // Return -1 since the product was not found
                    }
                }

                // Now validate the stock level and expiry for the retrieved ProductID
                using (SqlCommand validationCommand = new SqlCommand("SELECT StockLevel, ExpiryDate FROM Products WHERE ProductID = @ProductID", orderdbconnection))
                {
                    validationCommand.Parameters.AddWithValue("@ProductID", productId);

                    SqlDataReader reader = validationCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        // Read StockLevel as a decimal
                        decimal stockLevel = reader.GetDecimal(0);
                        DateTime? expiryDate = reader.IsDBNull(1) ? null : reader.GetDateTime(1);

                        if (stockLevel == 0)
                        {
                            MessageBox.Show("This product is out of stock.");
                        }
                        else if (expiryDate.HasValue && expiryDate <= DateTime.Now)
                        {
                            MessageBox.Show("This product has expired.");
                        }
                        else
                        {
                            MessageBox.Show("This product is available for ordering.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve product details.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error validating product: {ex.Message}");
            }
            finally
            {
                orderdbconnection.Close();
            }

            return productId; // Return the ProductID (or -1 if an issue occurred)
        }

        /* private void ValidateProductSelection(string productName)
         {
             try
             {
                 orderdbconnection.Open();

                 // First, retrieve the ProductID for the given ProductName
                 int productId = -1;

                 using (SqlCommand idCommand = new SqlCommand("SELECT ProductID FROM Products WHERE ProductName = @ProductName", orderdbconnection))
                 {
                     idCommand.Parameters.AddWithValue("@ProductName", productName);

                     object result = idCommand.ExecuteScalar();
                     if (result != null)
                     {
                         productId = Convert.ToInt32(result);
                     }
                     else
                     {
                         MessageBox.Show("Product not found in the database.");
                         return;
                     }
                 }

                 // Now validate the stock level and expiry for the retrieved ProductID
                 using (SqlCommand validationCommand = new SqlCommand("SELECT StockLevel, ExpiryDate FROM Products WHERE ProductID = @ProductID", orderdbconnection))
                 {
                     validationCommand.Parameters.AddWithValue("@ProductID", productId);

                     SqlDataReader reader = validationCommand.ExecuteReader();

                     if (reader.Read())
                     {
                         // Read StockLevel as a decimal
                         decimal stockLevel = reader.GetDecimal(0);
                         DateTime? expiryDate = reader.IsDBNull(1) ? null : reader.GetDateTime(1);

                         if (stockLevel == 0)
                         {
                             MessageBox.Show("This product is out of stock.");
                         }
                         else if (expiryDate.HasValue && expiryDate <= DateTime.Now)
                         {
                             MessageBox.Show("This product has expired.");
                         }
                         else
                         {
                             MessageBox.Show("This product is available for ordering.");
                         }
                     }
                     else
                     {
                         MessageBox.Show("Failed to retrieve product details.");
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show($"Error validating product: {ex.Message}");
             }
             finally
             {
                 orderdbconnection.Close();
             }
         }*/


        private void productselection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productselection.SelectedItem != null)
            {
                string selectedProductName = productselection.Text;
                ValidateProductSelection(selectedProductName);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void checkQuantityButton_Click(object sender, EventArgs e)
        {
            // Ensure a product is selected
            if (productselection.SelectedItem == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            // Ensure quantity is entered
            if (string.IsNullOrWhiteSpace(quantityTextBox.Text))
            {
                MessageBox.Show("Please enter a quantity.");
                return;
            }

            // Get the product name and quantity
            string productName = productselection.SelectedItem.ToString();
            int quantityRequested;

            // Validate if the entered quantity is a valid integer
            if (!int.TryParse(quantityTextBox.Text, out quantityRequested) || quantityRequested <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for quantity.");
                return;
            }

            // Call the method to check quantity
            CheckProductQuantity(productName, quantityRequested);
            AddNewCustomer();
        }

        private void CheckProductQuantity(string productName, int quantityRequested)
        {
            string query = @"
        SELECT ProductID, StockLevel 
        FROM Products 
        WHERE ProductName = @ProductName";

            try
            {
                orderdbconnection.Open();
                using (SqlCommand command = new SqlCommand(query, orderdbconnection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int productId = Convert.ToInt32(reader["ProductID"]);
                            int stockLevel = Convert.ToInt32(reader["StockLevel"]);

                            // Check if requested quantity exceeds stock level
                            if (quantityRequested > stockLevel)
                            {
                                MessageBox.Show($"Error: Requested quantity exceeds available stock. Total stock level is {stockLevel}.",
                                    "Quantity Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Quantity is valid. You can proceed.", "Quantity Valid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Additional logic to proceed with the order can be added here
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: Product not found.", "Product Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                orderdbconnection.Close();
            }
        }



        private void quantityTextBox_Leave_1(object sender, EventArgs e)
        {
            // Ensure quantity is a valid integer
            if (!int.TryParse(quantityTextBox.Text, out int quantityRequested))
            {
                MessageBox.Show("Please enter a valid quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure a product is selected
            if (productselection.SelectedItem == null)
            {
                MessageBox.Show("Please select a product first.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected product name and check its stock level
            string productName = productselection.SelectedItem.ToString();
            CheckProductQuantity(productName, quantityRequested);
        }

        private int AddNewCustomer()
        {
            try
            {
                // Fetch values directly from input fields
                string firstName = txtFirstName.Text.Trim(); // Replace txtFirstName with your actual text box name
                string lastName = txtLastName.Text.Trim();  // Replace txtLastName with your actual text box name
                string phone = txtPhone.Text.Trim();        // Replace txtPhone with your actual text box name

                // Ensure inputs are not empty
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Please fill in all customer details!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }

                orderdbconnection.Open();

                // Query to insert a new customer
                string query = @"INSERT INTO Customers (FirstName, LastName, Phone) 
                             VALUES (@FirstName, @LastName, @Phone);
                             SELECT SCOPE_IDENTITY();"; // Get the new CustomerID

                using (SqlCommand command = new SqlCommand(query, orderdbconnection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Phone", phone);

                    // Execute query and retrieve the CustomerID
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result); // Return the newly generated CustomerID
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                orderdbconnection.Close();
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {

        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            int customerId = AddNewCustomer();

            if (customerId != -1)
            {
                // Store the CustomerID for later use (e.g., for orders)
                MessageBox.Show($"Customer added with ID: {customerId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optional: Clear textboxes for new input
                // txtFirstName.Clear();
                // txtLastName.Clear();
                // txtPhone.Clear();

                // Proceed with order creation if required
            }
            else
            {
                MessageBox.Show("Failed to add customer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (staffcombo.SelectedItem != null)
            {
                // Get the selected username from the dropdown
                string selectedUsername = staffcombo.SelectedItem.ToString();

                // Pass the username to the method
                int staffId = GetStaffIDByUsername(selectedUsername);

                // Handle the returned StaffID
                if (staffId != -1)
                {
                    MessageBox.Show($"Selected Staff ID: {staffId}");
                }
                else
                {
                    MessageBox.Show("Staff not found!");
                }
            }
        }
        // Method to populate the dropdown
        private void PopulateStaffDropdown()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
                {
                    connection.Open();

                    // Query to fetch Username and StaffID
                    string query = @"SELECT StaffID, Username FROM Staff";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            staffcombo.Items.Clear(); // Clear existing items

                            while (reader.Read())
                            {
                                // Add only the username to the dropdown
                                staffcombo.Items.Add(reader["Username"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff data: {ex.Message}");
            }
        }



        // Method to retrieve StaffID from selected name
        private int GetStaffIDByUsername(string username)
        {
            int staffId = -1; // Default value if not found

            try
            {
                using (SqlConnection connection = new SqlConnection(loginForm.connectionString))
                {
                    connection.Open();

                    // Query to get the StaffID for the given username
                    string query = @"SELECT StaffID FROM Staff WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            staffId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching Staff ID: {ex.Message}");
            }

            return staffId;
        }

        /* private void PlaceOrder(int customerId, int staffId, int productId, int quantity)
          {
              SqlTransaction transaction = null;

              try
              {
                  orderdbconnection.Open();

                  // Begin a transaction to ensure consistency
                  transaction = orderdbconnection.BeginTransaction();

                  // Insert into Orders table
                  int orderId = -1;
                  using (SqlCommand orderCommand = new SqlCommand(
                      "INSERT INTO Orders (OrderDate, CustomerID, StaffID) OUTPUT INSERTED.OrderID VALUES (@OrderDate, @CustomerID, @StaffID)",
                      orderdbconnection, transaction))
                  {
                      orderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                      orderCommand.Parameters.AddWithValue("@CustomerID", customerId);
                      orderCommand.Parameters.AddWithValue("@StaffID", staffId);

                      orderId = (int)orderCommand.ExecuteScalar(); // Get the newly created OrderID
                  }

                  if (orderId == -1)
                  {
                      throw new Exception("Failed to insert into Orders table.");
                  }

                  // Retrieve the SellingPrice of the product
                  decimal sellingPrice = 0;
                  using (SqlCommand priceCommand = new SqlCommand(
                      "SELECT SellingPrice FROM Products WHERE ProductID = @ProductID", orderdbconnection, transaction))
                  {
                      priceCommand.Parameters.AddWithValue("@ProductID", productId);

                      object result = priceCommand.ExecuteScalar();
                      if (result != null)
                      {
                          sellingPrice = Convert.ToDecimal(result);
                      }
                      else
                      {
                          throw new Exception($"Failed to retrieve SellingPrice for ProductID {productId}.");
                      }
                  }

                  // Calculate Subtotal
                  decimal subtotal = sellingPrice * quantity;

                  // Insert into OrderDetails table
                  using (SqlCommand detailsCommand = new SqlCommand(
                      "INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Subtotal) VALUES (@OrderID, @ProductID, @Quantity, @Subtotal)",
                      orderdbconnection, transaction))
                  {
                      detailsCommand.Parameters.AddWithValue("@OrderID", orderId);
                      detailsCommand.Parameters.AddWithValue("@ProductID", productId);
                      detailsCommand.Parameters.AddWithValue("@Quantity", quantity);
                      detailsCommand.Parameters.AddWithValue("@Subtotal", subtotal);

                      detailsCommand.ExecuteNonQuery();
                  }

                  // Reduce the stock level of the product
                  using (SqlCommand updateStockCommand = new SqlCommand(
                      "UPDATE Products SET StockLevel = StockLevel - @Quantity WHERE ProductID = @ProductID",
                      orderdbconnection, transaction))
                  {
                      updateStockCommand.Parameters.AddWithValue("@Quantity", quantity);
                      updateStockCommand.Parameters.AddWithValue("@ProductID", productId);

                      updateStockCommand.ExecuteNonQuery();
                  }

                  // Commit the transaction
                  transaction.Commit();
                  MessageBox.Show("Order placed successfully!");
              }
              catch (Exception ex)
              {
                  transaction?.Rollback();
                  MessageBox.Show($"Error placing order: {ex.Message}");
              }
              finally
              {
                  orderdbconnection.Close();
              }
          }*/
        private void PlaceOrder(int customerId, int staffId, int productId, int quantity, decimal recievedAmount, DateTime dueDate)
        {
            SqlTransaction transaction = null;
            try
            {
                orderdbconnection.Open();

                // Start a transaction
                transaction = orderdbconnection.BeginTransaction();


                // Fetch the selling price of the product using the product ID
                decimal sellingPrice = 0;
                using (SqlCommand priceCommand = new SqlCommand("SELECT SellingPrice FROM Products WHERE ProductID = @ProductID", orderdbconnection, transaction))
                {
                    priceCommand.Parameters.AddWithValue("@ProductID", productId);
                    object result = priceCommand.ExecuteScalar();

                    if (result != null)
                    {
                        sellingPrice = Convert.ToDecimal(result);
                    }
                    else
                    {
                        MessageBox.Show("Product not found.");
                        transaction.Rollback(); // Rollback if product is not found
                        return;
                    }
                }

                // Calculate the subtotal (Quantity * SellingPrice)
                decimal subtotal = quantity * sellingPrice;
                txtSubtotal.Text = subtotal.ToString("F2");

                // Insert into the Orders table
                int orderId = 0;
                using (SqlCommand orderCommand = new SqlCommand("INSERT INTO Orders (OrderDate, CustomerID, StaffID) OUTPUT INSERTED.OrderID VALUES (@OrderDate, @CustomerID, @StaffID)", orderdbconnection, transaction))
                {
                    orderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    orderCommand.Parameters.AddWithValue("@CustomerID", customerId);
                    orderCommand.Parameters.AddWithValue("@StaffID", staffId);

                    orderId = (int)orderCommand.ExecuteScalar(); // Get the OrderID from the inserted record
                }

                // Insert into the OrderDetails table
                using (SqlCommand orderDetailsCommand = new SqlCommand("INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Subtotal, recievedAmount) VALUES (@OrderID, @ProductID, @Quantity, @Subtotal, @recievedAmount)", orderdbconnection, transaction))
                {
                    orderDetailsCommand.Parameters.AddWithValue("@OrderID", orderId);
                    orderDetailsCommand.Parameters.AddWithValue("@ProductID", productId);
                    orderDetailsCommand.Parameters.AddWithValue("@Quantity", quantity);
                    orderDetailsCommand.Parameters.AddWithValue("@Subtotal", subtotal);
                    orderDetailsCommand.Parameters.AddWithValue("@recievedAmount", recievedAmount);
                    orderDetailsCommand.ExecuteNonQuery(); // Insert order details
                }

                // Handle customer debt if received amount is less than subtotal
                if (recievedAmount < subtotal)
                {
                    decimal debtAmount = subtotal - recievedAmount;

                    // Insert into the CustomerDebt table
                    using (SqlCommand debtCommand = new SqlCommand("INSERT INTO CustomerDebt (CustomerID, DebtAmount, DueDate) VALUES (@CustomerID, @DebtAmount,  @DueDate)", orderdbconnection, transaction))
                    {
                        debtCommand.Parameters.AddWithValue("@CustomerID", customerId);
                        debtCommand.Parameters.AddWithValue("@DebtAmount", debtAmount);
                        debtCommand.Parameters.AddWithValue("@DueDate", dueDate);
                        debtCommand.ExecuteNonQuery(); // Insert debt record
                    }

                    //  MessageBox.Show($"Debt of {debtAmount:C} has been recorded. Due date: {dueDate.ToShortDateString()}");
                }

                // Commit the transaction
                transaction.Commit();

                // Show a success message
                MessageBox.Show("Order placed successfully!");
            }
            catch (Exception ex)
            {
                // Rollback if there is any error
                transaction?.Rollback();
                MessageBox.Show($"Error placing order: {ex.Message}");
            }
            finally
            {
                orderdbconnection.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Retrieve values from form controls
                int customerId = AddNewCustomer(); // Customer ID entered by cashier
                int quantity = int.Parse(quantityTextBox.Text);     // Quantity entered
                string staffUsername = staffcombo.SelectedItem.ToString(); // Selected staff username
                string productName = productselection.SelectedItem.ToString(); // Selected product name

                // Get StaffID based on username
                int staffId = GetStaffIDByUsername(staffUsername); // Method to fetch StaffID

                // Get ProductID based on product name
                int productId = ValidateProductSelection(productName); // Method to fetch ProductID
                int recievedAmount = int.Parse(rcvdamount.Text);
                DateTime selectedDate = DateTime.Now;

                // Call the PlaceOrder method
                PlaceOrder(customerId, staffId, productId, quantity, recievedAmount, selectedDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}