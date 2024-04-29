using DancellApp.Models;
using DancellApp.Services;
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
        #endregion

        #region Constructor
        public EditProfileViewModels()
        {
            baseConstants = new DataBaseConstants();
            loadImageService = new LoadImageService();
            User = baseConstants.GetUserAsync();
            PickImageCommand = new Command(() => DoPickImage());
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

        }
        #endregion
    }
}
