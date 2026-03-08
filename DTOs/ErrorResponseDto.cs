using System.Text.Json.Serialization;
using TestBookApi.Enums;

namespace TestBookApi.DTOs;

public class ErrorResponseDto
{
    [JsonPropertyName("type")]
    public TypeError Type { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    public static ErrorResponseDto Create(TypeError type, string message) =>
        new() { Type = type, Message = message};
}
