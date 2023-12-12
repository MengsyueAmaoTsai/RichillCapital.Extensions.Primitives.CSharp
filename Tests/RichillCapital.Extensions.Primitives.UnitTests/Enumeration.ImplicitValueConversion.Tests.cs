namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationImplicitValueConversionTests
{
    [TestMethod]
    public void ReturnsValueOfGivenEnum()
    {
        var enumeration = TestEnumeration.One;

        int result = enumeration;

        result.Should().Be(enumeration.Value);
    }
}