using Microsoft.AspNetCore.Mvc;
using TestBookApi.DTOs;
using TestBookApi.Enums;
using TestBookApi.Interfaces;

namespace TestBookApi.Controllers;

[ApiController]
[Route("api")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        try
        {
            var result = await _authService.LoginAsync(dto);
            if (result == null)
                return Unauthorized(ErrorResponseDto.Create(TypeError.InvalidCredential, "Invalid username or password."));
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Login error");
            return StatusCode(500, ErrorResponseDto.Create(TypeError.InternalError, "An error occurred."));
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    {
        try
        {
            var result = await _authService.RegisterAsync(dto);
            if (result == null)
                return Conflict(ErrorResponseDto.Create(TypeError.Conflict, "Username already exists."));
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Register error");
            return StatusCode(500, ErrorResponseDto.Create(TypeError.InternalError, "An error occurred."));
        }
    }
}
