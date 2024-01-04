namespace RichillCapital.Extensions.Primitives;

public class Error
{
    public static readonly Error Default = new(string.Empty);

    public Error(string message) => Message = message;

    public string Message { get; private init; }
}
