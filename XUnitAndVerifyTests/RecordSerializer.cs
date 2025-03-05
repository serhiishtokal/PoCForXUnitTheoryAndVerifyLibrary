using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Xunit.Sdk;

namespace XUnitAndVerifyTests;

public class RecordSerializer : IXunitSerializer
{
    public bool IsSerializable(Type type, object? value, [NotNullWhen(false)] out string? failureReason)
    {
        if (IsRecordType(type))
        {
            failureReason = null;
            return true;
        }
        failureReason = $"Type {type.FullName} is not recognized as a record.";
        return false;
    }

    public string Serialize(object value)
    {
        return JsonSerializer.Serialize(value);
    }

    public object Deserialize(Type type, string serializedValue)
    {
        return JsonSerializer.Deserialize(serializedValue, type)!;
    }

    public static bool IsRecordType(Type type)
    {
        return type.GetMethods().Any(m => m.Name == "<Clone>$") && 
               type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEquatable<>));
    }
}