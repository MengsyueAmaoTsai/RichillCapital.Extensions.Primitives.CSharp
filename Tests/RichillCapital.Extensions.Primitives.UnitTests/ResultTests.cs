
namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class ResultTests
{
    [TestMethod]
    public void ImplicitCast_Should_CastErrorToFailureResult()
    {
        var error = GetError();
        Result result = error;

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
        result.Error.Message.Should().Be("ErrorMessage");
    }

    [TestMethod]
    public void Success_Should_ReturnSuccessResult()
    {
        Result result = Result.Success();

        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
    }

    [TestMethod]
    public void From_Should_ReturnSuccessResultWithValue()
    {
        var value = GetValue();
        Result<int> result = Result.From(value);

        result.IsFailure.Should().BeFalse();
        result.Value.Should().Be(value);
        result.Error.Should().Be(Error.None);
    }

    [TestMethod]
    public void ImplicitCast_Should_CastValueToResultWithValue()
    {
        var value = GetValue();
        Result<int> result = value;

        result.IsFailure.Should().BeFalse();
        result.Value.Should().Be(value);
        result.Error.Should().Be(Error.None);
    }

    [TestMethod]
    public void ImplicitCast_Should_CastErrorToResultWithDefaultValue()
    {
        var error = GetError();
        Result<int> result = error;

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
        result.Error.Message.Should().Be("ErrorMessage");
        result.Value.Should().Be(default);
    }

    private static int GetValue() => 10;

    private static Error GetError() => new("ErrorMessage");
}
