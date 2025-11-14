using System.Data;
using System.Data.SqlClient;

namespace Cashiering_Lloren_IT13
{
    public partial class ProductManagement : Form
    {
        // Database connection string
        private string connectionString = "Data Source=NIKOLA\\SQLEXPRESS;Initial Catalog=DB_Cashiering_Lloren_IT13;Integrated Security=True;Encrypt=False";
        private int selectedProductId = -1;

        public ProductManagement()
        {
            InitializeComponent();
            LoadProducts();
        }

        //  READ / VIEW FUNCTION
       
        private void LoadProducts()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ProductID, ProductName, Price, Quantity FROM Products WHERE IsArchived = 0 ORDER BY ProductName";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    dataGridView1.Columns["ProductID"].Width = 80;
                    dataGridView1.Columns["ProductID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    
                    dataGridView1.Columns["ProductName"].Width = 200;
                    
                    if (dataGridView1.Columns.Contains("Price"))
                    {
                        dataGridView1.Columns["Price"].Width = 120;
                        dataGridView1.Columns["Price"].DefaultCellStyle.Format = "₱#,##0.00";
                        dataGridView1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    
                    if (dataGridView1.Columns.Contains("Quantity"))
                    {
                        dataGridView1.Columns["Quantity"].Width = 100;
                        dataGridView1.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    selectedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);
                    txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    txtPrice.Text = price.ToString("F2");
                    txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting product: " + ex.Message);
            }
        }

        //  CREATE / INSERT FUNCTION 
    
        private void btnSaveAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProductName.Text) || 
                    string.IsNullOrWhiteSpace(txtPrice.Text) || 
                    string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Products (ProductName, Price, Quantity) VALUES (@productName, @price, @quantity)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@productName", txtProductName.Text);
                
                    string priceText = txtPrice.Text.Replace("₱", "").Trim();
                    command.Parameters.AddWithValue("@price", decimal.Parse(priceText));
                    command.Parameters.AddWithValue("@quantity", int.Parse(txtQuantity.Text));

                    command.ExecuteNonQuery();
                    MessageBox.Show("Product added successfully!");
                    ClearFields();
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message);
            }
        }

        //  UPDATE FUNCTION 
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedProductId == -1)
                {
                    MessageBox.Show("Please select a product to update.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtProductName.Text) || 
                    string.IsNullOrWhiteSpace(txtPrice.Text) || 
                    string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Products SET ProductName = @productName, Price = @price, Quantity = @quantity WHERE ProductID = @productId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@productName", txtProductName.Text);
                    string priceText = txtPrice.Text.Replace("₱", "").Trim();
                    command.Parameters.AddWithValue("@price", decimal.Parse(priceText));
                    command.Parameters.AddWithValue("@quantity", int.Parse(txtQuantity.Text));
                    command.Parameters.AddWithValue("@productId", selectedProductId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Product updated successfully!");
                    ClearFields();
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
            }
        }

        // ARCHIVE
        // Archive (soft delete) a product instead of permanently deleting it
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedProductId == -1)
                {
                    MessageBox.Show("Please select a product to archive.");
                    return;
                }

                DialogResult result = MessageBox.Show("Archive this product?\n\nArchived products will no longer appear in sales but their transaction history will be preserved.", "Confirm Archive", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        
                        // Archive the product (soft delete)
                        string query = "UPDATE Products SET IsArchived = 1, ArchivedDate = GETDATE() WHERE ProductID = @productId";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@productId", selectedProductId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Product archived successfully!\n\nThe product is no longer available for sales but its history is preserved.", "Archive Complete");
                        ClearFields();
                        LoadProducts();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error archiving product: " + ex.Message);
            }
        }

        // Helper method to refresh the form
        private void RefreshForm()
        {
            ClearFields();
            LoadProducts();
        }

        private void ClearFields()
        {
            txtProductName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            selectedProductId = -1;
        }
    }
}
