namespace RichillCapital.Extensions.Primitives.UnitTests;

[TestClass]
public sealed class EnumerationCompareToTests
{
    [TestMethod]
    public void CompareToReturnsExpected()
    {
        TestCompareTo(TestEnum.Two, TestEnum.One, 1);
        TestCompareTo(TestEnum.Two, TestEnum.Two, 0);
        TestCompareTo(TestEnum.Two, TestEnum.Three, -1);
    }

    [TestMethod]
    public void LessThanReturnsExpected()
    {
        TestComparisonOperators(TestEnum.Two, TestEnum.One, false, false, true);
        TestComparisonOperators(TestEnum.Two, TestEnum.Two, false, true, false);
        TestComparisonOperators(TestEnum.Two, TestEnum.Three, true, false, false);
    }

    [TestMethod]
    public void LessThanOrEqualReturnsExpected()
    {
        TestComparisonOperators(TestEnum.Two, TestEnum.One, false, false, true);
        TestComparisonOperators(TestEnum.Two, TestEnum.Two, false, true, false);
        TestComparisonOperators(TestEnum.Two, TestEnum.Three, true, false, false);
    }

    [TestMethod]
    public void GreaterThanReturnsExpected()
    {
        TestComparisonOperators(TestEnum.Two, TestEnum.One, false, false, true);
        TestComparisonOperators(TestEnum.Two, TestEnum.Two, false, true, false);
        TestComparisonOperators(TestEnum.Two, TestEnum.Three, true, false, false);
    }

    [TestMethod]
    public void GreaterThanOrEqualReturnsExpected()
    {
        TestComparisonOperators(TestEnum.Two, TestEnum.One, false, false, true);
        TestComparisonOperators(TestEnum.Two, TestEnum.Two, false, true, false);
        TestComparisonOperators(TestEnum.Two, TestEnum.Three, true, false, false);
    }

    private static void TestCompareTo(TestEnum left, TestEnum right, int expected)
    {
        var result = left.CompareTo(right);

        result.Should().Be(expected);
    }

    private static void TestComparisonOperators(TestEnum left, TestEnum right, bool lessThan, bool equalTo, bool greaterThan)
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