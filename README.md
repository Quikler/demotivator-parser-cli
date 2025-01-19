# demotivator-parser-cli

demotivator-parser-cli is a simple CLI tool that can be used to create a simple demotivator image by parsing and making requests to [imgonline](https://www.imgonline.com.ua/demotivational-poster.php) website

## Usage

### Run executable file:
```
./demotivator-parser-cli
```

### See the required arguments in the output:
```
demotivator-parser-cli 1.0.0+472c859a469aca61f8702c0f93c6246b46da9096
Copyright (C) 2025 demotivator-parser-cli

ERROR(S):
  Required option 'f, filepath' is missing.
  Required option 'o, outputpath' is missing.

  -f, --filepath       Required. File path to image that will be demotivated

  -o, --outputpath     Required. Output file path to demotivated image

  -t, --title          Title of demotivator image

  -d, --description    Description of demotivator image

  -v, --verbose        Set output to verbose message

  --help               Display this help screen.

  --version            Display version information.
```

## Example usage
Create demotivator with verbose argument of demo.jpg with title="Title" and description="Description" into output file demo-output.jpg:
```
./demotivator-parser-cli -f demo.jpg -t Title -d Description -o demo-output.jpg -v
```

### See the result output:
```
Verbose output enabled. Current Arguments: -v True
Creating multipart form data...
Making requests...
OK
Downloading result...
```

### Result
| Before | After |
| ------ | ----- |
| ![demo](https://github.com/user-attachments/assets/c58bfb2d-4788-42df-bcd5-bc9446506f46)| ![demo-output](https://github.com/user-attachments/assets/99d1dae1-3c82-47a3-bd3f-23c0346ba90f) |

## Clone the repository:

```
git clone https://github.com/Quikler/demotivator-parser-cli.git
```

## Libraries Used

[commandline](https://github.com/commandlineparser/commandline) -  The best C# command line parser that brings standardized *nix getopt style, for .NET. Includes F# support.

[AngleSharp](https://github.com/AngleSharp/AngleSharp) - 👼 The ultimate angle brackets parser library parsing HTML5, MathML, SVG and CSS to construct a DOM based on the official W3C specifications.

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/Quikler/demotivator-parser-cli/blob/master/LICENSE) file for more details.

### Developed with ❤️ by Quikler
