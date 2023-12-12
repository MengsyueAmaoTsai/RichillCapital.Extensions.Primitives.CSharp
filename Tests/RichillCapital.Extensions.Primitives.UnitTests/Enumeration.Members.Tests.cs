using FluentAssertions;

namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationMembersTests
{
    [TestMethod]
    public void Should_ReturnsAllDefinedEnumerations()
    {
        var result = TestEnumeration.Members;

        result.Should().BeEquivalentTo([TestEnumeration.One, TestEnumeration.Two, TestEnumeration.Three]);
    }
}