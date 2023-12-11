namespace RichillCapital.Extensions.Primitives;

public readonly struct EnumerationThen<TEnum, TValue>
    where TEnum : IEnumeration
    where TValue : IEquatable<TValue>, IComparable<TValue>
{
    private readonly IEnumeration _enumeration;
    private readonly bool _isMatched;
    private readonly bool _stopEvaluating;

    internal EnumerationThen(IEnumeration enumeration, bool isMatched, bool stopEvaluating)
    {
        _enumeration = enumeration;
        _isMatched = isMatched;
        _stopEvaluating = stopEvaluating;
    }

    public EnumerationMatch<TEnum, TValue> Then(Action action)
    {
        if (!_stopEvaluating && _isMatched)
        {
            action();
        }

        return new EnumerationMatch<TEnum, TValue>(_enumeration, _stopEvaluating || _isMatched);
    }
}