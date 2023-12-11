using FluentAssertions;

namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationTests
{
    [TestMethod]
    public void Should_NotCallsDefaultAction_WhenAnyConditionMatched()
    {
        var one = TestEnum.One;
        var firstActionCalled = false;
        var defaultActionCalled = false;

        one
            .Match(TestEnum.One).Then(() => firstActionCalled = true)
            .Default(() => defaultActionCalled = true);

        firstActionCalled.Should().BeTrue();
        defaultActionCalled.Should().BeFalse();
    }
}