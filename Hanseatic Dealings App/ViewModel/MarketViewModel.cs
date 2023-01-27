using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hanseatic_Dealings_App.Models;
using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Hanseatic_Dealings_App.ViewModel;

// text = Id

[QueryProperty(nameof(cityId), nameof(cityId))]
[QueryProperty(nameof(shipId), nameof(shipId))]
public partial class MarketViewModel : ObservableObject
{
    public int cityId { get; set; }
    public int shipId { get; set; }

    [ObservableProperty]
    public ShipModel player;

    [ObservableProperty]
    public CityModel city;

    public MarketViewModel() {
        getData();
    } 

    [RelayCommand]
    public async void ReturnToMap()
    {
        await Shell.Current.GoToAsync($"{nameof(MapPage)}?ShipId={Player.Id}");
    }

    [RelayCommand]
    public async void Buy(int id)
    {
        ApiModel CallApi = new();
        var client = CallApi.getClient();

        MarketModel marketModel = new();

        marketModel.Player = Player;
        marketModel.CityStorage = City.Goods[id];
        marketModel.Amount = 1;

        HttpResponseMessage response = await client.PutAsJsonAsync<MarketModel>("api/City/Purchase", marketModel);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            await Shell.Current.GoToAsync($"{nameof(MarketPage)}?cityId={City.Id}&shipId={Player.Id}");
        } else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            await Shell.Current.DisplayAlert("Error", "Does not have any more of this product.", "Ok");
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "Someone has already purchased this will reload the page.", "Ok");
            await Shell.Current.GoToAsync($"{nameof(MarketPage)}?cityId={City.Id}&shipId={Player.Id}");
        }
    }

    [RelayCommand]
    public async void Sell(int id)
    {
        ApiModel CallApi = new();
        var client = CallApi.getClient();

        MarketModel marketModel = new MarketModel();
        marketModel.Player = Player;
        marketModel.CityStorage = City.Goods[id];
        marketModel.Amount = 1;

        marketModel.Amount = 1;

        HttpResponseMessage response = await client.PutAsJsonAsync<MarketModel>("api/City/Sell", marketModel);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            await Shell.Current.GoToAsync($"{nameof(MarketPage)}?cityId={City.Id}&shipId={Player.Id}");
        } else
        {
            await Shell.Current.DisplayAlert("Error", "Someone has already sold this will reload the page.", "Ok");
            await Shell.Current.GoToAsync($"{nameof(MarketPage)}?cityId={City.Id}&shipId={Player.Id}");
        }
    }

    public async void getData()
    {
        await Task.Delay(1);
        ApiModel CallApi = new();
        var client = CallApi.getClient();

        HttpResponseMessage response = await client.GetAsync($"api/Ship/{shipId}");

        response.EnsureSuccessStatusCode();
        Player = await response.Content.ReadFromJsonAsync<ShipModel>();

        response = await client.GetAsync($"api/City/{cityId}");
        response.EnsureSuccessStatusCode();
        City = await response.Content.ReadFromJsonAsync<CityModel>();
    }
}
