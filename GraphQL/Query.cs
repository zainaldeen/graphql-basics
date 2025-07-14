using System.Text.Json;
using System.Text.Json.Serialization;

public class Query
{
    // public List<Book> Books => ReadBooks();

    public List<Book> Books(string search="")
    {
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var books = JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;

        return books.Where(b => b.Name.IndexOf(search) >= 0).ToList();
    }

    // public List<Magazine> Magazine => ReadMagazine();

    public List<Magazine> Magazines(string search = "")
    {
        string fileName = "Database/magazines.json";
        string jsonString = File.ReadAllText(fileName);
        var magazines = JsonSerializer.Deserialize<List<Magazine>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;
        return magazines.Where(magazine => magazine.Name.IndexOf(search) >= 0).ToList();
    }
    
    // public List<IReadingMaterials> ReadingMaterials => ReadReadingMaterials();   

    public List<IReadingMaterials> ReadingMaterials()  {
        var materials = Books().Cast<IReadingMaterials>().ToList();
        materials.AddRange(Magazines().Cast<IReadingMaterials>());
        return materials;
    }
    // public List<IThings> Things => Things();   

    public List<IThings> Things()  {
        var things = Books().Cast<IThings>().ToList();
        things.AddRange(Magazines().Cast<IThings>());
        return things;
    }
}