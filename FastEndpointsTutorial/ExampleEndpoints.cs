namespace FastEndpointsTutorial;

public class ExampleEndpoints : EndpointWithoutRequest
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("example");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new
        {
            message = "Yo, Ive been hit"
        }, cancellation: ct);
    }
}