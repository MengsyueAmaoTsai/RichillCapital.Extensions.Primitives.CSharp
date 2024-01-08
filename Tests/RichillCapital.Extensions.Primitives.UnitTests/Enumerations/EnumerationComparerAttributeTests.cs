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
        // Act
        var maybe = VanillaStringEnum.FromValue("ONE");

        // Assert
        maybe.HasValue.Should().BeFalse();
    }

    [TestMethod]
    public void ReturnsItem_CaseInsensitiveEnum_FromValue_WhenStringDoesNotMatchCase()
    {
        // Act
        var maybe = CaseInsensitiveEnum.FromValue("ONE");

        // Assert
        maybe.Value.Should().Be(CaseInsensitiveEnum.One);
    }

    [TestMethod]
    public void Should_ThrowsException_CaseSensitiveEnum_FromValue_WhenStringDoesNotMatchCase()
    {
        // Act
        var maybe = CaseSensitiveEnum.FromValue("ONE");

        // Assert
        maybe.HasValue.Should().BeFalse();
    }

    [TestMethod]
    public void Should_ReturnsItem_VanillaStringEnum_FromValue_WhenStringMatchesCase()
    {
        var maybe = VanillaStringEnum.FromValue("one");

        maybe.Value.Should().Be(VanillaStringEnum.One);
    }

    [TestMethod]
    public void Should_ReturnsItem_CaseInsensitiveEnum_FromValue_WhenStringMatchesCase()
    {
        var maybe = CaseInsensitiveEnum.FromValue("one");

        maybe.Value.Should().Be(CaseInsensitiveEnum.One);
    }

    [TestMethod]
    public void Should_ReturnsItem_CaseSensitiveEnum_FromValue_WhenStringMatchesCase()
    {
        var maybe = CaseSensitiveEnum.FromValue("one");

        maybe.Value.Should().Be(CaseSensitiveEnum.One);
    }
}