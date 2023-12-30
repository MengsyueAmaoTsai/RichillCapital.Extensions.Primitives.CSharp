using RichillCapital.Extensions.Primitives.Results;

namespace RichillCapital.Extensions.Primitives.UnitTests.Results;

[TestClass]
public sealed class ResultWithoutValueTests
{
    [TestMethod]
    public void Success_Should_CreateSuccessResult()
    {
        // Act
        var result = Result.Success();

        // Assert
        result.IsFailure.Should().BeFalse();
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().Be(Error.Null);
        result.Error.Message.Should().Be(string.Empty);
    }

    [TestMethod]
    public void Failure_Should_CreateFailureResult()
    {
        // Act
        var result = Result.Failure(Error.WithMessage("Error message"));

        // Assert
        result.IsFailure.Should().BeTrue();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBe(Error.Null);
        result.Error.Message.Should().Be("Error message");
    }
}