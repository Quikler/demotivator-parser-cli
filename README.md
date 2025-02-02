# demotivator-parser-cli

demotivator-parser-cli is a simple CLI tool that can be used to create a simple demotivator image by parsing and making requests to [imgonline](https://www.imgonline.com.ua/demotivational-poster.php) website

## Usage

### Run executable file:
```
./demotivator-parser-cli
```

### See the required arguments in the output:
```
Usage: <command> <parameters> [options]
commands:
        help - shows help text of command
        demotivate - This will be help text for command
```

## Example usage
Create demotivator of demo.jpg with title="Title" and description="Description" into output file demotivated.jpg:

```
./demotivator-parser-cli demotivate .assets/demo.jpg .assets/demotivated.jpg
```

### See the result output:
```
Creating multipart form data...
Making requests...
OK
Download php: download.php?file=result_img/imgonline-com-ua-Demotivator-4JBv5AeBNfhyVD.jpg
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

[CommandLineArgsGenerator](https://github.com/xb-bx/CommandLineArgsGenerator) -  Source generator to generate command line args parser 

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/Quikler/demotivator-parser-cli/blob/master/LICENSE) file for more details.

### Developed with ❤️ by Quikler
