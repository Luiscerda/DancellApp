using DancellApp.Interfaces;
using SQLite;

namespace DancellApp.Models
{
    public class DataAcces : IDisposable
    {
        private SQLiteConnection connection;
        public DataAcces()
        {
            var config = DependencyService.Get<IConfig>();
            this.connection = new SQLiteConnection(Path.Combine(config.DirecttoryDB, "DancellApp.db3"));
            connection.CreateTable<Usuario>();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
        public List<Usuario> GetUsuarios()
        {
            return this.connection.Table<Usuario>().ToList();
        }
    }
}
