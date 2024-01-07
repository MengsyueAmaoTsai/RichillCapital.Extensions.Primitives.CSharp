namespace RichillCapital.Extensions.Primitives;

public static class ErrorOrRailwayExtensions
{
    public static ErrorOr<TDestination> Map<TSource, TDestination>(
        this ErrorOr<TSource> errorOr,
        Func<TSource, TDestination> map) =>
        errorOr.HasError ?
            ErrorOr<TDestination>.WithError(errorOr.Error) :
            ErrorOr<TDestination>.WithValue(map(errorOr.Value));
}