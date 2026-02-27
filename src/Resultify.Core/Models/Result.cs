using System;
using Microsoft.VisualBasic;
using Resultify.Core.Abstractions;
using Resultify.Core.ValueObjects;

namespace Resultify.Core.Models;

public sealed class Result : BaseResult
{
    private Result(bool isSuccess, Error error) : base(isSuccess, error) { }


    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);


    public void Match(Action onSuccess, Action<Error> onFailure)
    {
        if (onSuccess is null) throw new ArgumentNullException(nameof(onSuccess));
        if (onFailure is null) throw new ArgumentNullException(nameof(onFailure));

        if (IsSuccess)
            onSuccess();
        else
            onFailure(Error);
    }

    public TResult Match<TResult>(Func<TResult> onSuccess, Func<Error, TResult> onFailure)
    {
        if (onSuccess is null) throw new ArgumentNullException(nameof(onSuccess));
        if (onFailure is null) throw new ArgumentNullException(nameof(onFailure));

        return IsSuccess
            ? onSuccess()
            : onFailure(Error);
    }

    public Result<T> Map<T>(Func<T> func)
    {
        if (func is null) throw new ArgumentNullException(nameof(func));

        return IsSuccess
            ? Result<T>.Success(func())
            : Result<T>.Failure(Error);
    }
    public Result Map(Func<Result> func)
    {
        if (func is null) throw new ArgumentNullException(nameof(func));

        return IsSuccess
            ? func()
            : Failure(Error);
    }

    public Result Bind(Func<Result> func)
    {
        if (func is null) throw new ArgumentNullException(nameof(func));

        return IsSuccess
            ? func()
            : Result.Failure(Error);
    }

    public static Result Try(Action action)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        try
        {
            action();
            return Success();
        }
        catch (Exception ex)
        {
            return Failure(new Error(Code: ex.GetType().Name, Description: ex.Message));
        }
    }

}
