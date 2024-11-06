using template_api_rest_postgres.Dto;
using template_api_rest_postgres.Dto.Output;

namespace template_api_rest_postgres.Servicies.role
{
    public interface ISrvRole
    {
        Task<ResponseApi<RoleDto>> GetRoleAsync(int id);
        Task<ResponseApi<RoleDto>> GetAllRoleAsync(int pag, int limit);
        Task<ResponseApi<RoleDto>> CreateRoleAsync(RoleDto roleDto);
        Task<ResponseApi<RoleDto>> UpdateRoleAsync(RoleDto roleDto);
    }
}
