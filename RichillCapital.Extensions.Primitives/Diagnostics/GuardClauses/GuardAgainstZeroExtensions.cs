using System.Runtime.CompilerServices;

namespace RichillCapital.Extensions.Primitives.Diagnostics.GuardClauses;

public static partial class GuardClauseExtensions
{
    public static int Zero(
        this IGuardClause guardClause,
        int value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null) =>
        Zero<int>(guardClause, value, parameterName!, message);

    public static long Zero(
        this IGuardClause guardClause,
        long value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null) =>
        Zero<long>(guardClause, value, parameterName!, message);

    public static decimal Zero(
        this IGuardClause guardClause,
        decimal value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null) =>
        Zero<decimal>(guardClause, value, parameterName!, message);

    public static float Zero(
        this IGuardClause guardClause,
        float value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null) =>
        Zero<float>(guardClause, value, parameterName!, message);

    public static double Zero(
        this IGuardClause guardClause,
        double value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null) => Zero<double>(guardClause, value, parameterName!, message);

    public static TimeSpan Zero(
        this IGuardClause guardClause,
        TimeSpan value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null) =>
        Zero<TimeSpan>(guardClause, value, parameterName!);

    public static TNumeric Zero<TNumeric>(
        this IGuardClause guardClause,
        TNumeric value,
        string parameterName,
        string? message = null)
        where TNumeric : struct
    {
        return EqualityComparer<TNumeric>.Default.Equals(value, default)
            ? throw new ArgumentException(message ?? $"Required input {parameterName} cannot be zero.", parameterName)
            : value;
    }
}