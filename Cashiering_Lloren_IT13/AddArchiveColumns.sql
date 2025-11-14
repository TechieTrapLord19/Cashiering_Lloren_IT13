-- SQL Migration Script for Adding Archive Functionality
-- Run this script if your database already exists and is missing the IsArchived and ArchivedDate columns

-- Check if IsArchived column exists, if not, add it
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Products' AND COLUMN_NAME = 'IsArchived'
)
BEGIN
    ALTER TABLE Products ADD IsArchived BIT DEFAULT 0;
    PRINT 'IsArchived column added successfully.';
END
ELSE
BEGIN
    PRINT 'IsArchived column already exists.';
END

-- Check if ArchivedDate column exists, if not, add it
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Products' AND COLUMN_NAME = 'ArchivedDate'
)
BEGIN
    ALTER TABLE Products ADD ArchivedDate DATETIME NULL;
    PRINT 'ArchivedDate column added successfully.';
END
ELSE
BEGIN
    PRINT 'ArchivedDate column already exists.';
END

-- Verify the columns were added
SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Products'
ORDER BY ORDINAL_POSITION;

-- Display current Products table structure
EXEC sp_help 'Products';
