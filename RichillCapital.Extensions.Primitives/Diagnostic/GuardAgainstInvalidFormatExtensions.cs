using System.Text.RegularExpressions;

namespace RichillCapital.Extensions.Primitives.Diagnostic;

public static partial class GuardClauseExtensions
{
    public static string InvalidFormat(
        this IGuardClause guardClause,
        string value,
        string parameterName,
        string regexPattern,
        string? message = null)
    {
        var match = Regex.Match(value, regexPattern);

        return !match.Success || value != match.Value
            ? throw new ArgumentException(message ?? $"Input {parameterName} was not in required format", parameterName)
            : value;
    }

    public static T InvalidInput<T>(
        this IGuardClause guardClause,
        T value,
        string parameterName,
        Func<T, bool> predicate,
        string? message = null)
    {
        return !predicate(value)
            ? throw new ArgumentException(message ?? $"Input {parameterName} did not satisfy the options", parameterName)
            : value;
    }

    public static async Task<T> InvalidInputAsync<T>(
        this IGuardClause guardClause,
        T value,
        string parameterName,
        Func<T, Task<bool>> predicate,
        string? message = null)
    {
        return !await predicate(value)
            ? throw new ArgumentException(message ?? $"Input {parameterName} did not satisfy the options", parameterName)
            : value;
    }
}