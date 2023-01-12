using Hanseatic_Dealings_App.ViewModel;

namespace Hanseatic_Dealings_App;

public partial class MainPage : ContentPage
{
	public MainPage(MarketViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    private async void goToMarketPage(object sender, CheckedChangedEventArgs e)
    {
		RadioButton btn = (RadioButton)sender;

		if (e.Value)
		{
			await Shell.Current.GoToAsync($"{nameof(MarketPage)}?Id={btn.Content}");
		}
    }
}

