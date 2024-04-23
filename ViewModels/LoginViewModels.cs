using CommunityToolkit.Mvvm.Input;
using DancellApp.Services;
using DancellApp.Views;
using System.Windows.Input;

namespace DancellApp.ViewModels
{
    public partial class LoginViewModels : BaseViewModels
    {
        #region Properties
        public ICommand NewCommand { get; }
        public ICommand NavSingUpCommand { get; }
        #endregion

        #region Constructor
        public LoginViewModels()
        {
            NewCommand = new AsyncRelayCommand(NewNoteAsync);
            NavSingUpCommand = new AsyncRelayCommand(NavSingUp);
        }
        #endregion

        #region Methods
        private async Task NewNoteAsync()
        {
            await Shell.Current.Navigation.PushAsync(new LoginScreenPage(), false);
        }

        private async Task NavSingUp()
        {
            await Shell.Current.Navigation.PushAsync(new SingupPage(), false);
        }
        #endregion
    }
}
