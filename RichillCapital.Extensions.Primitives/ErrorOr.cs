namespace RichillCapital.Extensions.Primitives;

public sealed class ErrorOr<TValue>
{
    private ErrorOr(bool hasError, TValue value, Error error)
    {
        HasError = hasError;
        Value = value;
        Error = error;
    }

    public bool HasError { get; private init; }

    public TValue Value { get; private init; }

    public Error Error { get; private init; }

    public static ErrorOr<TValue> WithValue(TValue value) =>
        new(false, value, Error.Default);

    public static ErrorOr<TValue> WithError(Error error) =>
        new(true, default, error);

    public static implicit operator ErrorOr<TValue>(Error error) => WithError(error);

    public static implicit operator ErrorOr<TValue>(TValue value) => WithValue(value);
}