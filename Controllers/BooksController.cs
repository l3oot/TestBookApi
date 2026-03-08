using Microsoft.AspNetCore.Mvc;
using TestBookApi.DTOs;
using TestBookApi.Enums;
using TestBookApi.Interfaces;

namespace TestBookApi.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ILogger<BooksController> _logger;

    public BooksController(IBookService bookService, ILogger<BooksController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<BookDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBooks()
    {
        try
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetBooks error");
            return StatusCode(500, ErrorResponseDto.Create(TypeError.InternalError, "An error occurred."));
        }
    }
}
