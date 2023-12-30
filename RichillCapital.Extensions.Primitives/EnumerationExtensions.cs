namespace RichillCapital.Extensions.Primitives;

public static class EnumerationExtensions
{
    public static EnumerationThen<TEnum, TValue> Match<TEnum, TValue>(
        this Enumeration<TEnum, TValue> enumeration,
        Enumeration<TEnum, TValue> other)
        where TEnum : Enumeration<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue> =>
            new(enumeration, enumeration.Equals(other), false);

    public static EnumerationThen<TEnum, TValue> Match<TEnum, TValue>(
        this Enumeration<TEnum, TValue> enumeration,
        params Enumeration<TEnum, TValue>[] enumerations)
        where TEnum : Enumeration<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue> =>
            new(enumeration, enumerations.Contains(enumeration), false);

    public static EnumerationThen<TEnum, TValue> Match<TEnum, TValue>(
        this Enumeration<TEnum, TValue> enumeration,
        IEnumerable<Enumeration<TEnum, TValue>> enumerations)
        where TEnum : Enumeration<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue> =>
            new(enumeration, enumerations.Contains(enumeration), false);
}