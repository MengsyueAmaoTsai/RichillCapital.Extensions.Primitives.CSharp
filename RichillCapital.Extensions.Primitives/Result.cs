

namespace RichillCapital.Extensions.Primitives;

public class Result
{
    protected Result(bool isFailure, Error error)
    {
        IsFailure = isFailure;
        Error = error;
    }

    public bool IsFailure { get; private init; }

    public Error Error { get; private init; }

    public static Result<TValue> From<TValue>(TValue value) => new(value, false, Error.None);

    public static Result Success() => new(false, Error.None);

    public static implicit operator Result(Error error) => new(true, error);
}

public class Result<TValue> : Result
{
    internal Result(TValue value, bool isFailure, Error error)
        : base(isFailure, error)
    {
        Value = value;
    }

    public TValue Value { get; }

    public static implicit operator Result<TValue>(TValue value) => new(value, false, Error.None);

    public static implicit operator Result<TValue>(Error error) => new(default, true, error);
}