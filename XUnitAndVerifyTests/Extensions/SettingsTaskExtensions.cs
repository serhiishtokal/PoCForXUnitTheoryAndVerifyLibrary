using XUnitAndVerifyTests.Entities;

namespace XUnitAndVerifyTests.Extensions;

public static class SettingsTaskExtensions
{
    public static SettingsTask UseCustomFileName(this SettingsTask settingsTask, TestCase testCase)
    {
        var shortHash = ComputeShortHash(testCase.ToString());
        return settingsTask.UseTextForParameters(shortHash);
    }
    
    public static SettingsTask UseCustomDirectory(this SettingsTask settingsTask)
    {
        var directoryName = GenerateDirectoryName();
        return settingsTask.UseDirectory(directoryName);
    }
    
    private static string GenerateDirectoryName()
    {
        var testClassName = TestContext.Current.TestClass?.TestClassSimpleName;
        var testMethodName = TestContext.Current.TestMethod?.MethodName;
        return $"Snapshots/{testClassName}/{testMethodName}";
    }

    private static string ComputeShortHash(string input)
    {
        // Fowler–Noll–Vo prime and offset
        const uint fnvPrime = 16777619;
        const uint offsetBasis = 2166136261;

        var hash = offsetBasis;
        foreach (var c in input)
        {
            hash ^= c;
            hash *= fnvPrime;
        }

        // Return as 8-char hex (e.g. "2A3B4C5D")
        return hash.ToString("X8");
    }
}