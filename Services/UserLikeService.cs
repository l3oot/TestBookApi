using Microsoft.EntityFrameworkCore;
using TestBookApi.Data;
using TestBookApi.DTOs;
using TestBookApi.Interfaces;
using TestBookApi.Models;

namespace TestBookApi.Services;

public class UserLikeService : IUserLikeService
{
    private readonly AppDbContext _db;

    public UserLikeService(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddLikeAsync(UserLikeRequestDto dto)
    {
        var userExists = await _db.Users.AnyAsync(u => u.UserId == dto.UserId);
        if (!userExists)
            throw new InvalidOperationException($"User not found: {dto.UserId}");

        var bookId = dto.BookId.Trim();
        var alreadyLiked = await _db.UserLikes.AnyAsync(ul => ul.UserId == dto.UserId && ul.Isbn13 == bookId);
        if (alreadyLiked)
            throw new InvalidOperationException("Already liked this book.");

        var like = new UserLike
        {
            UserLikeId = Guid.NewGuid(),
            UserId = dto.UserId,
            Isbn13 = bookId,
            CreatedAt = DateTime.UtcNow
        };
        _db.UserLikes.Add(like);
        await _db.SaveChangesAsync();
    }
}
