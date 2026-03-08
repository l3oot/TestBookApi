using Microsoft.EntityFrameworkCore;
using TestBookApi.Data;
using TestBookApi.DTOs;
using TestBookApi.Interfaces;
using TestBookApi.Models;

namespace TestBookApi.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _db;

    public AuthService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto dto)
    {
        var exists = await _db.Users.AnyAsync(u => u.Username == dto.Username);
        if (exists)
            return null;

        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = dto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Fullname = dto.Fullname,
            CreatedAt = DateTime.UtcNow
        };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return new AuthResponseDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Fullname = user.Fullname
        };
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto)
    {
        var user = await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == dto.Username);
        if (user == null)
            return null;

        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            return null;

        return new AuthResponseDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Fullname = user.Fullname
        };
    }
}
