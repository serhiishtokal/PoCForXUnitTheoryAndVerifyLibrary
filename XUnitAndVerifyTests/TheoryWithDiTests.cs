using Microsoft.Extensions.DependencyInjection;
using Xunit.DependencyInjection;
using XUnitAndVerifyTests.Services;

namespace XUnitAndVerifyTests;

public class TheoryWithDiTests
{
    private readonly ICustomDependency _dependency;

    public TheoryWithDiTests(ICustomDependency dependency)
    {
        _dependency = dependency;
    }


    [Theory]
    [MethodData(nameof(GetData))]
    public void ClassDataScopePerTheoryTest(ICustomDependency dependency, int count)
    {
        Assert.NotNull(dependency);
        Assert.NotNull(_dependency);
        Assert.NotEqual(dependency, _dependency);
        Assert.Equal(dependency.Id, count);
        dependency.Id++;
    }

    [Theory]
    [MemberData(nameof(GetScopedData))]
    public void ClassDataScopedTest([FromServices] ICustomDependency? dependency, int count)
    {
        Assert.NotNull(dependency);
        Assert.NotNull(_dependency);
        Assert.Equal(dependency, _dependency);
        Assert.Equal(0, dependency.Id);
        Console.WriteLine(count);
        Console.WriteLine(dependency.Id);
        dependency.Id++;
    }

    public static IEnumerable<TheoryDataRow<ICustomDependency, int>> GetData(IServiceProvider services) =>
        ActivatorUtilities.CreateInstance<MethodTheoryData>(services);

    public static IEnumerable<TheoryDataRow<ICustomDependency?, int>> GetScopedData()
    {
        yield return new(null, 0);
        yield return new(null, 1);
        yield return new(null, 2);
    }
}

public class MethodTheoryData : TheoryData<ICustomDependency, int>
{
    public MethodTheoryData(ICustomDependency customDependency)
    {
        Add(customDependency, 0);
        Add(customDependency, 1);
        Add(customDependency, 2);
    }
}

