namespace RichillCapital.Extensions.Primitives;

public static class ResultRailwayExtensions
{
    public static void Bind()
    {
    }

    public static Result<TDestination> Map<TSource, TDestination>(
        this Result<TSource> result,
        Func<TSource, TDestination> map)
    {
        if (result.IsFailure)
        {
            return result.Error;
        }

        return map(result.Value);
    }

    public static void Match()
    {
    }

    public static void Tap()
    {
    }

    public static void Select()
    {
    }
}