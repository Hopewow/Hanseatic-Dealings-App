using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hanseatic_Dealings_App.Models;
using System.Net;
using System.Net.Http.Json;

namespace Hanseatic_Dealings_App.ViewModel;
[QueryProperty(nameof(UserId), nameof(UserId))]
public partial class CreateShipViewModel : ObservableObject
{
    public int UserId { get; set; }

    [ObservableProperty]
    public ShipModel ship = new();

    [RelayCommand]
    public async Task RedirectToShipList()
    {
        await Task.Delay(500);

        ApiModel CallApi = new();
        var client = CallApi.getClient();

        Ship.UserId = UserId;
        Ship.Money = 100;
        HttpResponseMessage response = await client.PostAsJsonAsync<ShipModel>("api/Ship", Ship);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            await Shell.Current.GoToAsync($"{nameof(ShipListPage)}?UserId={UserId}");
        } else
        {
            await Shell.Current.DisplayAlert("Error", "Please try again later seems there was an issue", "Ok");
        }
    }

    [RelayCommand]
    async Task RedirectToShipSelection()
    {
        await Task.Delay(500);
        await Shell.Current.GoToAsync($"{nameof(ShipListPage)}?UserId={UserId}");
    }
}
