using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Hanseatic_Dealings_App.ViewModel;

public partial class ShipViewModel : ObservableObject
{
    [ObservableProperty]
    public string money = "0.00";

    [RelayCommand]
    async Task RedirectToMarket(string market)
    {
        await Shell.Current.GoToAsync($"{nameof(MarketPage)}?Id={market}");
    }
}
