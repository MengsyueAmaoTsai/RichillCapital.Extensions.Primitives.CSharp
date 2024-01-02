namespace RichillCapital.Extensions.Primitives.UnitTests.Results;

[TestClass]
public sealed class ResultRailwayExtensionsTests
{
    [TestMethod]
    public void Ensure_Should_ReturnSameFailureResult_WithFailureResult()
    {
        var error = Error.WithMessage("Error");
        Result<string> failureResult = Result.Failure(error);

        var result = failureResult.Ensure(value => !string.IsNullOrEmpty(value), Error.WithMessage("Empty string"));

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
    }

    [TestMethod]
    public void Ensure_Should_ReturnOriginalResult_WithTruePredicate()
    {
        var successResult = Result.Success("ValidValue");

        var result = successResult.Ensure(value => value.Length > 0, Error.WithMessage("Error"));

        result.IsFailure.Should().BeFalse();
        result.Value.Should().Be("ValidValue");
        result.Error.Should().Be(Error.None);
    }

    [TestMethod]
    public void Ensure_Should_ReturnErrorResult_WithFalsePredicate()
    {
        string text = "Success";
        var successResult = Result.Success(text);
        var error = Error.WithMessage("Error");

        var result = successResult.Ensure(value => value.Length == 1, error);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
        result.Error.Message.Should().Be("Error");
    }
}