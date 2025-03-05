using XUnitAndVerifyTests.Entities;

namespace XUnitAndVerifyTests.Data;

public static class TestsDataConstants
{
    public static readonly IEnumerable<TestCase> TestItems =
    [
        new("Test1", new NestedData(1, "Descr1")),
        new("Test2", new NestedData(2, "Descr2")),
        new("Test3", new NestedData(3, "Descr3"))
    ];
    
    public static readonly IEnumerable<XUnitNotSerializableTestItem> XUnitNotSerializableTestItems =
    [
        new("NsTest1", new NestedData(1, "Descr1")),
        new("NsTest2", new NestedData(2, "Descr2")),
        new("NsTest3", new NestedData(3, "Descr3"))
    ];
}