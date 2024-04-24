using CommunityToolkit.Mvvm.Input;
using DancellApp.Models;
using DancellApp.Services;
using DancellApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DancellApp.ViewModels
{
    public partial class LoginScreenViewModels : BaseViewModels
    {
        #region Attributes
        private string _userName;
        private string _password;
        #endregion

        #region Services
        private UserService userService;
        private BaseService baseService;
        #endregion
        #region Constructor
        public LoginScreenViewModels()
        {
            UserName = "admin";
            Password = "DANcell2020";
            NavSingUpCommand = new AsyncRelayCommand(NavSingUp);
            LoginCommand = new AsyncRelayCommand(GetByUserAndPassword);
            userService = new UserService();
            baseService = new BaseService();
        }
        #endregion

        #region Properties
        public ICommand NavSingUpCommand { get; }
        public ICommand LoginCommand { get; }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        #endregion

        #region Methods
        private async Task NavSingUp()
        {
            await Shell.Current.Navigation.PushAsync(new SingupPage(), false);
        }

        private async Task GetByUserAndPassword()
        {
            if (string.IsNullOrEmpty(this.UserName))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usuario no puede estar vacio",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Por favor ingrese una contraseña",
                    "Aceptar");
                return;
            }
            var result = await this.userService.GetByUserAndPassword("/Public/Login", this.UserName, this.Password);
            if (result.Is_Error)
            {
                //this.IsRunning = false;
                //this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    result.Msj,
                    "OK");
                return;
            }
            if (result.Objeto == null)
            {
                //this.IsRunning = false;
                //this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "No se pudo iniciar sesion verifique los datos",
                    "OK");
                return;
            }
            var user = JsonConvert.DeserializeObject<Usuario>(result.Objeto.ToString());
            await this.baseService.SaveUserAsync(user);
        }
        #endregion
    }
}
