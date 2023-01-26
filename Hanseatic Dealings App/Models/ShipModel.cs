using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hanseatic_Dealings_App.Models;

public partial class ShipModel : ObservableObject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DisplayName { get { return "Ship Name: " + Name; } }
    public int Money { get; set; }
    public string DisplayMoney { get { return "Money: " + Money; } }
    public int UserId { get; set; }
}
