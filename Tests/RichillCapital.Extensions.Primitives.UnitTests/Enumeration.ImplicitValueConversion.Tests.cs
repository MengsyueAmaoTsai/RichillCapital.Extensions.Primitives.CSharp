namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationImplicitValueConversionTests
{
    [TestMethod]
    public void ReturnsValueOfGivenEnum()
    {
        var enumeration = TestEnum.One;

        int result = enumeration;

        result.Should().Be(enumeration.Value);
    }
}