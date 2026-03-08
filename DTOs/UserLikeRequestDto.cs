using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestBookApi.DTOs;

public class UserLikeRequestDto
{
    [JsonPropertyName("user_id")]
    [Required(ErrorMessage = "user_id is required")]
    public Guid UserId { get; set; }

    [JsonPropertyName("book_id")]
    [Required(ErrorMessage = "book_id (isbn13) is required")]
    public string BookId { get; set; } = string.Empty;
}
