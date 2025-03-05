using System.Runtime.CompilerServices;
using DiffEngine;

namespace XUnitAndVerifyTests.Configuration;

public static class VerifySettingsInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifierSettings.UseStrictJson();
        DiffRunner.Disabled= true;
        
        // DiffTools.
        // VerifierSettings.AutoVerify();
    }
}