using DancellApp.ViewModels;

namespace DancellApp.Views;

public partial class FlyoutMenuPage : ContentPage
{
	public FlyoutMenuPage()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetService<FlyoutMenuViewModels>();
    }
}