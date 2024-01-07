namespace RichillCapital.Extensions.Primitives;

public static class MaybeRailwayExtensions
{
    public static Maybe<TDestination> Map<TSource, TDestination>(
        this Maybe<TSource> maybe,
        Func<TSource, TDestination> map) =>
        maybe.HasValue ?
            Maybe<TDestination>.WithValue(map(maybe.Value)) :
            Maybe<TDestination>.NoValue;

    public static Result<TValue> AsResult<TValue>(this Maybe<TValue> maybe) => maybe.HasValue ?
        Result<TValue>.Success(maybe.Value) :
        Result<TValue>.Failure(Error.Invalid("No value."));
}
