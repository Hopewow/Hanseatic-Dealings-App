using Hanseatic_Dealings_App.Models;
using Hanseatic_Dealings_App.ViewModel;
using Microsoft.Maui.Controls;
using System;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Hanseatic_Dealings_App;

public partial class MainPage : ContentPage
{
	public MainPage(LoginViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }
}

