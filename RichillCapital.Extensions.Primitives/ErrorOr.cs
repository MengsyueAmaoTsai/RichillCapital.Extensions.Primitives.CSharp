namespace RichillCapital.Extensions.Primitives;

public sealed class ErrorOr<TValue>
{
    private ErrorOr(TValue value)
    {
        Value = value;
        HasValue = true;
    }

    private ErrorOr(Error error)
    {
        Error = error;
    }

    public bool HasValue { get; private init; }

    public TValue Value { get; private init; }

    public Error Error { get; private init; }

    public static ErrorOr<TValue> WithValue(TValue value)
    {
        return new(value);
    }

    public static ErrorOr<TValue> WithError(Error error)
    {
        return new(error);
    }
}