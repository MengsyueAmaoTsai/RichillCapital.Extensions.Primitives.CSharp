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

    [TestMethod]
    public void Should_CallsDefaultAction_WhenNoConditionMatched()
    {
        var three = TestEnum.Three;
        var firstActionCalled = false;
        var secondActionCalled = false;
        var defaultActionCalled = false;

        three
            .Match(TestEnum.One).Then(() => firstActionCalled = true)
            .Match(TestEnum.Two).Then(() => secondActionCalled = true)
            .Default(() => defaultActionCalled = true);

        firstActionCalled.Should().BeFalse();
        secondActionCalled.Should().BeFalse();
        defaultActionCalled.Should().BeTrue();
    }

    [TestMethod]
    public void Should_CallsFirstAction_WhenFirstConditionMatched()
    {
        var one = TestEnum.One;
        var firstActionCalled = false;
        var secondActionCalled = false;

        one
            .Match(TestEnum.One).Then(() => firstActionCalled = true)
            .Match(TestEnum.Two).Then(() => secondActionCalled = true);

        firstActionCalled.Should().BeTrue();
        secondActionCalled.Should().BeFalse();
    }

    [TestMethod]
    public void Should_CalledAction_WhenMatchesLastList()
    {
        var three = TestEnum.Three;
        var firstActionCalled = false;
        var secondActionCalled = false;
        var thirdActionCalled = false;

        three
            .Match(TestEnum.One).Then(() => firstActionCalled = true)
            .Match(TestEnum.Two).Then(() => secondActionCalled = true)
            .Match(new List<TestEnum> { TestEnum.One, TestEnum.Two, TestEnum.Three }).Then(() => thirdActionCalled = true);

        firstActionCalled.Should().BeFalse();
        secondActionCalled.Should().BeFalse();
        thirdActionCalled.Should().BeTrue();
    }

    [TestMethod]
    public void Should_CallsAction_WhenMatchesLastParameter()
    {
        var three = TestEnum.Three;
        var firstActionCalled = false;
        var secondActionCalled = false;
        var thirdActionCalled = false;

        three
            .Match(TestEnum.One).Then(() => firstActionCalled = true)
            .Match(TestEnum.Two).Then(() => secondActionCalled = true)
            .Match(TestEnum.One, TestEnum.Two, TestEnum.Three).Then(() => thirdActionCalled = true);

        firstActionCalled.Should().BeFalse();
        secondActionCalled.Should().BeFalse();
        thirdActionCalled.Should().BeTrue();
    }
}