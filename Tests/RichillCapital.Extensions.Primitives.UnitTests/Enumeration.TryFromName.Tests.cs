using FluentAssertions;

namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationTryFromNameTests
{
    [TestMethod]
    public void Should_ReturnsTrue_WhenGivenMatchingName()
    {
        var result = TestEnum.TryFromName("One", out var _);

        result.Should().BeTrue();
    }

    [TestMethod]
    public void Should_ProducesEnum_WhenGivenMatchingName()
    {
        TestEnum.TryFromName("One", out var enumeration);

        enumeration.Should().BeSameAs(TestEnum.One);
    }

    [TestMethod]
    public void Should_ReturnsFalse_WhenGivenEmptyString()
    {
        var result = TestEnum.TryFromName(string.Empty, out var _);

        result.Should().BeFalse();
    }

    [TestMethod]
    public void Should_ProducesNull_GivenEmptyString()
    {
        TestEnum.TryFromName(string.Empty, out var enumeration);

        enumeration.Should().BeNull();
    }

    [TestMethod]
    public void Should_ReturnsFalse_WhenGivenNull()
    {
        var result = TestEnum.TryFromName(null, out var _);

        result.Should().BeFalse();
    }

    [TestMethod]
    public void Should_ProducesNull_WhenGivenNull()
    {
        TestEnum.TryFromName(null, out var enumeration);

        enumeration.Should().BeNull();
    }
}