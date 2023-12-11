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
}