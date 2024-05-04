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
        private LoadImageService loadImageService;
        private UserService userService;
        #endregion

        #region Constructor
        public EditProfileViewModels()
        {
            baseConstants = new DataBaseConstants();
            loadImageService = new LoadImageService();
            userService = new UserService();
            User = baseConstants.GetUserAsync();
            PickImageCommand = new Command(() => DoPickImage());
            EditProfileCommand = new Command(() => EditProfile());
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
        public ICommand PickImageCommand { get; }
        public ICommand EditProfileCommand { get; }
        #endregion

        #region Attributes
        private Usuario user;
        private ImageModel image;
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
            var result = await this.userService.EditProfileUser("/Administracion/UpdateUsuario", this.User);
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
            baseConstants.UpdateUser(this.User);
            await Application.Current.MainPage.DisplayAlert(
                   "Exito",
                   result.Msj,
                   "OK");
            ProfilePage profilePage = new ProfilePage();
            await App.Navigator.PopAsync();
            
        }
        #endregion
    }
}
