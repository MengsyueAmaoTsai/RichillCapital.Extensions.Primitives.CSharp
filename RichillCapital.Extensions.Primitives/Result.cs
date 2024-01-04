namespace RichillCapital.Extensions.Primitives;

public sealed class Result<TValue>
{
    private Result(TValue value)
    {
        IsSuccess = true;
        Value = value;
        Error = default;
    }

    private Result(Error error)
    {
        IsSuccess = false;
        Value = default;
        Error = error;
    }

    public static Result<TValue> Success(TValue value)
    {
        return new(value);
    }

    public static Result<TValue> Failure(Error error)
    {
        return new(error);
    }

    public bool IsSuccess { get; private init; }

    public TValue Value { get; private init; }

    public Error Error { get; private init; }
}