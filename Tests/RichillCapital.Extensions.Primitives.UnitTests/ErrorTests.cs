namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class ErrorTests
{
    [TestMethod]
    public void NotFound_Should_CreateErrorWithNotFoundType()
    {
        var error = Error.NotFound("Not found!");

        error.Type.Should().Be(ErrorType.NotFound);
    }

    [TestMethod]
    public void NotFound_Should_CreateErrorWithConflictType()
    {
        var error = Error.Conflict("Conflict!");

        error.Type.Should().Be(ErrorType.Conflict);
    }

    [TestMethod]
    public void NotFound_Should_CreateErrorWithUnauthorizedType()
    {
        var error = Error.Unauthorized("Unauthorized!");

        error.Type.Should().Be(ErrorType.Unauthorized);
    }

    [TestMethod]
    public void Equals_Should_ReturnTrueWithSameError()
    {
        var message = "Not found.";
        var error1 = Error.NotFound(message);
        var error2 = Error.NotFound(message);

        error1.Should().Be(error2);
    }
}