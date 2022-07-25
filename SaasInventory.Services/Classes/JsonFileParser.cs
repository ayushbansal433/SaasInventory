using Newtonsoft.Json;
using SaasInventory.Common.Classes;
using SaasInventory.Services.Interfaces;

namespace SaasInventory.Services.Classes
{
    public class JsonFileParser : IFileParser
    {
        public Inventory ParseProducts(StreamReader streamReader)
        {
            string fileData = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<Inventory>(fileData);
        }
    }
}
