namespace Cashiering_Lloren_IT13
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // Initialize database on application startup
            try
            {
                DatabaseSetup databaseSetup = new DatabaseSetup();
                databaseSetup.CreateDatabase();      // Create database if it doesn't exist
                databaseSetup.CreateTables();        // Create tables if they don't exist
                databaseSetup.InsertSampleData();    // Insert sample data if tables are empty
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization error: {ex.Message}\n\nPlease ensure SQL Server is running and accessible.", "Database Error");
            }
            
            Application.Run(new CashieringForm());
        }
    }
}