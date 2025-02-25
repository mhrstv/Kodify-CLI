using System.CommandLine;
using Kodify.DevOps.Pipeline;
using Kodify.DevOps.IaC;
using Kodify.DevOps;

namespace Kodify.CLI.Commands;

public class GitHubActionsCommand : Command
{
    public GitHubActionsCommand() : base("githubactions", "Generate GitHub Actions workflow")
    {
        var pathOption = new Option<string>(
            "--path",
            "The path to the project or solution")
        {
            IsRequired = false
        };
        AddOption(pathOption);
        this.SetHandler(async (string? path) => await HandleCommand(path), pathOption);
    }

    private async Task HandleCommand(string? path = null)
    {
        try
        {
            var generator = new GithubActionsGenerator();
            await generator.GenerateAsync();
            Console.WriteLine("GitHub Actions workflow generated successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error generating GitHub Actions workflow: {ex.Message}");
            Environment.Exit(1);
        }
    }
}

public class GitLabCICommand : Command
{
    public GitLabCICommand() : base("gitlabci", "Generate GitLab CI pipeline")
    {
        var pathOption = new Option<string>(
            "--path",
            "The path to the project or solution")
        {
            IsRequired = false
        };
        AddOption(pathOption);
        this.SetHandler(async (string? path) => await HandleCommand(path), pathOption);
    }

    private async Task HandleCommand(string? path = null)
    {
        try
        {
            var generator = new GitLabCIGenerator();
            await generator.GenerateAsync();
            Console.WriteLine("GitLab CI pipeline generated successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error generating GitLab CI pipeline: {ex.Message}");
            Environment.Exit(1);
        }
    }
}

public class AzureDevOpsCommand : Command
{
    public AzureDevOpsCommand() : base("azuredevops", "Generate Azure DevOps pipeline")
    {
        var pathOption = new Option<string>(
            "--path",
            "The path to the project or solution")
        {
            IsRequired = false
        };
        AddOption(pathOption);
        this.SetHandler(async (string? path) => await HandleCommand(path), pathOption);
    }

    private async Task HandleCommand(string? path = null)
    {
        try
        {
            var generator = new AzureDevOpsGenerator();
            await generator.GenerateAsync();
            Console.WriteLine("Azure DevOps pipeline generated successfully!");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error generating Azure DevOps pipeline: {ex.Message}");
            Environment.Exit(1);
        }
    }
}

public class TerraformCommand : Command
{
    public TerraformCommand() : base("terraform", "Generate Terraform infrastructure code")
    {
        var pathOption = new Option<string>(
            "--path",
            "The path to the project or solution")
        {
            IsRequired = false
        };
        AddOption(pathOption);
        this.SetHandler(async (string? path) => await HandleCommand(path), pathOption);
    }

    private async Task HandleCommand(string? path = null)
    {
        try
        {
            var generator = new TerraformGenerator(path != null ? new DevOpsAnalyzer() : null);
            await generator.GenerateTemplateAsync();
            Console.WriteLine("Terraform infrastructure code generated successfully!");
            Console.WriteLine("Generated files can be found in the 'iac' directory.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error generating Terraform infrastructure: {ex.Message}");
            Environment.Exit(1);
        }
    }
}

public class CloudFormationCommand : Command
{
    public CloudFormationCommand() : base("cloudformation", "Generate AWS CloudFormation template")
    {
        var pathOption = new Option<string>(
            "--path",
            "The path to the project or solution")
        {
            IsRequired = false
        };
        AddOption(pathOption);
        this.SetHandler(async (string? path) => await HandleCommand(path), pathOption);
    }

    private async Task HandleCommand(string? path = null)
    {
        try
        {
            var generator = new CloudFormationGenerator(path != null ? new DevOpsAnalyzer() : null);
            await generator.GenerateTemplateAsync();
            Console.WriteLine("CloudFormation template generated successfully!");
            Console.WriteLine("Generated files can be found in the 'iac' directory.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error generating CloudFormation template: {ex.Message}");
            Environment.Exit(1);
        }
    }
} 