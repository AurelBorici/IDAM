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
    public async Task<IActionResult> Authenticate([FromBody] AuthRequestModel auth)
        =>Ok(await _mediator.Send(auth));
}
