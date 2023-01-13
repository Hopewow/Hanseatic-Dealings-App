using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Hanseatic_Dealings_App.ViewModel;

public partial class ShipViewModel : ObservableObject
{
    [ObservableProperty]
    public int money = 0;

    [RelayCommand]
    async Task RedirectToMarket(string market)
    {
        await Shell.Current.GoToAsync($"{nameof(MarketPage)}?Id={market}");
    }

    [RelayCommand]
    async Task RedirectToHiddenArea(string market)
    {
        int secondsToVibrate = Random.Shared.Next(1, 7);
        TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);

        Vibration.Default.Vibrate(vibrationLength);
    }
}
