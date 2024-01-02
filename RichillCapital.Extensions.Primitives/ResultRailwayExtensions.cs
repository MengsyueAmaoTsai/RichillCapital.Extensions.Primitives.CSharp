namespace RichillCapital.Extensions.Primitives;

public static class ResultRailwayExtensions
{
    public static Result<TValue> Ensure<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> ensure,
        Error error) =>
        result.IsFailure ? result : ensure(result.Value) ? result : error;

    public static Result<TDestination> Map<TSource, TDestination>(
        this Result<TSource> result,
        Func<TSource, TDestination> map) =>
        result.IsFailure ? result.Error : map(result.Value);
}