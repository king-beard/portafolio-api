using Microsoft.EntityFrameworkCore;
using Portafolio.Domain.Entities;

namespace Portafolio.Application.Abstractions.Database;

public interface IApplicationDbContext
{
    DbSet<Users> Users { get; set; }
}