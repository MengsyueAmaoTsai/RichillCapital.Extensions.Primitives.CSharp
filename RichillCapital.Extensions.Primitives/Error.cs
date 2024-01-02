namespace RichillCapital.Extensions.Primitives;

public record class Error(string Message)
{
    public static readonly Error None = new(string.Empty);

    public static Error WithMessage(string message) => string.IsNullOrEmpty(message) ? None : new(message);
}
