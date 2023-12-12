namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationExplicitConversionTests
{
    [TestMethod]
    public void Should_ReturnsEnum_FromGivenValue()
    {
        int value = 1;

        var result = (TestEnumeration)value;

        result.Should().BeSameAs(TestEnumeration.Two);
    }

    [TestMethod]
    public void Should_ReturnsEnum_FromGivenNullableValue()
    {
        int? value = 1;

        var result = (TestEnumeration)value;

        result.Should().BeSameAs(TestEnumeration.Two);
    }

    [TestMethod]
    public void Should_ReturnsEnum_FromGivenNullableValueAsNull()
    {
        int? value = null;

        var result = (TestEnumeration?)value;

        result.Should().BeNull();
    }
}