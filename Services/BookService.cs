using System.Text.Json;
using TestBookApi.DTOs;
using TestBookApi.Interfaces;

namespace TestBookApi.Services;

public class BookService : IBookService
{
    private const string ItBookSearchUrl = "https://api.itbook.store/1.0/search/mysql";
    private readonly IHttpClientFactory _httpClientFactory;

    public BookService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IReadOnlyList<BookDto>> GetBooksAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync(ItBookSearchUrl);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<ItBookSearchResponseDto>(json);

        var books = data?.Books ?? new List<BookDto>();
        return books.OrderBy(b => b.Title, StringComparer.OrdinalIgnoreCase).ToList();
    }
}
