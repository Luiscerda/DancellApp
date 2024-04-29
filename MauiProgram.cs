namespace DancellApp;
using CommunityToolkit;
using DancellApp.Controls;
using DancellApp.Platforms;
using DancellApp.Services;

#if ANDROID
using DancellApp.Platforms.Android;
#endif
#if IOS
using DancellApp.Platforms.iOS;
#endif

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureMauiHandlers(handlers => {
#if ANDROID
                handlers.AddHandler<CustomViewCell, CustomViewCellMapper>();
#endif
#if IOS
				handlers.AddHandler<CustomViewCell, CustomViewCellMapper>();
#endif
            })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
#if ANDROID

#endif
        Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
        {
            if (view is CustomEntry)
            {
                CustomEntryMapper.Map(handler, view);
            }
        });
        builder.Services.AddSingleton<DataBaseConstants>();

        return builder.Build();
	}
}
