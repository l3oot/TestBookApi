using TestBookApi.DTOs;

namespace TestBookApi.Interfaces;

public interface IBookService
{
    Task<IReadOnlyList<BookDto>> GetBooksAsync();
}
