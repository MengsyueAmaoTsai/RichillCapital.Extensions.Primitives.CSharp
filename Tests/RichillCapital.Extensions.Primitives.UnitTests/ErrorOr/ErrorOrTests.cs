namespace RichillCapital.Extensions.Primitives.UnitTests.ErrorOr;

[TestClass]
public sealed class ErrorOrTests
{
    [TestMethod]
    public void WithValue_Should_CreateErrorOr_WithIntValue()
    {
        var value = 42;

        var errorOr = ErrorOr<int>.WithValue(value);

        errorOr.HasError.Should().BeFalse();
        errorOr.Value.Should().Be(42);
        errorOr.Error.Should().Be(Error.Null);
    }

    [TestMethod]
    public void WithError_Should_CreateErrorOr_WithIntError()
    {
        var error = Error.WithMessage("Error");

        var errorOr = ErrorOr<int>.WithError(error);

        errorOr.HasError.Should().BeTrue();
        errorOr.Value.Should().Be(default);
        errorOr.Error.Should().Be(error);
    }

    [TestMethod]
    public void WithValue_Should_CreateErrorOr_WithStringValue()
    {
        var value = "Test";

        var errorOr = ErrorOr<string>.WithValue(value);

        errorOr.HasError.Should().BeFalse();
        errorOr.Value.Should().Be("Test");
        errorOr.Error.Should().Be(Error.Null);
    }

    [TestMethod]
    public void WithError_Should_CreateErrorOr_WithStringError()
    {
        var error = Error.WithMessage("Error");

        var errorOr = ErrorOr<string>.WithError(error);

        errorOr.HasError.Should().BeTrue();
        errorOr.Value.Should().Be(default);
        errorOr.Error.Should().Be(error);
    }

    [TestMethod]
    public void WithValue_Should_CreateErrorOr_WithBoolValue()
    {
        var value = true;

        var errorOr = ErrorOr<bool>.WithValue(value);

        errorOr.HasError.Should().BeFalse();
        errorOr.Value.Should().BeTrue();
        errorOr.Error.Should().Be(Error.Null);
    }

    [TestMethod]
    public void WithError_Should_CreateErrorOr_WithBoolError()
    {
        var error = Error.WithMessage("Error");

        var errorOr = ErrorOr<bool>.WithError(error);

        errorOr.HasError.Should().BeTrue();
        errorOr.Value.Should().Be(default);
        errorOr.Error.Should().Be(error);
    }

    [TestMethod]
    public void WithValue_Should_CreateErrorOr_WithDateTimeOffsetValue()
    {
        var value = DateTimeOffset.Now;

        var errorOr = ErrorOr<DateTimeOffset>.WithValue(value);

        errorOr.HasError.Should().BeFalse();
        errorOr.Value.Should().Be(value);
        errorOr.Error.Should().Be(Error.Null);
    }

    [TestMethod]
    public void WithError_Should_CreateErrorOr_WithDateTimeOffsetError()
    {
        var error = Error.WithMessage("Error");

        var errorOr = ErrorOr<DateTimeOffset>.WithError(error);

        errorOr.HasError.Should().BeTrue();
        errorOr.Value.Should().Be(default);
        errorOr.Error.Should().Be(error);
    }

    [TestMethod]
    public void ImplicitOperator_FromError_Should_CreateErrorOrWithErrorMessage()
    {
        // Arrange
        var error = Error.WithMessage("Some error message");

        // Act
        ErrorOr<int> result = error;

        // Assert
        result.HasError.Should().BeTrue();
        result.Error.Should().Be(error);
        result.Value.Should().Be(default);
    }

    [TestMethod]
    public void ImplicitOperator_FromErrorOr_Should_ExtractValueFromErrorOr()
    {
        // Arrange & Act
        ErrorOr<int> result = 42;

        // Assert
        result.HasError.Should().BeFalse();
        result.Value.Should().Be(42);
        result.Error.Should().Be(Error.Null);
    }
}