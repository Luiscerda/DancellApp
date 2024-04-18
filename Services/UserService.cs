using DancellApp.Models;

namespace DancellApp.Services
{
    public class UserService
    {
        public Usuario First()
        {
            using (var da = new DataAcces())
            {
                return da.GetUsuarios().FirstOrDefault();
            }
        }
    }
}
