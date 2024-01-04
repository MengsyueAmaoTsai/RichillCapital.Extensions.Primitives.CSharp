namespace RichillCapital.Extensions.Primitives;

public struct Maybe<TValue>
{
    public static readonly Maybe<TValue> NoValue = new();

    private readonly TValue _value;

    private Maybe(TValue value)
    {
        _value = value;
        HasValue = true;
    }

    public bool HasValue { get; private init; }

    public readonly TValue Value => HasValue ?
        _value :
        throw new InvalidOperationException("The Maybe<T> instance has no value.");

    public static Maybe<TValue> WithValue(TValue value) => new(value);
}