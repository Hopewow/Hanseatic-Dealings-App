using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hanseatic_Dealings_App.Models;
using System.Net;
using System.Net.Http.Json;

namespace Hanseatic_Dealings_App.ViewModel;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    public UserModel user = new();

    [RelayCommand]
    public async Task RedirectToShipList()
    {
        ApiModel CallApi = new();

        var client = CallApi.getClient();
        User.Password = PasswordHashModel.HashPassword(User.Password);
        HttpResponseMessage response = await client.GetAsync($"api/User?email={User.Email}&psw={User.Password}");

        var code = response.StatusCode;

        if (code == HttpStatusCode.NotFound)
        {
            await Shell.Current.DisplayAlert("Error", "Email or Password is wrong", "Ok");
        } else if (code == HttpStatusCode.OK)
        {
            var user = await response.Content.ReadFromJsonAsync<UserModel>();

            await Shell.Current.GoToAsync($"{nameof(ShipListPage)}?UserId={user.Id}");
        }
    }

    [RelayCommand]
    public async Task RedirectToCreateUserPage()
    {
        await Shell.Current.GoToAsync($"{nameof(CreateUserPage)}");
    }
}
