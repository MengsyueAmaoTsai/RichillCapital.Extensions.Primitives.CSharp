namespace RichillCapital.Extensions.Primitives.UnitTests.Enumerations;

[TestClass]
public sealed class EnumerationFromFromNameTests
{
    [TestMethod]
    public void Should_ReturnsEnum_WhenGivenNoExplicitPriorUse()
    {
        var expected = "One";

        var result = TestEnumeration.FromName(expected);

        result.Value.Name.Should().Be(expected);
    }

    [TestMethod]
    public void Should_ReturnsEnum_WhenGivenExplicitPriorUse()
    {
        var expected = TestEnumeration.One.Name;

        var result = TestEnumeration.FromName(expected);

        result.Value.Name.Should().Be(expected);
    }

    [TestMethod]
    public void Should_ReturnsEnum_WhenGivenMatchingString()
    {
        var matchingString = "One";
        var result = TestEnumeration.FromName(matchingString);

        result.Value.Should().BeSameAs(TestEnumeration.One);
    }

    [TestMethod]
    public void Should_ReturnFailureResult_WhenGivenEmptyString()
    {
        var result = TestEnumeration.FromName(string.Empty);

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBe(Error.Default);
    }

    [TestMethod]
    public void Should_ReturnFailureResult_WhenGivenNull()
    {
        var result = TestEnumeration.FromName(null!);

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBe(Error.Default);
    }

    [TestMethod]
    public void Should_ReturnFailureResult_WhenGivenNonMatchingString()
    {
        var nonMatchingName = "nonMatchingName";
        var result = TestEnumeration.FromName(nonMatchingName);

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBe(Error.Default);
    }
}