using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BandUp.Infrastructure.Persistence;

public sealed class BandUpDbContextFactory : IDesignTimeDbContextFactory<BandUpDbContext>
{
    public BandUpDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__Database")
            ?? throw new InvalidOperationException("ConnectionStrings__Database is required for migrations.");

        var options = new DbContextOptionsBuilder<BandUpDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new BandUpDbContext(options);
    }
}
