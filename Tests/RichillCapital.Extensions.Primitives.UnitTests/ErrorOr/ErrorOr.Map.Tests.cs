namespace RichillCapital.Extensions.Primitives.UnitTests.ErrorOr;

[TestClass]
public sealed class ErrorOrMapTests
{
    [TestMethod]
    public void When_HasNoError_Should_ReturnMappedError()
    {
        // Arrange
        var sourceValue = 42;
        var sourceResult = ErrorOr<int>.WithValue(sourceValue);

        // Act
        var result = sourceResult.Map(value => value * 2);

        // Assert
        result.HasError.Should().BeFalse();
        result.Value.Should().Be(84);
        result.Error.Should().Be(Error.Null);
    }

    [TestMethod]
    public void Map_Should_ReturnOriginalError_When_ResultIsFailure()
    {
        // Arrange
        var error = Error.WithMessage("Some error");
        var failureResult = ErrorOr<int>.WithError(error);

        // Act
        var result = failureResult.Map(value => value * 2);

        // Assert
        result.HasError.Should().BeTrue();
        result.Value.Should().Be(default);
        result.Error.Should().Be(error);
    }
}