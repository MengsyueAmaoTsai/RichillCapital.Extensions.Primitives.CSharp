namespace RichillCapital.Extensions.Primitives.UnitTests.Results;

internal static class Extensions
{
    public static void ShouldBeValidFailureResult(this Result result, Error error, string errorMessage)
    {
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
        result.Error.Message.Should().Be(errorMessage);
    }

    public static void ShouldBeValidFailureResult<TValue>(this Result<TValue> result, Error error, string errorMessage)
    {
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
        result.Error.Message.Should().Be(errorMessage);
        result.Value.Should().Be(default(TValue));
    }

    public static void ShouldBeValidSuccessResult(this Result result)
    {
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
    }

    public static void ShouldBeValidSuccessResult<TValue>(this Result<TValue> result, TValue value)
    {
        result.IsFailure.Should().BeFalse();
        result.Value.Should().Be(value);
        result.Error.Should().Be(Error.None);
    }
}