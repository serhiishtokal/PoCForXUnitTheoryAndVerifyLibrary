using XUnitAndVerifyTests.Entities;

namespace XUnitAndVerifyTests.Data;

public class TestCasesTheoryData : TheoryData<TestCase>
{
    public TestCasesTheoryData()
    {
        foreach (var testCase in TestsDataConstants.TestCases)
        {
            var theoryDataRow = new TheoryDataRow<TestCase>(testCase)
            {
                TestDisplayName = $"CustomName: {testCase.UserFirstName} {testCase.NestedData.Id}"
            };
            
            Add(theoryDataRow);
        }
    }
}