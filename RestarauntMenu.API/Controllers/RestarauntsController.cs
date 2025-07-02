using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestarauntMenu.API.Filters;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Commands;
using RestarauntMenu.Application.UseCases.RestarauntSerivices.Queries;
using RestarauntMenu.Domain.DTOs;
using System.Security.Claims;

namespace RestarauntMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin,Admin,User")]
    public class RestarauntsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestarauntsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaraunt([FromForm] CreateRestarauntCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaraunt(long id)
        {
            var command = new DeleteRestarauntCommand { Id = id };
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return NotFound(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRestarauntAll([FromForm] UpdateRestarauntCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("{id}")]
        [RestaurantAccess]
        public async Task<IActionResult> UpdateRestarauntAdmin(long id, [FromForm] UpdateRestaurantDTO dto)
        {
            var command = new UpdateRestarauntCommand()
            {
                Id = id,
                Name = dto.Name,
                Address = dto.Address,
                WorkTime = dto.WorkTime,
                Logo = dto.Logo
            };

            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRestarauntById(long id)
        {
            var query = new GetRestarauntByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound("Restaraunt not found");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllRestaraunts()
        {
            var query = new GetAllRestarauntsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
