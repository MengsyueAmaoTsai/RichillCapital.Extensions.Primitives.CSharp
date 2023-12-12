using FluentAssertions;

namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationFromValueTests
{
    [TestMethod]
    public void Should_ReturnsEnum_WhenGivenMatchingValue()
    {
        var result = TestEnum.FromValue(1);

        result.Should().BeSameAs(TestEnum.One);
    }
}