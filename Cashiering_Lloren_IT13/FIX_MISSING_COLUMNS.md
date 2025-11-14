# How to Fix the "Invalid Column Name 'IsArchived'" Error

## Problem
You're getting the error: `Error loading products: Invalid column name 'IsArchived'.`

This happens because your database was created **before** the archive functionality was added, so the `IsArchived` and `ArchivedDate` columns don't exist yet.

## Solution

### Option 1: Run the Migration Script (RECOMMENDED)

1. **Open SQL Server Management Studio**
2. **Connect to your database**: `NIKOLA\SQLEXPRESS`
3. **Select the database**: `DB_Cashiering_Lloren_IT13`
4. **Open the script**: `AddArchiveColumns.sql`
5. **Run the script** (Click Execute or press F5)

The script will:
- Check if `IsArchived` column exists
- Check if `ArchivedDate` column exists
- Add both columns if they don't exist
- Show you the updated table structure

### Option 2: Manual SQL Commands

If you prefer to run the commands manually, run these one by one:

```sql
-- Add IsArchived column
ALTER TABLE Products ADD IsArchived BIT DEFAULT 0;

-- Add ArchivedDate column
ALTER TABLE Products ADD ArchivedDate DATETIME NULL;

-- Verify the columns were added
SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Products'
ORDER BY ORDINAL_POSITION;
```

### Option 3: Drop and Recreate (Clean Start)

If you want a completely fresh database:

1. **Open SQL Server Management Studio**
2. **Delete the database** `DB_Cashiering_Lloren_IT13`
3. **Create a new database** with the same name
4. **Run the script**: `DatabaseSetup.sql`
5. **Restart the application** - it will automatically create tables with archive columns

## Verify the Fix

After running the migration script, you should see:

```
IsArchived column added successfully.
ArchivedDate column added successfully.
```

And the table structure should show:

| Column Name | Data Type | IS_NULLABLE |
|-------------|-----------|------------|
| ProductID | int | NO |
| ProductName | nvarchar(100) | NO |
| Price | decimal(10,2) | NO |
| Quantity | int | NO |
| IsArchived | bit | YES |
| CreatedDate | datetime | NO |
| ArchivedDate | datetime | YES |

## After Fixing

1. **Restart the application**
2. **The error should be gone**
3. **Products will load properly**
4. **Archive functionality will work**

## What These Columns Do

- **IsArchived**: Marks if a product is archived (0 = Active, 1 = Archived)
- **ArchivedDate**: Records the exact date/time when a product was archived
- **Purpose**: Allows soft deletes while preserving transaction history

---

**Need Help?**
- Make sure you're using the correct SQL Server instance: `NIKOLA\SQLEXPRESS`
- Verify the database name: `DB_Cashiering_Lloren_IT13`
- Check that the Products table exists before running the migration
