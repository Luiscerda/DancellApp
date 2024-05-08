using DancellApp.Models;
using DancellApp.Services;
using Newtonsoft.Json;
using System.Windows.Input;

namespace DancellApp.ViewModels
{
    public class ComitionViewModels : BaseViewModels
    {
        #region Services
        readonly ComitionService comitionService;
        private readonly ConnectivityService connectivityService;
        private readonly DataBaseConstants baseConstants;
        #endregion

        #region Constructor
        public ComitionViewModels()
        {
            comitionService = new ComitionService();
            connectivityService = new ConnectivityService();
            baseConstants = new DataBaseConstants();
            IsEnabled = true;
            GetComitionByIdPosCommand = new Command(() => GetComitionByIdPos());
        }
        #endregion

        #region Attributes
        private string idPos;
        private bool isEnabled;
        #endregion

        #region Properties
        public string IdPos
        {
            get => idPos;
            set => SetValue(ref idPos, value);
        }
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public ICommand GetComitionByIdPosCommand { get; }
        #endregion

        #region Methods
        public async void GetComitionByIdPos()
        {
            if (string.IsNullOrEmpty(IdPos))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Por favor ingrese el idPos a consultar.",
                    "Aceptar");
                return;
            }
            IsEnabled = false;
            var connectivity = connectivityService.CheckConnectivity();
            if (!connectivity.IsSuccess)
            {
                //IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connectivity.Message,
                    "OK");
                return;
            }
            var user = baseConstants.GetUserAsync();
            var result = await this.comitionService.GetComitionByIdPos("/Liquidaciones/GetGestionPrepago", user.UserName, user.Password, IdPos);
            if (result.Is_Error)
            {
                //IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    result.Msj,
                    "OK");
                return;
            }
            var comitions = JsonConvert.DeserializeObject<List<ComitionModel>>(result.Objeto.ToString());
            if (comitions.Count == 0)
            {
                //IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    $"No se encontro comision para el IDPOS {IdPos}.",
                    "OK");
                return;
            }
            foreach (var item in comitions)
            {

            }
        }
        #endregion
    }
}
