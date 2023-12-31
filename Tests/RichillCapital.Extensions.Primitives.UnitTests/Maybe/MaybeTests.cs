namespace RichillCapital.Extensions.Primitives.UnitTests.Maybe;

[TestClass]
public sealed class MaybeTests
{
    [TestMethod]
    public void Some_Should_CreateMaybe_WithIntValue()
    {
        // Arrange
        var value = 42;

        // Act
        var maybe = Maybe<int>.WithValue(value);

        // Assert
        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(42);
    }

    [TestMethod]
    public void None_Should_CreateEmptyMaybe()
    {
        // Act
        var maybe = Maybe<int>.NoValue;

        // Assert
        maybe.HasValue.Should().BeFalse();
    }
}