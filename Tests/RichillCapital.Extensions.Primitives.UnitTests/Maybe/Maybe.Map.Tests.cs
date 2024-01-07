namespace RichillCapital.Extensions.Primitives.UnitTests.Maybe;

[TestClass]
public sealed class MaybeMapTests
{
    [TestMethod]
    public void When_MaybeHasValue_Should_ReturnMappedValue()
    {
        // Arrange
        var sourceValue = 42;
        var maybe = Maybe<int>.WithValue(sourceValue);

        // Act
        var result = maybe.Map(value => value * 2);

        // Assert
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be(84);
    }

    [TestMethod]
    public void Map_Should_ReturnOriginalError_When_ResultIsFailure()
    {
        // Arrange
        var failureResult = Maybe<int>.NoValue;

        // Act
        var maybe = failureResult.Map(value => value * 2);

        // Assert
        maybe.HasValue.Should().BeFalse();
    }
}
