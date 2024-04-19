using DancellApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace DancellApp.ViewModels
{
    public class LoginViewModels
    {
        #region Methods
        public async void NavComision()
        {
            MainViewModels.GetInstance().LoginScreenView = new LoginScreenViewModels();
            await App.Navigation.PushAsync(new LoginPage());
        }
        #endregion

        #region Commands
        public ICommand NavComisionCommand
        {
            get
            {
                return new RelayCommand(NavComision);
            }
        }
        #endregion
    }
}
