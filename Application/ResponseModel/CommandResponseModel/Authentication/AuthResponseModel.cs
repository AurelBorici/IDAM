using System.Text.Json.Serialization;

namespace Application.ResponseModel.CommandResponseModel.Authentication;

public class AuthResponseModel
{
    public string? Token { get; set; }
    public DateTime? ExpirationTime { get; set; }
    public bool IsEmailConfirmed { get; set; }
    [JsonIgnore]
    public string? RefreshToken { get; set; }
}

public class AuthRefreshToken
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpirationTime { get; set; }

}
