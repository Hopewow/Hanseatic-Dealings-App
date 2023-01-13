using Hanseatic_Dealings_App.ViewModel;

namespace Hanseatic_Dealings_App;

public partial class MainPage : ContentPage
{
	public MainPage(ShipViewModel vm)
	{
        var window = App.Window;
        window.Created += (s, e) =>
        {
            BindingContext = vm;
            InitializeComponent();

        };
	}

    private async void goToMarketPage(object sender, CheckedChangedEventArgs e)
    {
		RadioButton btn = (RadioButton)sender;

		if (e.Value)
		{
			Button market = (Button)Shell.Current.CurrentPage.FindByName("Market");
			market.IsVisible = true;
			market.CommandParameter = $"{btn.Content}";

			await Shell.Current.GoToAsync($"{nameof(MarketPage)}?Id={btn.Content}");
		}
    }
}

