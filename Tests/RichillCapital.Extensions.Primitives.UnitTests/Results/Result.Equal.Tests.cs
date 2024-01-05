namespace RichillCapital.Extensions.Primitives.UnitTests.Results;

[TestClass]
public sealed class ResultEqualTests
{
    [TestMethod]
    public void FailureResult_WithException_Should_EqualFailureResult_WithError()
    {
        var message = "Exception";
        var result = Result<int>.Failure(new Exception(message));
        var result2 = Result<int>.Failure(Error.WithMessage(message));

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(result2.Error);
    }
}