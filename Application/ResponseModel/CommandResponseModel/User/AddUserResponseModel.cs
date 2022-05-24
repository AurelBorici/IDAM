namespace Application.ResponseModel.CommandResponseModel.User;

public class AddUserResponseModel
{
    public Guid Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
    public DateTime Birthday { get; set; }
    public string? Username { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedTime { get; set; }
    public bool IsActive { get; set; }
    public Guid RoleId { get; set; }
}
