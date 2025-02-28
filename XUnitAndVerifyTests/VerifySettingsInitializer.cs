﻿using System.Runtime.CompilerServices;

namespace XUnitAndVerifyTests;

public static class VerifySettingsInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifierSettings.UseStrictJson();
        VerifierSettings.AutoVerify();
    }
}