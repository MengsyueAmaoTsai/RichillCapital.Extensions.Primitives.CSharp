namespace RichillCapital.Extensions.Primitives.UnitTests.Results;

[TestClass]
public sealed class ResultTests
{
    [TestMethod]
    public void Success_Should_ReturnSuccessResult()
    {
        Result result = Result.Success();

        result.ShouldBeValidSuccessResult();
    }

    [TestMethod]
    public void Success_Should_ReturnSuccessResultWithValue_WhenGivenValue()
    {
        var value = GetValue();
        Result<int> result = Result.Success(value);

        result.ShouldBeValidSuccessResult(value);
    }

    [TestMethod]
    public void Failure_Should_ReturnFailureResult()
    {
        var error = GetError();
        Result result = Result.Failure(error);

        result.ShouldBeValidFailureResult(error, "ErrorMessage");
    }

    [TestMethod]
    public void Failure_Should_ReturnFailureResultWithDefault()
    {
        var error = GetError();
        Result<string> result = Result.Failure(error);
        result.ShouldBeValidFailureResult(error, "ErrorMessage");
    }

    [TestMethod]
    public void From_Should_ReturnSuccessResultWithValue()
    {
        var value = GetValue();
        Result<int> result = Result.From(value);

        result.ShouldBeValidSuccessResult(value);
    }

    [TestMethod]
    public void ImplicitCast_Should_CastErrorToFailureResult()
    {
        var error = GetError();
        Result result = error;

        result.ShouldBeValidFailureResult(error, "ErrorMessage");
    }

    [TestMethod]
    public void ImplicitCast_Should_CastValueToResultWithValue()
    {
        var value = GetValue();
        Result<int> result = value;

        result.ShouldBeValidSuccessResult(value);
    }

    [TestMethod]
    public void ImplicitCast_Should_CastErrorToResultWithDefaultValue()
    {
        var error = GetError();
        Result<int> result = error;

        result.ShouldBeValidFailureResult(error, "ErrorMessage");
    }

    private static int GetValue() => 10;

    private static Error GetError() => new("ErrorMessage");
}
