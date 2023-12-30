namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class MaybeTests
{
    [TestMethod]
    public void HasValue_Should_ReturnTrue_WhenValueIsSet()
    {
        // Act
        var maybe = Maybe.WithValue("Hello");

        // Assert
        maybe.HasValue.Should().BeTrue();
        maybe.HasNoValue.Should().BeFalse();
    }

    [TestMethod]
    public void HasNoValue_Should_ReturnTrue_WhenValueIsNotSet()
    {
        // Act
        var maybe = Maybe<string>.Null;

        // Assert
        maybe.HasNoValue.Should().BeTrue();
        maybe.HasValue.Should().BeFalse();
    }

    [TestMethod]
    public void Value_Should_ReturnValue_WhenValueIsSet()
    {
        // Act
        var maybeString = Maybe.WithValue("Hello");
        var maybeInt = Maybe.WithValue(123);
        var maybeDouble = Maybe.WithValue(12.55);

        // Assert
        maybeString.Value.Should().Be("Hello");
        maybeInt.Value.Should().Be(123);
        maybeDouble.Value.Should().Be(12.55);
    }

    [TestMethod]
    public void Value_Should_ThrowException_WhenValueIsNotSet()
    {
        // Arrange
        var maybe = Maybe<string>.Null;

        // Act
        var action = () => _ = maybe.Value;

        // Assert
        action.Should()
            .ThrowExactly<InvalidOperationException>()
            .WithMessage("The value can not be accessed because it does not exist.");
    }

    [TestMethod]
    public void Null_Should_HasNoValue()
    {
        // Assert
        Maybe<string>.Null.HasNoValue.Should().BeTrue();
    }

    [TestMethod]
    public void WithValue_Should_CreateMaybeWithSpecifiedValue()
    {
        // Arrange
        var expectedValue = "Hello";

        // Act
        var maybe = Maybe.WithValue(expectedValue);

        // Assert
        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(expectedValue);
    }

    [TestMethod]
    public void Equals_Should_ReturnTrue_When_ValuesAreEqual()
    {
        // Arrange
        var maybe1 = Maybe.WithValue("Hello");
        var maybe2 = Maybe.WithValue("Hello");

        // Act
        var areEqual = maybe1.Equals(maybe2);

        // Assert
        areEqual.Should().BeTrue();
    }

    [TestMethod]
    public void Equals_Should_ReturnFalse_When_ValuesAreNotEqual()
    {
        // Arrange
        var maybe1 = Maybe.WithValue("Hello");
        var maybe2 = Maybe.WithValue("World");

        // Act
        var areEqual = maybe1.Equals(maybe2);

        // Assert
        areEqual.Should().BeFalse();
    }
}