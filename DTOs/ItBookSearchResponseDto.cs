using System.Text.Json.Serialization;

namespace TestBookApi.DTOs;

public class ItBookSearchResponseDto
{
    [JsonPropertyName("books")]
    public List<BookDto> Books { get; set; } = new();
}
