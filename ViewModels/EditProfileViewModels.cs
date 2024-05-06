using DancellApp.Models;
using DancellApp.Services;
using DancellApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DancellApp.ViewModels
{
    public class EditProfileViewModels : BaseViewModels
    {
        #region Services
        private readonly DataBaseConstants baseConstants;
        private readonly LoadImageService loadImageService;
        private readonly UserService userService;
        private readonly ConnectivityService connectivityService;
        #endregion

        #region Constructor
        public EditProfileViewModels()
        {
            baseConstants = new DataBaseConstants();
            loadImageService = new LoadImageService();
            userService = new UserService();
            connectivityService = new ConnectivityService();
            User = baseConstants.GetUserAsync();
            PickImageCommand = new Command(() => DoPickImage());
            EditProfileCommand = new Command(() => EditProfile());
            IsEnabled = true;
            IsRunning = false;
        }
        #endregion

        #region Properties
        public Usuario User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        public ImageModel Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }
        public bool IsRunning
        {
            get => isRunning;
            set => SetProperty(ref isRunning, value);
        }
        public ICommand PickImageCommand { get; }
        public ICommand EditProfileCommand { get; }
        #endregion

        #region Attributes
        private Usuario user;
        private ImageModel image;
        private bool isEnabled;
        private bool isRunning;
        #endregion

        #region Methods
        async void DoPickImage()
        {
            var options = new MediaPickerOptions
            {
                Title = "Please select an image"
            };

            await loadImageService.PickAndShow(options);
            Image = loadImageService.imageModel;
        }

        public async void EditProfile()
        {          
            if (string.IsNullOrEmpty(User.Nombre))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Por favor ingrese por lo menos un nombre.",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(User.Apellido))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Por favor ingrese por lo menos un apellido.",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(User.Telefono))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Por favor ingrese un numero de celular.",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(User.Correo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Por favor ingrese un correo electronico.",
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
            var result = await this.userService.EditProfileUser("/Administracion/UpdateUsuario", this.User);
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
            baseConstants.UpdateUser(this.User);
            await Application.Current.MainPage.DisplayAlert(
                   "Exito",
                   result.Msj,
                   "OK");
            IsEnabled = true;
            IsRunning = false;
            Application.Current.MainPage = new MasterPage();

        }
        #endregion
    }
}
