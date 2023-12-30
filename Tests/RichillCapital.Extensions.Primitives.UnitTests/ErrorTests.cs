namespace RichillCapital.Extensions.Primitives.UnitTests;

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