namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class ErrorOrTests
{
    [TestMethod]
    public void WithValue_Should_CreateErrorOr_WithIntValue()
    {
        var value = 42;

        var errorOr = ErrorOr<int>.WithValue(value);

        errorOr.HasValue.Should().BeTrue();
        errorOr.Value.Should().Be(42);
        errorOr.Error.Should().BeNull();
    }

    [TestMethod]
    public void WithError_Should_CreateErrorOr_WithIntError()
    {
        var error = new Error("Error");

        var errorOr = ErrorOr<int>.WithError(error);

        errorOr.HasValue.Should().BeFalse();
        errorOr.Value.Should().Be(default);
        errorOr.Error.Should().Be(error);
    }

    [TestMethod]
    public void WithValue_Should_CreateErrorOr_WithStringValue()
    {
        var value = "Test";

        var errorOr = ErrorOr<string>.WithValue(value);

        errorOr.HasValue.Should().BeTrue();
        errorOr.Value.Should().Be("Test");
        errorOr.Error.Should().BeNull();
    }

    [TestMethod]
    public void WithError_Should_CreateErrorOr_WithStringError()
    {
        var error = new Error("Error");

        var errorOr = ErrorOr<string>.WithError(error);

        errorOr.HasValue.Should().BeFalse();
        errorOr.Value.Should().Be(default);
        errorOr.Error.Should().Be(error);
    }

    [TestMethod]
    public void WithValue_Should_CreateErrorOr_WithBoolValue()
    {
        var value = true;

        var errorOr = ErrorOr<bool>.WithValue(value);

        errorOr.HasValue.Should().BeTrue();
        errorOr.Value.Should().BeTrue();
        errorOr.Error.Should().BeNull();
    }

    [TestMethod]
    public void WithError_Should_CreateErrorOr_WithBoolError()
    {
        var error = new Error("Error");

        var errorOr = ErrorOr<bool>.WithError(error);

        errorOr.HasValue.Should().BeFalse();
        errorOr.Value.Should().Be(default);
        errorOr.Error.Should().Be(error);
    }

    [TestMethod]
    public void WithValue_Should_CreateErrorOr_WithDateTimeOffsetValue()
    {
        var value = DateTimeOffset.Now;

        var errorOr = ErrorOr<DateTimeOffset>.WithValue(value);

        errorOr.HasValue.Should().BeTrue();
        errorOr.Value.Should().Be(value);
        errorOr.Error.Should().BeNull();
    }

    [TestMethod]
    public void WithError_Should_CreateErrorOr_WithDateTimeOffsetError()
    {
        var error = new Error("Error");

        var errorOr = ErrorOr<DateTimeOffset>.WithError(error);

        errorOr.HasValue.Should().BeFalse();
        errorOr.Value.Should().Be(default);
        errorOr.Error.Should().Be(error);
    }
}