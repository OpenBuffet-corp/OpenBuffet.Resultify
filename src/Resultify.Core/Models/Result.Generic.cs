using System;
using Resultify.Core.Abstractions;
using Resultify.Core.ValueObjects;

namespace Resultify.Core.Models;

public sealed class Result<T> : BaseResult
{
    public T? Value { get; }

    private Result(bool isSuccess, Error error, T? value) : base(isSuccess, error)
        => Value = value;


    public static Result<T> Success(T value) => new(true, Error.None, value);
    public static Result<T> Failure(Error error) => new(false, error, default);



    public void Match(Action<T?> onSuccess, Action<Error> onFailure)
    {
        if (onSuccess is null) throw new ArgumentNullException(nameof(onSuccess));
        if (onFailure is null) throw new ArgumentNullException(nameof(onFailure));

        if (IsSuccess)
            onSuccess(Value);
        else
            onFailure(Error);
    }

    public TResult Match<TResult>(Func<T?, TResult> onSuccess, Func<Error, TResult> onFailure)
    {
        if (onSuccess is null) throw new ArgumentNullException(nameof(onSuccess));
        if (onFailure is null) throw new ArgumentNullException(nameof(onFailure));

        return IsSuccess
            ? onSuccess(Value)
            : onFailure(Error);
    }

    public Result<TResult> Map<TResult>(Func<T?, TResult> func)
    {
        if (func is null) throw new ArgumentNullException(nameof(func));

        return IsSuccess
            ? Result<TResult>.Success(func(Value))
            : Result<TResult>.Failure(Error);
    }

    public Result<T> Map(Action<T?> action)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        if (IsSuccess)
            action(Value);

        return this;
    }

    public Result<TResult> Bind<TResult>(Func<T?, Result<TResult>> func)
    {
        if (func is null) throw new ArgumentNullException(nameof(func));

        return IsSuccess
            ? func(Value)
            : Result<TResult>.Failure(Error);
    }

    public static Result<T> Try(Func<T> func)
    {
        if (func is null) throw new ArgumentNullException(nameof(func));

        try
        {
            var value = func();
            return Success(value);
        }
        catch (Exception ex)
        {
            return Failure(new Error(Code: ex.GetType().Name, Description: ex.Message));
        }
    }

}
