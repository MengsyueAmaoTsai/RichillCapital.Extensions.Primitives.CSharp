namespace RichillCapital.Extensions.Primitives;

public struct Maybe<TValue>
{
    private readonly TValue _value;

    private Maybe(TValue value)
    {
        _value = value;
        HasValue = true;
    }

    public bool HasValue { get; private init; }

    public TValue Value => HasValue ?
        _value :
        throw new InvalidOperationException("The Maybe<T> instance has no value.");

    public static Maybe<TValue> Some(TValue value) => new(value);

    public static Maybe<TValue> None() => new();
}