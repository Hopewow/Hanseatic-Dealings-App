using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanseatic_Dealings_App.Models
{
    public class MarketModel
    {
        public CityStorageModel CityStorage { get; set; }
        public ShipModel Player { get; set; }
        public int Amount { get; set; }
    }

   
}
