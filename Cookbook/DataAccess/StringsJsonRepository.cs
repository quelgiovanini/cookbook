namespace Cookbook.DataAccess;

using System.Text.Json;

public class StringsJsonRepository : StringsRepository
{
    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToStrings(string dataContent)
    {
        return JsonSerializer.Deserialize<List<string>>(dataContent);
    }
}
