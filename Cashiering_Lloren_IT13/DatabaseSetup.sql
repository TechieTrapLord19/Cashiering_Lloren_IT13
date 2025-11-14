

-- Create Products Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL,
    IsArchived BIT DEFAULT 0,
    CreatedDate DATETIME DEFAULT GETDATE(),
    ArchivedDate DATETIME NULL
);

-- Create Transactions Table
CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    TransactionDate DATETIME NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Create TransactionDetails Table
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
);

-- Insert sample data (optional)
INSERT INTO Products (ProductName, Price, Quantity, IsArchived) VALUES
('Laptop', 50000.00, 5, 0),
('Mouse', 500.00, 50, 0),
('Keyboard', 1500.00, 30, 0),
('Monitor', 8000.00, 10, 0),
('USB Cable', 200.00, 100, 0);

-- Display the created tables
SELECT * FROM Products;
SELECT * FROM Transactions;
SELECT * FROM TransactionDetails;
