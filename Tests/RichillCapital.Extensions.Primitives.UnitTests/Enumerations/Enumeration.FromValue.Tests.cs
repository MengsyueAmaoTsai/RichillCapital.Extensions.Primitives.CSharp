namespace RichillCapital.Extensions.Primitives.UnitTests.Enumerations;

[TestClass]
public sealed class EnumerationFromValueTests
{
    [TestMethod]
    public void ReturnsEnumGivenMatchingValue()
    {
        // Act
        var maybe = TestEnumeration.FromValue(0);

        // Assert
        maybe.Value.Should().BeSameAs(TestEnumeration.One);
    }

    [TestMethod]
    public void When_NonMatchingValue_Should_ReturnNoValue()
    {
        var nonMatchingValue = -1;
        var maybe = TestEnumeration.FromValue(nonMatchingValue);

        // Assert
        maybe.HasValue.Should().BeFalse();
    }

    [TestMethod]
    public void Should_ReturnsDefaultEnum_WhenGivenNonMatchingValue()
    {
        var value = -1;
        var defaultEnum = TestEnumeration.One;

        var result = TestEnumeration.FromValue(value, defaultEnum);

        result.Value.Should().BeSameAs(defaultEnum);
    }
}