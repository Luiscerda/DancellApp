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
    public  class ProfileViewModels : BaseViewModels
    {
        #region Services
        private readonly DataBaseConstants baseConstants;
        #endregion

        #region Attributes
        private Usuario user;
        private bool isRefreshing;
        private GeolocationService geolocationService;
        #endregion

        #region Constructor
        public ProfileViewModels()
        {
            baseConstants = new DataBaseConstants();
            geolocationService = new GeolocationService();
            User = baseConstants.GetUserAsync();
            //GetLocationCache();
            //GetCurrentLocation();
        }
        #endregion

        #region Properties
        public Usuario User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }
        public ICommand NavEditProfilePageCommand => new Command(NavEditProfilePage);
        #endregion

        #region Methods
        public async void NavEditProfilePage()
        {
            await App.Navigator.PushAsync(new EditProfilePage());
        }

        public async void GetLocationCache()
        {
            var location = await geolocationService.GetCachedLocation();
            await Application.Current.MainPage.DisplayAlert("Mensaje", $"{location.Message}", "OK");
        }

        public async void GetCurrentLocation()
        {
            var location = await geolocationService.GetCurrentLocation();
            await Application.Current.MainPage.DisplayAlert("Mensaje", $"{location.Message}", "OK");
        }
        #endregion
    }
}
