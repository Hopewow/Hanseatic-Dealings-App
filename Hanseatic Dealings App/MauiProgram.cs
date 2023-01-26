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

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<CreateUserPage>();
        builder.Services.AddTransient<CreateUserViewModel>();

        builder.Services.AddTransient<ShipListPage>();
		builder.Services.AddTransient<ShipListViewModel>();

        builder.Services.AddTransient<CreateShipPage>();
        builder.Services.AddTransient<CreateShipViewModel>();

        builder.Services.AddTransient<MapPage>();
        builder.Services.AddTransient<MapViewModel>();

        builder.Services.AddTransient<MarketPage>();
        builder.Services.AddTransient<MarketViewModel>();
        
		return builder.Build();
	}
}
