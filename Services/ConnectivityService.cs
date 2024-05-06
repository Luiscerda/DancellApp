using DancellApp.Models;

namespace DancellApp.Services
{
    public class ConnectivityService
    {
        public ConnectivityModel CheckConnectivity()
        {

            NetworkAccess accessType = Connectivity.Current.NetworkAccess;

            if (accessType == NetworkAccess.Internet)
            {
                return new ConnectivityModel
                {
                    IsSuccess = true
                };
            }
            return new ConnectivityModel 
            { 
                IsSuccess = false,
                Message = "Por favor, comprueba tu conexión a internet y vuelve a intentarlo."
            };
        }
    }
}
