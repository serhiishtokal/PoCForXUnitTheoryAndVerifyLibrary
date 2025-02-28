using XUnitAndVerifyTests.Data;
using XUnitAndVerifyTests.Entities;

namespace XUnitAndVerifyTests;

public class UnitTest1
{
    [Theory]
    [ClassData(typeof(TestCasesTheoryData))]
    public async Task Test1(TestCase testCase)
    {
        Assert.NotNull(testCase);

        await Verify(testCase)
            .UseDirectory("Snapshots")
            .UseStrictJson()
            .UseFileName(testCase);
    }
    
    [Fact]
    public void Test2()
    {
        
        Assert.True(true);
    }
}