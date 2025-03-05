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
    
    //////// VERIFY ASSERTING ////////
    // Ran in [Rider], Verify does not recognize IXunitSerializer for TestCase,
    // causing it to use the same file name for all test cases, which results in test failures.
    ////////
    // It's not recommended to use Verify for complex objects without custom file name specifying,
    // due to the fact that Verify can use too long file names, which cannot be staged in git for Windows.
    // limit is 260 characters
    // https://stackoverflow.com/questions/22575662/filename-too-long-in-git-for-windows#:~:text=Git%20has%20a%20limit%20of,260%20characters%20for%20a%20filename.
    [Theory]
    [ClassData(typeof(TestCasesTheoryData))]
    public async Task UseDefaultFileName(TestCase testCase)
    {
        Assert.NotNull(testCase);
        await Verify(testCase)
            .UseCustomDirectory();
    }
    
    //////// DISPLAYING ////////
    //// [Visual Studio Test Explorer] with [Microsoft.Testing.Platform] console displays this as a single test in the test explorer.
    //// Until a custom `IXunitSerializer` is used for `XUnitNotSerializableTestItem`,
    //// [Rider] will display this as multiple tests in the test explorer.
    //// [Microsoft.Testing.Platform] also displays this as a single test in the test explorer.
    
    //////// VERIFY ASSERTING ////////
    /// [Visual Studio Test Explorer] with [Microsoft.Testing.Platform] and [Rider]:
    /// `Verify` will create a single file for all test cases, so only the first test case will be verified properly,
    /// while the others will fail.
    [Theory]
    [ClassData(typeof(XUnitNotSerializableItemTheoryData))]
    public async Task UseDefaultFileNameNotSerializableTestItem(XUnitNotSerializableTestItem testItem)
    {
        Assert.NotNull(testItem);
        if (testItem.UserFirstName == "NsTest1")
        {
            await Verify(testItem)
                .UseCustomDirectory();
        }
        else
        {
            await Assert.ThrowsAnyAsync<Exception>(() => 
                Verify(testItem).UseCustomDirectory());
        }
    }
    
    // verified.json file names are too long for git staging
    [Theory]
    [ClassData(typeof(TestCasesTheoryData))]
    public async Task UseParameters(TestCase testCase)
    {
        var isRecord = RecordSerializer.IsRecordType(typeof(TestCase));
        Assert.True(isRecord);
        Assert.NotNull(testCase);

        await Verify(testCase)
            .UseCustomDirectory()
            .UseParameters(testCase);
    }
}