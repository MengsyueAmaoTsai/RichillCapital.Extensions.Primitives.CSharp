namespace RichillCapital.Extensions.Primitives;

public sealed class ErrorOr<TValue>
{
    private ErrorOr(bool hasValue, TValue value, Error error)
    {
        HasValue = hasValue;
        Value = value;
        Error = error;
    }

    public bool HasValue { get; private init; }

    public TValue Value { get; private init; }

    public Error Error { get; private init; }

    public static ErrorOr<TValue> WithValue(TValue value)
    {
        return new(true, value, Error.Default);
    }

    public static ErrorOr<TValue> WithError(Error error)
    {
        return new(false, default, error);
    }
}