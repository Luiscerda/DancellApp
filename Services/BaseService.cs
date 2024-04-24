using DancellApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancellApp.Services
{
    public class BaseService
    {
        SQLiteAsyncConnection Database;
        public string StatusMessage;
        DataBaseConstants dataBaseConstants;

        public BaseService()
        {
            dataBaseConstants = new DataBaseConstants();
        }

        //public async Task Init()
        //{
        //    if (Database is not null)
        //        return;

        //    Database = new SQLiteConnection(dataBaseConstants.connection , dataBaseConstants.flags);

        //    var result = await Database.CreateTableAsync<Usuario>();
        //}

        //public async Task<int> SaveUserAsync(Usuario usuario)
        //{
        //    await Init();
        //    if(usuario.IdUser != 0)
        //    {
        //        return await Database.UpdateAsync(usuario);
        //    }
        //    else
        //    {
        //        return await Database.InsertAsync(usuario);
        //    }
        //}

        //public async Task<Usuario> GetUserAsync()
        //{
        //    await Init();
        //    return await dataBaseConstants.connection.Table<Usuario>().FirstOrDefault();
        //}
    }
}
