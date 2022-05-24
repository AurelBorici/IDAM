using Application.RequestModels.CommandRequestModel.Role;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDAM.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RoleController : BaseController
{
    public RoleController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("add")]
    public IActionResult AddRole(AddRoleRequestModel role)
        => Ok(_mediator.Send(role).Result);
}
