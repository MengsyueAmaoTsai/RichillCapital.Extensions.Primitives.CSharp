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
    public static IReadOnlyCollection<TEnum> Members =>
        _fromName.Value.Values
            .ToList()
            .AsReadOnly();

    private static readonly Lazy<TEnum[]> _enumOptions =
        new(GetAllOptions, LazyThreadSafetyMode.ExecutionAndPublication);

    private static readonly Lazy<Dictionary<string, TEnum>> _fromName =
        new(() => _enumOptions.Value.ToDictionary(item => item.Name));

    private static readonly Lazy<Dictionary<string, TEnum>> _fromNameIgnoreCase =
        new(() => _enumOptions.Value.ToDictionary(
            item => item.Name,
            StringComparer.OrdinalIgnoreCase));

    private static readonly Lazy<Dictionary<TValue, TEnum>> _fromValue =
        new(() =>
        {
            var dictionary = new Dictionary<TValue, TEnum>(GetValueComparer());

            foreach (var item in _enumOptions.Value)
            {
                if (item.Value != null && !dictionary.ContainsKey(item.Value))
                {
                    dictionary.Add(item.Value, item);
                }
            }

            return dictionary;
        });

    protected Enumeration(string name, TValue value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; private init; }

    public TValue Value { get; private init; }

    public static Maybe<TEnum> FromName(string name, bool ignoreCase = false)
    {
        return string.IsNullOrWhiteSpace(name)
            ? Maybe<TEnum>.NoValue
            : ignoreCase ? FindByName(_fromNameIgnoreCase.Value) : FindByName(_fromName.Value);

        Maybe<TEnum> FindByName(Dictionary<string, TEnum> dictionary) =>
            dictionary.TryGetValue(name, out var enumeration) ?
                Maybe<TEnum>.WithValue(enumeration) :
                Maybe<TEnum>.NoValue;
    }

    public static Maybe<TEnum> FromValue(TValue value)
    {
        TEnum? enumeration;

        if (value is not null)
        {
            if (!_fromValue.Value.TryGetValue(value, out enumeration))
            {
                return Maybe<TEnum>.NoValue;
            }
        }
        else
        {
            enumeration = _enumOptions.Value.FirstOrDefault(x => x.Value is null);

            if (enumeration is null)
            {
                return Maybe<TEnum>.NoValue;
            }
        }

        return Maybe<TEnum>.WithValue(enumeration);
    }

    public static Maybe<TEnum> FromValue(TValue value, TEnum defaultEnumeration) =>
        value is null ?
        Maybe<TEnum>.NoValue :
        !_fromValue.Value.TryGetValue(value, out var result) ?
        Maybe<TEnum>.WithValue(defaultEnumeration) :
        Maybe<TEnum>.WithValue(result);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(Enumeration<TEnum, TValue>? other) =>
        other is null ? 0 : Value.CompareTo(other.Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TValue(Enumeration<TEnum, TValue> enumeration) =>
        enumeration is not null ? enumeration.Value : default!;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Enumeration<TEnum, TValue>(TValue value) =>
        FromValue(value).Value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Enumeration<TEnum, TValue> left, Enumeration<TEnum, TValue> right) =>
        left.CompareTo(right) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Enumeration<TEnum, TValue> left, Enumeration<TEnum, TValue> right) =>
        left.CompareTo(right) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Enumeration<TEnum, TValue> left, Enumeration<TEnum, TValue> right) =>
        left.CompareTo(right) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Enumeration<TEnum, TValue> left, Enumeration<TEnum, TValue> right) =>
        left.CompareTo(right) >= 0;

    public static bool operator ==(Enumeration<TEnum, TValue> left, Enumeration<TEnum, TValue> right) =>
        left is null ? right is null : left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Enumeration<TEnum, TValue> left, Enumeration<TEnum, TValue> right) =>
        !(left == right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => Value.GetHashCode();

    public override bool Equals(object? obj) =>
        (obj is Enumeration<TEnum, TValue> other) && Equals(other);

    public bool Equals(Enumeration<TEnum, TValue>? other) =>
        other is not null && (ReferenceEquals(this, other) || Value.Equals(other.Value));

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

    private static IEqualityComparer<TValue>? GetValueComparer() =>
        typeof(TEnum).GetCustomAttribute<EnumerationComparerAttribute<TValue>>()?.Comparer;
}