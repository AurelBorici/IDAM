using Application.ResponseModel.QueryResponseModel.User;
using MediatR;

namespace Application.RequestModels.QueryRequestModel.User;

public class GetUserByUsernameRequestModel : IRequest<GetUserByUsernameResponseModel>
{
    public string? Username { get; set; }

}
