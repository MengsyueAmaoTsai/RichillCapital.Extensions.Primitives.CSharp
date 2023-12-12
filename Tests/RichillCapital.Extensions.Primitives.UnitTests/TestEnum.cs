namespace RichillCapital.Extensions.Primitives.UnitTests;

public sealed class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration One = new(nameof(One), 0);
    public static readonly TestEnumeration Two = new(nameof(Two), 1);
    public static readonly TestEnumeration Three = new(nameof(Three), 2);

    private TestEnumeration(string name, int value)
        : base(name, value)
    {
    }
}