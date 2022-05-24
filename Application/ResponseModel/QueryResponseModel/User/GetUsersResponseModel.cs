namespace Application.ResponseModel.QueryResponseModel.User;

public class GetUsersResponseModel
{
    public Guid Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public DateTime LoginTime { get; set; }
}
