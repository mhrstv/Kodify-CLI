using System.CommandLine;
using Kodify.Extensions.Diagrams;

namespace Kodify.CLI.Commands;

public class PUMLCommand : Command
{
    public PUMLCommand() : base("puml", "Generate PlantUML class diagrams for the project")
    {
        // Path option for output directory
        var outputPathOption = new Option<string>(
            "--output",
            "The output directory path for the generated PUML files. Defaults to './diagrams' if not specified.")
        {
            IsRequired = false
        };

        // Path option for source directory
        var sourcePathOption = new Option<string>(
            "--path",
            "The path to the project or solution to analyze. Defaults to current directory if not specified.")
        {
            IsRequired = false
        };

        AddOption(outputPathOption);
        AddOption(sourcePathOption);

        this.SetHandler(HandleCommand, outputPathOption, sourcePathOption);
    }

    private async Task HandleCommand(string? outputPath, string? sourcePath)
    {
        try
        {
            var generator = new PUMLDiagramGenerator();

            if (string.IsNullOrEmpty(outputPath) && string.IsNullOrEmpty(sourcePath))
            {
                // Use default behavior
                generator.GeneratePUML();
            }
            else if (!string.IsNullOrEmpty(outputPath))
            {
                // Use specified output path
                generator.GeneratePUML(outputPath);
            }

            Console.WriteLine("PlantUML class diagrams generated successfully!");
            Console.WriteLine($"Generated files can be found in the 'diagrams' directory.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error generating PlantUML diagrams: {ex.Message}");
            Environment.Exit(1);
        }
    }
} 