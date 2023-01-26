using Hanseatic_Dealings_App.Models;
using Hanseatic_Dealings_App.ViewModel;
using System.Linq;

namespace Hanseatic_Dealings_App;

public partial class ShipListPage : ContentPage
{
	public ShipListPage(ShipListViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		int current = (e.CurrentSelection.FirstOrDefault() as ShipModel).Id;
        await Shell.Current.GoToAsync($"{nameof(MapPage)}?ShipId={current}");
    }
}