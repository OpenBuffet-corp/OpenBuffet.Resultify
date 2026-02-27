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

}
