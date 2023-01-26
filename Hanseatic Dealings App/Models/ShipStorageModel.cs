using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hanseatic_Dealings_App.Models
{
    public class ShipStorageModel
    {
        public int Id { get; set; }
        public GoodsModel Item { get; set; }
        public int Amount { get; set; }
        [JsonIgnore]
        public ShipModel? Player { get; set; }
        public int PlayerId { get; set; }
    }
}
