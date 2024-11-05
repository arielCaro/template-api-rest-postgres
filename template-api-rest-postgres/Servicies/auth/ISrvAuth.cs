using template_api_rest_postgres.Dto.Input;
using template_api_rest_postgres.Dto.Output;
using template_api_rest_postgres.Dto;

namespace template_api_rest_postgres.Servicies.auth
{
    public interface ISrvAuth
    {
        Task<ResponseApi<SessionDto>> SignOn(Login login);
        Task<ResponseApi<SessionDto>> SignOut(SessionDto sessionDto);
    }
}
