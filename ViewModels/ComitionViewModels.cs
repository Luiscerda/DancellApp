using DancellApp.Models;
using DancellApp.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            Comitions = new ObservableCollection<ComitionModel>();
            IsEnabled = true;
            IsRunning = false;
            IsVisible = false;
            IsVisibleType = false;
            GetComitionByIdPosCommand = new Command(() => GetComitionByIdPos());
        }
        #endregion

        #region Attributes
        private string idPos;
        private string valorRestante;
        private ObservableCollection<ComitionModel> comitions;
        private bool isEnabled;
        private bool isRunning;
        private bool isVisible;
        private bool isVisibleType;
        private string efectivo;
        private int cursorPosition;
        #endregion

        #region Properties
        public string IdPos
        {
            get => idPos;
            set => SetValue(ref idPos, value);
        }
        public string ValorRestante
        {
            get => valorRestante;
            set => SetValue(ref valorRestante, value);
        }
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public bool IsVisible
        {
            get => isVisible;
            set => SetValue(ref isVisible, value);
        }
        public bool IsVisibleType
        {
            get => isVisibleType;
            set => SetValue(ref isVisibleType, value);
        }
        public ICommand GetComitionByIdPosCommand { get; }
        public ObservableCollection<ComitionModel> Comitions
        {
            get => comitions;
            set => SetValue(ref comitions, value);
        }
        public bool IsRunning
        {
            get => isRunning;
            set => SetValue(ref isRunning, value);

        }
        public int CursorPosition
        {
            get => cursorPosition;
            set
            {
                if (cursorPosition != value)
                {
                    cursorPosition = value;
                    OnPropertyChanged(nameof(CursorPosition));
                }
            }

        }
        public string Efectivo
        {
            get => efectivo;
            set
            {
                if (efectivo != value)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (value.Length > 3)
                        {
                            value = value.Contains('$') ? value.Replace("$", "").Replace(",", "") : value;
                            if (value != "")
                            {
                                efectivo = Convert.ToDecimal(value).ToString("C0", CultureInfo.CurrentCulture);
                                CursorPosition = efectivo.Length + 1;
                            }
                            else
                            {
                                efectivo = "";
                            }
                        }
                        else
                        {
                            efectivo = value;
                        }

                        OnPropertyChanged();
                    }
                }
                
                
                
               
            }
        }
        public ICommand SelectComitionCommand => new Command<ComitionModel>(ViewTypeComitions);
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
            IsRunning = true;
            var connectivity = connectivityService.CheckConnectivity();
            if (!connectivity.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connectivity.Message,
                    "OK");
                return;
            }
            Comitions.Clear();
            var user = baseConstants.GetUserAsync();
            var result = await this.comitionService.GetComitionByIdPos("/Liquidaciones/GetGestionPrepago", user.UserName, user.Password, IdPos);
            if (result.Is_Error)
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    result.Msj,
                    "OK");
                return;
            }
            var _comitions = JsonConvert.DeserializeObject<List<ComitionModel>>(result.Objeto.ToString());
            if (_comitions.Count == 0)
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    $"No se encontro comisión para el IDPOS {IdPos}.",
                    "OK");
                return;
            }
            foreach (var item in _comitions)
            {
                if (item.Vigente.ToUpper().Trim() == "SI")
                {
                    item.Valor = item.ValorComision.ToString("C0", CultureInfo.CurrentCulture);
                    this.comitions.Add(item);
                }
            }
            IsVisible = true;
            Comitions = this.comitions;
            IsEnabled = true;
            IsRunning = false;
        }

        public async void ViewTypeComitions(ComitionModel comition)
        {
            IsVisible = false;
            IsVisibleType = true;
            ValorRestante = comition.Valor;
        }

        public void ConvertMoney(decimal value)
        {
            Efectivo = value.ToString("C0", CultureInfo.CurrentCulture);
        }
        #endregion
    }
}
