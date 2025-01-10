using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Dtos.Users;
using Server.Application.Common.Interfaces.Persistence;

namespace Server.Application.Features.UsersApp.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    ILogger<GetUserByIdQueryHandler> _logger;
    IMapper _mapper;
    IUserRepository _userRepository;

    public GetUserByIdQueryHandler(ILogger<GetUserByIdQueryHandler> logger, IMapper mapper, IUserRepository userRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id);

        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }
}
