using System.Text.Json;

namespace Api;

public static class JsonSerializationDefaults
{
    public static JsonSerializerOptions DefaultOptions => new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
}