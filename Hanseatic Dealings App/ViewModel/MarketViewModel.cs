using CommunityToolkit.Mvvm.ComponentModel;

namespace Hanseatic_Dealings_App.ViewModel;

// text = Id
[QueryProperty("Text", "Id")]
public partial class MarketViewModel : ObservableObject
{
    [ObservableProperty]
    string text;
    [ObservableProperty]
    string money = "1111111111111111111222222222222222222222";
    
}
