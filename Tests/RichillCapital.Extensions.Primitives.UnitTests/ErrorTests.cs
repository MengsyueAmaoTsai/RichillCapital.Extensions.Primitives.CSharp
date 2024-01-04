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
}