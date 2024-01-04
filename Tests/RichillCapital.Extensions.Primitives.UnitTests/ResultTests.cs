namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class ResultTests
{
    [TestMethod]
    public void Success_Should_CreateSuccessResult_WithNumericVale()
    {
        var value = 42;

        var result = Result<int>.Success(value);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(42);
        result.Error.Should().Be(Error.Default);
    }

    [TestMethod]
    public void Failure_Should_CreateFailureResult_WithIntError()
    {
        var error = new Error("Error");

        var result = Result<int>.Failure(error);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().Be(default);
        result.Error.Should().Be(error);
    }

    [TestMethod]
    public void Success_Should_CreateSuccessResult_WithStringValue()
    {
        var value = "Test";

        var result = Result<string>.Success(value);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("Test");
        result.Error.Should().Be(Error.Default);
    }

    [TestMethod]
    public void Failure_Should_CreateFailureResult_WithStringError()
    {
        var error = new Error("Error");

        var result = Result<string>.Failure(error);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().Be(default);
        result.Error.Should().Be(error);
    }

    [TestMethod]
    public void Success_Should_CreateSuccessResult_WithBoolValue()
    {
        var value = true;

        var result = Result<bool>.Success(value);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeTrue();
        result.Error.Should().Be(Error.Default);
    }

    [TestMethod]
    public void Failure_Should_CreateFailureResult_WithBoolError()
    {
        var error = new Error("Error");

        var result = Result<bool>.Failure(error);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().Be(default);
        result.Error.Should().Be(error);
    }

    [TestMethod]
    public void Success_Should_CreateSuccessResult_WithDateTimeOffsetValue()
    {
        var value = DateTimeOffset.Now;

        var result = Result<DateTimeOffset>.Success(value);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(value);
        result.Error.Should().Be(Error.Default);
    }

    [TestMethod]
    public void Failure_Should_CreateFailureResult_WithDateTimeOffsetError()
    {
        var error = new Error("Error");

        var result = Result<DateTimeOffset>.Failure(error);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().Be(default);
        result.Error.Should().Be(error);
    }

    private sealed class TestClass
    {
    }

    [TestMethod]
    public void Success_Should_CreateSuccessResult_WithTestClass()
    {
        var value = new TestClass();

        var result = Result<TestClass>.Success(value);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(value);
        result.Error.Should().Be(Error.Default);
    }

    [TestMethod]
    public void Failure_Should_CreateFailureResult_WithTestClass()
    {
        var error = new Error("Error");

        var result = Result<TestClass>.Failure(error);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().Be(default);
        result.Error.Should().Be(error);
    }

    [TestMethod]
    public void Success_Should_CreateSuccessResult_WithNoError()
    {
        // Arrange & Act
        var result = Result.Success();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().Be(Error.Default);
    }

    [TestMethod]
    public void Failure_Should_CreateFailureResult_WithError()
    {
        // Arrange
        var error = new Error("Error");

        // Act
        var result = Result.Failure(error);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(error);
    }

    [TestMethod]
    public void ImplicitConversionFromError_Should_CreateFailureResult_WithError()
    {
        // Arrange
        var error = new Error("Error");

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
        result.Error.Should().Be(Error.Default);
    }
}