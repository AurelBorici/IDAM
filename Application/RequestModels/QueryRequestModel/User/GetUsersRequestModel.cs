using Application.ResponseModel.QueryResponseModel.User;
using MediatR;

namespace Application.RequestModels.QueryRequestModel.User;

public class GetUsersRequestModel : IRequest<List<GetUsersResponseModel>>
{
}
