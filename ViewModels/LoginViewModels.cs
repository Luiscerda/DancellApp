using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace DancellApp.ViewModels
{
    public class LoginViewModels
    {
        #region Methods
        public async void NavComision()
        {
            await App.Master.Detail.Navigation.PushAsync(new Views.LoginPage());
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
