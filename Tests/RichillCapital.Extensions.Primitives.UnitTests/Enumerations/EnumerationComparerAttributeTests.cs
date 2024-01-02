namespace RichillCapital.Extensions.Primitives.UnitTests.Enumerations;

[TestClass]
public class EnumerationComparerAttributeTests
{
    internal class VanillaStringEnum : Enumeration<VanillaStringEnum, string>
    {
        protected VanillaStringEnum(string name, string value)
            : base(name, value)
        {
        }

        public static readonly VanillaStringEnum One = new("One", "one");
        public static readonly VanillaStringEnum Two = new("Two", "two");
    }

    [EnumerationStringComparer(StringComparison.InvariantCultureIgnoreCase)]
    internal class CaseInsensitiveEnum : Enumeration<CaseInsensitiveEnum, string>
    {
        protected CaseInsensitiveEnum(string name, string value)
            : base(name, value)
        {
        }

        public static readonly CaseInsensitiveEnum One = new("One", "one");
        public static readonly CaseInsensitiveEnum Two = new("Two", "two");
    }

    [EnumerationStringComparer(StringComparison.InvariantCulture)]
    internal class CaseSensitiveEnum : Enumeration<CaseSensitiveEnum, string>
    {
        protected CaseSensitiveEnum(string name, string value)
            : base(name, value)
        {
        }

        public static readonly CaseSensitiveEnum One = new("One", "one");
        public static readonly CaseSensitiveEnum Two = new("Two", "two");
    }

    [TestMethod]
    public void Should_ThrowsException_VanillaStringEnum_FromValue_WhenStringDoesNotMatchCase()
    {
        var action = () =>
        {
            var actual = VanillaStringEnum.FromValue("ONE");
        };

        action.Should()
            .ThrowExactly<EnumerationNotFoundException>();
    }

    [TestMethod]
    public void ReturnsItem_CaseInsensitiveEnum_FromValue_WhenStringDoesNotMatchCase()
    {
        var actual = CaseInsensitiveEnum.FromValue("ONE");

        actual.Should().Be(CaseInsensitiveEnum.One);
    }

    [TestMethod]
    public void Should_ThrowsException_CaseSensitiveEnum_FromValue_WhenStringDoesNotMatchCase()
    {
        var action = () =>
        {
            var actual = CaseSensitiveEnum.FromValue("ONE");
        };

        action.Should()
            .ThrowExactly<EnumerationNotFoundException>();
    }

    [TestMethod]
    public void Should_ReturnsItem_VanillaStringEnum_FromValue_WhenStringMatchesCase()
    {
        var actual = VanillaStringEnum.FromValue("one");

        actual.Should().Be(VanillaStringEnum.One);
    }

    [TestMethod]
    public void Should_ReturnsItem_CaseInsensitiveEnum_FromValue_WhenStringMatchesCase()
    {
        var actual = CaseInsensitiveEnum.FromValue("one");

        actual.Should().Be(CaseInsensitiveEnum.One);
    }

    [TestMethod]
    public void Should_ReturnsItem_CaseSensitiveEnum_FromValue_WhenStringMatchesCase()
    {
        var actual = CaseSensitiveEnum.FromValue("one");

        actual.Should().Be(CaseSensitiveEnum.One);
    }
}