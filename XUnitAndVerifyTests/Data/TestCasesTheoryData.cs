using XUnitAndVerifyTests.Entities;

namespace XUnitAndVerifyTests.Data;

public class TestCasesTheoryData : TheoryData<TestCase>
{
    public TestCasesTheoryData()
    {
        foreach (var testCase in TestsDataConstants.TestItems)
        {
            var theoryDataRow = new TheoryDataRow<TestCase>(testCase)
            {
                TestDisplayName = $"Custom: {testCase.UserFirstName} {testCase.NestedData.Id}"
            };
            
            Add(theoryDataRow);
        }
    }
}