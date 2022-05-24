using Application.RequestModels.CommandRequestModel.User;
using Application.ResponseModel.CommandResponseModel.User;
using AutoMapper;
using Dapper;
using Domain.Models;
using Infrastructure.ExceptionHandler;
using MediatR;
using MigrationMSSQL;
using Perstistence.Dapper;

namespace Perstistence.Handlers.CommandHandler.Users;

internal class AddUserCommandHandler : BaseHandler, IRequestHandler<AddUserRequestModel, AddUserResponseModel>
{
    public AddUserCommandHandler(IDapperConnectionProvider dapperConnectionProvider, IDAMContext idamContext, IMapper mapper)
        : base(dapperConnectionProvider, idamContext, mapper)
    {
    }

    public async Task<AddUserResponseModel> Handle(AddUserRequestModel request, CancellationToken cancellationToken)
    {
        if (!await CheckIfUserExistsByUsername(request) && !await CheckIfUserExistsByEmail(request))
        {
            AddUserRequestModel user = NewUser(request);

            _idamContext.Users.Add(_mapper.Map<User>(user));
            _idamContext.SaveChanges();

            return _mapper.Map<AddUserResponseModel>(request);
        }
        else
            throw new ThrowException();
    }

    private static AddUserRequestModel NewUser(AddUserRequestModel request)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password).ToString();
        AddUserRequestModel user = new()
        {
            Username = request.Username,
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            Password = passwordHash,
            Email = request.Email,
            Birthday = request.Birthday,
            Gender = request.Gender,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            RoleId = request.RoleId
        };
        return user;
    }

    private Task<bool> CheckIfUserExistsByUsername(AddUserRequestModel request)
    {
        using var connection = _dapperConnectionProvider.GetDbConnection();

        var result = connection.ExecuteScalar<bool>("select count(1) from [Users] where Username = @Username", new { request.Username });
        if (result)
        {
            throw new ThrowException("User with this username already exists");
        }

        return Task.FromResult(result);

    }
    private Task<bool> CheckIfUserExistsByEmail(AddUserRequestModel request)
    {
        using var connection = _dapperConnectionProvider.GetDbConnection();

        var result = connection.ExecuteScalar<bool>("select count(1) from [Users] where Email = @Email", new { request.Email });

        if (result)
        {
            throw new ThrowException("User with this email already exists");
        }

        return Task.FromResult(result);
    }
}
