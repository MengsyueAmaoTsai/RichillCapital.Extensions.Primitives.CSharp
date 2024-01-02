namespace RichillCapital.Extensions.Primitives.UnitTests.Enumerations;

[TestClass]
public sealed class EnumerationFromFromNameTests
{
    [TestMethod]
    public void Should_ReturnsEnum_WhenGivenNoExplicitPriorUse()
    {
        var expected = "One";

        var result = TestEnumeration.FromName(expected);

        result.Name.Should().Be(expected);
    }

    [TestMethod]
    public void Should_ReturnsEnum_WhenGivenExplicitPriorUse()
    {
        var expected = TestEnumeration.One.Name;

        var result = TestEnumeration.FromName(expected);

        result.Name.Should().Be(expected);
    }

    [TestMethod]
    public void Should_ReturnsEnum_WhenGivenMatchingString()
    {
        var matchingString = "One";
        var result = TestEnumeration.FromName(matchingString);

        result.Should().BeSameAs(TestEnumeration.One);
    }

    [TestMethod]
    public void Should_ThrowException_WhenGivenEmptyString()
    {
        var action = () => TestEnumeration.FromName(string.Empty);

        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Argument cannot be null or empty. (Parameter 'name')")
            .Which.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void Should_ThrowException_WhenGivenNull()
    {
        var action = () => TestEnumeration.FromName(null!);
        var exceptionMessage = $"Argument cannot be null or empty. (Parameter 'name')";

        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage(exceptionMessage)
            .Which.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void Should_ThrowException_WhenGivenNonMatchingString()
    {
        var nonMatchingName = "nonMatchingName";
        var action = () => TestEnumeration.FromName(nonMatchingName);
        var exceptionMessage = $@"No {typeof(TestEnumeration).Name} with name ""{nonMatchingName}"" found.";

        action.Should()
            .ThrowExactly<EnumerationNotFoundException>()
            .WithMessage(exceptionMessage);
    }
}