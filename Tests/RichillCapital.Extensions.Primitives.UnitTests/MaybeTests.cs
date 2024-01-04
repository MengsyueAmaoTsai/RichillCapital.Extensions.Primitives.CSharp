namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class MaybeTests
{
    [TestMethod]
    public void Some_Should_CreateMaybe_WithIntValue()
    {
        // Arrange
        var value = 42;

        // Act
        var maybe = Maybe<int>.Some(value);

        // Assert
        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(42);
    }

    [TestMethod]
    public void None_Should_CreateEmptyMaybe()
    {
        // Act
        var maybe = Maybe<int>.None();

        // Assert
        maybe.HasValue.Should().BeFalse();
        Action action = () => _ = maybe.Value;
        action
            .Should().Throw<InvalidOperationException>("The Maybe<T> instance has no value.")
            .WithMessage("The Maybe<T> instance has no value.");
    }
}