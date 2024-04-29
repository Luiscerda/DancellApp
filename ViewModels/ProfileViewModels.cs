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
        #endregion

        #region Constructor
        public ProfileViewModels()
        {
            baseConstants = new DataBaseConstants();
            User = baseConstants.GetUserAsync();
        }
        #endregion

        #region Properties
        public Usuario User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        public ICommand NavEditProfilePageCommand => new Command(NavEditProfilePage);
        #endregion

        #region Methods
        public async void NavEditProfilePage()
        {
            await App.Navigator.PushAsync(new EditProfilePage());
        }
        #endregion
    }
}
