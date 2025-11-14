using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashiering_Lloren_IT13
{
    public partial class CashieringForm : Form
    {
        // Database connection string
        private string connectionString = "Data Source=NIKOLA\\SQLEXPRESS;Initial Catalog=DB_Cashiering_Lloren_IT13;Integrated Security=True;Encrypt=False";
        
        // Dictionary to store product data (ProductID, Price)
        private Dictionary<int, (string ProductName, decimal Price)> products = new Dictionary<int, (string, decimal)>();
        
        // DataTable to store current cart items
        private DataTable cartTable = new DataTable();

        public CashieringForm()
        {
            InitializeComponent();
            InitializeCart();
            LoadProducts();
        }

        // Initialize DataGridView columns for shopping cart
        private void InitializeCart()
        {
            cartTable.Columns.Add("ProductID", typeof(int));
            cartTable.Columns.Add("Product Name", typeof(string));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Price", typeof(decimal));
            cartTable.Columns.Add("Total", typeof(decimal));

            dgvCart.DataSource = cartTable;
            dgvCart.Columns["ProductID"].Visible = false;

            // Format and style columns
            dgvCart.Columns["Product Name"].Width = 200;
            dgvCart.Columns["Product Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            
            dgvCart.Columns["Quantity"].Width = 80;
            dgvCart.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgvCart.Columns["Price"].Width = 130;
            dgvCart.Columns["Price"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvCart.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            dgvCart.Columns["Total"].Width = 130;
            dgvCart.Columns["Total"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvCart.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        // ==================== READ FUNCTION ====================
        // Load all products from database and populate ComboBox
        private void LoadProducts()
        {
            try
            {
                cmbProducts.Items.Clear();
                products.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Only load non-archived products with available quantity
                    string query = "SELECT ProductID, ProductName, Price FROM Products WHERE Quantity > 0 AND IsArchived = 0 ORDER BY ProductName";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int productId = reader.GetInt32(0);
                        string productName = reader.GetString(1);
                        decimal price = reader.GetDecimal(2);

                        cmbProducts.Items.Add(productName);
                        products[productId] = (productName, price);
                    }
                }

                if (cmbProducts.Items.Count > 0)
                    cmbProducts.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        // ==================== CREATE / ADD TO CART FUNCTION ====================
        // Add selected product to shopping cart
        private void btnAddCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProducts.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a product.");
                    return;
                }

                string selectedProductName = cmbProducts.SelectedItem.ToString();
                int quantity = (int)numQuantity.Value;

                // Find the ProductID from the selected product name
                var productEntry = products.FirstOrDefault(p => p.Value.ProductName == selectedProductName);
                if (productEntry.Key == 0)
                {
                    MessageBox.Show("Invalid product selected.");
                    return;
                }

                int productId = productEntry.Key;
                decimal price = productEntry.Value.Price;
                decimal total = price * quantity;

                // Check if product already exists in cart
                DataRow existingRow = cartTable.AsEnumerable().FirstOrDefault(r => r.Field<int>("ProductID") == productId);
                
                if (existingRow != null)
                {
                    // Update quantity and total
                    int currentQuantity = existingRow.Field<int>("Quantity");
                    existingRow["Quantity"] = currentQuantity + quantity;
                    existingRow["Total"] = price * (currentQuantity + quantity);
                }
                else
                {
                    // Add new row to cart
                    DataRow newRow = cartTable.NewRow();
                    newRow["ProductID"] = productId;
                    newRow["Product Name"] = selectedProductName;
                    newRow["Quantity"] = quantity;
                    newRow["Price"] = price;
                    newRow["Total"] = total;
                    cartTable.Rows.Add(newRow);
                }

                UpdateTotal();
                numQuantity.Value = 1;
                MessageBox.Show("Product added to cart!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product to cart: " + ex.Message);
            }
        }

        // ==================== UPDATE / REMOVE FROM CART FUNCTION ====================
        // Remove selected item from cart (optional - can be triggered by row deletion)
        private void RemoveFromCart(int rowIndex)
        {
            try
            {
                if (rowIndex >= 0 && rowIndex < cartTable.Rows.Count)
                {
                    cartTable.Rows[rowIndex].Delete();
                    UpdateTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing item: " + ex.Message);
            }
        }

        // ==================== CALCULATE TOTAL FUNCTION ====================
        // Calculate and update the total price
        private void UpdateTotal()
        {
            try
            {
                decimal total = 0;
                foreach (DataRow row in cartTable.Rows)
                {
                    total += row.Field<decimal>("Total");
                }
                lblTotal.Text = $"TOTAL: ₱{total:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating total: " + ex.Message);
            }
        }

        // ==================== CREATE / FINALIZE SALE FUNCTION ====================
        // Finalize the sale and save transaction to database
        private void btnFinalizeSale_Click(object sender, EventArgs e)
        {
            try
            {
                if (cartTable.Rows.Count == 0)
                {
                    MessageBox.Show("Cart is empty. Please add products.");
                    return;
                }

                // Calculate total
                decimal totalAmount = 0;
                foreach (DataRow row in cartTable.Rows)
                {
                    totalAmount += row.Field<decimal>("Total");
                }

                // Confirm sale
                DialogResult result = MessageBox.Show($"Total Amount: ₱{totalAmount:F2}\n\nConfirm finalize sale?", "Finalize Sale", MessageBoxButtons.YesNo);
                
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            // Insert transaction record
                            string transactionQuery = "INSERT INTO Transactions (TransactionDate, TotalAmount) OUTPUT INSERTED.TransactionID VALUES (GETDATE(), @totalAmount)";
                            SqlCommand transactionCommand = new SqlCommand(transactionQuery, connection, transaction);
                            transactionCommand.Parameters.AddWithValue("@totalAmount", totalAmount);
                            int transactionId = (int)transactionCommand.ExecuteScalar();

                            // Insert transaction details for each item
                            foreach (DataRow row in cartTable.Rows)
                            {
                                int productId = row.Field<int>("ProductID");
                                int quantity = row.Field<int>("Quantity");
                                decimal price = row.Field<decimal>("Price");
                                decimal itemTotal = row.Field<decimal>("Total");

                                string detailQuery = "INSERT INTO TransactionDetails (TransactionID, ProductID, Quantity, UnitPrice, Total) VALUES (@transactionId, @productId, @quantity, @unitPrice, @total)";
                                SqlCommand detailCommand = new SqlCommand(detailQuery, connection, transaction);
                                detailCommand.Parameters.AddWithValue("@transactionId", transactionId);
                                detailCommand.Parameters.AddWithValue("@productId", productId);
                                detailCommand.Parameters.AddWithValue("@quantity", quantity);
                                detailCommand.Parameters.AddWithValue("@unitPrice", price);
                                detailCommand.Parameters.AddWithValue("@total", itemTotal);

                                detailCommand.ExecuteNonQuery();

                                // Update product quantity
                                string updateQuery = "UPDATE Products SET Quantity = Quantity - @quantity WHERE ProductID = @productId";
                                SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction);
                                updateCommand.Parameters.AddWithValue("@quantity", quantity);
                                updateCommand.Parameters.AddWithValue("@productId", productId);

                                updateCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show($"Sale finalized successfully!\nTransaction ID: {transactionId}\nTotal: ₱{totalAmount:F2}");
                            
                            // Clear cart and reload products
                            cartTable.Clear();
                            LoadProducts();
                            UpdateTotal();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error finalizing sale: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ==================== MANAGEMENT FUNCTION ====================
        // Open ProductManagement form
        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            ProductManagement productManagementForm = new ProductManagement();
            productManagementForm.ShowDialog();
            
            // Reload products after returning from ProductManagement form
            LoadProducts();
        }
    }
}
