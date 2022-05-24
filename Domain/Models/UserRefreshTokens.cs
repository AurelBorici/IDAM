using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class UserRefreshTokens
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string RefreshToken { get; set; }
    public bool IsActive { get; set; } = true;
}
