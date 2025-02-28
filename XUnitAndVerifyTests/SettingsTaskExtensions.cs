using XUnitAndVerifyTests.Entities;

namespace XUnitAndVerifyTests;

public static class SettingsTaskExtensions
{
     public static SettingsTask UseFileName(this SettingsTask settingsTask, TestCase testCase)
     {
         var fileName = ComputeShortHash(testCase.ToString());
         return settingsTask.UseFileName(fileName);
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