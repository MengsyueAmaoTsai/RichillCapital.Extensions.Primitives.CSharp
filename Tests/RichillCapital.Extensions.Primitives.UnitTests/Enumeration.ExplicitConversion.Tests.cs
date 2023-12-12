namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationExplicitConversionTests
{
    [TestMethod]
    public void Should_ReturnsEnum_FromGivenValue()
    {
        int value = 1;

        var result = (TestEnum)value;

        result.Should().BeSameAs(TestEnum.Two);
    }

    [TestMethod]
    public void Should_ReturnsEnum_FromGivenNullableValue()
    {
        int? value = 1;

        var result = (TestEnum)value;

        result.Should().BeSameAs(TestEnum.Two);
    }

    [TestMethod]
    public void Should_ReturnsEnum_FromGivenNullableValueAsNull()
    {
        int? value = null;

        var result = (TestEnum?)value;

        result.Should().BeNull();
    }
}