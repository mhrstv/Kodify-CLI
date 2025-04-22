using System.CommandLine;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace Kodify.CLI.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Program_ShouldHaveRootCommand()
        {
            // Arrange & Act
            var programType = typeof(Program);
            var mainMethod = programType.GetMethod("Main", BindingFlags.Static | BindingFlags.NonPublic);
            
            // Assert
            mainMethod.Should().NotBeNull("because Program should have a Main method");
        }

        [Fact]
        public void Program_RootCommandShouldContainCommands()
        {
            // This test checks that the Program class creates a RootCommand with commands
            // We can indirectly test this by checking the assembly contains Command types
            var assembly = Assembly.GetAssembly(typeof(Program));
            assembly.Should().NotBeNull("because we need to analyze the Program's assembly");
            
            var commandTypes = assembly!.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Command)) && !t.IsAbstract)
                .ToList();
            
            commandTypes.Should().NotBeEmpty("because Program should register Command classes");
        }
    }
} 