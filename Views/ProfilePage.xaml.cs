using DancellApp.ViewModels;

namespace DancellApp.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetService<ProfileViewModels>();
    }
}