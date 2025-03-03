using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;
using XUnitAndVerifyTests.Services;

namespace XUnitAndVerifyTests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services) =>
        services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Debug).AddXunitOutput())
            .AddScoped<ICustomDependency, CustomDependency>();

    public void Configure(IServiceProvider provider, ITestOutputHelperAccessor accessor)
    {
        Assert.NotNull(provider);
        Assert.NotNull(accessor);
    }
}