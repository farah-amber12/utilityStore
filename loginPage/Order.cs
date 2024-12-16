using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using loginPage;
using Microsoft.Data.SqlClient; // Import this namespace for database connection
using System.Text.RegularExpressions; // Required for Regex

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
            InitializeCart();

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
                string query = "SELECT CategoryName FROM Categories order by CategoryName ASC";

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
                          WHERE c.CategoryName = @CategoryName
                            order by ProductName ASC";

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
                        decimal stockLevel = Convert.ToDecimal(reader.GetValue(0));
                        DateTime? expiryDate = reader.IsDBNull(1) ? null : reader.GetDateTime(1);

                        if (stockLevel == 0)
                        {
                            MessageBox.Show("This product is out of stock.");
                        }
                        else if (expiryDate.HasValue && expiryDate <= DateTime.Now)
                        {
                            MessageBox.Show("This product has expired.");
                        }
                        /* else
                         {
                             MessageBox.Show("This product is available for ordering.");
                         }*/
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
                            /* else
                             {
                                 MessageBox.Show("Quantity is valid. You can proceed.", "Quantity Valid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 // Additional logic to proceed with the order can be added here
                             }*/
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
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string phone = txtPhone.Text.Trim();

                // Ensure inputs are not empty
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Please fill in all customer details!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }

                // Validate phone format using Regex
                string phonePattern = @"^03[0-9]{2}-[0-9]{7}$"; // Format: 03XX-XXXXXXX
                if (!Regex.IsMatch(phone, phonePattern))
                {
                    MessageBox.Show("Phone number must be in the format 03XX-XXXXXXX.", "Invalid Phone Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /*  private void PlaceOrder(int customerId, int staffId, int productId, int quantity, decimal recievedAmount, DateTime dueDate)
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
          }*/
        /*  private void PlaceOrder(int customerId, int staffId, List<(int productId, int quantity)> cart, decimal receivedAmount, DateTime dueDate)
          {
              SqlTransaction transaction = null;

              try
              {
                  orderdbconnection.Open();
                  transaction = orderdbconnection.BeginTransaction();

                  // Step 1: Insert into Orders table and get OrderID
                  int orderId = 0;
                  using (SqlCommand orderCommand = new SqlCommand(
                      "INSERT INTO Orders (OrderDate, CustomerID, StaffID) OUTPUT INSERTED.OrderID VALUES (@OrderDate, @CustomerID, @StaffID)",
                      orderdbconnection, transaction))
                  {
                      orderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                      orderCommand.Parameters.AddWithValue("@CustomerID", customerId);
                      orderCommand.Parameters.AddWithValue("@StaffID", staffId);

                      orderId = (int)orderCommand.ExecuteScalar();
                  }

                  // Step 2: Process each product in the cart
                  decimal totalSubtotal = 0; // Total cost for the order
                  foreach (var (productId, quantity) in cart)
                  {
                      // Fetch the selling price of the product
                      decimal sellingPrice = 0;
                      using (SqlCommand priceCommand = new SqlCommand(
                          "SELECT SellingPrice FROM Products WHERE ProductID = @ProductID",
                          orderdbconnection, transaction))
                      {
                          priceCommand.Parameters.AddWithValue("@ProductID", productId);
                          object result = priceCommand.ExecuteScalar();

                          if (result != null)
                          {
                              sellingPrice = Convert.ToDecimal(result);
                          }
                          else
                          {
                              MessageBox.Show($"Product with ID {productId} not found.");
                              transaction.Rollback();
                              return;
                          }
                      }

                      // Calculate subtotal for this product
                      decimal subtotal = quantity * sellingPrice;
                      totalSubtotal += subtotal;

                      // Insert into OrderDetails
                      using (SqlCommand orderDetailsCommand = new SqlCommand(
                          "INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Subtotal, recievedAmount) VALUES (@OrderID, @ProductID, @Quantity, @Subtotal, @recievedAmount)",
                          orderdbconnection, transaction))
                      {
                          orderDetailsCommand.Parameters.AddWithValue("@OrderID", orderId);
                          orderDetailsCommand.Parameters.AddWithValue("@ProductID", productId);
                          orderDetailsCommand.Parameters.AddWithValue("@Quantity", quantity);
                          orderDetailsCommand.Parameters.AddWithValue("@Subtotal", subtotal);
                          orderDetailsCommand.Parameters.AddWithValue("@recievedAmount", receivedAmount);

                          orderDetailsCommand.ExecuteNonQuery();
                      }
                  }

                  // Step 3: Handle customer debt if totalSubtotal > receivedAmount
                  if (receivedAmount < totalSubtotal)
                  {
                      decimal debtAmount = totalSubtotal - receivedAmount;

                      using (SqlCommand debtCommand = new SqlCommand(
                          "INSERT INTO CustomerDebt (CustomerID, DebtAmount, DueDate) VALUES (@CustomerID, @DebtAmount, @DueDate)",
                          orderdbconnection, transaction))
                      {
                          debtCommand.Parameters.AddWithValue("@CustomerID", customerId);
                          debtCommand.Parameters.AddWithValue("@DebtAmount", debtAmount);
                          debtCommand.Parameters.AddWithValue("@DueDate", dueDate);

                          debtCommand.ExecuteNonQuery();
                      }
                  }

                  // Commit transaction
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


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            cashier cashier = new cashier();
            cashier.Show();
        }

        DataTable cartTable = new DataTable();
        decimal totalAmount = 0;
        private void InitializeCart()
        {

            // Initialize the cart table structure
            cartTable.Columns.Add("ProductID", typeof(int));
            cartTable.Columns.Add("ProductName", typeof(string));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Price", typeof(decimal));
            cartTable.Columns.Add("Subtotal", typeof(decimal));

            cartGridView.DataSource = cartTable;
            lblTotalAmount.Text = "0";
            DataGridViewButtonColumn removeButton = new DataGridViewButtonColumn();
            removeButton.Name = "Remove";
            removeButton.Text = "Remove";
            removeButton.UseColumnTextForButtonValue = true; // Display "Remove" text in the button

            if (!cartGridView.Columns.Contains("Remove"))
            {
                cartGridView.Columns.Add(removeButton);
            }

            // Add a handler for the button click event
            cartGridView.CellClick += CartGridView_CellClick;
            cartGridView.Columns["Quantity"].ReadOnly = false;
        }



        private void AddProductToCart(int productID, string productName, int quantity, decimal price)
        {
            // Calculate subtotal for the product
            decimal subtotal = quantity * price;

            // Add row to the cart table
            cartTable.Rows.Add(productID, productName, quantity, price, subtotal);

            // Update the total amount
            totalAmount += subtotal;
            lblTotalAmount.Text = totalAmount.ToString("F2"); // Format as currency
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                decimal sellingPrice = 0;

                //Retrieve values from form controls
                // int customerId = AddNewCustomer(); // Customer ID entered by cashier
                int quantity = int.Parse(quantityTextBox.Text);     // Quantity entered
                string productName = productselection.SelectedItem.ToString(); // Selected product name

                // Get ProductID based on product name
                int productId = ValidateProductSelection(productName); // Method to fetch ProductID
                orderdbconnection.Open();
                using (SqlCommand priceCommand = new SqlCommand(
                   "SELECT SellingPrice FROM Products WHERE ProductID = @ProductID", orderdbconnection))
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
                    // Call the PlaceOrder method
                    AddProductToCart(productId, productName, quantity, sellingPrice);
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
        private void CartGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click was on the "Remove" button column
            if (e.RowIndex >= 0 && cartGridView.Columns[e.ColumnIndex].Name == "Remove")
            {
                // Get the price and quantity of the product being removed
                decimal productSubtotal = Convert.ToDecimal(cartGridView.Rows[e.RowIndex].Cells["Subtotal"].Value);

                // Remove the row from the cart
                cartGridView.Rows.RemoveAt(e.RowIndex);

                // Update the total amount after removing the product
                UpdateTotalAmount(productSubtotal);
            }
        }

        private void UpdateTotalAmount(decimal change)
        {
            // Get the current total
            decimal currentTotal = string.IsNullOrEmpty(lblTotalAmount.Text)
                ? 0
                : Convert.ToDecimal(lblTotalAmount.Text);

            // Update the total
            currentTotal -= change;

            // Display the updated total
            lblTotalAmount.Text = currentTotal.ToString("F2");
        }

        /*  private void cartGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
          {
              try
              {
                  // Check if the edited cell belongs to the Quantity column
                  if (e.ColumnIndex == cartGridView.Columns["Quantity"].Index)
                  {
                      // Get the updated Quantity and Unit Price
                      int quantity = Convert.ToInt32(cartGridView.Rows[e.RowIndex].Cells["Quantity"].Value);
                      decimal unitPrice = Convert.ToDecimal(cartGridView.Rows[e.RowIndex].Cells["UnitPrice"].Value);

                      // Validate Quantity (optional)
                      if (quantity <= 0)
                      {
                          MessageBox.Show("Quantity must be greater than 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                          cartGridView.Rows[e.RowIndex].Cells["Quantity"].Value = 1; // Reset to default value
                          quantity = 1;
                      }

                      // Recalculate Subtotal for this row
                      decimal newSubtotal = quantity * unitPrice;
                      cartGridView.Rows[e.RowIndex].Cells["Subtotal"].Value = newSubtotal;
                     // cartGridView.CellEndEdit += cartGridView_CellEndEdit;

                      // Recalculate Total Amount for the cart
                      RecalculateTotalAmount();
                  }
              }
              catch (Exception ex)
              {
                  MessageBox.Show($"Error updating quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
          }
          private void RecalculateTotalAmount()
          {
              decimal totalAmount = 0;

              foreach (DataGridViewRow row in cartGridView.Rows)
              {
                  // Skip empty or invalid rows
                  if (row.Cells["Subtotal"].Value != null)
                  {
                      totalAmount += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                  }
              }

              // Update the Total Amount Label
              lblTotalAmount.Text = totalAmount.ToString("F2");
          }*/

        /*private void PlaceOrder(int customerId, int staffId, List<(int productId, int quantity)> cart, decimal recievedAmount)
        {
            SqlTransaction transaction = null;

            try
            {
                orderdbconnection.Open();
                transaction = orderdbconnection.BeginTransaction();

                // Step 1: Insert into Orders table and get OrderID
                int orderId = 0;
                using (SqlCommand orderCommand = new SqlCommand(
                    "INSERT INTO Orders (OrderDate, CustomerID, StaffID) OUTPUT INSERTED.OrderID VALUES (@OrderDate, @CustomerID, @StaffID)",
                    orderdbconnection, transaction))
                {
                    orderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    orderCommand.Parameters.AddWithValue("@CustomerID", customerId);
                    orderCommand.Parameters.AddWithValue("@StaffID", staffId);

                    orderId = (int)orderCommand.ExecuteScalar();
                }

                // Step 2: Process each product in the cart
                decimal totalSubtotal = 0; // Total cost for the order
                foreach (var (productId, quantity) in cart)
                {
                    // Fetch the selling price of the product
                    decimal sellingPrice = 0;
                    using (SqlCommand priceCommand = new SqlCommand(
                        "SELECT SellingPrice FROM Products WHERE ProductID = @ProductID",
                        orderdbconnection, transaction))
                    {
                        priceCommand.Parameters.AddWithValue("@ProductID", productId);
                        object result = priceCommand.ExecuteScalar();

                        if (result != null)
                        {
                            sellingPrice = Convert.ToDecimal(result);
                        }
                        else
                        {
                            MessageBox.Show($"Product with ID {productId} not found.");
                            transaction.Rollback();
                            return;
                        }
                    }

                    // Calculate subtotal for this product
                    decimal subtotal = quantity * sellingPrice;
                    totalSubtotal += subtotal;

                    // Insert into OrderDetails
                    using (SqlCommand orderDetailsCommand = new SqlCommand(
                        "INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Subtotal, recievedAmount) VALUES (@OrderID, @ProductID, @Quantity, @Subtotal, @recievedAmount)",
                        orderdbconnection, transaction))
                    {
                        orderDetailsCommand.Parameters.AddWithValue("@OrderID", orderId);
                        orderDetailsCommand.Parameters.AddWithValue("@ProductID", productId);
                        orderDetailsCommand.Parameters.AddWithValue("@Quantity", quantity);
                        orderDetailsCommand.Parameters.AddWithValue("@Subtotal", subtotal);
                        orderDetailsCommand.Parameters.AddWithValue("@recievedAmount", recievedAmount);

                        orderDetailsCommand.ExecuteNonQuery();
                    }
                }
                debtDueDateLabel.Visible = false;
                debtDueDatePicker.Visible = false;
                // Step 3: Handle customer debt only if there is any
                if (recievedAmount < totalSubtotal)
                {
                    decimal debtAmount = totalSubtotal - recievedAmount;

                    // Calculate due date (e.g., 30 days from now)
                    DateTime dueDate = DateTime.Now.AddDays(30);
                    //  debtDueDateLabel.Visible = true;
                    // debtDueDatePicker.Visible = true;

                    //    MessageBox.Show("Received amount is less than the total. Please select a due date.");


                    // Insert into the CustomerDebt table
                    using (SqlCommand debtCommand = new SqlCommand(
                        "INSERT INTO CustomerDebt (CustomerID, DebtAmount, DueDate) VALUES (@CustomerID, @DebtAmount, @DueDate)",
                        orderdbconnection, transaction))
                    {
                        debtCommand.Parameters.AddWithValue("@CustomerID", customerId);
                        debtCommand.Parameters.AddWithValue("@DebtAmount", debtAmount);
                        debtCommand.Parameters.AddWithValue("@DueDate", dueDate);

                        debtCommand.ExecuteNonQuery();
                    }

                    // Inform the cashier about the debt
                    //    MessageBox.Show($"Debt of {debtAmount:C} has been recorded for Customer ID: {customerId}. Due date: {dueDate.ToShortDateString()}");
                }
                //                else
                //              {
                //                // Hide the controls if no debt
                // debtDueDateLabel.Visible = false;
                //debtDueDatePicker.Visible = false;
                //      }

                // Commit transaction
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

        private void PlaceOrder(int customerId, int staffId, List<(int productId, int quantity)> cart, decimal recievedAmount)
        {
            SqlTransaction transaction = null;

            try
            {
                orderdbconnection.Open();
                transaction = orderdbconnection.BeginTransaction();

                // Step 1: Insert into Orders table and get OrderID
                int orderId = 0;
                using (SqlCommand orderCommand = new SqlCommand(
                    "INSERT INTO Orders (OrderDate, CustomerID, StaffID) OUTPUT INSERTED.OrderID VALUES (@OrderDate, @CustomerID, @StaffID)",
                    orderdbconnection, transaction))
                {
                    orderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    orderCommand.Parameters.AddWithValue("@CustomerID", customerId);
                    orderCommand.Parameters.AddWithValue("@StaffID", staffId);

                    orderId = (int)orderCommand.ExecuteScalar();
                }

                // Step 2: Process each product in the cart
                decimal totalSubtotal = 0; // Total cost for the order
                decimal totalProfit = 0;   // Total profit for the order
                foreach (var (productId, quantity) in cart)
                {
                    int sellingPrice = 0;
                    int purchasePrice = 0;

                    // Fetch selling and purchase prices for the product
                    using (SqlCommand priceCommand = new SqlCommand(
                        "SELECT SellingPrice, PurchasePrice FROM Products WHERE ProductID = @ProductID",
                        orderdbconnection, transaction))
                    {
                        priceCommand.Parameters.AddWithValue("@ProductID", productId);
                        using (var reader = priceCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                sellingPrice = reader.GetInt32(0);
                                purchasePrice = reader.GetInt32(1);
                            }
                            else
                            {
                                MessageBox.Show($"Product with ID {productId} not found.");
                                transaction.Rollback();
                                return;
                            }
                        }
                    }

                    // Calculate subtotal and profit for this product
                    decimal subtotal = quantity * sellingPrice;
                    decimal profit = (sellingPrice - purchasePrice) * quantity;
                    totalSubtotal += subtotal;
                    totalProfit += profit;

                    // Insert into OrderDetails
                    using (SqlCommand orderDetailsCommand = new SqlCommand(
                        "INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Subtotal, recievedAmount) VALUES (@OrderID, @ProductID, @Quantity, @Subtotal, @recievedAmount)",
                        orderdbconnection, transaction))
                    {
                        orderDetailsCommand.Parameters.AddWithValue("@OrderID", orderId);
                        orderDetailsCommand.Parameters.AddWithValue("@ProductID", productId);
                        orderDetailsCommand.Parameters.AddWithValue("@Quantity", quantity);
                        orderDetailsCommand.Parameters.AddWithValue("@Subtotal", subtotal);
                        orderDetailsCommand.Parameters.AddWithValue("@recievedAmount", recievedAmount);

                        orderDetailsCommand.ExecuteNonQuery();
                    }
                }

                // Step 3: Insert or update profit in Profit table
                using (SqlCommand profitCommand = new SqlCommand(
     "IF EXISTS (SELECT 1 FROM dailyProfit WHERE Dates = @Date) " +
     "UPDATE dailyProfit SET ProfitAmount = ProfitAmount + @ProfitAmount WHERE Dates = @Date " +
     "ELSE " +
     "INSERT INTO dailyProfit (Dates, ProfitAmount) VALUES (@Date, @ProfitAmount)",
     orderdbconnection, transaction))
                {
                    profitCommand.Parameters.AddWithValue("@Date", DateTime.Today);  // Ensure this matches the SQL query
                    profitCommand.Parameters.AddWithValue("@ProfitAmount", totalProfit);

                    profitCommand.ExecuteNonQuery();
                }

                // Step 4: Handle customer debt only if there is any
                if (recievedAmount < totalSubtotal)
                {
                    decimal debtAmount = totalSubtotal - recievedAmount;

                    // Calculate due date (e.g., 30 days from now)
                    DateTime dueDate = DateTime.Now.AddDays(30);

                    // Insert into the CustomerDebt table
                    using (SqlCommand debtCommand = new SqlCommand(
                        "INSERT INTO CustomerDebt (CustomerID, DebtAmount, DueDate) VALUES (@CustomerID, @DebtAmount, @DueDate)",
                        orderdbconnection, transaction))
                    {
                        debtCommand.Parameters.AddWithValue("@CustomerID", customerId);
                        debtCommand.Parameters.AddWithValue("@DebtAmount", debtAmount);
                        debtCommand.Parameters.AddWithValue("@DueDate", dueDate);

                        debtCommand.ExecuteNonQuery();
                    }
                }

                // Commit transaction
                transaction.Commit();
                MessageBox.Show("Order placed successfully, and profit recorded!");
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
        }



        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                // Step 1: Add new customer
                int customerId = AddNewCustomer();
                if (customerId == -1) return;

                // Step 2: Fetch StaffID
                int staffId = GetStaffIDByUsername(staffcombo.SelectedItem.ToString());
                if (staffId == -1) return;

                // Step 3: Create cart (list of product IDs and quantities)
                List<(int productId, int quantity)> cart = new List<(int, int)>();

                foreach (DataGridViewRow row in cartGridView.Rows)
                {
                    if (!row.IsNewRow && row.Cells["ProductName"] != null && row.Cells["ProductName"].Value != null)
                    {
                        string productName = row.Cells["ProductName"].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(productName))
                        {
                            int productId = ValidateProductSelection(productName);
                            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                            if (productId != -1 && quantity > 0)
                            {
                                cart.Add((productId, quantity));
                            }
                            else
                            {
                                MessageBox.Show("Invalid product or quantity. Please check the cart.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Product name cannot be empty. Please check the cart.");
                        }
                    }
                }

                // Step 4: Validate received amount
                decimal receivedAmount = decimal.Parse(rcvdamount.Text);
                if (receivedAmount < 0) throw new Exception("Received amount cannot be negative.");

                // Step 5: Call PlaceOrder
                PlaceOrder(customerId, staffId, cart, receivedAmount);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please ensure all numeric fields are valid.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cartGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
    
