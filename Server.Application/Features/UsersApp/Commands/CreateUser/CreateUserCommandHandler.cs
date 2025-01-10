using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Identity;
using Server.Domain.Exceptions;

namespace Server.Application.Features.UsersApp.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    ILogger<CreateUserCommandHandler> _logger;
    IMapper _mapper;
    IUserRepository _userRepository;

    public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IMapper mapper, IUserRepository userRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.FindByEmailAsync(request.Email) is not null) 
        {
            throw new DuplicateEmailException();
        }

        var mappedUser = _mapper.Map<AppUser>(request);

        await _userRepository.CreateUserAsync(mappedUser);

        _logger.LogInformation("Created User: {@User}", mappedUser);
    }
}
