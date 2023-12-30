namespace RichillCapital.Extensions.Primitives;

public static class ResultExtensions
{
    public static Result<TValue> Ensure<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Error error) =>
        result.IsFailure ? result : result.IsSuccess && predicate(result.Value) ?
            result : Result.Failure<TValue>(error);

    public static Result<TOutput> Map<TInput, TOutput>(
        this Result<TInput> result,
        Func<TInput, TOutput> func) =>
        result.IsSuccess ? func(result.Value) : Result.Failure<TOutput>(result.Error);

    public static async Task<Result> Bind<TIn>(this Result<TIn> result, Func<TIn, Task<Result>> resultTask) =>
        result.IsSuccess ? await resultTask(result.Value) : Result.Failure(result.Error);

    public static async Task<Result<TOutput>> Bind<TInput, TOutput>(
        this Result<TInput> result,
        Func<TInput, Task<Result<TOutput>>> resultTask) =>
        result.IsSuccess ? await resultTask(result.Value) : Result.Failure<TOutput>(result.Error);

    public static async Task<T> Match<T>(this Task<Result> resultTask, Func<T> onSuccess, Func<Error, T> onFailure)
    {
        Result result = await resultTask;

        return result.IsSuccess ? onSuccess() : onFailure(result.Error);
    }

    public static async Task<TOutput> Match<TInput, TOutput>(
        this Task<Result<TInput>> resultTask,
        Func<TInput, TOutput> onSuccess,
        Func<Error, TOutput> onFailure)
    {
        Result<TInput> result = await resultTask;

        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error);
    }
}