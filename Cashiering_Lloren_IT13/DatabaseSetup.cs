using System;
using System.Data.SqlClient;

namespace Cashiering_Lloren_IT13
{
    public class DatabaseSetup
    {
        private string connectionString = "Data Source=NIKOLA\\SQLEXPRESS;Initial Catalog=DB_Cashiering_Lloren_IT13;Integrated Security=True;Encrypt=False";
        private string masterConnectionString = "Data Source=NIKOLA\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Encrypt=False";

        /// <summary>
        /// Creates the database if it doesn't exist
        /// </summary>
        public void CreateDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(masterConnectionString))
                {
                    connection.Open();

                    // Check if database exists
                    string checkDatabaseQuery = @"
                        SELECT COUNT(*) FROM sys.databases 
                        WHERE name = 'DB_Cashiering_Lloren_IT13'";
                    
                    SqlCommand checkCommand = new SqlCommand(checkDatabaseQuery, connection);
                    int databaseCount = (int)checkCommand.ExecuteScalar();

                    if (databaseCount == 0)
                    {
                        // Create database if it doesn't exist
                        string createDatabaseQuery = @"
                            CREATE DATABASE DB_Cashiering_Lloren_IT13
                            ON PRIMARY (
                                NAME = DB_Cashiering_Lloren_IT13_Data,
                                FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DB_Cashiering_Lloren_IT13.mdf',
                                SIZE = 10MB,
                                MAXSIZE = 1GB,
                                FILEGROWTH = 1MB
                            )
                            LOG ON (
                                NAME = DB_Cashiering_Lloren_IT13_Log,
                                FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DB_Cashiering_Lloren_IT13.ldf',
                                SIZE = 5MB,
                                MAXSIZE = 500MB,
                                FILEGROWTH = 1MB
                            );";
                        
                        SqlCommand createCommand = new SqlCommand(createDatabaseQuery, connection);
                        createCommand.ExecuteNonQuery();
                        Console.WriteLine("Database 'DB_Cashiering_Lloren_IT13' created successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Database 'DB_Cashiering_Lloren_IT13' already exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Creates all required database tables for the cashiering system
        /// </summary>
        public void CreateTables()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create Products Table
                    string productsTable = @"
                        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Products')
                        BEGIN
                            CREATE TABLE Products (
                                ProductID INT PRIMARY KEY IDENTITY(1,1),
                                ProductName NVARCHAR(100) NOT NULL,
                                Price DECIMAL(10, 2) NOT NULL,
                                Quantity INT NOT NULL,
                                IsArchived BIT DEFAULT 0,
                                CreatedDate DATETIME DEFAULT GETDATE(),
                                ArchivedDate DATETIME NULL
                            )
                        END";

                    ExecuteCommand(connection, productsTable);

                    // Create Transactions Table
                    string transactionsTable = @"
                        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Transactions')
                        BEGIN
                            CREATE TABLE Transactions (
                                TransactionID INT PRIMARY KEY IDENTITY(1,1),
                                TransactionDate DATETIME NOT NULL,
                                TotalAmount DECIMAL(10, 2) NOT NULL,
                                CreatedDate DATETIME DEFAULT GETDATE()
                            )
                        END";

                    ExecuteCommand(connection, transactionsTable);

                    // Create TransactionDetails Table
                    string transactionDetailsTable = @"
                        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TransactionDetails')
                        BEGIN
                            CREATE TABLE TransactionDetails (
                                TransactionDetailID INT PRIMARY KEY IDENTITY(1,1),
                                TransactionID INT NOT NULL,
                                ProductID INT NOT NULL,
                                Quantity INT NOT NULL,
                                UnitPrice DECIMAL(10, 2) NOT NULL,
                                Total DECIMAL(10, 2) NOT NULL,
                                CreatedDate DATETIME DEFAULT GETDATE(),
                                FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID) ON DELETE CASCADE,
                                FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
                            )
                        END";

                    ExecuteCommand(connection, transactionDetailsTable);

                    // Add Archive columns to existing tables if needed
                    AddArchiveColumnsIfNeeded(connection);

                    Console.WriteLine("Database tables created/verified successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database tables: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Adds IsArchived and ArchivedDate columns to existing Products table if they don't exist
        /// This handles migration for existing databases
        /// </summary>
        private void AddArchiveColumnsIfNeeded(SqlConnection connection)
        {
            try
            {
                // Add IsArchived column if it doesn't exist
                string addIsArchivedColumn = @"
                    IF NOT EXISTS (
                        SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
                        WHERE TABLE_NAME = 'Products' AND COLUMN_NAME = 'IsArchived'
                    )
                    BEGIN
                        ALTER TABLE Products ADD IsArchived BIT DEFAULT 0;
                        PRINT 'IsArchived column added successfully.';
                    END";

                ExecuteCommand(connection, addIsArchivedColumn);

                // Add ArchivedDate column if it doesn't exist
                string addArchivedDateColumn = @"
                    IF NOT EXISTS (
                        SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
                        WHERE TABLE_NAME = 'Products' AND COLUMN_NAME = 'ArchivedDate'
                    )
                    BEGIN
                        ALTER TABLE Products ADD ArchivedDate DATETIME NULL;
                        PRINT 'ArchivedDate column added successfully.';
                    END";

                ExecuteCommand(connection, addArchivedDateColumn);

                Console.WriteLine("Archive columns verified/added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not add archive columns: {ex.Message}");
                // Don't throw - this is a non-critical migration step
            }
        }

        /// <summary>
        /// Inserts sample products into the database
        /// </summary>
        public void InsertSampleData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sampleData = @"
                        IF NOT EXISTS (SELECT * FROM Products)
                        BEGIN
                            INSERT INTO Products (ProductName, Price, Quantity, IsArchived) VALUES
                            ('Laptop', 50000.00, 5, 0),
                            ('Mouse', 500.00, 50, 0),
                            ('Keyboard', 1500.00, 30, 0),
                            ('Monitor', 8000.00, 10, 0),
                            ('USB Cable', 200.00, 100, 0)
                        END";

                    ExecuteCommand(connection, sampleData);
                    Console.WriteLine("Sample data verified/inserted successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting sample data: {ex.Message}");
                throw;
            }
        }

        private void ExecuteCommand(SqlConnection connection, string commandText)
        {
            using (SqlCommand command = new SqlCommand(commandText, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
