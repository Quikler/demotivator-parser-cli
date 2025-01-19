using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace demotivator_parser;

public static class DemotivatorParser
{
    public const string BASE_URL = "https://www.imgonline.com.ua";

    public static async Task<byte[]> ParseAsync(string filePath, string? title, string? description, bool verbose)
    {
        var http = new HttpClient()
        {
            BaseAddress = new Uri(BASE_URL),
        };

        var data = new MultipartFormDataContent();

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

        var config = Configuration.Default;
        var context = BrowsingContext.New(config);

        var document = await context.OpenAsync(req =>
        {
            req.Content(resultHtml);
            req.Address(BASE_URL);
        });

        var anchors = document.QuerySelectorAll<IHtmlAnchorElement>("a");
        var downloadAnchor = anchors.FirstOrDefault(a => a.Href.Contains("download.php")) ?? throw new Exception("download.php link cannot be found");

        if (verbose) Console.WriteLine("Downloading result...");

        var downloadResponse = await http.GetAsync(downloadAnchor.Href);
        return await downloadResponse.Content.ReadAsByteArrayAsync();
    }
}
