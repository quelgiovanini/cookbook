namespace Cookbook.FileAccess;

public class FileData
{
    public string Name { get; }
    public FileFormat Format { get; }

    public FileData(string name, FileFormat format)
    {
        Name = name;
        Format = format;
    }

    public string ToPath() => $"{Name}.{Format.AsFileExtension()}";

}
