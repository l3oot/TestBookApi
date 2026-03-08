using Microsoft.AspNetCore.Mvc;
using TestBookApi.DTOs;
using TestBookApi.Enums;
using TestBookApi.Interfaces;

namespace TestBookApi.Controllers;

[ApiController]
[Route("api/user")]
public class UserLikesController : ControllerBase
{
    private readonly IUserLikeService _userLikeService;
    private readonly ILogger<UserLikesController> _logger;

    public UserLikesController(IUserLikeService userLikeService, ILogger<UserLikesController> logger)
    {
        _userLikeService = userLikeService;
        _logger = logger;
    }

    [HttpPost("like")]
    public async Task<IActionResult> Like([FromBody] UserLikeRequestDto dto)
    {
        try
        {
            await _userLikeService.AddLikeAsync(dto);
            return Ok(new { message = "Like saved." });
        }
        catch (InvalidOperationException ex)
        {
            if (ex.Message.StartsWith("Already liked", StringComparison.OrdinalIgnoreCase))
                return Conflict(ErrorResponseDto.Create(TypeError.Conflict, ex.Message));
            return NotFound(ErrorResponseDto.Create(TypeError.NotFound, ex.Message));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Like error");
            return StatusCode(500, ErrorResponseDto.Create(TypeError.InternalError, "An error occurred."));
        }
    }
}
