namespace Cookbook.DataAccess;

public abstract class StringsRepository : IStringsRepository
{
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var dataContent = File.ReadAllText(filePath);
            return TextToStrings(dataContent);
        }
        return new List<string>();

    }

    protected abstract List<string> TextToStrings(string dataContent);

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, StringsToText(strings));
    }

    protected abstract string StringsToText(List<string> strings);
}
