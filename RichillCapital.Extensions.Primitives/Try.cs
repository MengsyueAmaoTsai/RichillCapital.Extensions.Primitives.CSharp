namespace RichillCapital.Extensions.Primitives;

public class Try<T>
{
    private readonly T _value;
    private readonly Error _error;

    private Try(T value)
    {
        _value = value;
        _error = null;
        IsSuccess = true;
    }

    private Try(Error error)
    {
        _error = error;
        _value = default;
        IsSuccess = false;
    }

    public bool IsSuccess { get; private init; }

    public T Value => IsSuccess ?
        _value :
        throw new InvalidOperationException("The Try<T> operation was not successful.");

    public Error Error => IsSuccess ?
        throw new InvalidOperationException("The Try<T> operation was successful.") :
        _error;

    public static Try<T> Success(T value) => new(value);

    public static Try<T> Failure(Error error) => new(error);
}