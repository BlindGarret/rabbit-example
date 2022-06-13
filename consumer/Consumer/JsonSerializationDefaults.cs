using System.Text.Json;

namespace Consumer;

public static class JsonSerializationDefaults
{
    public static JsonSerializerOptions DefaultOptions => new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
}