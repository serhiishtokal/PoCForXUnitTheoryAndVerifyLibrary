using XUnitAndVerifyTests.Entities;

namespace XUnitAndVerifyTests.Data;

public class XUnitNotSerializableItemTheoryData : TheoryData<XUnitNotSerializableTestItem>
{
    public XUnitNotSerializableItemTheoryData()
    {
        foreach (var testCase in TestsDataConstants.XUnitNotSerializableTestItems)
        {
            var theoryDataRow = new TheoryDataRow<XUnitNotSerializableTestItem>(testCase)
            {
                TestDisplayName = $"Custom: {testCase.UserFirstName} {testCase.NestedData.Id}"
            };
            
            Add(theoryDataRow);
        }
    }
}