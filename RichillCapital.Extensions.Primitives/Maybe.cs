namespace RichillCapital.Extensions.Primitives;

public static class Maybe
{
    public static Maybe<TValue> WithValue<TValue>(TValue value) => new(value);
}

public sealed class Maybe<TValue> : IEquatable<Maybe<TValue>>
{
    private readonly TValue _value;

    internal Maybe(TValue value) => _value = value;

    public bool HasValue => !HasNoValue;

    public bool HasNoValue => _value is null;

    public TValue Value => HasValue ?
        _value :
        throw new InvalidOperationException("The value can not be accessed because it does not exist.");

    public static readonly Maybe<TValue> Null = new(default!);

    public bool Equals(Maybe<TValue>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (HasNoValue && other.HasNoValue)
        {
            return true;
        }

        if (HasNoValue || other.HasNoValue)
        {
            return false;
        }

        return Value!.Equals(other.Value);
    }

    public static implicit operator Maybe<TValue>(TValue value) => new(value);

    public static implicit operator TValue(Maybe<TValue> maybe) => maybe.Value;

    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            TValue value => Equals(new Maybe<TValue>(value)),
            Maybe<TValue> maybe => Equals(maybe),
            _ => false
        };

    public override int GetHashCode() => HasValue ? Value!.GetHashCode() : 0;
}