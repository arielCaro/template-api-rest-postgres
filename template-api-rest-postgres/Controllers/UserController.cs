using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using template_api_rest_postgres.Dto;
using template_api_rest_postgres.Servicies.user;

namespace template_api_rest_postgres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Properties.
        private readonly ILogger<UserController> logger;
        private readonly ISrvUser service;
        private readonly IConfiguration config;
        #endregion

        #region Constructor
        public UserController(ILogger<UserController> _logger, ISrvUser _service, IConfiguration _config) 
        {
            this.logger = _logger;
            this.service = _service;
            this.config = _config;
        }
        #endregion

        #region Public Method.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            try
            {
                string? token = Request.Headers["Authorization"];
                if (!String.IsNullOrEmpty(token))
                    return Ok(await service.CreateAsync(userDto, token));
                else
                    return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        [Authorize]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            try
            {
                string? token = Request.Headers["Authorization"];
                if (!String.IsNullOrEmpty(token))
                    return Ok(await service.UpdateAsync(userDto, token));
                else
                    return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUser/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser([FromQuery] long id)
        {
            try
            {
                string? token = Request.Headers["Authorization"];
                if (!String.IsNullOrEmpty(token))
                    return Ok(await service.GetAsync(id));
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserEmail/{email}")]
        [Authorize]
        public async Task<IActionResult> GetUserEmail([FromQuery] string email)
        {
            try
            {
                string? token = Request.Headers["Authorization"];
                if (!String.IsNullOrEmpty(token))
                    return Ok(await service.GetAsync(email));
                else
                    return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="npag"></param>
        /// <param name="pag"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll/{npag}/{limit}")]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] int npag, int limit)
        {
            try
            {
                string? token = Request.Headers["Authorization"];
                if (!String.IsNullOrEmpty(token))
                    return Ok(await service.GetAllAsync(npag, limit));
                else
                    return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] Models.Input.Login login)
        {
            try
            {
                string? token = Request.Headers["Authorization"];
                if (!String.IsNullOrEmpty(token))
                    return Ok(await service.ChangePassword(login, token));
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */
        #endregion

    }
}
