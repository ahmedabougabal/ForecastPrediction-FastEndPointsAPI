using FastEndpoints;

namespace fastEndPointsAPIs;

public class ExampleEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        // configure here what this endpoint looks like 
        Verbs(Http.GET);
        Routes("example");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new { message = "Hello, World :) " }, cancellation: ct);
    }
    
}