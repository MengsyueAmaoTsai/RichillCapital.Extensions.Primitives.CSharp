namespace RichillCapital.Extensions.Primitives;

public class Error
{
    public static readonly Error Null = new(string.Empty, ErrorType.Null);

    private Error(string message, ErrorType type)
    {
        Message = message;
        Type = type;
    }

    public string Message { get; private init; }

    public ErrorType Type { get; private init; }

    public static Error WithMessage(string message) => new(message, ErrorType.Default);

    public static Error NotFound(string message) => new(message, ErrorType.NotFound);

    public static Error Invalid(string message) => new(message, ErrorType.Invalid);

    public static Error Conflict(string message) => new(message, ErrorType.Conflict);

    public static Error Unauthorized(string message) => new(message, ErrorType.Unauthorized);
}

public enum ErrorType
{
    Null,

    Default,

    Invalid,

    NotFound,

    Conflict,

    Unauthorized,
}