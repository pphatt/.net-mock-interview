using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Persistence;

namespace Server.Application.Features.UsersApp.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    ILogger<DeleteUserCommandHandler> _logger;
    IMapper _mapper;
    IUserRepository _userRepository;

    public DeleteUserCommandHandler(ILogger<DeleteUserCommandHandler> logger, IMapper mapper, IUserRepository userRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id);

        if (user is null) throw new Exception("User not found");

        await _userRepository.DeleteUserAsync(user);
    }
}
