using CommunityToolkit.Mvvm.Input;
using DancellApp.Services;
using DancellApp.Views;
using System.Windows.Input;

namespace DancellApp.ViewModels
{
    public partial class LoginViewModels : BaseViewModels
    {
        #region Constructor
        public LoginViewModels()
        {

        }
        #endregion

        #region Methods

        #endregion

        #region Commands
        [RelayCommand]
        public void NavLoginScreen()
        {
            MainViewModels.GetInstance().LoginScreenView = new LoginScreenViewModels();
            App.Navigation.PushAsync(new LoginScreenPage());
        }
        #endregion
    }
}
