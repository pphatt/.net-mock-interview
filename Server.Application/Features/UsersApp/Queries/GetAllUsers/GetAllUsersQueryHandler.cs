using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Dtos.Users;
using Server.Application.Common.Interfaces.Persistence;
using Server.Application.Features.UsersApp.Queries.GetAllUser;

namespace Server.Application.Features.UsersApp.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    ILogger<GetAllUsersQueryHandler> _logger;
    IMapper _mapper;
    IUserRepository _userRepository;

    public GetAllUsersQueryHandler(ILogger<GetAllUsersQueryHandler> logger, IMapper mapper, IUserRepository userRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get All Users Here");
        var users = await _userRepository.GetAllAsync();

        var usersDto = _mapper.Map<List<UserDto>>(users);

        return usersDto;
    }
}
