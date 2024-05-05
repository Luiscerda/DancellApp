using DancellApp.Models;

namespace DancellApp.Services
{
    public class GeolocationService
    {
        public async Task<LocationModel> GetCachedLocation()
        {
            LocationModel locationModel = new();
            try
            {
                Location location = await Geolocation.Default.GetLastKnownLocationAsync();
                
                if (location != null)
                {
                    locationModel.Latitude = location.Latitude;
                    locationModel.Longitude = location.Longitude;
                    if (location.Altitude != null || location.Latitude != 0)
                    {
                        locationModel.Altitude = (double)location.Altitude;
                    }
                    locationModel.Message =$"{"Longitud: " + location.Longitude + location.Altitude + " Latitud: " + location.Latitude}";
                }
                else
                {
                    locationModel.Message = "NO ENCONTRADO";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                var message = fnsEx.Message;
                locationModel.Message = "Geolocalización no admitida en el dispositivo.";
            }
            catch (FeatureNotEnabledException fneEx)
            {
                var message = fneEx.Message;
                locationModel.Message = "Geolocalización no habilitada en el dispositivo.";
            }
            catch (PermissionException pEx)
            {
                var message = pEx.Message;
                locationModel.Message = "No se han otorgado permisos de ubicación.";
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                locationModel.Message = "No se pudo obtener la geolocalización.";
            }

            return locationModel;
        }

        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        public async Task<LocationModel> GetCurrentLocation()
        {
            LocationModel locationModel = new();
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                {
                    locationModel.Latitude = location.Latitude;
                    locationModel.Longitude = location.Longitude;
                    if (location.Altitude != null || location.Latitude != 0)
                    {
                        locationModel.Altitude = (double)location.Altitude;
                    }
                    locationModel.Message = $"{"Longitud:" + location.Longitude + location.Altitude + "Latitud:" + location.Latitude}";
                }
                else
                {
                    locationModel.Message = "NO ENCONTRADO";
                }
            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            //   PermissionException
            catch (Exception ex)
            {
                // Unable to get location
            }
            finally
            {
                _isCheckingLocation = false;
            }
            return locationModel;
        }

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }
    }
}
