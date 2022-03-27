using AutoMapper;
using FastEndpointsTutorial.Entities;
using FastEndpointsTutorial.Features.Users.Add.Requests;
using FastEndpointsTutorial.Features.Users.Add.Responses;

namespace FastEndpointsTutorial.Features.Users.Mappers;

public class UserMapper : Mapper<AddUserRequest, AddUserResponse, User>
{
    private readonly IMapper _mapper;
    
    public UserMapper()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            // create your own locally
            cfg.CreateMap<AddUserRequest, User>();
        });
        _mapper = configuration.CreateMapper();
    }
    
    public User FromEntity(AddUserRequest r) => _mapper.Map<User>(r);
}