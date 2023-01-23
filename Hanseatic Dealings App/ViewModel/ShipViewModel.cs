using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hanseatic_Dealings_App.Models;

namespace Hanseatic_Dealings_App.ViewModel;

public partial class ShipViewModel : ObservableObject
{
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
    void RedirectToHiddenArea(string market)
    {
        int secondsToVibrate = Random.Shared.Next(1, 7);
        TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);

        Vibration.Default.Vibrate(vibrationLength);
    }
}
