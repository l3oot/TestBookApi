using System.ComponentModel.DataAnnotations;

namespace TestBookApi.DTOs;

public class UserLikeRequestDto
{
    [Required(ErrorMessage = "user_id is required")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "book_id (isbn13) is required")]
    public string BookId { get; set; } = string.Empty;
}
