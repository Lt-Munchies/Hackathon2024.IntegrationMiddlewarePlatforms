using System.Net;
using Flurl.Http;
using Polly;
using Polly.Retry;

namespace Hackathorn2024.Server.Clients;

public abstract class BaseHttpClient(ILogger<BaseHttpClient> logger, HttpClient client)
{
    private readonly ILogger<BaseHttpClient> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    internal readonly HttpClient Client = client ?? throw new ArgumentNullException(nameof(client));

    internal async Task<TResult> WrapRetryRequestAsync<TResult>(Func<FlurlClient, Task<TResult>> execute)
    {
        var retryPolicy = GetRetryPolicy();

        return await retryPolicy.ExecuteAsync(() => execute.Invoke(new FlurlClient(Client)));
    }

    internal AsyncRetryPolicy GetRetryPolicy()
    {
        return Policy
            .Handle<FlurlHttpException>(IsTransientError)
            .WaitAndRetryAsync(5,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)), onRetry:
                (exception, span) =>
                {
                    _logger.LogError(exception, "Failed to execute request. Retrying in {TotalSeconds}s",
                        span.TotalSeconds);
                });
    }

    private static bool IsTransientError(FlurlHttpException exception)
    {
        var httpStatusCodesWorthRetrying = new[]
        {
            (int) HttpStatusCode.RequestTimeout, // 408
            (int) HttpStatusCode.BadGateway, // 502
            (int) HttpStatusCode.ServiceUnavailable, // 503
            (int) HttpStatusCode.GatewayTimeout // 504
        };

        return exception.StatusCode.HasValue && httpStatusCodesWorthRetrying.Contains(exception.StatusCode.Value);
    }
}