using template_api_rest_postgres.Dto;
using template_api_rest_postgres.Dto.Output;

namespace template_api_rest_postgres.Servicies.user
{
    public interface ISrvUser
    {
        Task<ResponseApi<UserDto>> CreateAsync(UserDto userDto, string token);
        Task<ResponseApi<UserDto>> UpdateAsync(UserDto userDto, string token);
        Task<ResponseApi<UserDto>> GetAsync(long id);
        Task<ResponseApi<UserDto>> GetAsync(string email);
        Task<ResponseApi<UserDto>> GetAllAsync(int npag, int limit);

    }
}
