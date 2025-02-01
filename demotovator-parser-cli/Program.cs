using System.Diagnostics.CodeAnalysis;
using CommandLine;

namespace demotovator_parser_cli;

internal class Program
{
    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(Options))]
    private static async Task Main(string[] args)
    {
        await Parser.Default.ParseArguments<Options>(args)
            .WithParsedAsync(async o =>
            {
                if (o.Verbose)
                {
                    Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                }
                else
                {
                    Console.WriteLine($"Verbose output disabled. Current Arguments: -v {o.Verbose}");
                }

                o.FilePath = Path.GetFullPath(o.FilePath);
                o.OutputFilePath = Path.GetFullPath(o.OutputFilePath);

#if DEBUG
                Console.WriteLine($"FilePath: {o.FilePath}");
                Console.WriteLine($"OutputFilePath: {o.OutputFilePath}");
#endif

                if (string.IsNullOrWhiteSpace(o.FilePath) || !File.Exists(o.FilePath))
                {
                    Console.WriteLine($"-f, --filepath\t'{o.FilePath}' File not found");
                    return;
                }

                if (string.IsNullOrWhiteSpace(o.OutputFilePath) || Path.GetExtension(o.OutputFilePath) == string.Empty)
                {
                    Console.WriteLine("-o, --outputpath\tMust be a valid output file");
                    return;
                }

                var bytes = await DemotivatorParser.ParseAsync(o.FilePath, o.Title, o.Description, o.Verbose);
                await File.WriteAllBytesAsync(o.OutputFilePath, bytes);
            });
    }
}