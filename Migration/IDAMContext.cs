using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration;

public class IDAMContext : DbContext
{
    DbSet<User>? Users { get; set; }
    DbSet<Role>? Roles { get; set; }

    public IDAMContext(DbContextOptions<IDAMContext> options) : base(options)
    {
    }

}
