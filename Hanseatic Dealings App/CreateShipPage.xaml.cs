using Hanseatic_Dealings_App.ViewModel;

namespace Hanseatic_Dealings_App;

public partial class CreateShipPage : ContentPage
{
	public CreateShipPage(CreateShipViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}