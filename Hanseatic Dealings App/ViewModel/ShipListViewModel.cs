using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hanseatic_Dealings_App.Models;
using System.Net.Http.Json;

namespace Hanseatic_Dealings_App.ViewModel;

//Hvis man bruger query property skal man Af uransagelige årsager lave en en await task.delay(200). For ellers virker lortet ikke! :D
[QueryProperty(nameof(UserId),nameof(UserId))]
public partial class ShipListViewModel : ObservableObject
{
    public int UserId { get; set; }

    [ObservableProperty]
    public List<ShipModel> ships;

    public ShipListViewModel() {
        getListOfShips();
    }

    [RelayCommand]
    public async void RedirectToCreateShipPage()
    {
        await Shell.Current.GoToAsync($"{nameof(CreateShipPage)}?UserId={UserId}");
    }

    [RelayCommand]
    public void RedirectToLogin()
    {
        Application.Current.Quit();
    }

    public async void getListOfShips()
    {
        await Task.Delay(500);
        ApiModel CallApi = new();
        var client = CallApi.getClient();
        //UserId = 1;
        HttpResponseMessage response = await client.GetAsync($"api/Ship/GetPlayersShips?userId={UserId}");
        response.EnsureSuccessStatusCode();
        Ships = await response.Content.ReadFromJsonAsync<List<ShipModel>>();
    }
}
