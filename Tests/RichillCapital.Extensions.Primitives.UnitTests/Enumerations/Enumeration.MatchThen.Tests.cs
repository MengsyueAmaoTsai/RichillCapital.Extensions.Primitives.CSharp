namespace RichillCapital.Extensions.Primitives.UnitTests.Enumerations;

[TestClass]
public sealed class EnumerationMatchThenTests
{
    [TestMethod]
    public void Should_NotCallsDefaultAction_WhenAnyConditionMatched()
    {
        var one = TestEnumeration.One;
        var firstActionCalled = false;
        var defaultActionCalled = false;

        one
            .Match(TestEnumeration.One).Then(() => firstActionCalled = true)
            .Default(() => defaultActionCalled = true);

        firstActionCalled.Should().BeTrue();
        defaultActionCalled.Should().BeFalse();
    }

    [TestMethod]
    public void Should_CallsDefaultAction_WhenNoConditionMatched()
    {
        var three = TestEnumeration.Three;
        var firstActionCalled = false;
        var secondActionCalled = false;
        var defaultActionCalled = false;

        three
            .Match(TestEnumeration.One).Then(() => firstActionCalled = true)
            .Match(TestEnumeration.Two).Then(() => secondActionCalled = true)
            .Default(() => defaultActionCalled = true);

        firstActionCalled.Should().BeFalse();
        secondActionCalled.Should().BeFalse();
        defaultActionCalled.Should().BeTrue();
    }

    [TestMethod]
    public void Should_CallsFirstAction_WhenFirstConditionMatched()
    {
        var one = TestEnumeration.One;
        var firstActionCalled = false;
        var secondActionCalled = false;

        one
            .Match(TestEnumeration.One).Then(() => firstActionCalled = true)
            .Match(TestEnumeration.Two).Then(() => secondActionCalled = true);

        firstActionCalled.Should().BeTrue();
        secondActionCalled.Should().BeFalse();
    }

    [TestMethod]
    public void Should_CalledAction_WhenMatchesLastList()
    {
        var three = TestEnumeration.Three;
        var firstActionCalled = false;
        var secondActionCalled = false;
        var thirdActionCalled = false;

        three
            .Match(TestEnumeration.One).Then(() => firstActionCalled = true)
            .Match(TestEnumeration.Two).Then(() => secondActionCalled = true)
            .Match(new List<TestEnumeration> { TestEnumeration.One, TestEnumeration.Two, TestEnumeration.Three }).Then(() => thirdActionCalled = true);

        firstActionCalled.Should().BeFalse();
        secondActionCalled.Should().BeFalse();
        thirdActionCalled.Should().BeTrue();
    }

    [TestMethod]
    public void Should_CallsAction_WhenMatchesLastParameter()
    {
        var three = TestEnumeration.Three;
        var firstActionCalled = false;
        var secondActionCalled = false;
        var thirdActionCalled = false;

        three
            .Match(TestEnumeration.One).Then(() => firstActionCalled = true)
            .Match(TestEnumeration.Two).Then(() => secondActionCalled = true)
            .Match(TestEnumeration.One, TestEnumeration.Two, TestEnumeration.Three).Then(() => thirdActionCalled = true);

        firstActionCalled.Should().BeFalse();
        secondActionCalled.Should().BeFalse();
        thirdActionCalled.Should().BeTrue();
    }

    [TestMethod]
    public void Should_CallsSecondAction_WhenSecondConditionMatched()
    {
        var two = TestEnumeration.Two;
        var firstActionCalled = false;
        var secondActionCalled = false;

        two
            .Match(TestEnumeration.One).Then(() => firstActionCalled = true)
            .Match(TestEnumeration.Two).Then(() => secondActionCalled = true);

        firstActionCalled.Should().BeFalse();
        secondActionCalled.Should().BeTrue();
    }
}