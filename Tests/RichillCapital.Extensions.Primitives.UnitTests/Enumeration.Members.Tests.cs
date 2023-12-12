using FluentAssertions;

namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationMembersTests
{
    [TestMethod]
    public void Should_ReturnsAllDefinedEnumerations()
    {
        var result = TestEnum.Members;

        result.Should().BeEquivalentTo([TestEnum.One, TestEnum.Two, TestEnum.Three]);
    }
}