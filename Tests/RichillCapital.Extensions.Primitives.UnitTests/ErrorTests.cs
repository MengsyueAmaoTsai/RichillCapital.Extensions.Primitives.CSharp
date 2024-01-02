namespace RichillCapital.Extensions.Primitives;

[TestClass]
public sealed class ErrorTests
{
    [TestMethod]
    public void WithMessage_ShouldReturnErrorWithMessage()
    {
        string message = "This is and error message.";
        var error = Error.WithMessage(message);

        error.Message.Should().Be(message);
    }

    [TestMethod]
    public void WithMessage_Should_ReturnNoneWhenGivenEmptyMessage()
    {
        var error = Error.WithMessage(string.Empty);

        error.Should().Be(Error.None);
    }
}