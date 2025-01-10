using MediatR;
using Server.Application.Common.Dtos.Users;

namespace Server.Application.Features.UsersApp.Queries.GetAllUser;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
}
