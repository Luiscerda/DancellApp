using DancellApp.ViewModels;

namespace DancellApp.Views;

public partial class LoginScreenPage : ContentPage
{
	public LoginScreenPage()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetService<LoginScreenViewModels>();
    }
}