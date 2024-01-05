namespace RichillCapital.Extensions.Primitives.UnitTests.Errors;

[TestClass]
public sealed class ErrorCreationTests
{
    [TestMethod]
    public void NotFound_Should_CreateNotFoundTypeError()
    {
        var message = "Not found.";
        var error = Error.NotFound(message);

        error.Should().NotBeNull();
        error.Message.Should().Be(message);
        error.Type.Should().Be(ErrorType.NotFound);
    }

    [TestMethod]
    public void Conflict_Should_CreateConflictTypeError()
    {
        var message = "Conflict.";
        var error = Error.Conflict(message);

        error.Should().NotBeNull();
        error.Message.Should().Be(message);
        error.Type.Should().Be(ErrorType.Conflict);
    }

    [TestMethod]
    public void Unauthorized_Should_CreateUnauthorizedTypeError()
    {
        var message = "Unauthorized.";
        var error = Error.Unauthorized(message);

        error.Should().NotBeNull();
        error.Message.Should().Be(message);
        error.Type.Should().Be(ErrorType.Unauthorized);
    }

    [TestMethod]
    public void Invalid_Should_CreateInvalidTypeError()
    {
        var message = "Invalid.";
        var error = Error.Invalid(message);

        error.Should().NotBeNull();
        error.Message.Should().Be(message);
        error.Type.Should().Be(ErrorType.Invalid);
    }

    [TestMethod]
    public void Invalid_Should_CreateForbiddenTypeError()
    {
        var message = "Forbidden.";
        var error = Error.Forbidden(message);

        error.Should().NotBeNull();
        error.Message.Should().Be(message);
        error.Type.Should().Be(ErrorType.Forbidden);
    }

    [TestMethod]
    public void Null_Should_CreateNullTypeError()
    {
        var error = Error.Null;

        error.Should().NotBeNull();
        error.Message.Should().Be(string.Empty);
        error.Type.Should().Be(ErrorType.Null);
    }

    [TestMethod]
    public void WithMessage_Should_CreateDefaultTypeError()
    {
        var message = "default";
        var error = Error.WithMessage(message);

        error.Should().NotBeNull();
        error.Message.Should().Be(message);
        error.Type.Should().Be(ErrorType.Default);
    }
}