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
        string expectedValue = "ValidValue";
        var successResult = Result.Success(expectedValue);

        var result = successResult.Ensure(value => value.Length > 0, Error.WithMessage("Error"));

        result.ShouldBeValidSuccessResult(expectedValue);
    }

    [TestMethod]
    public void Ensure_Should_ReturnErrorResult_WithFalsePredicate()
    {
        string text = "Success";
        var successResult = Result.Success(text);
        var error = Error.WithMessage("Error");

        var result = successResult.Ensure(value => value.Length == 1, error);

        result.ShouldBeValidFailureResult(error, "Error");
    }

    private sealed record Person(string Name);

    [TestMethod]
    public void Map_Should_ReturnResultWithDestinationValue_WhenResultIsSuccess()
    {
        var name = "John";
        var result = Result.From(name);

        var personResult = result.Map(name => new Person(name));
        var person = personResult.Value;

        personResult.ShouldBeValidSuccessResult(new Person(name));
        person.Should().BeOfType<Person>();
        person.Name.Should().Be(name);
    }

    [TestMethod]
    public void Map_Should_ReturnFailureResultWithSameError_WithFailureResult()
    {
        var errorMessage = "Something went wrong.";
        var error = new Error(errorMessage);
        Result<string> failureResult = Result.Failure(error);

        var personResult = failureResult.Map(name => new Person(name));

        personResult.ShouldBeValidFailureResult(error, errorMessage);
    }
}