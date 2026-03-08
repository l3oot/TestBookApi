using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestBookApi.Models;

[Table("user_likes")]
public class UserLike
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Required]
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("isbn13")]
    public string Isbn13 { get; set; } = string.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}
