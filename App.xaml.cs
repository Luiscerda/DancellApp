using DancellApp.Services;
using DancellApp.ViewModels;
using DancellApp.Views;

namespace DancellApp;

public partial class App : Application
{
	#region Properties
	public static NavigationPage Navigation { get; internal set; }
	public static MasterPage Master { get; internal set; }
    public new static App Current => (App)Application.Current;
    public IServiceProvider Services { get; }
    #endregion
    public App()
	{
        var services = new ServiceCollection();
        Services = ConfigureServices(services);
        InitializeComponent();
        MainPage = new AppShell();

    }

	public static IServiceProvider ConfigureServices(ServiceCollection services)
	{
		services.AddTransient<LoginViewModels>();
        services.AddTransient<LoginScreenViewModels>();

        services.AddSingleton<LoginScreenPage>();

		return services.BuildServiceProvider();
    }
}
