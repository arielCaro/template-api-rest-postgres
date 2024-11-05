using System.Data;
using System.Security.Claims;
using System.Text;
using template.api.postgres.common;
using template.api.postgres.data;
using template.api.postgres.data.Models;
using template_api_rest_postgres.Dto;
using template_api_rest_postgres.Dto.Input;
using template_api_rest_postgres.Dto.Output;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.AccessControl;

namespace template_api_rest_postgres.Servicies.auth
{
    public class SrvAuth:ISrvAuth
    {

        #region Properties.
        private readonly string Key = string.Empty;
        private readonly ILogger<SrvAuth> logger;
        private readonly DbtemplateRestContext dbContext;
        private readonly IConfiguration configuration;
        #endregion

        #region Constructor.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_logger"></param>
        /// <param name="_dbContext"></param>
        /// <param name="_configuration"></param>
        public SrvAuth(ILogger<SrvAuth> _logger, DbtemplateRestContext _dbContext, IConfiguration _configuration)
        {
            logger = _logger;
            dbContext = _dbContext;
            configuration = _configuration;
        }

        #endregion

        #region Method Public
        
        public async Task<ResponseApi<SessionDto>> SignOn(Login loginInput)
        {
            var response = new ResponseApi<SessionDto>();
            SessionDto tokenWeb = null;
            try
            {
                var userWeb = await DataUser.Get(dbContext, loginInput.User, template.api.postgres.common.Security.Encrypt(loginInput.Password));
                if (userWeb == null)
                    throw new ArgumentException("El usuario no pudo ser validado, por favor revise sus credenciales.");
                var date = DateTime.UtcNow;
                var expireDate = TimeSpan.FromMinutes(15);
                var expireDateTime = date.Add(expireDate);
                var token = await DataSession.Get(dbContext, userWeb.Id);
                var userformat = this.ConvertToUser(userWeb);

                if (token != null)
                {
                    tokenWeb = new SessionDto()
                    {
                        IdUser = token.Id,
                        SessionOn = token.SessionOn,
                        SessionOut = token.SessionOut,
                        Active = token.Active,
                        TokenBearer = token.TokenBearer
                    };
                    if (tokenWeb.SessionOut >= DateTime.Now)
                    {
                        response.Entity = tokenWeb;
                        return Task.FromResult(response).Result;
                    }
                    else
                    {
                        token.Active = false;
                        await DataSession.Update(dbContext, token);
                        token.TokenBearer = GenerateToken(date, userformat, expireDate);
                        token.IdUser = userWeb.Id;
                        token.SessionOut = expireDateTime;
                        token.SessionOn = DateTime.UtcNow;
                        token.Active = true;
                        await DataSession.Create(dbContext, token);
                        tokenWeb = new SessionDto() { SessionOut = token.SessionOut, TokenBearer = token.TokenBearer };

                        response.Entity = tokenWeb;
                        return Task.FromResult(response).Result;
                    }
                }
                else
                {

                    token = new TbSession();
                    token.TokenBearer = GenerateToken(date, userformat, expireDate);
                    token.IdUser = (int)userWeb.Id;
                    token.SessionOut = expireDateTime;
                    token.SessionOn = DateTime.UtcNow;
                    token.Active = true;
                    await DataSession.Create(dbContext, token);
                    tokenWeb = new SessionDto() { SessionOut = token.SessionOut, TokenBearer = token.TokenBearer };
                }
                response.Entity= tokenWeb;
                return Task.FromResult(response).Result;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Ocurrió un error: {ex.Message}", DateTime.UtcNow.ToLongTimeString());
                this.logger.LogError($"Exception : {ex.Message}", DateTime.UtcNow.ToLongTimeString());
                response.Ex = ex;
                response.Message = ex.Message;
                response.State = "Error";
                return Task.FromResult(response).Result;
            }
        }

        public async Task<ResponseApi<SessionDto>> SignOut(SessionDto sessionDto)
        {
            var response = new ResponseApi<SessionDto>();
            try
            {
                if (!sessionDto.Active)
                {
                    var token = await DataSession.Get(dbContext, sessionDto.TokenBearer);
                    if (token != null)
                    {
                        if (token.Active)
                        {
                            token.SessionOut = DateTime.UtcNow;
                            token.Active = false;
                            await DataSession.Update(dbContext, token);
                            sessionDto.Active = false;
                        }
                    }
                    else
                    {
                        sessionDto.Active = false;
                    }
                }
                response.Entity = sessionDto;
                return Task.FromResult(response).Result;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Ocurrió un error: {ex.Message}", DateTime.UtcNow.ToLongTimeString());
                this.logger.LogError($"Exception : {ex.Message}", DateTime.UtcNow.ToLongTimeString());
                response.Message= ex.Message;
                response.Ex= ex;
                response.State = "Error";
                return Task.FromResult(response).Result;
            }
        }

        #endregion

        #region Methods Internals

        /// <summary>
        /// Método que genera Token de seguridad para autorizar al usuario.
        /// </summary>
        /// <param name="date">Fehca de autorización.</param>
        /// <param name="user">Ususario</param>
        /// <param name="validDate">Tiempo estimado de autorización.</param>
        /// <returns>Retorna un string con el token codificado.</returns>
        internal string GenerateToken(DateTime date, UserDto user, TimeSpan validDate)
        {
            try
            {
                var expire = date.Add(validDate);
                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(
                            JwtRegisteredClaimNames.Iat,
                            new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds().ToString(),
                            ClaimValueTypes.Integer64
                        ),
                    new Claim("roles", user.Role.Name),
                    new Claim("Names", user.Name),
                    new Claim("LastName", user.LastName),
                };


                var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AuthSettings:SigningKey"])),
                    SecurityAlgorithms.HmacSha256Signature
                );

                var jwt = new JwtSecurityToken(
                    issuer: configuration["AuthSettings:Issuer"],
                    audience: configuration["AuthSettings:Audience"],
                    claims: claims,
                    notBefore: date,
                    expires: expire,
                    signingCredentials: signingCredentials
                );

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return encodedJwt;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Ocurrió un error: {ex.Message}", DateTime.UtcNow.ToLongTimeString());
                this.logger.LogError($"Exception : {ex.Message}", DateTime.UtcNow.ToLongTimeString());
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbUser"></param>
        /// <returns></returns>
        internal UserDto ConvertToUser(TbUser tbUser)
        {
            try
            {
                var user = new UserDto();
                user.Id = tbUser.Id;
                user.LastName = tbUser.LastName;
                user.Email = tbUser.Email;
                user.Active = tbUser.Active;
                user.Email = tbUser.Email;
                //user.Country = Data
                user.Name = tbUser.Name;
                user.UserCreated = tbUser.UserCreated;
                user.DateCreated = tbUser.DateCreated;
                user.IdRole = tbUser.IdRole;
                
                var tbRole = DataRole.Get(dbContext, tbUser.IdRole);
                user.Role = new RoleDto()
                {
                    Id = tbRole.Result.Id,
                    Name = tbRole.Result.Name,
                    Active = tbRole.Result.Active,
                    Description = tbRole.Result.Description
                };
                user.Phone = tbUser.Phone;
                user.PhoneMobile = tbUser.PhoneMobile;
                //user.SecurityStamp = tbUser.SecurityStamp;
                return user;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Ocurrió un error: {ex.Message}", DateTime.UtcNow.ToLongTimeString());
                this.logger.LogError($"Exception : {ex.Message}", DateTime.UtcNow.ToLongTimeString());
                throw ex;
            }
        }


        #endregion


    }
}
