using DancellApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancellApp.Services
{
    public class UserService : BaseService
    {
        public UserService(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Usuario> GetUsuarioActAsync()
        {
            try
            {
                return await dbContext.Database.Table<Usuario>().Where(x => x.Activo == true).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"No se pudieron recuperar los datos. {ex.Message}";
            }

            return null;
        }
    }
}
