namespace RichillCapital.Extensions.Primitives;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.Null)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.Null)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; private init; }

    public static Result Success() => new(true, Error.Null);

    public static Result<T> Success<T>(T value) => new(value, true, Error.Null);

    public static Result Failure(Error error) => new(false, error);

    public static Result<T> Failure<T>(Error error) => new(default!, false, error);
}

public class Result<TValue> : Result
{
    private readonly TValue _value;

    protected internal Result(TValue value, bool isSuccess, Error error)
        : base(isSuccess, error) => _value = value;

    public TValue Value => IsSuccess ?
        _value :
        throw new InvalidOperationException($"Result is in status failed. Value is not set. Having: Error with Message='{Error.Message}'");

    public TValue ValueOrDefault => IsSuccess ? _value : default!;

    public static implicit operator TValue(Result<TValue> result) => result.Value;

    public static implicit operator Result<TValue>(TValue value) => Success(value);
}