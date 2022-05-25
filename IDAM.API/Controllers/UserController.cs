using Application.RequestModels.CommandRequestModel.User;
using Application.RequestModels.QueryRequestModel.User;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDAM.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UserController : BaseController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] AddUserRequestModel user)
            => Ok(await _mediator.Send(user));

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
            => Ok(await _mediator.Send(new GetUserByIdRequestModel { Id = id }));

    [HttpGet]
    public async Task<IActionResult> GetUsers()
            => Ok(await _mediator.Send(new GetUsersRequestModel()));


}
