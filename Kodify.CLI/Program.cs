using System;
using System.CommandLine;
using Kodify.CLI.Commands;

namespace Kodify.CLI
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand
            {
                new GenerateChangelogCommand(),
                new GenerateReadmeCommand(),
                new GitHubActionsCommand(),
                new GitLabCICommand(),
                new AzureDevOpsCommand(),
                new TerraformCommand(),
                new CloudFormationCommand(),
                new PUMLCommand()
            };

            rootCommand.Description = "Kodify CLI - A command-line interface for the Kodify tools.";

            return await rootCommand.InvokeAsync(args);
        }
    }
}