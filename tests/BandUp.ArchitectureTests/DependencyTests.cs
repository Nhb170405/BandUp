using System.Reflection;
using BandUp.Contracts;
using BandUp.Infrastructure.Persistence;
using Xunit;

namespace BandUp.ArchitectureTests;

public sealed class DependencyTests
{
    [Fact]
    public void Contracts_do_not_reference_infrastructure_or_modules()
    {
        var references = typeof(AssemblyMarker).Assembly.GetReferencedAssemblies().Select(x => x.Name);

        Assert.DoesNotContain("BandUp.Infrastructure", references);
        Assert.DoesNotContain("BandUp.Modules", references);
    }

    [Fact]
    public void Shared_kernel_does_not_reference_infrastructure()
    {
        var assembly = Assembly.Load("BandUp.SharedKernel");
        var references = assembly.GetReferencedAssemblies().Select(x => x.Name);

        Assert.DoesNotContain(typeof(BandUpDbContext).Assembly.GetName().Name, references);
    }
}
