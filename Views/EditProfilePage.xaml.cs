using DancellApp.ViewModels;

namespace DancellApp.Views;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePage()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetService<EditProfileViewModels>();
    }
}
