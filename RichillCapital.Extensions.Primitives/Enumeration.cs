using System.Reflection;

using Primitives.RichillCapital.Extensions.Primitives;

namespace RichillCapital.Extensions.Primitives;

public abstract class Enumeration<TEnum> : Enumeration<TEnum, int>
    where TEnum : Enumeration<TEnum, int>
{
    protected Enumeration(string name, int value)
        : base(name, value)
    {
    }
}

public abstract class Enumeration<TEnum, TValue> :
    IEnumeration,
    IEquatable<Enumeration<TEnum, TValue>>,
    IComparable<Enumeration<TEnum, TValue>>
    where TEnum : Enumeration<TEnum, TValue>
    where TValue : IEquatable<TValue>, IComparable<TValue>
{
    public static IReadOnlyCollection<TEnum> Members => _fromName.Value.Values.ToList().AsReadOnly();

    private static readonly Lazy<TEnum[]> _enumOptions =
        new(GetAllOptions, LazyThreadSafetyMode.ExecutionAndPublication);

    private static readonly Lazy<Dictionary<string, TEnum>> _fromName =
        new(() => _enumOptions.Value.ToDictionary(item => item.Name));

    private static readonly Lazy<Dictionary<string, TEnum>> _fromNameIgnoreCase =
        new(() => _enumOptions.Value.ToDictionary(item => item.Name, StringComparer.OrdinalIgnoreCase));

    protected Enumeration(string name, TValue value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; private init; }
    public TValue Value { get; private init; }

    public override int GetHashCode() => base.GetHashCode();

    public int CompareTo(Enumeration<TEnum, TValue>? other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj) => (obj is Enumeration<TEnum, TValue> other) && Equals(other);

    public bool Equals(Enumeration<TEnum, TValue>? other)
        => other is not null && (ReferenceEquals(this, other) || Value.Equals(other.Value));

    public EnumerationThen<TEnum, TValue> Match(Enumeration<TEnum, TValue> enumeration)
        => new(enumeration: this, isMatched: Equals(enumeration), stopEvaluating: false);

    public static TEnum FromName(string name, bool ignoreCase = false)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException($"Argument cannot be null or empty.", nameof(name));
        }

        return ignoreCase ? FindByName(_fromNameIgnoreCase.Value) : FindByName(_fromName.Value);

        TEnum FindByName(Dictionary<string, TEnum> dictionary)
        {
            if (!dictionary.TryGetValue(name, out var result))
            {
                throw new EnumerationNotFoundException($@"No {typeof(TEnum).Name} with name ""{name}"" found.");
            }

            return result;
        }
    }

    public static bool TryFromName(string name, out TEnum? enumeration)
        => TryFromName(name, false, out enumeration);

    public static bool TryFromName(string name, bool ignoreCase, out TEnum? enumeration)
    {
        if (string.IsNullOrEmpty(name))
        {
            enumeration = default;
            return false;
        }

        return ignoreCase ?
            _fromNameIgnoreCase.Value.TryGetValue(name, out enumeration) :
            _fromName.Value.TryGetValue(name, out enumeration);
    }

    public static TEnum FromValue(TValue value)
    {
        throw new NotImplementedException();
    }

    public static bool TryFromValue(TValue value, out TEnum enumeration)
    {
        throw new NotImplementedException();
    }

    public override string ToString() => Name;

    private static TEnum[] GetAllOptions()
    {
        var enumType = typeof(TEnum);
        var assembly = Assembly.GetAssembly(enumType) ?? throw new InvalidOperationException();

        return assembly.GetTypes()
            .Where(enumType.IsAssignableFrom)
            .SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(field => type.IsAssignableFrom(field.FieldType))
                .Select(field => (TEnum)field.GetValue(null)!)
                .ToList())
            .OrderBy(enumeration => enumeration.Name)
            .ToArray();
    }
}