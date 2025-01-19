using System;
using CommandLine;

namespace cli.Arguments;

public class Options
{
    [Option('f', "filepath", Required = true, HelpText = "File path to image that will be demotivated")]
    public string FilePath { get; set; } = null!;

    [Option('o', "outputpath", Required = true, HelpText = "Output file path to demotivated image")]
    public string OutputFilePath { get; set; } = null!;

    [Option('t', "title", Required = false, HelpText = "Title of demotivator image")]
    public string? Title { get; set; }

    [Option('d', "description", Required = false, HelpText = "Description of demotivator image")]
    public string? Description { get; set; }

    [Option('v', "verbose", Required = false, HelpText = "Set output to verbose message")]
    public bool Verbose { get; set; }
}