using Application.RequestModels.CommandRequestModel.User;
using Application.RequestModels.QueryRequestModel.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IDAM.API.Controllers;

public class UserController : BaseController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("add")]
    public IActionResult CreateUser([FromBody] AddUserRequestModel user)
            => Ok(_mediator.Send(user).Result);

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetUserById([FromRoute] Guid id)
            => Ok(_mediator.Send(new GetUserByIdRequestModel { Id = id }).Result);


    [HttpGet]
    [Route("users")]
    public IActionResult GetUsers()
            => Ok(_mediator.Send(new GetUsersRequestModel()).Result);


}
