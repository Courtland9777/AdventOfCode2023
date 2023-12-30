using AdventOfCode2023.Helpers;
using AdventOfCode2023.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new HostBuilder().ConfigureServices((hostContext, services) => { services.ConfigureSolutionManager(); });
var host = builder.Build();

var solutionManager = host.Services.GetServices<ISolutionManager>().FirstOrDefault();

const int day = 21;

var solver = solutionManager?.GetSolution(day);

Console.WriteLine(solver?.PartOne());
Console.WriteLine(solver?.PartTwo());