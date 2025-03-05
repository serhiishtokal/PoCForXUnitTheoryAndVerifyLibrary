using XUnitAndVerifyTests.Entities;

namespace XUnitAndVerifyTests.Data;

public class TestItemTheoryData : TheoryData<TestItem>
{
    public TestItemTheoryData()
    {
        foreach (var testCase in TestsDataConstants.TestItems)
        {
            var theoryDataRow = new TheoryDataRow<TestItem>(testCase)
            {
                TestDisplayName = $"Custom: {testCase.UserFirstName} {testCase.NestedData.Id}"
            };
            
            Add(theoryDataRow);
        }
    }
}