using FluentAssertions;

using Primitives.RichillCapital.Extensions.Primitives;

namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationFromFromNameTests
{
    [TestMethod]
    public void Should_ReturnsEnum_WhenGivenNoExplicitPriorUse()
    {
        var expected = "One";

        var result = TestEnum.FromName(expected);

        result.Name.Should().Be(expected);
    }

    [TestMethod]
    public void Should_ReturnsEnum_WhenGivenExplicitPriorUse()
    {
        var expected = TestEnum.One.Name;

        var result = TestEnum.FromName(expected);

        result.Name.Should().Be(expected);
    }

    [TestMethod]
    public void Should_ReturnsEnum_WhenGivenMatchingString()
    {
        var matchingString = "One";
        var result = TestEnum.FromName(matchingString);

        result.Should().BeSameAs(TestEnum.One);
    }

    [TestMethod]
    public void Should_ThrowException_WhenGivenEmptyString()
    {
        var action = () => TestEnum.FromName(string.Empty);

        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Argument cannot be null or empty. (Parameter 'name')")
            .Which.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void Should_ThrowException_WhenGivenNull()
    {
        var action = () => TestEnum.FromName(null);
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
        var action = () => TestEnum.FromName(nonMatchingName);
        var exceptionMessage = $@"No {typeof(TestEnum).Name} with name ""{nonMatchingName}"" found.";

        action.Should()
            .ThrowExactly<EnumerationNotFoundException>()
            .WithMessage(exceptionMessage);
    }
}