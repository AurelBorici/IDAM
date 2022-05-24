namespace Application.RequestModels.CommandRequestModel.Authentication;

public class RefreshTokenRequest
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }  
}
