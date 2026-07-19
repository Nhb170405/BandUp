using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BandUp.Api.IntegrationTests;

public sealed class HealthCheckTests
{
    [Fact]
    public async Task Live_health_does_not_require_database()
    {
        const string variable = "ConnectionStrings__Database";
        var previousValue = Environment.GetEnvironmentVariable(variable);

        try
        {
            Environment.SetEnvironmentVariable(variable, "Host=127.0.0.1;Port=1;Database=none;Username=none;Password=none;Timeout=1");
            await using var factory = new WebApplicationFactory<Program>();
            using var client = factory.CreateClient();

            var response = await client.GetAsync("/health/live");

            response.EnsureSuccessStatusCode();
        }
        finally
        {
            Environment.SetEnvironmentVariable(variable, previousValue);
        }
    }
}
