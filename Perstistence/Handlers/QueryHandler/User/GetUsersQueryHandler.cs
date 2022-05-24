using Application.RequestModels.QueryRequestModel.User;
using Application.ResponseModel.QueryResponseModel.User;
using AutoMapper;
using Dapper;
using MediatR;
using MigrationMSSQL;
using Perstistence.Dapper;

namespace Perstistence.Handlers.QueryHandler.User;

internal class GetUsersQueryHandler : BaseHandler, IRequestHandler<GetUsersRequestModel, List<GetUsersResponseModel>>
{
    public GetUsersQueryHandler(IDapperConnectionProvider dapperConnectionProvider, IDAMContext idamContext, IMapper mapper) 
        : base(dapperConnectionProvider, idamContext, mapper)
    {
    }


    public async Task<List<GetUsersResponseModel>> Handle(GetUsersRequestModel request, CancellationToken cancellationToken)
    {
        using var connection = _dapperConnectionProvider.GetDbConnection();
        connection.Open();
        var query = "Select Id, Firstname, Lastname, Username, Email, LoginTime from [Users]";
        var result = await connection.QueryAsync<GetUsersResponseModel>(query);
        connection.Close();
        return result.ToList();
    }
}
