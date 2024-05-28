namespace Cookbook.DataAccess;

public class StringsTxtRepository : StringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    protected override string StringsToText(List<string> strings)
    {
        return string.Join(Separator, strings);
    }

    protected override List<string> TextToStrings(string dataContent)
    {
        return dataContent.Split(Separator).ToList();
    }
}
