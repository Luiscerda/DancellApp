using DancellApp.Models;
using SQLite;
using System;
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

        public BaseService()
        {

        }

        public async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DataBaseConstants.DatabasePath, DataBaseConstants.flags);

            var result = await Database.CreateTableAsync<Usuario>();
        }

        public async Task<int> SaveUserAsync(Usuario usuario)
        {
            await Init();
            if(usuario.IdUser != 0)
            {
                return await Database.UpdateAsync(usuario);
            }
            else
            {
                return await Database.InsertAsync(usuario);
            }
        }

        public async Task<Usuario> GetUserAsync()
        {
            await Init();
            return await Database.Table<Usuario>().FirstOrDefaultAsync();
        }
    }
}
