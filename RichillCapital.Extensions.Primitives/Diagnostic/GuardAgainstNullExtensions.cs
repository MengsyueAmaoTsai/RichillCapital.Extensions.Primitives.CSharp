using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace RichillCapital.Extensions.Primitives.Diagnostic;

public static partial class GuardClauseExtensions
{
    public static T Null<T>(
        this IGuardClause guardClause,
        [NotNull][ValidatedNotNull] T? value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null)
    {
        if (value is null)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(parameterName);
            }

            throw new ArgumentNullException(parameterName, message);
        }

        return value;
    }

    public static T Null<T>(
        this IGuardClause guardClause,
        [NotNull][ValidatedNotNull] T? value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null)
        where T : struct
    {
        if (value is null)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(parameterName);
            }

            throw new ArgumentNullException(parameterName, message);
        }

        return value.Value;
    }

    public static string NullOrEmpty(
        this IGuardClause guardClause,
        [NotNull][ValidatedNotNull] string? value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null)
    {
        Guard.Against.Null(value, parameterName, message);

        return string.IsNullOrEmpty(value)
            ? throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName)
            : value;
    }

    public static Guid NullOrEmpty(
        this IGuardClause guardClause,
        [NotNull][ValidatedNotNull] Guid? value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null)
    {
        Guard.Against.Null(value, parameterName, message);

        return value == Guid.Empty
            ? throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName)
            : value.Value;
    }

    public static IEnumerable<T> NullOrEmpty<T>(
        this IGuardClause guardClause,
        [NotNull][ValidatedNotNull] IEnumerable<T>? value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null)
    {
        Guard.Against.Null(value, parameterName, message);

        return !value.Any()
            ? throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName)
            : value;
    }

    public static string NullOrWhiteSpace(
        this IGuardClause guardClause,
        [NotNull][ValidatedNotNull] string? value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null)
    {
        Guard.Against.NullOrEmpty(value, parameterName, message);

        return string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName)
            : value;
    }

    public static T Default<T>(
        this IGuardClause guardClause,
        [AllowNull, NotNull] T value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null,
        string? message = null)
    {
        return EqualityComparer<T>.Default.Equals(value, default!) || value is null
            ? throw new ArgumentException(message ?? $"Parameter [{parameterName}] is default value for type {typeof(T).Name}", parameterName)
            : value;
    }

    public static T NullOrInvalidInput<T>(
        this IGuardClause guardClause,
        [NotNull] T? value,
        string parameterName,
        Func<T, bool> predicate,
        string? message = null)
    {
        Guard.Against.Null(value, parameterName, message);

        return Guard.Against.InvalidInput(value, parameterName, predicate, message);
    }
}