namespace RichillCapital.Extensions.Primitives.UnitTests.Enumerations;

[TestClass]
public sealed class EnumerationTryFromNameTests
{
    [TestMethod]
    public void Should_ProducesEnum_WhenGivenMatchingName()
    {
        var maybe = TestEnumeration.TryFromName("One");

        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().BeSameAs(TestEnumeration.One);
    }

    [TestMethod]
    public void Should_ProducesNull_GivenEmptyString()
    {
        var maybe = TestEnumeration.TryFromName(string.Empty);

        maybe.HasValue.Should().BeFalse();
    }

    [TestMethod]
    public void Should_ReturnsFalse_WhenGivenNull()
    {
        var maybe = TestEnumeration.TryFromName(null!);

        maybe.HasValue.Should().BeFalse();
    }

    [TestMethod]
    public void Should_ProducesNull_WhenGivenNull()
    {
        var maybe = TestEnumeration.TryFromName(null!);

        maybe.HasValue.Should().BeFalse();
    }
}