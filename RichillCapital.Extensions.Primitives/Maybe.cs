namespace RichillCapital.Extensions.Primitives;

public sealed class Maybe
{
    public static Maybe<TValue> From<TValue>(TValue value) => new(value);
}

public sealed class Maybe<TValue>
{
    internal Maybe(TValue value)
    {
        Value = value;
    }

    public static Maybe<TValue> Null => new(default);

    public TValue Value { get; private init; }

    public bool HasValue => Value is not null;

    public static implicit operator Maybe<TValue>(TValue value) => new(value);

    public static implicit operator TValue(Maybe<TValue> maybe) => maybe.Value;
}