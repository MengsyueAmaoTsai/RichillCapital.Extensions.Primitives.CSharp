namespace Primitives.RichillCapital.Extensions.Primitives;

public sealed class EnumerationNotFoundException : Exception
{
    public EnumerationNotFoundException(string? message)
        : base(message)
    {
    }
}