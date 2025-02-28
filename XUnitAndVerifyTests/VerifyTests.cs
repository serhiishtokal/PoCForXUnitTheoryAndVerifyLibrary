using XUnitAndVerifyTests.Data;
using XUnitAndVerifyTests.Entities;
using XUnitAndVerifyTests.Extensions;

namespace XUnitAndVerifyTests;

public class VerifyTests
{
    [Theory]
    [ClassData(typeof(TestCasesTheoryData))]
    public async Task UseCustomFileNameExtension(TestCase testCase)
    {
        Assert.NotNull(testCase);
        await Verify(testCase)
            .UseCustomDirectory()
            .UseCustomFileName(testCase);
    }
    
    // these tests will fail because the Verify uses the same file name for all test cases
    [Theory]
    [ClassData(typeof(TestCasesTheoryData))]
    public async Task UseDefaultFileName(TestCase testCase)
    {
        Assert.NotNull(testCase);

        await Verify(testCase).UseCustomDirectory();
    }
    
    // verified.json file names are too long for git staging
    [Theory]
    [ClassData(typeof(TestCasesTheoryData))]
    public async Task UseParameters(TestCase testCase)
    {
        Assert.NotNull(testCase);

        await Verify(testCase)
            .UseCustomDirectory()
            .UseParameters(testCase);
    }
}