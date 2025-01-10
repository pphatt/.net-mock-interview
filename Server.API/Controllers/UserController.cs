using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Common.Dtos.Users;
using Server.Application.Features.UsersApp.Commands.CreateUser;
using Server.Application.Features.UsersApp.Commands.DeleteUser;
using Server.Application.Features.UsersApp.Commands.UpdateUser;
using Server.Application.Features.UsersApp.Queries.GetAllUser;
using Server.Application.Features.UsersApp.Queries.GetAllUsers;
using Server.Application.Features.UsersApp.Queries.GetUserById;

namespace Server.API.Controllers;

[ApiController]
[Route("/user")]
public class UserController : ControllerBase
{
    IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());

        if (users is null)
        {
            return NotFound();
        }

        return Ok(users);
    }

    [HttpGet]
    [Route("/users/{Id}")]
    public async Task<ActionResult<UserDto>> GetUserById([FromRoute] Guid Id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(Id));

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    [Route("/user")]
    public async Task<ActionResult> CreateUser([FromForm] CreateUserCommand command)
    {
        await _mediator.Send(command);

        return Created(string.Empty, "Create new user successfully.");
    }

    [HttpDelete]
    [Route("/user/{Id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] DeleteUserCommand command)
    {
        await _mediator.Send(command);

        return Ok("Deleted user successfully.");
    }

    [HttpPatch]
    [Route("/user")]
    public async Task<ActionResult> UpdateUser([FromForm] UpdateUserCommand command)
    {
        await _mediator.Send(command);

        return Ok("Update user successfully.");
    }
}
