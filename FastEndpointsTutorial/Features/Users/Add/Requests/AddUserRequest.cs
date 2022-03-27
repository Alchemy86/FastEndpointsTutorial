namespace FastEndpointsTutorial.Features.Users.Add.Requests;

public class AddUserRequest
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }
}