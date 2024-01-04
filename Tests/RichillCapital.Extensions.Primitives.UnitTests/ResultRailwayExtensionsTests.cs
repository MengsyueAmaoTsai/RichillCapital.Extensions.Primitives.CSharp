namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class ResultRailwayExtensionsTests
{
    [TestMethod]
    public void Map_Should_ReturnMappedResult_When_ResultIsSuccess()
    {
        // Arrange
        var sourceValue = 42;
        var sourceResult = Result<int>.Success(sourceValue);

        // Act
        var result = sourceResult.Map(value => value * 2);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(84);
        result.Error.Should().Be(Error.Null);
    }

    [TestMethod]
    public void Map_Should_ReturnOriginalError_When_ResultIsFailure()
    {
        // Arrange
        var error = Error.WithMessage("Some error");
        var failureResult = Result<int>.Failure(error);

        // Act
        var result = failureResult.Map(value => value * 2);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().Be(default);
        result.Error.Should().Be(error);
    }
}
