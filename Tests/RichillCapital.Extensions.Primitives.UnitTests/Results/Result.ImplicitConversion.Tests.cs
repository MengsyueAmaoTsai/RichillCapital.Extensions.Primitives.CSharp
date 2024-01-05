namespace RichillCapital.Extensions.Primitives.UnitTests.Results;

[TestClass]
public sealed class ResultImplicitConversionTests
{
    [TestMethod]
    public void ImplicitConversionFromError_Should_CreateFailureResult_WithError()
    {
        // Arrange
        var error = Error.WithMessage("Error");

        // Act
        Result<int> result = error;

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().Be(default);
        result.Error.Should().Be(error);
    }

    [TestMethod]
    public void ImplicitConversionFromValue_Should_CreateSuccessResult_WithValue()
    {
        // Arrange & Act
        Result<int> result = 42;

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(42);
        result.Error.Should().Be(Error.Null);
    }
}