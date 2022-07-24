using Microsoft.Extensions.DependencyInjection;
using SaasInventory.Common.Classes;
using SaasInventory.Services.Classes;
using SaasInventory.Services.Interfaces;
using static SaasInventory.Common.Enum;

var collection = new ServiceCollection();
IServiceProvider serviceProvider = collection.BuildServiceProvider();
collection.AddTransient<YamlFileParser>();
collection.AddTransient<JsonFileParser>();
collection.AddTransient<Func<FileType, IFileParser>>(serviceProvider => key =>
{
    switch (key)
    {
        case FileType.yaml:
            {
                return serviceProvider.GetService<YamlFileParser>();
            }
        default:
            return serviceProvider.GetService<JsonFileParser>();
    }
});

try
{
    string input = Console.ReadLine();

    if (String.IsNullOrEmpty(input) || input.Split(" ").Length != 2)
        throw new Exception("Please supply valid parameters");
    else
    {
        var inputArray = input.Split(" ");
        
        SaasInventoryParser inventoryParser = new SaasInventoryParser();
        var parsedData = inventoryParser.Products(inputArray[0], inputArray[1]);
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
if (serviceProvider is IDisposable)
{
    ((IDisposable)serviceProvider).Dispose();
}

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
                _fileParser = new Func<FileType, IFileParser>(IFileParser (FileType) => new JsonFileParser()); var fileParser = _filePars
            e.json);
                products = fileParser.ParseProd


                else if
            wer().Contains(".yaml"))
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