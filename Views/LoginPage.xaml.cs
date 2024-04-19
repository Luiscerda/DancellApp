using DancellApp.ViewModels;

namespace DancellApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		this.BindingContext = new LoginViewModels();
	}
}