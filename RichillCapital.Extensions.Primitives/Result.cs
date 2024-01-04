namespace RichillCapital.Extensions.Primitives;

public class Result<TValue>
{
    private Result(bool isSuccess, TValue value, Error error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public bool IsSuccess { get; }

    public TValue Value { get; }

    public Error Error { get; }

    public static Result<TValue> Success(TValue value) => new(true, value, Error.Default);

    public static Result<TValue> Failure(Error error) => new(false, default, error);
}