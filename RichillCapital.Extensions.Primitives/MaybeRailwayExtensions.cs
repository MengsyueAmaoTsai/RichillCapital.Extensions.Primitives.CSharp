namespace RichillCapital.Extensions.Primitives;

public static class MaybeRailwayExtensions
{
    public static Result<TValue> AsResult<TValue>(this Maybe<TValue> maybe) => maybe.HasValue ?
        Result<TValue>.Success(maybe.Value) :
        Result<TValue>.Failure(Error.Invalid("No value."));
}
