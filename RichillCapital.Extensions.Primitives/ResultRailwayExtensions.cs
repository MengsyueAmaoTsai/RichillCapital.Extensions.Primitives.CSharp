namespace RichillCapital.Extensions.Primitives;

public static class ResultRailwayExtensions
{
    public static Result<TValue> Ensure<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Error error) =>
        result.IsFailure ? result : predicate(result.Value) ? result : (Result<TValue>)error;
}