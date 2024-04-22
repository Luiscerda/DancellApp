﻿namespace DancellApp;
using DancellApp.Controls;
using DancellApp.Platforms;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
		{
			if (view is CustomEntry)
			{
                CustomEntryMapper.Map(handler, view);
			}
		});

		return builder.Build();
	}
}
