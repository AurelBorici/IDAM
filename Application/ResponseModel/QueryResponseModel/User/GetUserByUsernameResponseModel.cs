namespace Application.ResponseModel.QueryResponseModel.User;

public class GetUserByUsernameResponseModel
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public bool IsEmailConfirmed { get; set; }

}
