using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
    var input = args.AsQueryable().ToList();

    if (input.Count != 2)
        throw new Exception("Please supply valid parameters");
    else
    {
        SaasInventoryParser inventoryParser = new SaasInventoryParser();
        var parsedData = inventoryParser.Products(input[0].Trim(), input[1].Trim());
        if (parsedData != null && parsedData.Products.Count > 0)
        {
            foreach (Product item in parsedData.Products)
            {
                Console.WriteLine("importing: " + (string.IsNullOrEmpty(item.Name) ? "Title: " + item.Title : "Name: " + item.Name) + "; " + (item.Categories.Count > 0 ? "Categories: " + string.Join(",", item.Categories) : "Tags: " + item.Tags) + (!string.IsNullOrEmpty(item.Twitter) ? "; Twitter:" + item.Twitter : ""));
                Thread.Sleep(300);
            }
        }

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