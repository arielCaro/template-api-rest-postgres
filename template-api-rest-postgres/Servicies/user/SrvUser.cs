using template_api_rest_postgres.Dto;
using template_api_rest_postgres.Dto.Output;
using template.api.postgres.data;
using AutoMapper;
using template.api.postgres.data.Models;

namespace template_api_rest_postgres.Servicies.user
{
    /// <summary>
    /// Class SrvUser
    /// </summary>
    public class SrvUser : ISrvUser
    {
        #region Properties.
        private readonly ILogger<SrvUser> logger;
        private readonly IConfiguration config;
        private readonly IMapper mapper;
        private readonly template.api.postgres.data.Models.DbtemplateRestContext dbtemplate;
        #endregion

        #region Constructor.
        /// <summary>
        /// Constructor the class.
        /// </summary>
        /// <param name="_logger"></param>
        /// <param name="_config"></param>
        /// <param name="_srvUser"></param>
        public SrvUser(ILogger<SrvUser> _logger, IConfiguration _config, template.api.postgres.data.Models.DbtemplateRestContext _dbtemplate, IMapper _mapper)
        {
            this.logger = _logger;
            this.config = _config;
            this.dbtemplate = _dbtemplate;
            this.mapper = _mapper;
        }

        #endregion

        #region

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public async Task<ResponseApi<UserDto>> CreateAsync(UserDto userDto, string token)
        {
            var response = new ResponseApi<UserDto>();
            try
            {
                var user = new template.api.postgres.data.Models.TbUser();
                template.api.postgres.data.DataUser.Create(this.dbtemplate, user);
                response.Message = "Se ha creado correctamente";
                response.Entity = userDto;
                response.State = "Success";
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.State = "Error";
                return await Task.FromResult(response);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseApi<UserDto>> GetAllAsync(int npag, int limit)
        {
            var response = new ResponseApi<UserDto>();
            try
            {
                var users = await DataUser.GetAll(this.dbtemplate);
                response.List = new List<UserDto>();
                foreach (var user in users) {
                    response.List.Add(this.mapper.Map<TbUser, UserDto>(user));
                }
                
                response.Message = "Se han obtenido correctamente";
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.State = "Error";
                return await Task.FromResult(response);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseApi<UserDto>> GetAsync(long id)
        {
            var response = new ResponseApi<UserDto>();
            try
            {
                var user = await DataUser.Get(this.dbtemplate, id);
                response.Entity = this.mapper.Map<TbUser, UserDto>(user);
                response.State = "Success";
                response.Message = "Se ha obtenido correctamente";
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.Ex = ex;
                response.State = "Error";
                return await Task.FromResult(response);
            }
        }

        public async Task<ResponseApi<UserDto>> GetAsync(string email)
        {
            var response = new ResponseApi<UserDto>();
            try
            {
                var user = await DataUser.Get(this.dbtemplate, email);
                response.Entity = this.mapper.Map<TbUser, UserDto>(user);
                response.State = "Success";
                response.Message = "Se ha obtenido correctamente";
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.Ex = ex;
                response.State = "Error";
                return await Task.FromResult(response);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public async Task<ResponseApi<UserDto>> UpdateAsync(UserDto userDto, string token)
        {
            var response = new ResponseApi<UserDto>();
            try
            {
                var user = new template.api.postgres.data.Models.TbUser();
                template.api.postgres.data.DataUser.Create(this.dbtemplate, user);
                response.Message = "Se ha actualizado correctamente";
                response.Entity = userDto;
                response.State = "Success";
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.State = "Error";
                return await Task.FromResult(response);
            }
        }

        #endregion
    }
}
