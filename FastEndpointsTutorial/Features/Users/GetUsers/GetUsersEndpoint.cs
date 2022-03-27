using FastEndpointsTutorial.Entities;
using FastEndpointsTutorial.Features.Users.GetUsers.Responses;
using MongoDB.Driver;
using MongoDB.Entities;

namespace FastEndpointsTutorial.Features.Users.GetUsers;

public class GetUsersEndpoint : EndpointWithoutRequest<UsersResponse>
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/users");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var moons = await DB.Collection<User>().Find(_ => true).ToListAsync(cancellationToken: ct);

        await SendAsync(new UsersResponse
        {
            Users = moons
        }, cancellation: ct);
    }
}