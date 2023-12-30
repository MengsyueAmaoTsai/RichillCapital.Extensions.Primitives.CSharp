namespace RichillCapital.Extensions.Primitives;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; private init; }

    public static Result Success() => new(true, Error.Null);

    public static Result Failure(Error error) => new(false, error);

    public static Result<T> Success<T>(T value) => new(value);

    public static Result<T> Failure<T>(Error error) => new(error);
}

public class Result<T> : Result
{
    private readonly T _value;

    protected internal Result(T value)
        : base(true, Error.Null)
    {
        _value = value;
    }

    protected internal Result(Error error)
        : base(false, error)
    {
        _value = default!;
    }

    public T Value => IsFailure ?
        throw new InvalidOperationException($"Result is in status failed. Value is not set. Having: Error with Message='{Error.Message}'")
        : _value;

    public T ValueOrDefault => IsSuccess ? _value : default!;

    public static implicit operator T(Result<T> result) => result.Value;

    public static implicit operator Result<T>(T value) => new(value);
}