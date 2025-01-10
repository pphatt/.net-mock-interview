using MediatR;
using Server.Application.Common.Dtos.Users;

namespace Server.Application.Features.UsersApp.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}
