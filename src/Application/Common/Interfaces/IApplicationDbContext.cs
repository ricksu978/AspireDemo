using AspireDemo.Domain.Heroes;
using AspireDemo.Domain.Teams;

namespace AspireDemo.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Hero> Heroes { get; }
    DbSet<Team> Teams { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}