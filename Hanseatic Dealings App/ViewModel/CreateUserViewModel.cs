using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hanseatic_Dealings_App.Models;
using System.Net;
using System.Net.Http.Json;

namespace Hanseatic_Dealings_App.ViewModel;

public partial class CreateUserViewModel : ObservableObject
{
    [ObservableProperty]
    public UserModel user = new();

    [RelayCommand]
    public async Task RedirectToLogin()
    {
        ApiModel CallApi = new();
        var Client = CallApi.getClient();

        if (this.User.Password.Length <= 7)
        {
            await Shell.Current.DisplayAlert("Error", "Password must be atleast 8 characters", "Ok");
        } else if (this.User.Password != this.User.ConfirmPassword)
        {
            await Shell.Current.DisplayAlert("Error", "Password must match", "Ok");
        }
        else
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync<UserModel>("api/User", User);

            if (response.StatusCode == HttpStatusCode.OK) {
                await Shell.Current.GoToAsync($"..");
            } else {
                await Shell.Current.DisplayAlert("Error", "User Already Exists", "Ok");
            }

        }
    }
}
