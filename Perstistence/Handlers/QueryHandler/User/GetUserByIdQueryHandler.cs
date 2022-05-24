using Application.RequestModels.QueryRequestModel.User;
using Application.ResponseModel.QueryResponseModel.User;
using AutoMapper;
using Dapper;
using Infrastructure.ExceptionHandler;
using MediatR;
using MigrationMSSQL;
using Perstistence.Dapper;

namespace Perstistence.Handlers.QueryHandler.User;

internal class GetUserByIdQueryHandler : BaseHandler, IRequestHandler<GetUserByIdRequestModel, GetUserByIdResponseModel>
{
    public GetUserByIdQueryHandler(IDapperConnectionProvider dapperConnectionProvider, IDAMContext idamContext, IMapper mapper)
        : base(dapperConnectionProvider, idamContext, mapper)
    {
    }

    public async Task<GetUserByIdResponseModel> Handle(GetUserByIdRequestModel request, CancellationToken cancellationToken)
    {
        using var connention = _dapperConnectionProvider.GetDbConnection();
        var param = new { Id = request.Id };
        var query = @"Select * from [Users] Where Id = @Id";
        connention.Open();
        try
        {
            return await connention.QueryFirstAsync<GetUserByIdResponseModel>(query, param);
        }
        catch
        {
            throw new ThrowException($"User with id \"'{request.Id}'\" does not exists!");
        }
    }
}
