using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using task2.API.Security;
using task2.Core.DTO;
using task2.Core.Services;

namespace task2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;
        private readonly IConfiguration _configuration;
        public LoginController(IMapper mapper, IUserService service, IConfiguration configuration)
        {
            _mapper = mapper;
            _service = service;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                var user = await _service.LoginAsync(model.Email, model.Password);

                if (user == null)
                {
                    return BadRequest("E-posta veya şifre hatalı.");
                }

                var token = TokenHandler.CreateToken(_configuration);
                


                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }
        }
    }

}
