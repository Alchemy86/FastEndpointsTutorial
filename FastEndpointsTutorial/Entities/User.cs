using MongoDB.Entities;

namespace FastEndpointsTutorial.Entities;

public class User: Entity
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }
}