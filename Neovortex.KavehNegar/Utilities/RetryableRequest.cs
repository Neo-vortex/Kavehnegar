using System.Net;
using Neovortex.KavehNegar.Model;
using Polly;

namespace Neovortex.KavehNegar.Utilities;

public class RetryableRequest
{
    private readonly RetryOptions _retryOptions;

    public RetryableRequest(RetryOptions retryOptions)
    {
        _retryOptions = retryOptions;
    }

    public async Task<T> Invoke<T>(Func<Task<T>> action)
    {
        var retryPolicy = Policy
            .Handle<HttpRequestException>(ex =>
                ex.StatusCode != HttpStatusCode.NotFound) // Handle errors other than 404
            .WaitAndRetryAsync(_retryOptions.MaxTry, retryAttempt =>
                TimeSpan.FromMilliseconds(_retryOptions.WaitBetweenTriesMilliseconds)); // Retry with wait between tries

        return await retryPolicy.ExecuteAsync(action);
    }
}