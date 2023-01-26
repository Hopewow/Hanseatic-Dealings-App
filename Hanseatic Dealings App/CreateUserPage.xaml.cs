using Hanseatic_Dealings_App.ViewModel;

namespace Hanseatic_Dealings_App;

public partial class CreateUserPage : ContentPage
{
	public CreateUserPage(CreateUserViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}