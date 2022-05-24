using Application.ResponseModel.CommandResponseModel.Role;
using MediatR;

namespace Application.RequestModels.CommandRequestModel.Role;

public class AddRoleRequestModel : IRequest<AddRoleResponseModel>
{
    public Guid Id { get => Guid.NewGuid(); }
    public string? RoleName { get; set; }

}
