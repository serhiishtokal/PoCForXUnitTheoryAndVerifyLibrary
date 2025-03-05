using Xunit.Sdk;
using XUnitAndVerifyTests;
using XUnitAndVerifyTests.Entities;

[assembly: CaptureConsole]
[assembly: RegisterXunitSerializer(typeof(RecordSerializer), typeof(TestItem))]

// commented on purpose
//[assembly: RegisterXunitSerializer(typeof(RecordSerializer), typeof(JetBrainsTestCase))]