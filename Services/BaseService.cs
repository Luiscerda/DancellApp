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
        protected readonly DbContext dbContext;
        public string StatusMessage;

        public BaseService(DbContext dbContext)
        {
            this.dbContext = dbContext;
            _ = Init(this.dbContext);
        }

        public async Task Init(DbContext dbContext)
        {
            if (dbContext.Database is not null)
                return;

            dbContext.Database = new SQLite.SQLiteAsyncConnection(DataBaseConstants.DatabasePath, DataBaseConstants.flags);

            var migrationResult = await dbContext.Database.CreateTablesAsync(CreateFlags.None, typeof(Usuario));
        }
    }
}
