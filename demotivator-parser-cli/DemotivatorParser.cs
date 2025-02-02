using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace demotovator_parser_cli;

public static partial class DemotivatorParser
{
    public const string BASE_URL = "https://www.imgonline.com.ua";

    [System.Text.RegularExpressions.GeneratedRegex(@"href=""(download\.php\?file=[^""]+)""", System.Text.RegularExpressions.RegexOptions.Compiled)]
    private static partial System.Text.RegularExpressions.Regex DownloadPhpRegex();

    public static async Task<byte[]> ParseAsync(string filePath, string title, string description, bool verbose)
    {
        using var http = new HttpClient()
        {
            BaseAddress = new Uri(BASE_URL),
        };

        using var data = new MultipartFormDataContent();

        if (verbose) Console.WriteLine("Creating multipart form data...");

        var imageContent = new StreamContent(File.OpenRead(filePath));
        imageContent.Headers.Add("Content-Type", "image/jpg");
        data.Add(imageContent, "uploadfile", "sample.jpg");
        data.Add(new StringContent("2"), "efset1");
        data.Add(new StringContent(title ?? string.Empty), "efset2");
        data.Add(new StringContent(description ?? string.Empty), "efset3");
        data.Add(new StringContent("3"), "efset4");
        data.Add(new StringContent("1"), "efset5");
        data.Add(new StringContent("3"), "efset6");
        data.Add(new StringContent("1"), "efset7");
        data.Add(new StringContent("2"), "outformat");
        data.Add(new StringContent("1"), "jpegtype");
        data.Add(new StringContent("92"), "jpegqual");
        data.Add(new StringContent("2"), "jpegmeta");

        if (verbose) Console.WriteLine("Making requests...");

        var result = await http.PostAsync("demotivational-poster-result.php", data);
        result.EnsureSuccessStatusCode();

        Console.WriteLine(result.StatusCode);

        var resultHtml = await result.Content.ReadAsStringAsync();

        var downloadPhp = DownloadPhpRegex().Match(resultHtml).Groups[1].Value;

#if DEBUG
        Console.WriteLine($"Download php: {downloadPhp}");
#endif

        if (verbose) Console.WriteLine("Downloading result...");

        var downloadResponse = await http.GetAsync(downloadPhp);
        return await downloadResponse.Content.ReadAsByteArrayAsync();
    }
}
