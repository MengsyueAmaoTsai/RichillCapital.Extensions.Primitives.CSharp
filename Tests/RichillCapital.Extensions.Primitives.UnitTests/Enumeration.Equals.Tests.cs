namespace RichillCapital.Extensions.Primitives.UnitTests;

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
            new object[] { TestEnum.One, null!, false },
            new object[] { TestEnum.One, TestEnum.One, true },
            new object[] { TestEnum.One, TestEnum2.One, false },
            new object[] { TestEnum.One, TestEnum.Two, false },
        };

    [DataTestMethod]
    [DynamicData(nameof(EqualsObjectData))]
    public void EqualsObjectReturnsExpected(TestEnum left, object right, bool expected)
    {
        var result = left.Equals(right);

        Assert.AreEqual(expected, result);
    }

    public static IEnumerable<object[]> EqualsEnumerationData =>
        new List<object[]>
        {
            new object[] { TestEnum.One, null!, false },
            new object[] { TestEnum.One, TestEnum.One, true },
            new object[] { TestEnum.One, TestEnum.Two, false },
        };

    [DataTestMethod]
    [DynamicData(nameof(EqualsEnumerationData))]
    public void EqualsEnumerationReturnsExpected(TestEnum left, object right, bool expected)
    {
        var result = left.Equals(right);

        Assert.AreEqual(expected, result);
    }

    public static IEnumerable<object[]> EqualOperatorData =>
        new List<object[]>
        {
            new object[] { null!, null!, true },
            new object[] { null!, TestEnum.One, false },
            new object[] { TestEnum.One, null!, false },
            new object[] { TestEnum.One, TestEnum.One, true },
            new object[] { TestEnum.One, TestEnum.Two, false },
        };

    [DataTestMethod]
    [DynamicData(nameof(EqualOperatorData))]
    public void EqualOperatorReturnsExpected(TestEnum left, TestEnum right, bool expected)
    {
        var result = left == right;

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DynamicData(nameof(EqualOperatorData))]
    public void NotEqualOperatorReturnsExpected(TestEnum left, TestEnum right, bool expected)
    {
        var result = left != right;

        Assert.AreEqual(!expected, result);
    }
}
