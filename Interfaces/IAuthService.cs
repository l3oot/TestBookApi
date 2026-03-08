using TestBookApi.DTOs;

namespace TestBookApi.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto dto);

    Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto);
}
