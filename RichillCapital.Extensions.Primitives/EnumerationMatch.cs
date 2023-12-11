namespace RichillCapital.Extensions.Primitives;

public readonly struct EnumerationMatch<TEnum, TValue>
    where TEnum : IEnumeration
    where TValue : IEquatable<TValue>, IComparable<TValue>
{
    private readonly IEnumeration _enumeration;
    private readonly bool _stopEvaluating;

    internal EnumerationMatch(IEnumeration enumeration, bool stopEvaluating)
    {
        _enumeration = enumeration;
        _stopEvaluating = stopEvaluating;
    }

    public void Default(Action action)
    {
        if (!_stopEvaluating)
        {
            action();
        }
    }
}
