using System.Reflection;
using System.Runtime.CompilerServices;

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

    private static readonly Lazy<TEnum[]> _enumOptions = new(GetAllOptions, LazyThreadSafetyMode.ExecutionAndPublication);

    private static readonly Lazy<Dictionary<string, TEnum>> _fromName = new(() =>
        _enumOptions.Value.ToDictionary(item => item.Name));

    private static readonly Lazy<Dictionary<string, TEnum>> _fromNameIgnoreCase = new(() =>
        _enumOptions.Value.ToDictionary(item => item.Name, StringComparer.OrdinalIgnoreCase));

    private static TEnum[] GetAllOptions()
    {
        var baseType = typeof(TEnum);
        var assembly = Assembly.GetAssembly(baseType) ?? throw new InvalidOperationException();

        return assembly.GetTypes()
            .Where(baseType.IsAssignableFrom)
            .SelectMany(type => type.GetFields()
                .Where(field => type.IsAssignableFrom(field.FieldType))
                .Select(field => (TEnum)field.GetValue(null)!)
                .ToList())
            .OrderBy(enumeration => enumeration.Name)
            .ToArray();
    }

    protected Enumeration(string name, TValue value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; private init; }
    public TValue Value { get; private init; }

    public int CompareTo(Enumeration<TEnum, TValue>? other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj) => (obj is Enumeration<TEnum, TValue> other) && Equals(other);

    public bool Equals(Enumeration<TEnum, TValue>? other)
    {
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (other is null)
        {
            return false;
        }

        return Value.Equals(other.Value);
    }

    public EnumerationThen<TEnum, TValue> Match(Enumeration<TEnum, TValue> enumerationMatch)
        => new(enumeration: this, isMatched: Equals(enumerationMatch), stopEvaluating: false);

    public static TEnum FromName(string name, bool ignoreCase = false)
    {
        throw new NotImplementedException();

        TEnum FindByName(Dictionary<string, TEnum> dictionary)
        {
            dictionary.TryGetValue(name, out var result);

            return result;
        }
    }

    public static TEnum FromValue(TValue value)
    {
        throw new NotImplementedException();
    }
}