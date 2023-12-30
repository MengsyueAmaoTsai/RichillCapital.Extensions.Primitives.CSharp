using RichillCapital.Extensions.Primitives.Results;

namespace RichillCapital.Extensions.Primitives.UnitTests.Results;

[TestClass]
public sealed class ErrorTests
{
    [TestMethod]
    public void WithMessage_Should_CreateErrorWithEmptyString()
    {
        // Act
        var error = Error.WithMessage(string.Empty);

        // Assert
        error.Message.Should().BeEmpty();
    }
}