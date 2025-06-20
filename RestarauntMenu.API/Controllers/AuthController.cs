using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestarauntMenu.Application.UseCases.AuthServices.Commands;
using RestarauntMenu.Domain.DTOs;

namespace RestarauntMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var command = new RegisterUserCommand()
            {
                Name = dto.Name,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                var command = new LoginUserCommand()
                {
                    PhoneNumber = dto.PhoneNumber,
                    Password = dto.Password,
                };

                var token = await _mediator.Send(command);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("create-admin")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateAdmin(CreateAdminDTO dto)
        {
            var command = new CreateAdminCommand()
            {
                Name = dto.Name,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
