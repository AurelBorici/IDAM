using Application.ResponseModel.CommandResponseModel.User;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.RequestModels.CommandRequestModel.User;

public class AddUserRequestModel : IRequest<AddUserResponseModel>
{
    public Guid Id { get => Guid.NewGuid(); }
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    public DateTime Birthday { get; set; }
    public string? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    [Required]
    public string Password { get; set; }
    public DateTime CreatedTime { get => DateTime.Now; }
    public bool IsActive { get => true; }
    public Guid RoleId { get; set; }
}
