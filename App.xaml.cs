using DancellApp.Services;
using DancellApp.ViewModels;
using DancellApp.Views;

namespace DancellApp;

public partial class App : Application
{
	#region Properties
	public static NavigationPage Navigation { get; internal set; }
	public static MasterPage Master { get; internal set; }
    #endregion
    public App()
	{
		InitializeComponent();
        MainPage = new NavigationPage(new MainPage());

    }
}
