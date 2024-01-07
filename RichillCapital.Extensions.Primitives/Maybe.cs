namespace RichillCapital.Extensions.Primitives;

public struct Maybe<TValue>
{
    public static readonly Maybe<TValue> NoValue = new();

    private Maybe(TValue value)
    {
        Value = value;
        HasValue = true;
    }

    public bool HasValue { get; private init; }

    public readonly TValue Value { get; private init; }

    public static Maybe<TValue> WithValue(TValue value) => new(value);
}