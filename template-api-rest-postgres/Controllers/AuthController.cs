using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using template_api_rest_postgres.Dto;
using template_api_rest_postgres.Dto.Input;
using template_api_rest_postgres.Dto.Output;
using template_api_rest_postgres.Servicies.auth;

namespace template_api_rest_postgres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        #region Properties.
        private readonly ILogger<AuthController> logger;
        private readonly ISrvAuth service;
        private readonly IConfiguration config;
        #endregion


        public AuthController(ILogger<AuthController> _logger, ISrvAuth _service, IConfiguration _config)
        {
            logger = _logger;
            service = _service;
            config = _config;
        }

        [HttpPost]
        [Route("/SignOn")]
        public async Task<IActionResult> SingOnAsync([FromBody] Login input)
        {
            var response = new ResponseApi<SessionDto>();
            try
            {
                return Ok(await service.SignOn(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("/SignOut")]
        public async Task<IActionResult> SignOutAsync([FromBody] SessionDto sessionDto)
        {
            var response = new ResponseApi<SessionDto>();
            try
            {
                return Ok(await service.SignOut(sessionDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



    }
}
