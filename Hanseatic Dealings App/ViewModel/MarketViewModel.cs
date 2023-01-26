using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hanseatic_Dealings_App.Models;
using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Hanseatic_Dealings_App.ViewModel;

// text = Id
[QueryProperty("CityID", "CityID")]
[QueryProperty("ShipID", "ShipID")]
public partial class MarketViewModel : ObservableObject
{
    [ObservableProperty]
    string cityID;

    [ObservableProperty]
    string shipID;

    [ObservableProperty]
    public ShipModel player;

    [ObservableProperty]
    public CityModel city;

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
        response.EnsureSuccessStatusCode();


        await Shell.Current.GoToAsync($"{nameof(MarketPage)}?PlayerId={Player.Id}CityId={City.Id}");

    }
    [RelayCommand]
    public async void Sell(int id)
    {
        HttpClient client = new();
        client.BaseAddress = new Uri("http://10.130.54.25:5000/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        MarketModel marketModel = new MarketModel();
        marketModel.Player = Player;
        marketModel.CityStorage = City.Goods[id];
        marketModel.Amount = 1;

        marketModel.Amount = 1;

        HttpResponseMessage response = await client.PutAsJsonAsync<MarketModel>("api/City/Sell", marketModel);
        response.EnsureSuccessStatusCode();

        await Shell.Current.GoToAsync($"{nameof(MarketPage)}?PlayerId={Player.Id}CityId={City.Id}");

    }

}
