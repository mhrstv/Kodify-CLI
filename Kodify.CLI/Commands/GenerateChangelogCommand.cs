using System.CommandLine;
using Kodify.AI.Services;
using Kodify.AutoDoc.Services;
using Kodify.AI.Configuration;

namespace Kodify.CLI.Commands;

public class GenerateChangelogCommand : Command
{
    public GenerateChangelogCommand() : base("changelog", "Generates a changelog for the project")
    {
        // Path option
        var pathOption = new Option<string>(
            "--path",
            "The path to the project or solution")
        {
            IsRequired = false
        };

        // API Key option for AI service
        var apiKeyOption = new Option<string>(
            "--api-key",
            "The API key for AI service integration. If not provided, generates changelog without AI.")
        {
            IsRequired = false
        };

        AddOption(pathOption);
        AddOption(apiKeyOption);

        this.SetHandler(HandleCommand, pathOption, apiKeyOption);
    }

    private async Task HandleCommand(string path, string apiKey)
    {
        try
        {
            var generator = string.IsNullOrEmpty(apiKey) 
                ? new MarkdownGenerator()
                : new MarkdownGenerator(new OpenAIService(new OpenAIConfig { ApiKey = apiKey }));

            if (string.IsNullOrEmpty(path))
            {
                if (string.IsNullOrEmpty(apiKey))
                {
                    generator.GenerateChangelog();
                }
                else
                {
                    await generator.GenerateChangelogAsync(new OpenAIService(new OpenAIConfig { ApiKey = apiKey }));
                }
            }
            else
            {
                generator.GenerateChangelog(path);
            }

            Console.WriteLine("Changelog generated successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error generating changelog: {ex.Message}");
            Environment.Exit(1);
        }
    }
} 