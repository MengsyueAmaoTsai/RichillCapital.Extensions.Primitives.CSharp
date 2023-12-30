namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class ResultWithValueTests
{
    [TestMethod]
    public void Success_Should_ReturnSuccessResultWithValidValue()
    {
        // Act
        var intResult = Result.Success<int>(default);

        // Assert
        intResult.IsFailure.Should().BeFalse();
        intResult.IsSuccess.Should().BeTrue();
        intResult.Error.Should().Be(Error.Null);
        intResult.Value.Should().Be(0);
        intResult.ValueOrDefault.Should().Be(0);
    }

    [TestMethod]
    public void Failure_Should_ReturnFailureResult()
    {
        // Arrange
        var error = Error.WithMessage("Error message");

        // Act
        var intResult = Result.Failure<int>(error);

        // Assert
        intResult.IsFailure.Should().BeTrue();
        intResult.ValueOrDefault.Should().Be(0);
    }

    [TestMethod]
    public void ValueOrDefault_ShouldReturnFailureResultWithDateTime()
    {
        // Act
        var result = Result.Failure<DateTime>(Error.WithMessage("Error message"));

        // Assert
        result.ValueOrDefault.Should().Be(default);
    }

    private class TestValue
    {
    }

    [TestMethod]
    public void ValueOrDefault_ShouldReturnFailedResult()
    {
        // Act
        var result = Result.Failure<TestValue>(Error.WithMessage("ErrorMessage"));

        // Assert
        result.ValueOrDefault.Should().BeNull();
    }

    [TestMethod]
    public void Value_Should_ThrowExceptionInFailureResult()
    {
        // Act
        var result = Result.Failure<int>(Error.WithMessage("Error message"));
        var action = () => _ = result.Value;

        // Assert
        action
            .Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("Result is in status failed. Value is not set. Having: Error with Message='Error message'");
    }
}