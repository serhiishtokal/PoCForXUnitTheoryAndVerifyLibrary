namespace XUnitAndVerifyTests.Entities;

public record TestCase(string UserFirstName, NestedData NestedData);

public record NestedData(int Id, string Description);