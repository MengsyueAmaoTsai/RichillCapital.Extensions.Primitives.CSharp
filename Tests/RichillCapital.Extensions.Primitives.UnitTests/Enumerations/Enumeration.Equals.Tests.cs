namespace RichillCapital.Extensions.Primitives.UnitTests.Enumerations;

[TestClass]
public sealed class EnumerationEqualsTests
{
    private class TestEnum2 : Enumeration<TestEnum2, int>
    {
        public static readonly TestEnum2 One = new(nameof(One), 1);

        protected TestEnum2(string name, int value)
            : base(name, value)
        {
        }
    }

    public static IEnumerable<object[]> EqualsObjectData =>
        new List<object[]>
        {
            new object[] { TestEnumeration.One, null!, false },
            new object[] { TestEnumeration.One, TestEnumeration.One, true },
            new object[] { TestEnumeration.One, TestEnum2.One, false },
            new object[] { TestEnumeration.One, TestEnumeration.Two, false },
        };

    [DataTestMethod]
    [DynamicData(nameof(EqualsObjectData))]
    public void EqualsObjectReturnsExpected(TestEnumeration left, object right, bool expected)
    {
        var result = left.Equals(right);

        Assert.AreEqual(expected, result);
    }

    public static IEnumerable<object[]> EqualsEnumerationData =>
        new List<object[]>
        {
            new object[] { TestEnumeration.One, null!, false },
            new object[] { TestEnumeration.One, TestEnumeration.One, true },
            new object[] { TestEnumeration.One, TestEnumeration.Two, false },
        };

    [DataTestMethod]
    [DynamicData(nameof(EqualsEnumerationData))]
    public void EqualsEnumerationReturnsExpected(TestEnumeration left, object right, bool expected)
    {
        var result = left.Equals(right);

        Assert.AreEqual(expected, result);
    }

    public static IEnumerable<object[]> EqualOperatorData =>
        new List<object[]>
        {
            new object[] { null!, null!, true },
            new object[] { null!, TestEnumeration.One, false },
            new object[] { TestEnumeration.One, null!, false },
            new object[] { TestEnumeration.One, TestEnumeration.One, true },
            new object[] { TestEnumeration.One, TestEnumeration.Two, false },
        };

    [DataTestMethod]
    [DynamicData(nameof(EqualOperatorData))]
    public void EqualOperatorReturnsExpected(TestEnumeration left, TestEnumeration right, bool expected)
    {
        var result = left == right;

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DynamicData(nameof(EqualOperatorData))]
    public void NotEqualOperatorReturnsExpected(TestEnumeration left, TestEnumeration right, bool expected)
    {
        var result = left != right;

        Assert.AreEqual(!expected, result);
    }
}