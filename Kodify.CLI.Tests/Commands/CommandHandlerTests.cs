using System.CommandLine;
using FluentAssertions;
using Moq;
using Xunit;

namespace Kodify.CLI.Tests.Commands
{
    public class CommandHandlerTests
    {
        [Fact]
        public async Task Command_HandlerShouldBeInvoked()
        {
            // Arrange
            var mockHandler = new Mock<Action<string>>();
            var option = new Option<string>("--test", "Test option");
            var command = new Command("test-command", "Test command");
            command.AddOption(option);
            command.SetHandler(mockHandler.Object, option);

            // Act
            await command.InvokeAsync("--test value");

            // Assert
            mockHandler.Verify(h => h("value"), Times.Once);
        }

        [Fact]
        public async Task Command_HandlerShouldReceiveCorrectParameter()
        {
            // Arrange
            string? capturedValue = null;
            var option = new Option<string>("--test", "Test option");
            var command = new Command("test-command", "Test command");
            command.AddOption(option);
            command.SetHandler((string value) => { capturedValue = value; }, option);

            // Act
            await command.InvokeAsync("--test expected-value");

            // Assert
            capturedValue.Should().Be("expected-value");
        }
    }
} 