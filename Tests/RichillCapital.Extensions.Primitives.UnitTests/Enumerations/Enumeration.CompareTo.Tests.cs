namespace RichillCapital.Extensions.Primitives.UnitTests.Enumerations;

[TestClass]
public sealed class EnumerationCompareToTests
{
    [TestMethod]
    public void CompareToReturnsExpected()
    {
        TestCompareTo(TestEnumeration.Two, TestEnumeration.One, 1);
        TestCompareTo(TestEnumeration.Two, TestEnumeration.Two, 0);
        TestCompareTo(TestEnumeration.Two, TestEnumeration.Three, -1);
    }

    [TestMethod]
    public void LessThanReturnsExpected()
    {
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.One, false, false, true);
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.Two, false, true, false);
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.Three, true, false, false);
    }

    [TestMethod]
    public void LessThanOrEqualReturnsExpected()
    {
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.One, false, false, true);
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.Two, false, true, false);
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.Three, true, false, false);
    }

    [TestMethod]
    public void GreaterThanReturnsExpected()
    {
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.One, false, false, true);
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.Two, false, true, false);
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.Three, true, false, false);
    }

    [TestMethod]
    public void GreaterThanOrEqualReturnsExpected()
    {
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.One, false, false, true);
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.Two, false, true, false);
        TestComparisonOperators(TestEnumeration.Two, TestEnumeration.Three, true, false, false);
    }

    private static void TestCompareTo(TestEnumeration left, TestEnumeration right, int expected)
    {
        var result = left.CompareTo(right);

        result.Should().Be(expected);
    }

    private static void TestComparisonOperators(TestEnumeration left, TestEnumeration right, bool lessThan, bool equalTo, bool greaterThan)
    {
        var lessThanResult = left < right;
        var lessThanOrEqualResult = left <= right;
        var greaterThanResult = left > right;
        var greaterThanOrEqualResult = left >= right;

        lessThanResult.Should().Be(lessThan);
        lessThanOrEqualResult.Should().Be(lessThan || equalTo);
        greaterThanResult.Should().Be(greaterThan);
        greaterThanOrEqualResult.Should().Be(greaterThan || equalTo);
    }
}