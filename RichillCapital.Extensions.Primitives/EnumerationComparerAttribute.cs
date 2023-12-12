namespace RichillCapital.Extensions.Primitives;

[AttributeUsage(AttributeTargets.Class)]
public class EnumerationComparerAttribute<T> : Attribute
{
    protected EnumerationComparerAttribute(IEqualityComparer<T> comparer)
        => Comparer = comparer;

    public IEqualityComparer<T> Comparer { get; private init; }
}

public class EnumerationStringComparerAttribute : EnumerationComparerAttribute<string>
{
    public EnumerationStringComparerAttribute(StringComparison comparison)
        : base(GetComparer(comparison))
    {
    }

    private static IEqualityComparer<string> GetComparer(StringComparison comparison)
    {
        return comparison switch
        {
            StringComparison.Ordinal => StringComparer.Ordinal,
            StringComparison.OrdinalIgnoreCase => StringComparer.OrdinalIgnoreCase,
            StringComparison.CurrentCulture => StringComparer.CurrentCulture,
            StringComparison.CurrentCultureIgnoreCase => StringComparer.CurrentCultureIgnoreCase,
            StringComparison.InvariantCulture => StringComparer.InvariantCulture,
            StringComparison.InvariantCultureIgnoreCase => StringComparer.InvariantCultureIgnoreCase,
            _ => throw new ArgumentException($"StringComparison {comparison} is not supported", nameof(comparison)),
        };
    }
}