using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Common.Dtos.Users;
using Server.Application.Features.UsersApp.Commands.CreateUser;
using Server.Application.Features.UsersApp.Commands.DeleteUser;
using Server.Application.Features.UsersApp.Commands.UpdateUser;
using Server.Application.Features.UsersApp.Queries.GetAllUser;
using Server.Application.Features.UsersApp.Queries.GetAllUsers;
using Server.Application.Features.UsersApp.Queries.GetUserById;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerOperation(Summary = "Get all the users", Description = "Get all the available users in the database.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    [SwaggerOperation(Summary = "Get the details of a specific user", Description = "Take a user id in order to retrieve.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CreateUser([FromForm] CreateUserCommand command)
    {
        await _mediator.Send(command);

        return Created(string.Empty, "Create new user successfully.");
    }

    [HttpDelete]
    [Route("/user/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteUser([FromRoute] DeleteUserCommand command)
    {
        await _mediator.Send(command);

        return Ok("Deleted user successfully.");
    }

    [HttpPatch]
    [Route("/user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateUser([FromForm] UpdateUserCommand command)
    {
        await _mediator.Send(command);

        return Ok("Update user successfully.");
    }
}
