namespace RichillCapital.Extensions.Primitives;

public static class MaybeExtensions
{
    public static async Task<Maybe<TOutput>> Bind<TInput, TOutput>(
        this Maybe<TInput> maybe,
        Func<TInput, Task<Maybe<TOutput>>> task) =>
        maybe.HasValue ? await task(maybe.Value) : Maybe<TOutput>.Null;

    public static async Task<TOutput> Match<TInput, TOutput>(
        this Task<Maybe<TInput>> task,
        Func<TInput, TOutput> onHasValue,
        Func<TOutput> onHasNoValue)
    {
        Maybe<TInput> maybe = await task;

        return maybe.HasValue ? onHasValue(maybe.Value) : onHasNoValue();
    }
}