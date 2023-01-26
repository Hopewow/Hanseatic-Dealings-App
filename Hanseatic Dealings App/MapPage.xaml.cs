using Hanseatic_Dealings_App.ViewModel;

namespace Hanseatic_Dealings_App;

public partial class MapPage : ContentPage
{
    public MapViewModel Data { get; set; }

    public MapPage(MapViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Data = vm;

        addButtons(vm);
    }

    private async void addButtons(MapViewModel vm)
    {
        await Task.Delay(250);
        foreach (var city in vm.Cities)
        {
            RadioButton button = new();

            button.Parent = Page;
            button.Value = city.Id;
            button.TranslationX = Double.Parse(city.Xcord);
            button.TranslationY = Double.Parse(city.Ycord);
            button.CheckedChanged += goToMarketPage;
            button.Content = city.Name;
            button.FontSize = 25d;
            switch (city.Name)
            {
                case "Groningen":
                case "Bremen":
                case "Lübeck":
                case "Stockholm":
                case "Velikij":
                case "Sankt Petersborg":
                    button.FlowDirection = FlowDirection.RightToLeft;
                    break;
                default:
                    break;
            }
            button.FontAttributes = FontAttributes.Bold;
            Page.Add(button);
        }
    }

    private async void goToMarketPage(object sender, CheckedChangedEventArgs e)
    {
        RadioButton btn = (RadioButton)sender;

        if (e.Value)
        {
            Button market = (Button)Shell.Current.CurrentPage.FindByName("Market");

            market.IsVisible = true;
            market.CommandParameter = $"{btn.Content}";

            await Shell.Current.GoToAsync($"{nameof(MarketPage)}?cityId={(int)btn.Value}&shipId={(int)Data.Player.Id}");
        }
    }
}

