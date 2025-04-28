namespace CareerKitBackend.Main.Utils;

public static class FileParser
{
    public static readonly string Marker = "[%R%]";
    private static readonly string BasePath = Path.Combine(AppContext.BaseDirectory, "Resources");

    public static string ReadFile(string fileName)
    {
        string filePath = Path.Combine(BasePath, fileName);
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }
        return File.ReadAllText(filePath);
    }
}