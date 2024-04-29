using DancellApp.Models;
using DancellApp.Services;
using DancellApp.ViewModels;
using DancellApp.Views;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace DancellApp;

public partial class App : Microsoft.Maui.Controls.Application
{
	#region Properties
	public static NavigationPage Navigator { get; internal set; }
	public static MasterPage Master { get; internal set; }
    public new static App Current => (App)Microsoft.Maui.Controls.Application.Current;
    public IServiceProvider Services { get; }
    public DataBaseConstants database { get; set; }
    #endregion
    public App(DataBaseConstants baseService)
	{
        App.Current.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
        var services = new ServiceCollection();
        Services = ConfigureServices(services);
        database = baseService;
        var user = GetUserAct();
        
        if (user != null)
        {
            MainPage = new MasterPage();
            //database.DeleteUser(user);
        }
        else
        {
            MainPage = new AppShell();
        }
        
        InitializeComponent();

    }

	public static IServiceProvider ConfigureServices(ServiceCollection services)
	{
		services.AddTransient<LoginViewModels>();
        services.AddTransient<LoginScreenViewModels>();
        services.AddTransient<FlyoutMenuViewModels>();
        services.AddTransient<EditProfileViewModels>();
        services.AddTransient<ProfileViewModels>();
        services.AddTransient<DataBaseConstants>();
        services.AddTransient<LoginScreenPage>();

        services.AddSingleton<LoginScreenPage>();
        services.AddSingleton<EditProfilePage>();
        services.AddSingleton<ProfilePage>();
        services.AddSingleton<FlyoutMenuPage>();

        return services.BuildServiceProvider();
    }

    public  Usuario GetUserAct()
    {
        return database.GetUserAsync();
    }
}
