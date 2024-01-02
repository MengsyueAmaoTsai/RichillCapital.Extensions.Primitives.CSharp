namespace RichillCapital.Extensions.Primitives;

public sealed class EnumerationNotFoundException : Exception
{
    public EnumerationNotFoundException(string? message)
        : base(message)
    {
    }

    public EnumerationNotFoundException()
    {
    }

    public EnumerationNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}