using System.ComponentModel.DataAnnotations;

namespace TestBookApi.DTOs;

public class RegisterRequestDto
{
    [Required(ErrorMessage = "username is required")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "password is required")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "fullname is required")]
    public string Fullname { get; set; } = string.Empty;
}
