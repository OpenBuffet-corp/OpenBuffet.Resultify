#define SAMPLE_1
#define SAMPLE_2
#define SAMPLE_3
#define SAMPLE_4
#define SAMPLE_5


using Resultify.Core.Models;
using Resultify.Core.ValueObjects;

#if SAMPLE_1 

Result sample1Result = Result.Success();

if (sample1Result.IsSuccess)
    Console.WriteLine("sample 1 success");

#endif

#if SAMPLE_2 

Error sample2error = new Error("Sample.2.Code", "Sample 2 error description");

Result sample2Result = Result.Failure(sample2error);

if (sample2Result.IsFailure)
    Console.WriteLine($"sample 2 failure | code: {sample2Result.Error.Code}, description: {sample2Result.Error.Description}");

#endif

#if SAMPLE_3

Result<int> sample3Result = Result<int>.Success(1);

if (sample3Result.IsSuccess)
    Console.WriteLine($"sample 3 success | value:{sample3Result.Value}");

#endif

#if SAMPLE_4

Error sample4error = new Error("Sample.4.Code", "Sample 4 error description");

Result<int> sample4Result = Result<int>.Failure(sample4error);

if (sample4Result.IsFailure)
    Console.WriteLine($"sample 4 failure | code: {sample4Result.Error.Code}, description: {sample4Result.Error.Description}");

#endif

#if SAMPLE_5

Result<int>
    .Try(() => { throw new DivideByZeroException(); })
    .Match(
        success => Console.WriteLine($"success: {success}"),
        failure => Console.WriteLine($"failure: {failure.Description}")
    );

#endif