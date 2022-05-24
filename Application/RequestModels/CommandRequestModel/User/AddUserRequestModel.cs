using Application.ResponseModel.CommandResponseModel.User;
using MediatR;

namespace Application.RequestModels.CommandRequestModel.User;

public class AddUserRequestModel : IRequest<AddUserResponseModel>
{
    public Guid Id { get => Guid.NewGuid(); }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public DateTime Birthday { get; set; }
    public string? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedTime { get => DateTime.Now; }
    public bool IsActive { get => true; }
    public Guid RoleId { get; set; }
}
