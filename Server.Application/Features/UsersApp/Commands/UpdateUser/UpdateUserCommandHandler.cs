using AutoMapper;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Server.Application.Common.Interfaces.Persistence;

namespace Server.Application.Features.UsersApp.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    ILogger<UpdateUserCommandHandler> _logger;
    IMapper _mapper;
    IUserRepository _userRepository;

    public UpdateUserCommandHandler(ILogger<UpdateUserCommandHandler> logger, IMapper mapper, IUserRepository userRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }


    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id);
        _logger.LogInformation("Before updated user details: {@User}", user);

        if (user is null) throw new Exception("User not found.");


        user.Username = request.Username;
        user.Dob = request.Dob;

        user.DateUpdated = DateTime.UtcNow;

        await _userRepository.CompleteAsync();

        _logger.LogInformation("After updated user details: {@User}", user);
    }
}
