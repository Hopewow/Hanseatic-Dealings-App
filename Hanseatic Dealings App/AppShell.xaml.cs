namespace Hanseatic_Dealings_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MarketPage), typeof(MarketPage));
	}
}
