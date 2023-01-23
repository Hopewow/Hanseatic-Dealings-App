using Hanseatic_Dealings_App.Models;
using Hanseatic_Dealings_App.ViewModel;
using Microsoft.Maui.Controls;
using System;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Hanseatic_Dealings_App;

public partial class MainPage : ContentPage
{
	public MainPage(ShipViewModel vm)
	{
        var window = App.Window;

        window.Created += async (s, e) =>
        {
            HttpClient client = new();
            client.BaseAddress = new Uri("http://10.130.54.25:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/player/11");
            response.EnsureSuccessStatusCode();
            vm.Player = await response.Content.ReadFromJsonAsync<ShipModel>();

            response = await client.GetAsync("api/city");
            response.EnsureSuccessStatusCode();
            vm.cities = await response.Content.ReadFromJsonAsync<List<CityModel>>();

            BindingContext = vm;
            InitializeComponent();

            foreach (var city in vm.cities)
            {
                RadioButton button = new();

                button.Parent = Page;
                button.TranslationX = Double.Parse(city.Xcord);
                button.TranslationY = Double.Parse(city.Ycord);
                button.CheckedChanged += goToMarketPage;
                button.Content = city.Name;
                button.FontSize = 25d;
                switch (city.Name)
                {
                    case "Groningen": case "Bremen": case "Lübeck": case "Stockholm": case "Velikij": case "Sankt Petersborg":
                        button.FlowDirection = FlowDirection.RightToLeft;
                        break;
                    default:
                        break;
                }
                button.FontAttributes = FontAttributes.Bold;
                Page.Add(button);
            }
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

