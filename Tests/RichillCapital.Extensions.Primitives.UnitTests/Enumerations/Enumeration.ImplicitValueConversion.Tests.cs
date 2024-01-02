namespace RichillCapital.Extensions.Primitives.UnitTests.Enumerations;

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