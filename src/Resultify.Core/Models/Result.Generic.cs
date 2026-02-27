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

}
