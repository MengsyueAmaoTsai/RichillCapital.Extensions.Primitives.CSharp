namespace RichillCapital.Extensions.Primitives.Diagnostic;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class ValidatedNotNullAttribute : Attribute
{
}