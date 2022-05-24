using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Role
{
    [Key]
    public Guid Id { get; set; }
    public string? RoleName { get; set; }

    public ICollection<User>? Users { get; set; }

}
