using Microsoft.EntityFrameworkCore;
using Portafolio.Application.Abstractions.Database;
using Portafolio.Domain.Entities;

namespace Portafolio.Infrastructure.Database;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Users> Users { get; set; }
}