using Application.RequestModels.CommandRequestModel.Authentication;
using Application.RequestModels.QueryRequestModel.User;
using Application.ResponseModel.CommandResponseModel.Authentication;
using Application.Settings.JWT;
using Infrastructure.ExceptionHandler;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Infrastructure.Identity.Authentication.CommandsHandler;

public class AuthenticationCommand : IRequestHandler<AuthRequestModel, AuthResponseModel>
{
    private readonly JWTSettings _jwtSettings;
    private readonly IMediator _mediator;

    public AuthenticationCommand(IOptions<JWTSettings> jwtSettings, IMediator mediator)
    {
        _jwtSettings=jwtSettings.Value;
        _mediator=mediator;
    }

    public async Task<AuthResponseModel> Handle(AuthRequestModel request, CancellationToken cancellationToken)
    {
        var login = await VerifyLogin(request);
        if (login)
        {
            JwtSecurityToken jwtSecurityToken = GenerateJWToken();
            AuthResponseModel response = new();
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.ExpirationTime =  DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes);
            response.IsEmailConfirmed = false;
            return response;
        }
        else
        {
            throw new Exception();
        }

    }

    private JwtSecurityToken GenerateJWToken()
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = JwtToken(signingCredentials);
        return jwtSecurityToken;
    }

    private JwtSecurityToken JwtToken(SigningCredentials signingCredentials)
        => new(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            ///claims: 
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
            );


    private async Task<bool> VerifyLogin(AuthRequestModel request)
    {
        GetUserByUsernameRequestModel getUserByUsername = new();
        getUserByUsername.Username = request.Username;
        try
        {
            var user = await _mediator.Send(getUserByUsername);
            bool verified = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            if (verified)
            {
                return true;
            }
            else
                throw new ThrowException("There was a problem logging in. Check your username and password!");
        }
        catch
        {
            throw new ThrowException("There was a problem logging in. Check your username and password!");

        }
    }
}
