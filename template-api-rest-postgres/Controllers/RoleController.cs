using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using template_api_rest_postgres.Servicies.role;
using template_api_rest_postgres.Servicies.user;

namespace template_api_rest_postgres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        #region Properties.
        private readonly ILogger<RoleController> logger;
        private readonly ISrvRole service;
        private readonly IConfiguration config;
        #endregion

        #region Constructor
        public RoleController(ILogger<RoleController> _logger, ISrvUser _service, IConfiguration _config)
        {
            this.logger = _logger;
            this.service = _service;
            this.config = _config;
        }
        #endregion

        #region Public Method

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetRole(long id) 
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex); 
            }
        }

        [HttpGet]
        [Route("GetAll/{pag}/{limit}")]
        [Authorize]
        public async Task<IActionResult> GetAllRoles([FromQuery] int pag, [FromQuery]  int limit)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Dto.RoleDto roleDto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("Update")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] Dto.RoleDto roleDto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion

    }
}
