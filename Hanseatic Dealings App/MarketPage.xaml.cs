using Hanseatic_Dealings_App.ViewModel;

namespace Hanseatic_Dealings_App;

public partial class MarketPage : ContentPage
{
	public MarketPage(MarketViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}