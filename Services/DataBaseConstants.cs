namespace DancellApp.Services
{
    public class DataBaseConstants
    {
        public const string DatabaseFileName = "SQLiteDancellDatabase.db3";

        public const SQLite.SQLiteOpenFlags flags = 
            SQLite.SQLiteOpenFlags.ReadWrite | 
            SQLite.SQLiteOpenFlags.Create | 
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFileName);
    }
}
