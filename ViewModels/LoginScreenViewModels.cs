using CommunityToolkit.Mvvm.Input;
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
    public partial class LoginScreenViewModels : BaseViewModels
    {
        #region Constructor
        public LoginScreenViewModels()
        {
            NavSingUpCommand = new AsyncRelayCommand(NavSingUp);
        }
        #endregion

        #region Properties
        public ICommand NavSingUpCommand { get; }
        #endregion

        #region Methods
        private async Task NavSingUp()
        {
            await Shell.Current.Navigation.PushAsync(new SingupPage(), false);
        }
        #endregion
    }
}
