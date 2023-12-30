using AdventOfCode2023.Interfaces;
using AdventOfCode2023.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2023.Helpers;

public static class ServiceExtensions
{
    public static void ConfigureSolutionManager(this IServiceCollection services) =>
        services.AddScoped<ISolutionManager, SolutionManager>();
}