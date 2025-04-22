using System.CommandLine;
using FluentAssertions;
using Kodify.CLI.Commands;
using Xunit;

namespace Kodify.CLI.Tests.Commands
{
    public class GenerateChangelogCommandTests
    {
        [Fact]
        public void Constructor_ShouldCreateCommandWithCorrectName()
        {
            // Arrange & Act
            var command = new GenerateChangelogCommand();

            // Assert
            command.Name.Should().Be("changelog");
            command.Description.Should().Be("Generates a changelog for the project");
        }

        [Fact]
        public void Constructor_ShouldAddPathOption()
        {
            // Arrange & Act
            var command = new GenerateChangelogCommand();

            // Assert
            command.Options.Should().Contain(o => o.Name == "path");
        }

        [Fact]
        public void Constructor_ShouldAddApiKeyOption()
        {
            // Arrange & Act
            var command = new GenerateChangelogCommand();

            // Assert
            command.Options.Should().Contain(o => o.Name == "api-key");
        }
    }
} 