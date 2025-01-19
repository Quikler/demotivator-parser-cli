using cli.Arguments;
using CommandLine;
using demotivator_parser;

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

        //o.FilePath = PathValidator.Validate(o.FilePath);
        //o.OutputFilePath = PathValidator.Validate(o.OutputFilePath);

        if (string.IsNullOrWhiteSpace(o.FilePath))
        {
            Console.WriteLine("-f, --filepath\tCannot be empty");
            return;
        }

        if (string.IsNullOrWhiteSpace(o.OutputFilePath))
        {
            Console.WriteLine("-o, --outputpath\tCannot be empty");
            return;
        }

        var bytes = await DemotivatorParser.ParseAsync(o.FilePath, o.Title, o.Description, o.Verbose);
        await File.WriteAllBytesAsync(o.OutputFilePath, bytes);
    });