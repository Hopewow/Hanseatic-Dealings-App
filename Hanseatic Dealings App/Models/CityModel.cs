using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanseatic_Dealings_App.Models;

public partial class CityModel : ObservableObject
{
    public int Id {get; set;}

    public string Name { get; set; }

    public string Xcord { get; set; }

    public string Ycord { get; set; }

    public List<CityStorageModel>? Goods { get; set; }
}
