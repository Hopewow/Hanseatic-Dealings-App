using Hanseatic_Dealings_App.ViewModel;

namespace Hanseatic_Dealings_App;

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

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<ShipViewModel>();

		builder.Services.AddTransient<MarketPage>();
		builder.Services.AddTransient<MarketViewModel>();

		return builder.Build();
	}
}
