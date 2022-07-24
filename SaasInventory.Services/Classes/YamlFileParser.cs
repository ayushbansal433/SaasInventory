using SaasInventory.Common.Classes;
using SaasInventory.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization.NamingConventions;

namespace SaasInventory.Services.Classes
{
    public class YamlFileParser : IFileParser
    {
        public Inventory ParseProducts(StreamReader streamReader)
        {
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
    .WithNamingConvention(CamelCaseNamingConvention.Instance)
    .Build();
            var result = deserializer.Deserialize<List<Product>>(streamReader);
            Inventory inventory = new Inventory();
            inventory.Products = new List<Product>();

            inventory.Products.AddRange(result);
            return inventory;
        }
    }
}
