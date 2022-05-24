using Application.RequestModels.CommandRequestModel.Role;
using Application.ResponseModel.CommandResponseModel.Role;
using AutoMapper;
using Domain.Models;
using MediatR;
using MigrationMSSQL;
using Perstistence.Dapper;

namespace Perstistence.Handlers.CommandHandler.Rolesp;

internal class AddRoleCommandHandler : BaseHandler, IRequestHandler<AddRoleRequestModel, AddRoleResponseModel>
{
    public AddRoleCommandHandler(IDapperConnectionProvider dapperConnectionProvider, IDAMContext idamContext, IMapper mapper)
        : base(dapperConnectionProvider, idamContext, mapper)
    {
    }

    public async Task<AddRoleResponseModel> Handle(AddRoleRequestModel request, CancellationToken cancellationToken)
    {
        _idamContext.Roles.Add(_mapper.Map<Role>(request));
        _idamContext.SaveChanges();
        return await Task.FromResult(_mapper.Map<AddRoleResponseModel>(request));
    }
}
