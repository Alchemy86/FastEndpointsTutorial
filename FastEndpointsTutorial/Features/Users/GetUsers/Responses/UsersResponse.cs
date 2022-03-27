using FastEndpointsTutorial.Entities;

namespace FastEndpointsTutorial.Features.Users.GetUsers.Responses;

public class UsersResponse
{
    public IEnumerable<User> Users { get; set; }
}