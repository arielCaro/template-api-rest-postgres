using template_api_rest_postgres.Dto;
using template_api_rest_postgres.Dto.Output;

namespace template_api_rest_postgres.Servicies.role
{
    public class SrvRole : ISrvRole
    {
        public Task<ResponseApi<RoleDto>> CreateRoleAsync(RoleDto roleDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseApi<RoleDto>> GetAllRoleAsync(int pag, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseApi<RoleDto>> GetRoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseApi<RoleDto>> UpdateRoleAsync(RoleDto roleDto)
        {
            throw new NotImplementedException();
        }
    }
}
