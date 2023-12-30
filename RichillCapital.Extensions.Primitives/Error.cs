namespace RichillCapital.Extensions.Primitives;

public class Error
{
    public static readonly Error Null = new(string.Empty);

    private Error(string message)
    {
        Message = message;
    }

    public string Message { get; private init; }

    public static Error WithMessage(string message) => new(message);
}