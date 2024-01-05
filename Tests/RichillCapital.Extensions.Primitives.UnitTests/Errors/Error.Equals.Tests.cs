namespace RichillCapital.Extensions.Primitives.UnitTests.Errors;

[TestClass]
public sealed class ErrorEqualsTests
{
    [TestMethod]
    public void SameError_Should_BeEqual()
    {
        var message = "Not found.";
        var error1 = Error.NotFound(message);
        var error2 = Error.NotFound(message);

        error1.Should().Be(error2);
        error1.Equals(error2).Should().BeTrue();
        error1.GetHashCode().Should().Be(error2.GetHashCode());
    }

    [TestMethod]
    public void DifferentErrorType_Should_NotBeEqual()
    {
        var message = "Not found.";
        var error1 = Error.NotFound(message);
        var error2 = Error.Conflict(message);

        error1.Should().NotBe(error2);
        error1.Equals(error2).Should().BeFalse();
        error1.GetHashCode().Should().NotBe(error2.GetHashCode());
    }

    [TestMethod]
    public void SameErrorType_Should_BeEqual()
    {
        var error1 = Error.Null;
        var error2 = Error.Null;

        error1.Should().Be(error2);
        error1.Equals(error2).Should().BeTrue();
        error1.GetHashCode().Should().Be(error2.GetHashCode());
    }

    [TestMethod]
    public void DifferenceErrorType_When_HaveSameMessage_Should_NotBeEqual()
    {
        var errorNull = Error.Null;
        var errorDefault = Error.WithMessage(string.Empty);

        errorNull.Message.Should().Be(errorDefault.Message);
        errorNull.Should().NotBe(errorDefault);
    }
}