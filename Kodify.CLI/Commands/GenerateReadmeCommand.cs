using System.CommandLine;
using Kodify.AI.Services;
using Kodify.AutoDoc.Services;
using Kodify.AI.Configuration;
using Kodify.Repository.Models;
using Kodify.Repository.Services;

namespace Kodify.CLI.Commands;

public class GenerateReadmeCommand : Command
{
    public GenerateReadmeCommand() : base("readme", "Generates a README.md file for the project")
    {
        // Path option
        var pathOption = new Option<string>(
            "--path",
            "The path to the project or solution")
        {
            IsRequired = false
        };

        // Project name option
        var nameOption = new Option<string>(
            "--name",
            "The name of the project")
        {
            IsRequired = false
        };

        // Project summary option
        var summaryOption = new Option<string>(
            "--summary",
            "A brief summary of the project")
        {
            IsRequired = false
        };

        // Usage instructions option
        var usageOption = new Option<string>(
            "--usage",
            "Usage instructions for the project")
        {
            IsRequired = false
        };

        // API Key option for AI service
        var apiKeyOption = new Option<string>(
            "--api-key",
            "The API key for AI service integration. If not provided, generates basic README without AI.")
        {
            IsRequired = false
        };

        // Template option
        var templateOption = new Option<string>(
            "--template",
            "Path to a custom README template file")
        {
            IsRequired = false
        };

        AddOption(pathOption);
        AddOption(nameOption);
        AddOption(summaryOption);
        AddOption(usageOption);
        AddOption(apiKeyOption);
        AddOption(templateOption);

        this.SetHandler(HandleCommand, pathOption, nameOption, summaryOption, usageOption, apiKeyOption, templateOption);
    }

    private async Task HandleCommand(string path, string name, string summary, string usage, string apiKey, string template)
    {
        try
        {
            var generator = string.IsNullOrEmpty(apiKey) 
                ? new MarkdownGenerator()
                : new MarkdownGenerator(new OpenAIService(new OpenAIConfig { ApiKey = apiKey }));

            // Use project name from path if not specified
            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(path))
            {
                name = Path.GetFileNameWithoutExtension(path);
            }
            // Default to directory name if no name provided
            else if (string.IsNullOrEmpty(name))
            {
                name = Path.GetFileName(Directory.GetCurrentDirectory());
            }

            // Default values for summary and usage if not provided
            summary ??= "A software project.";
            usage ??= "Please refer to the documentation for usage instructions.";

            if (!string.IsNullOrEmpty(path))
            {
                var projectAnalyzer = new ProjectAnalyzer();
                var projectInfo = projectAnalyzer.Analyze(path);
                await generator.GenerateReadMeAsync(projectInfo, name, summary, usage, template);
            }
            else
            {
                await generator.GenerateReadMeAsync(name, summary, usage, template);
            }

            Console.WriteLine("README.md generated successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error generating README: {ex.Message}");
            Environment.Exit(1);
        }
    }
} 