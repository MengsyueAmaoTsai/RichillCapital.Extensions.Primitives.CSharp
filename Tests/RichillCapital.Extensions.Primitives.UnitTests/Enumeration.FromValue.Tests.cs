using Primitives.RichillCapital.Extensions.Primitives;

namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationFromValueTests
{
    [TestMethod]
    public void ReturnsEnumGivenMatchingValue()
    {
        var result = TestEnum.FromValue(0);

        result.Should().BeSameAs(TestEnum.One);
    }

    [TestMethod]
    public void Should_ThrowsException_GivenNonMatchingValue()
    {
        var nonMatchingValue = -1;
        string errorMessage = $"No {typeof(TestEnum).Name} with Value {nonMatchingValue} found.";
        var action = () => TestEnum.FromValue(nonMatchingValue);

        action.Should()
            .ThrowExactly<EnumerationNotFoundException>()
            .WithMessage(errorMessage);
    }

    [TestMethod]
    public void Should_ReturnsDefaultEnum_WhenGivenNonMatchingValue()
    {
        var value = -1;
        var defaultEnum = TestEnum.One;

        var result = TestEnum.FromValue(value, defaultEnum);

        result.Should().BeSameAs(defaultEnum);
    }
}