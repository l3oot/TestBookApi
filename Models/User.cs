using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestBookApi.Models;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("username")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [Column("password")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [MaxLength(40)]
    [Column("fullname")]
    public string Fullname { get; set; } = string.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property
    public virtual ICollection<UserLike> UserLikes { get; set; } = new List<UserLike>();
}