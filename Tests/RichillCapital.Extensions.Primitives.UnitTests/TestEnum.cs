namespace RichillCapital.Extensions.Primitives.UnitTests;

internal sealed class TestEnum : Enumeration<TestEnum>
{
    public static readonly TestEnum One = new(nameof(One), 0);
    public static readonly TestEnum Two = new(nameof(Two), 1);
    public static readonly TestEnum Three = new(nameof(Three), 2);

    public TestEnum(string name, int value)
        : base(name, value)
    {
    }
}