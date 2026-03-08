using TestBookApi.DTOs;

namespace TestBookApi.Interfaces;

public interface IUserLikeService
{
    Task AddLikeAsync(UserLikeRequestDto dto);
}
