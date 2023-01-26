using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hanseatic_Dealings_App.Models
{
    public class CityStorageModel
    {
        public int Id { get; set; }
        public GoodsModel Item { get; set; }
        public int Limit { get; set; }
        public int Current { get; set; }
        [JsonIgnore]
        public CityModel? City { get; set; }
        public int CityId { get; set; }

    }
}
