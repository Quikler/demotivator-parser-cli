using AngleSharp.Text;

namespace cli.Helpers;

public static class PathValidator
{
    public static string Validate(string path) => path
        .Replace("~", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))
        .ReplaceFirst("./", $"{Environment.CurrentDirectory}/")
        .Trim();
}