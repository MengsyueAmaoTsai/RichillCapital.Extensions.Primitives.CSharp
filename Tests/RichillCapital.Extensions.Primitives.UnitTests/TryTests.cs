namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class TryTests
{
    [TestMethod]
    public void Success_Should_CreateTry_WithIntValue()
    {
        // Arrange
        var value = 42;

        // Act
        var result = Try<int>.Success(value);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(42);
        Action action = () => _ = result.Error;
        action
            .Should().Throw<InvalidOperationException>()
            .WithMessage("The Try<T> operation was successful.");
    }

    [TestMethod]
    public void Failure_Should_CreateTry_WithErrorMessage()
    {
        // Arrange
        var error = Error.WithMessage("Operation failed");

        // Act
        var result = Try<int>.Failure(error);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(error);
        Action action = () => _ = result.Value;
        action.Should()
            .Throw<InvalidOperationException>()
            .WithMessage("The Try<T> operation was not successful.");
    }
}