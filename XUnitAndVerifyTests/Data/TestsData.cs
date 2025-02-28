using XUnitAndVerifyTests.Entities;

namespace XUnitAndVerifyTests.Data;

public static class TestsDataConstants
{
    public static readonly IEnumerable<TestCase> TestCases =
    [
        new("TestCase1", new TestNestedCase(1, "Description1")),
        new("TestCase2", new TestNestedCase(2, "Description2")),
        new("TestCase3", new TestNestedCase(3, "Description3"))
    ];
}