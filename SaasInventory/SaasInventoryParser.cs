using SaasInventory.Common.Classes;
using SaasInventory.Services.Classes;
using SaasInventory.Services.Interfaces;
using static SaasInventory.Common.Enum;

namespace SaasInventory
{
    public class SaasInventoryParser
    {
        private Func<FileType, IFileParser> _fileParser;
        public Inventory Products(string fileName, string path)
        {

            Inventory products = new Inventory();
            using (StreamReader r = new StreamReader(path))
            {
                if (path.ToLower().Contains(".json"))
                {
                    _fileParser = new Func<FileType, IFileParser>(IFileParser (FileType) => new JsonFileParser());
                    var fileParser = _fileParser(FileType.json);
                    products = fileParser.ParseProducts(r);
                }
                else if (path.ToLower().Contains(".yaml"))
                {
                    _fileParser = new Func<FileType, IFileParser>(IFileParser (FileType) => new YamlFileParser());
                    var fileParser = _fileParser(FileType.yaml);
                    products = fileParser.ParseProducts(r);
                }
                else
                {
                    return null;
                }
            }
            return products;
        }
    }
}
