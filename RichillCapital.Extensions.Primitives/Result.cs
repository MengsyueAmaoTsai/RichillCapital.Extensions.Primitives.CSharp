namespace RichillCapital.Extensions.Primitives;

public class Result : ResultBase<Result>
{
    protected Result(bool isFailure, Error error)
        : base(isFailure, error)
    {
    }

    public static Result Failure(Error error) => new(true, error);

    public static Result<TValue> From<TValue>(TValue value) => new(value, false, Error.None);

    public static Result Success() => new(false, Error.None);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, false, Error.None);

    public static implicit operator Result(Error error) => new(true, error);
}

public class Result<TValue> : ResultBase<Result<TValue>>
{
    internal Result(TValue value, bool isFailure, Error error)
        : base(isFailure, error)
    {
        Value = value;
    }

    public TValue Value { get; }

    public static implicit operator Result<TValue>(TValue value) => new(value, false, Error.None);

    public static implicit operator Result<TValue>(Error error) => new(default, true, error);

    public static implicit operator Result<TValue>(Result result) => new(default, true, result.Error);
}

public abstract class ResultBase : IResult
{
    protected ResultBase(bool isFailure, Error error)
    {
        IsFailure = isFailure;
        Error = error;
    }

    public bool IsFailure { get; private init; }

    public Error Error { get; private init; }
}

public abstract class ResultBase<TResult> : ResultBase
    where TResult : ResultBase<TResult>
{
    protected ResultBase(bool isFailure, Error error)
        : base(isFailure, error)
    {
    }
}

public interface IResult
{
    bool IsFailure { get; }

    Error Error { get; }
}