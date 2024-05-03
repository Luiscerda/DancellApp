namespace DancellApp.Services
{
    using DancellApp.Models;
    using SQLite;
    public class DataBaseConstants
    {
        public const string DatabaseFileName = "SQLiteDancellDatabase.db3";
        public SQLiteConnection connection { get; set; }

        public const SQLite.SQLiteOpenFlags flags = 
            SQLite.SQLiteOpenFlags.ReadWrite | 
            SQLite.SQLiteOpenFlags.Create | 
            SQLite.SQLiteOpenFlags.SharedCache;

        public DataBaseConstants()
        {
            connection = new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName));
            connection.CreateTable<Usuario>();
        }

        public void SaveUserAsync(Usuario usuario)
        {
            connection.Insert(usuario);
        }

        public Usuario GetUserAsync()
        {
            return connection.Table<Usuario>().FirstOrDefault();
        }

        public void DeleteUser(Usuario user)
        {
           connection.Delete(user);
        }

        public void UpdateUser(Usuario user)
        {
            connection.Update(user);
        }
    }
}
