namespace RichillCapital.Extensions.Primitives.Monad;

public sealed class Maybe<T> : IEquatable<Maybe<T>>
{
    private T? _value;

    private Maybe()
    {
    }

    public static readonly Maybe<T> None = new();

    public static Maybe<T> Have(T value) => new() { _value = value };

    public Maybe<TResult> Map<TResult>(Func<T, TResult> map) =>
        new() { _value = _value is not null ? map(_value) : default };

    public T OrElse(T defaultValue) => _value ?? defaultValue;

    public T OrElse(Func<T> orElse) => _value ?? orElse();

    public Maybe<T> Where(Func<T, bool> predicate) =>
        _value is not null && predicate(_value) ? this : Maybe<T>.None;

    public Maybe<T> WhereNot(Func<T, bool> predicate) =>
        _value is not null && !predicate(_value) ? this : Maybe<T>.None;

    public bool Equals(Maybe<T>? other) => other is null ? false : _value?.Equals(other._value) ?? false;

    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    public override bool Equals(object? obj) => Equals(obj as Maybe<T>);

    public static bool operator ==(Maybe<T>? right, Maybe<T>? left) =>
        right is null ? left is null : right.Equals(left);

    public static bool operator !=(Maybe<T>? right, Maybe<T>? left) => !(right == left);
}
