using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasInventory.Common.Classes
{
    public class Inventory
    {
        public List<Product> Products { get; set; }
    }


    public class Product
    {
        [JsonProperty("title")]
        public string Name { get; set; }
        public List<string> Categories { get; set; }
        public string Twitter { get; set; }

        public string Tags { get; set; }
    }
}
