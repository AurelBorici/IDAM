using Application.ResponseModel.CommandResponseModel.Authentication;
using MediatR;

namespace Application.RequestModels.CommandRequestModel.Authentication;

public class AuthRequestModel : IRequest<AuthResponseModel>
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
