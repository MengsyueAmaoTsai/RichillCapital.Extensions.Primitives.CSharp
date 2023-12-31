namespace RichillCapital.Extensions.Primitives;

public class Result
{
    private Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public Error Error { get; }

    public static Result Success() => new(true, Error.Null);

    public static Result Failure(Error error) => new(false, error);

    public static implicit operator Result(Error error) => new(false, error);
}

public class Result<TValue>
{
    internal Result(bool isSuccess, TValue value, Error error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public bool IsSuccess { get; }

    public TValue Value { get; }

    public Error Error { get; }

    public static Result<TValue> Success(TValue value) =>
        new(true, value, Error.Null);

    public static Result<TValue> Failure(Error error) =>
        new(false, default, error);

    public static Result<TValue> Failure(Exception exception) =>
        new(false, default, Error.WithMessage(exception.Message));

    public static implicit operator Result<TValue>(Error error) => Failure(error);

    public static implicit operator Result<TValue>(TValue value) => Success(value);
}