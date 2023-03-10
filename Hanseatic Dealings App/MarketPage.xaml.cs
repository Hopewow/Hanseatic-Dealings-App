using Hanseatic_Dealings_App.Models;
using Hanseatic_Dealings_App.ViewModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Hanseatic_Dealings_App;

public partial class MarketPage : ContentPage
{
    public MarketPage(MarketViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
        MarketAsync(vm);
    }
    public async void MarketAsync(MarketViewModel vm)
    {
        await Task.Delay(500);
        MarketGrid.Children.Clear();

        for (int i = 0; i < vm.City.Goods.Count; i++)
        {
            Grid market = new()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width = new GridLength(2,GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(2,GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(2,GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(2,GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(2,GridUnitType.Star)}
                }
            };
            

            Label cityItem = new();
            cityItem.Text = vm.City.Goods[i].Item.ToString();
            cityItem.HorizontalOptions = LayoutOptions.Center;
            cityItem.VerticalOptions = LayoutOptions.Center;
            market.SetColumn(cityItem, 0);
            market.Add(cityItem);

            Label cityItemAmunt = new();
            cityItemAmunt.HorizontalOptions = LayoutOptions.Center;
            cityItemAmunt.VerticalOptions = LayoutOptions.Center;
            cityItemAmunt.Text = vm.City.Goods[i].Current.ToString();
            market.SetColumn(cityItemAmunt, 1);
            market.Add(cityItemAmunt);

            int pricePr = Convert.ToInt32(-3 * (2 * vm.City.Goods[i].Current / vm.City.Goods[i].Limit - 1) ^ 3 + 5);
            string pricePrs = pricePr.ToString();
            Button buy = new();
            buy.Text = pricePrs;
            buy.Command = vm.BuyCommand;
            buy.CommandParameter = i;
            market.SetColumn(buy,2);
            market.Add(buy);

            pricePr = Convert.ToInt32(-3 * (2 * vm.City.Goods[i].Current / vm.City.Goods[i].Limit - 1) ^ 3 + 3);
            pricePrs = pricePr.ToString();
            Button sell = new();
            sell.Text = pricePrs;
            sell.Command = vm.SellCommand;
            sell.CommandParameter = i;
            market.SetColumn(sell, 3);
            market.Add(sell);   

            Label shipItemAmunt = new();
            shipItemAmunt.Text = vm.Player.Goods[i].Amount.ToString();
            shipItemAmunt.HorizontalOptions = LayoutOptions.Center;
            shipItemAmunt.VerticalOptions = LayoutOptions.Center;
            market.SetColumn(shipItemAmunt, 4);
            market.Add(shipItemAmunt);
            MarketGrid.Add(market);
        }
    }

}