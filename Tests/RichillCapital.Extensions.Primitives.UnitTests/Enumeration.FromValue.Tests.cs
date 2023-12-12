using Primitives.RichillCapital.Extensions.Primitives;

namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationFromValueTests
{
    [TestMethod]
    public void ReturnsEnumGivenMatchingValue()
    {
        var result = TestEnumeration.FromValue(0);

        result.Should().BeSameAs(TestEnumeration.One);
    }

    [TestMethod]
    public void Should_ThrowsException_GivenNonMatchingValue()
    {
        var nonMatchingValue = -1;
        string errorMessage = $"No {typeof(TestEnumeration).Name} with Value {nonMatchingValue} found.";
        var action = () => TestEnumeration.FromValue(nonMatchingValue);

        action.Should()
            .ThrowExactly<EnumerationNotFoundException>()
            .WithMessage(errorMessage);
    }

    [TestMethod]
    public void Should_ReturnsDefaultEnum_WhenGivenNonMatchingValue()
    {
        var value = -1;
        var defaultEnum = TestEnumeration.One;

        var result = TestEnumeration.FromValue(value, defaultEnum);

        result.Should().BeSameAs(defaultEnum);
    }
}