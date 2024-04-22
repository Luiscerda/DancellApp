using DancellApp.ViewModels;
using DancellApp.Views;

namespace DancellApp;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetService<LoginViewModels>();
    }
}

