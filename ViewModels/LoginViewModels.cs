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
        #endregion

        #region Constructor
        public LoginViewModels()
        {
            NewCommand = new AsyncRelayCommand(NewNoteAsync);
        }
        #endregion

        #region Methods
        private async Task NewNoteAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.LoginScreenPage));
        }
        #endregion
    }
}
