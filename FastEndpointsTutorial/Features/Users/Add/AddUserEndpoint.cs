using FastEndpointsTutorial.Features.Users.Add.Requests;
using FastEndpointsTutorial.Features.Users.Add.Responses;
using FastEndpointsTutorial.Features.Users.Mappers;
using MongoDB.Entities;

namespace FastEndpointsTutorial.Features.Users.Add;

public class AddUserEndpoint : Endpoint<AddUserRequest, AddUserResponse, UserMapper>
{
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/users/add");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(AddUserRequest r, CancellationToken c)
    {
        await Map.FromEntity(r).SaveAsync(cancellation: c);
;       await SendAsync(new AddUserResponse
        {
            Message = $"Hazza! - {r.FirstName} {r.LastName} has now been added"
        }, cancellation: c);
    }
}