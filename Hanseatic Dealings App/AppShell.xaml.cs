namespace Hanseatic_Dealings_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(CreateUserPage), typeof(CreateUserPage));
        Routing.RegisterRoute(nameof(ShipListPage), typeof(ShipListPage));
        Routing.RegisterRoute(nameof(CreateShipPage), typeof(CreateShipPage));
        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
		Routing.RegisterRoute(nameof(MarketPage), typeof(MarketPage));
    }
}
