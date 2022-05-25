using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MigrationMSSQL;

public class IDAMContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RefreshTokens> RefreshToken { get; set; }


    public IDAMContext(DbContextOptions<IDAMContext> options) : base(options)
    {
    }

}
