using Application.RequestModels.QueryRequestModel.User;
using Application.ResponseModel.QueryResponseModel.User;
using AutoMapper;
using Dapper;
using Infrastructure.ExceptionHandler;
using MediatR;
using MigrationMSSQL;
using Perstistence.Dapper;

namespace Perstistence.Handlers.QueryHandler.User;

internal class GetUserByUsernameQueryHandler : BaseHandler, IRequestHandler<GetUserByUsernameRequestModel, GetUserByUsernameResponseModel>
{
    public GetUserByUsernameQueryHandler(IDapperConnectionProvider dapperConnectionProvider, IDAMContext idamContext, IMapper mapper) 
        : base(dapperConnectionProvider, idamContext, mapper)
    {
    }

    public async Task<GetUserByUsernameResponseModel> Handle(GetUserByUsernameRequestModel request, CancellationToken cancellationToken)
    {
        using var connection = _dapperConnectionProvider.GetDbConnection();
        var param = new { Username = request.Username };
        var query = @"Select * from [Users] Where Username = @Username";
        connection.Open();
        try
        {
            return await connection.QueryFirstAsync<GetUserByUsernameResponseModel>(query, param);
        }
        catch
        {
            throw new ThrowException($"User '{request.Username}' does not exists!");
        }
    }
}
