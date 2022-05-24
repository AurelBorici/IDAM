using Application.RequestModels.CommandRequestModel.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IDAM.API.Controllers;

public class AuthenticationController : BaseController
{
    public AuthenticationController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public IActionResult Authenticate([FromBody] AuthRequestModel auth)
        =>Ok(_mediator.Send(auth).Result);
}
