namespace RichillCapital.Extensions.Primitives;

public class Error
{
    public static readonly Error Default = default;

    public Error(string errorMessage)
    {
        Message = Message;
    }

    public string Message { get; private init; }
}
