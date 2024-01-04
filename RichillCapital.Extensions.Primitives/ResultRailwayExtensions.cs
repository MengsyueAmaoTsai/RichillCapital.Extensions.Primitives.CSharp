namespace RichillCapital.Extensions.Primitives;

public static class ResultRailwayExtensions
{
    public static Result<TDestination> Map<TSource, TDestination>(this Result<TSource> result, Func<TSource, TDestination> map)
    {
        if (result.IsSuccess)
        {
            return map(result.Value);
        }

        return result.Error;
    }
}