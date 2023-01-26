using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanseatic_Dealings_App.Models;

public partial class UserModel : ObservableObject
{
    public int Id { get; set; }
    [EmailAddress]
    public string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public string Token { get; set; }

    public List<ShipModel> Ships { get; set; }
}
