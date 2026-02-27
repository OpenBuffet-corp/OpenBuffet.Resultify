# Samples

## Sample 1

```c#
using Resultify.Core.Models;
using Resultify.Core.ValueObjects;

Result result = Result.Success();

if (result.IsSuccess)
    Console.WriteLine("result success");
```

## Sample 2

```c#
using Resultify.Core.Models;
using Resultify.Core.ValueObjects;

Error error = new Error("Error.Code", " error description");

Result result = Result.Failure(error);

if (result.IsFailure)
    Console.WriteLine($"result failure | code: {result.Error.Code}, description: {result.Error.Description}");
```

## Sample 3

```c#
using Resultify.Core.Models;
using Resultify.Core.ValueObjects;

Result<int> result = Result<int>.Success(1);

if (result.IsSuccess)
    Console.WriteLine($"result success | value:{result.Value}");
```

## Sample 4

```c#
using Resultify.Core.Models;
using Resultify.Core.ValueObjects;

Error error = new Error("Error.Code", "error description");

Result<int> result = Result<int>.Failure(error);

if (result.IsFailure)
    Console.WriteLine($"result failure | code: {result.Error.Code}, description: {result.Error.Description}");
```

## Sample 5

```c#
using Resultify.Core.Models;
using Resultify.Core.ValueObjects;

Result<int>
    .Try(() => { throw new DivideByZeroException(); })
    .Match(
        success => Console.WriteLine($"success: {success}"),
        failure => Console.WriteLine($"failure: {failure.Description}")
    );
```