using System;
using System.IO;
using System.Threading.Tasks;

namespace demotovator_parser_cli;

[App]
internal class Program
{
    ///<summary>This will be help text for command</summary>
    ///<param name="input">Input file path (e.g. input.jpg)</param>
    ///<param name="output">Output file path (e.g. output.jpg)</param>
    ///<param name="title">Title of demotivator (e.g. title)</param>
    ///<param name="description">Description of demotivator (e.g. description)</param>
    public static async Task Demotivate(string input, string output, string title = null, string description = null)
    {
        input = Path.GetFullPath(input);
        output = Path.GetFullPath(output);

        if (string.IsNullOrWhiteSpace(input) || !File.Exists(input))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{input} - file does not exist.");
            return;
        }

        if (string.IsNullOrWhiteSpace(output) || Path.GetExtension(output) == string.Empty)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{output} - must be a valid output file.");
            return;
        }

        var bytes = await DemotivatorParser.ParseAsync(input, title, description, true);
        await File.WriteAllBytesAsync(output, bytes);
    }
}