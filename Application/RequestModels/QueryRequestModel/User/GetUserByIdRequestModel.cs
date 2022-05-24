using Application.ResponseModel.QueryResponseModel.User;
using MediatR;

namespace Application.RequestModels.QueryRequestModel.User;

public class GetUserByIdRequestModel : IRequest<GetUserByIdResponseModel>
{
    public Guid Id { get; set; }
}
