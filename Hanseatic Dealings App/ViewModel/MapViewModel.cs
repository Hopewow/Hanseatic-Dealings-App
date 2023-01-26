using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hanseatic_Dealings_App.Models;
using System.Net.Http.Json;

namespace Hanseatic_Dealings_App.ViewModel;

[QueryProperty("ShipId", "ShipId")]
public partial class MapViewModel : ObservableObject
{
    public MapViewModel()
    {
        getData();
    }

    public int ShipId { get; set; }

    [ObservableProperty]
    public ShipModel player;

    [ObservableProperty]
    public List<CityModel> cities;

    [RelayCommand]
    async Task RedirectToMarket(string market)
    {
        await Shell.Current.GoToAsync($"{nameof(MarketPage)}?Id={market}");
    }

    [RelayCommand]
    void RedirectToHiddenArea()
    {
        int secondsToVibrate = Random.Shared.Next(1, 7);
        TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);

        Vibration.Default.Vibrate(vibrationLength);
    }

    [RelayCommand]
    async Task RedirectToShipSelection()
    {
        await Shell.Current.GoToAsync($"{nameof(ShipListPage)}?UserId={Player.UserId}");
    }

    public async void getData()
    {
        await Task.Delay(1000);
        ApiModel CallApi = new();
        var client = CallApi.getClient();

        HttpResponseMessage response = await client.GetAsync($"api/Ship/{ShipId}");
        response.EnsureSuccessStatusCode();
        Player = await response.Content.ReadFromJsonAsync<ShipModel>();

        response = await client.GetAsync("api/City");
        response.EnsureSuccessStatusCode();
        Cities = await response.Content.ReadFromJsonAsync<List<CityModel>>();
    }
}
