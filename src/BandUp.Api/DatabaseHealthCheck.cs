using BandUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BandUp.Api;

public sealed class DatabaseHealthCheck(BandUpDbContext dbContext) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await dbContext.Database.CanConnectAsync(cancellationToken)
                ? HealthCheckResult.Healthy()
                : HealthCheckResult.Unhealthy("Database connection failed.");
        }
        catch (Exception exception)
        {
            return HealthCheckResult.Unhealthy("Database readiness check failed.", exception);
        }
    }
}
