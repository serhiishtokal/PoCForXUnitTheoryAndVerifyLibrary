namespace XUnitAndVerifyTests.Entities;

public record TestCase(string UserFirstName, TestNestedCase NestedData);
public record TestNestedCase(int Id, string Description);