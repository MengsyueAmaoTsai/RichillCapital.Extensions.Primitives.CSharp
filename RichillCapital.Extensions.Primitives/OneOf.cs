namespace RichillCapital.Extensions.Primitives;

public class OneOf<T1, T2, T3>
{
    private readonly object value;

    private OneOf(object value)
    {
        this.value = value;
    }

    public T Match<T>(Func<T1, T> case1, Func<T2, T> case2, Func<T3, T> case3)
    {
        return value is T1 t1 ? case1(t1) :
            value is T2 t2 ? case2(t2) :
            value is T3 t3 ? case3(t3) :
            throw new InvalidOperationException("None of the cases match.");
    }

    public static OneOf<T1, T2, T3> Case1(T1 value) => new(value);

    public static OneOf<T1, T2, T3> Case2(T2 value) => new(value);

    public static OneOf<T1, T2, T3> Case3(T3 value) => new(value);
}