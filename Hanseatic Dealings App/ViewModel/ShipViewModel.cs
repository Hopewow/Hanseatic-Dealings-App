using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Hanseatic_Dealings_App.ViewModel;

public partial class ShipViewModel : ObservableObject
{
    [ObservableProperty]
    public string test = "Hello";
}
