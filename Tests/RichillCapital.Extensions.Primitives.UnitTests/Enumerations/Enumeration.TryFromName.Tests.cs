namespace RichillCapital.Extensions.Primitives.UnitTests.Enumerations;

[TestClass]
public sealed class EnumerationTryFromNameTests
{
    [TestMethod]
    public void Should_ReturnsTrue_WhenGivenMatchingName()
    {
        var result = TestEnumeration.TryFromName("One", out var _);

        result.Should().BeTrue();
    }

    [TestMethod]
    public void Should_ProducesEnum_WhenGivenMatchingName()
    {
        TestEnumeration.TryFromName("One", out var enumeration);

        enumeration.Should().BeSameAs(TestEnumeration.One);
    }

    [TestMethod]
    public void Should_ReturnsFalse_WhenGivenEmptyString()
    {
        var result = TestEnumeration.TryFromName(string.Empty, out var _);

        result.Should().BeFalse();
    }

    [TestMethod]
    public void Should_ProducesNull_GivenEmptyString()
    {
        TestEnumeration.TryFromName(string.Empty, out var enumeration);

        enumeration.Should().BeNull();
    }

    [TestMethod]
    public void Should_ReturnsFalse_WhenGivenNull()
    {
        var result = TestEnumeration.TryFromName(null!, out var _);

        result.Should().BeFalse();
    }

    [TestMethod]
    public void Should_ProducesNull_WhenGivenNull()
    {
        TestEnumeration.TryFromName(null!, out var enumeration);

        enumeration.Should().BeNull();
    }
}